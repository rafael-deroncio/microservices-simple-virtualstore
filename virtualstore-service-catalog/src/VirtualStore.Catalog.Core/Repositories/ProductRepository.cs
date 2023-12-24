using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data;
using VirtualStore.Catalog.Core.Arguments;
using VirtualStore.Catalog.Core.Model;
using VirtualStore.Catalog.Core.Repositories.Interfaces;

namespace VirtualStore.Catalog.Core.Repositories;

public class ProductRepository : BaseRepository, IProductRepository
{
    private readonly ILogger<ProductRepository> _logger;

    public ProductRepository(IConfiguration configuration, ILogger<ProductRepository> logger) : base(configuration)
    {
        _logger = logger;
    }

    public async Task<ProductModel> CreateProduct(ProductArgument Product)
    {
        try
        {
            using IDbConnection connection = GetConnection();
            string query = @"
                            INSERT INTO product (Name, Description, Brand, Price, Stock, CategoryId, CreatedDate, LastModifiedDate, IsActive)
                            VALUES (@Name, @Description, @Brand, @Price, @Stock, @CategoryId, @CreatedDate, @LastModifiedDate, @IsActive)
                            RETURNING ProductId, Name, Description, Brand, Price, Stock, CategoryId, CreatedDate, LastModifiedDate";

            return await connection.QueryFirstOrDefaultAsync(query, Product);
        }
        catch (Exception ex)
        {
            _logger.LogError(string.Format("An error occurred while creating product.", ex.Message));
            return null;
        }
    }

    public async Task<bool> DeleteProduct(int id)
    {
        try
        {
            using IDbConnection connection = GetConnection();
            string query = @"
                            UPDATE product
                            SET IsActive = false
                            WHERE ProductId = @Id";

            return await connection.ExecuteAsync(query) > 0;
        }
        catch (Exception ex)
        {
            _logger.LogError(string.Format("An error occurred while deleting product. {0}", ex.Message));
            return false;
        }
    }

    public async Task<ProductModel> GetProduct(int id)
    {
        try
        {
            using IDbConnection connection = GetConnection();
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
                            FROM product 
                            WHERE ProductId = @Id AND IsActive = true";

            return await connection.QueryFirstAsync<ProductModel>(query, new { Id = id });
        }
        catch (Exception ex)
        {
            _logger.LogError(string.Format("An error occurred while fetching product. {0}", ex.Message));
            return null;
        }
    }

    public async Task<IEnumerable<ProductModel>> GetPagedProducts(PaginationArgument pagination)
    {
        try
        {
            using IDbConnection connection = GetConnection();
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
                            FROM product 
                            WHERE IsActive = true
                            ORDER BY ProductId
                            OFFSET @Skip ROWS
                            FETCH NEXT @Size ROWS ONLY;";

            return await connection.QueryAsync<ProductModel>(query, pagination);
        }
        catch (Exception ex)
        {
            _logger.LogError(string.Format("An error occurred while fetching products. {0}", ex.Message));
            return null;
        }
    }

    public async Task<IEnumerable<ProductModel>> GetProducts()
    {
        try
        {
            using IDbConnection connection = GetConnection();
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
                            FROM product 
                            WHERE IsActive = true;";

            return await connection.QueryAsync<ProductModel>(query);
        }
        catch (Exception ex)
        {
            _logger.LogError(string.Format("An error occurred while fetching products. {0}", ex.Message));
            return null;
        }
    }

    public async Task<int> GetTotalRegisteredProducts()
    {
        try
        {
            using IDbConnection connection = GetConnection();
            string query = @"
                            SELECT Count(*)
                            FROM product
                            WHERE IsActive = true";

            return await connection.ExecuteScalarAsync<int>(query);
        }
        catch (Exception ex)
        {
            _logger.LogError(string.Format("An error occurred while getting total registered products. {0}", ex.Message));
            return default;
        }
    }

    public async Task<ProductModel> UpdateProduct(ProductArgument Product)
    {
        try
        {
            using IDbConnection connection = GetConnection();
            string query = @"
                            UPDATE product
                            SET Name = @Name, 
                                Description = @Description, 
                                Brand = @Brand, 
                                Price = @Price, 
                                Stock = @Stock, 
                                LastModifiedDate = CURRENT_TIMESTAMP
                            WHERE ProductId = @ProductId
                            RETURNING ProductId, Name, Description, Brand, Price, Stock, CategoryId, CreatedDate, LastModifiedDate";

            return await connection.QueryFirstOrDefaultAsync(query, Product);
        }
        catch (Exception ex)
        {
            _logger.LogError(string.Format("An error occurred while updating product. {0}", ex.Message));
            return null;
        }
    }
}