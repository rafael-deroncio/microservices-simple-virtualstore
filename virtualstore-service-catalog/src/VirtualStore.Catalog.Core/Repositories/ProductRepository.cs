using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data;
using VirtualStore.Catalog.Core.Arguments;
using VirtualStore.Catalog.Core.Exceptions;
using VirtualStore.Catalog.Core.Model;
using VirtualStore.Catalog.Core.Models;
using VirtualStore.Catalog.Core.Repositories.Interfaces;

namespace VirtualStore.Catalog.Core.Repositories;

public class ProductRepository : BaseRepository, IProductRepository
{
    private readonly ILogger<ProductRepository> _logger;

    public ProductRepository(IConfiguration configuration, ILogger<ProductRepository> logger) : base(configuration)
    {
        _logger = logger;
    }

    public async Task<ProductModel> CreateProduct(ProductArgument product)
    {
        using IDbConnection connection = GetConnection();
        using IDbTransaction transaction = connection.BeginTransaction();

        try
        {
            ProductModel productModel = await SaveProduct(product, connection, transaction);
            CategoryProductArgument argument = new()
            {
                CategoryId = product.CategoryId,
                ProductId = productModel.ProductId
            };
            CategoryProductModel categoryProductModel = await SaveCategoryProduct(argument, connection, transaction);

            productModel = await GetProduct(productModel.ProductId, connection);

            transaction.Commit();

            return productModel;
        }
        catch (ProductException) { transaction.Rollback();  throw; }
        catch (CategoryProductException) { transaction.Rollback(); throw; }
        catch (Exception ex)
        {
            transaction.Rollback();
            _logger.LogError("An error occurred while creating product. {0}", ex.Message);
            throw new ProductException("An error occurred while creating product.", ex);
        }
    }

    public async Task<bool> DeleteProduct(int id)
    {
        using IDbConnection connection = GetConnection();
        using IDbTransaction transaction = connection.BeginTransaction();

        try
        {
            await DisableProduct(id, connection, transaction);
            await DisableCategoryProduct(id, connection, transaction);
            return true;
        }
        catch (Exception ex)
        {
            string message = string.Format("An error occurred while deleting product. {0}", ex.Message);
            _logger.LogError(message, ex);
            throw new ProductException(message, ex);
        }
    }

    public async Task<ProductModel> GetProduct(int id, IDbConnection connection = null)
    {
        using (connection ?? GetConnection())

        try
        {
            string query = @"
                            SELECT 
                                P.ProductId, 
                                P.Name, 
                                P.Description, 
                                P.Brand, 
                                P.Price, 
                                P.Stock, 
                                P.CreatedDate, 
                                P.LastModifiedDate,
                                P.IsActive,
                                C.CategoryId,
                                C.Name, 
                                C.Description, 
                                C.CreatedDate, 
                                C.LastModifiedDate,
                                C.IsActive
                            FROM Products P
                            JOIN CategoryProducts CP ON P.ProductId = CP.ProductId
                            join categories C ON C.CategoryId = CP.CategoryId
                            WHERE P.ProductId = @ProductId
                                AND C.IsActive = true AND P.IsActive = true";

            Dictionary<int, ProductModel> dataProductDict = new Dictionary<int, ProductModel>();

            return (await connection.QueryAsync<ProductModel>(
                sql: query,
                param: new { ProductId = id },
                transaction: null,
                buffered: true,
                splitOn: "CategoryId",
                types: new[]
                {
                    typeof(ProductModel),
                    typeof(CategoryModel),
                },
                map: obj =>
                {
                    ProductModel productTemp;
                    ProductModel product = obj[0] as ProductModel;
                    CategoryModel category = obj[1] as CategoryModel;

                    if (!dataProductDict.TryGetValue(product.ProductId, out productTemp))
                    {
                        productTemp = product;
                        if (category != null)
                            productTemp.Category = category;
                    }

                    return productTemp;
                }
                )).FirstOrDefault();
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred while fetching product. {0}", ex.Message);
            throw new ProductException("An error occurred while fetching product.", ex);
        }
    }

    public async Task<IEnumerable<ProductModel>> GetPagedProducts(PaginationArgument pagination)
    {
        using IDbConnection connection = GetConnection();

        try
        {
            string query = @"
                            SELECT 
                                P.ProductId, 
                                P.Name, 
                                P.Description, 
                                P.Brand, 
                                P.Price, 
                                P.Stock, 
                                P.CreatedDate, 
                                P.LastModifiedDate,
                                P.IsActive,
                                C.CategoryId,
                                C.Name, 
                                C.Description, 
                                C.CreatedDate, 
                                C.LastModifiedDate,
                                C.IsActive
                            FROM Products P
                            JOIN CategoryProducts CP ON P.ProductId = CP.ProductId
                            join categories C ON C.CategoryId = CP.CategoryId
                            WHERE C.IsActive = true AND P.IsActive = true
                            OFFSET @Skip ROWS
                            FETCH NEXT @Size ROWS ONLY;";

            Dictionary<int, ProductModel> dataProductDict = new Dictionary<int, ProductModel>();

            return await connection.QueryAsync<ProductModel>(
                sql:query,
                param: pagination,
                transaction: null,
                buffered: true,
                splitOn: "CategoryId",
                types: new[]
                { 
                    typeof(ProductModel),
                    typeof(CategoryModel),
                },
                map: obj =>
                {
                    ProductModel productTemp;
                    ProductModel product = obj[0] as ProductModel;
                    CategoryModel category = obj[1] as CategoryModel;

                    if (!dataProductDict.TryGetValue(product.ProductId, out productTemp))
                    {
                        productTemp = product;
                        if (category != null)
                            productTemp.Category = category;
                    }

                    return productTemp;
                }
                );
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred while fetching product. {0}", ex.Message);
            throw new ProductException("An error occurred while fetching products.", ex);
        }
    }

    public async Task<IEnumerable<ProductModel>> GetProducts()
    {
        using IDbConnection connection = GetConnection();

        try
        {
            string query = @"
                            SELECT 
                                ProductId,
                                Name, 
                                Description, 
                                Brand, 
                                Price, 
                                Stock, 
                                CategoryId, 
                                CreatedDate, 
                                LastModifiedDate
                            FROM Products
                            JOIN CategoryProducts ON ProductId = ProductId 
                            WHERE IsActive = true";

            return await connection.QueryAsync<ProductModel>(query);
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred while fetching products. {0}", ex.Message);
            throw new ProductException("An error occurred while fetching products.", ex);
        }
    }

    public async Task<int> GetTotalRegisteredProducts()
    {
        using IDbConnection connection = GetConnection();

        try
        {
            string query = @"
                            SELECT Count(*)
                            FROM Products
                            WHERE IsActive = true";

            return await connection.ExecuteScalarAsync<int>(query);
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred while getting total registered products. {0}", ex.Message);
            throw new ProductException("An error occurred while getting total registered products.", ex);
        }
    }

    public async Task<ProductModel> UpdateProduct(ProductArgument argument)
    {
        using IDbConnection connection = GetConnection();
        using IDbTransaction transaction = connection.BeginTransaction();

        try
        {
            ProductModel product = await UpdateProduct(argument, connection, transaction);
            await UpdateCategoryProduct(argument, connection, transaction);
            transaction.Commit();

            product = await GetProduct(product.ProductId, connection);
            return product;
        }
        catch(ProductException) { transaction.Rollback(); throw; }
        catch (CategoryProductException) { transaction.Rollback(); throw; }
        catch (Exception ex)
        {
            transaction.Rollback();
            _logger.LogError(string.Format("An error occurred while updating product. {0}", ex.Message));
            return null;
        }
    }

    public async Task<bool> ProductExists(string product)
    {

        using IDbConnection connection = GetConnection();

        try
        {
            string query = @"
                            SELECT 
                                ProductId, 
                                Name, 
                                Description, 
                                Brand, 
                                Price, 
                                Stock, 
                                IsActive, 
                                CreatedDate,
                                LastModifiedDate
                            FROM Products
                            WHERE Lower(Name) = @Name AND IsActive = true;";

            return await connection.QueryFirstOrDefaultAsync(query, new { Name = product.ToLower().Trim() }) != null;
        }
        catch (Exception ex)
        {
            string message = string.Format("An error occurred while getting product. {0}", ex.Message);
            _logger.LogError(ex, message);
            throw new ProductException(message, ex);
        }
    }

    #region Privates
    private async Task<ProductModel> SaveProduct(ProductArgument argument, IDbConnection connection, IDbTransaction transaction)
    {
        try
        {

            string query = @"
                            INSERT INTO Products (Name, Description, Brand, Price, Stock)
                            VALUES (@Name, @Description, @Brand, @Price, @Stock)
                            RETURNING ProductId, Name, Description, Brand, Price, Stock, CreatedDate, LastModifiedDate, IsActive";

            return await connection.QueryFirstOrDefaultAsync<ProductModel>(query, argument, transaction);
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred while save product. {0}", ex);
            throw new ProductException("An error occurred while save product.", ex);
        }
    }

    private async Task<CategoryProductModel> SaveCategoryProduct(CategoryProductArgument argument, IDbConnection connection, IDbTransaction transaction)
    {
        try
        {
            string query = @"
                            INSERT INTO CategoryProducts (ProductId, CategoryId)
                            VALUES (@ProductId, @CategoryId)
                            RETURNING CategoryProductId, ProductId, CategoryId, CreatedDate, LastModifiedDate, IsActive";

            return await connection.QueryFirstOrDefaultAsync<CategoryProductModel>(query, argument, transaction);
        }
        catch (Exception ex)
        {
            string message = string.Format("An error occurred while save product associations.");
            _logger.LogError(message, ex);
            throw new CategoryProductException(message, ex);
        }
    }

    private async Task DisableProduct(int productId, IDbConnection connection, IDbTransaction transaction)
    {
        try
        {
            string query = @"
                            UPDATE Products
                            SET IsActive = false
                            WHERE ProductId = @ProductId AND IsActive = true";

            await connection.QueryFirstOrDefaultAsync(query, new { ProductId = productId }, transaction);
        }
        catch (Exception ex)
        {
            string message = string.Format("An error occurred while disable product.");
            _logger.LogError(message, ex);
            throw new ProductException(message, ex);
        }
    }

    private async Task DisableCategoryProduct(int productId, IDbConnection connection, IDbTransaction transaction)
    {
        try
        {
            string query = @"
                            UPDATE CategoryProducts
                            SET IsActive = false
                            WHERE ProductId = @ProductId AND IsActive = true";

            await connection.QueryFirstOrDefaultAsync(query, new { ProductId = productId }, transaction);
        }
        catch (Exception ex)
        {
            string message = string.Format("An error occurred while disable product associations.");
            _logger.LogError(message, ex);
            throw new CategoryProductException(message, ex);
        }
    }

    private async Task<ProductModel> UpdateProduct(ProductArgument argument, IDbConnection connection, IDbTransaction transaction)
    {
        try
        {
            string query = @"
                            UPDATE Products
                            SET Name = @Name, 
                                Description = @Description, 
                                Brand = @Brand, 
                                Price = @Price, 
                                Stock = @Stock, 
                                LastModifiedDate = CURRENT_TIMESTAMP
                            WHERE ProductId = @ProductId
                            RETURNING ProductId, Name, Description, Brand, Price, Stock, CreatedDate, LastModifiedDate, IsActive";

            return await connection.QueryFirstOrDefaultAsync<ProductModel>(query, argument, transaction);
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred while updating product. {0}", ex.Message);
            throw new ProductException("An error occurred while updating product.", ex);
        }
    }

    private async Task<CategoryProductModel> UpdateCategoryProduct(ProductArgument argument, IDbConnection connection, IDbTransaction transaction)
    {
        try
        {
            string query = @"
                            UPDATE CategoryProducts
                            SET ProductId = @ProductId, 
                                CategoryId = @CategoryId,
                                LastModifiedDate = CURRENT_TIMESTAMP
                            WHERE ProductId = @ProductId
                            RETURNING CategoryProductId, ProductId, CategoryId, CreatedDate, LastModifiedDate, IsActive";

            return await connection.QueryFirstOrDefaultAsync<CategoryProductModel>(query, argument, transaction);
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred while updating product associations. {0}", ex.Message);
            throw new ProductException("An error occurred while updating product associations.", ex);
        }
    }
    #endregion
}