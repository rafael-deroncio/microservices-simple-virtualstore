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
                            INSERT INTO Product (name, description, brand, price, stock, active, id_category AS CategoryId, registration_date AS RegistrationDate, modification_date AS ModificationDate)
                            VALUES (@Name, @Description, @Ativo, @RegistrationDate)
                            RETURNING id_product AS Id, name, description, brand, price, stock, active, id_category AS CategoryId, registration_date AS RegistrationDate, modification_date AS ModificationDate";

            return await connection.QueryFirstOrDefaultAsync(query, Product);
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred while creating product.", ex.Message);
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
                            SET active = false
                            WHERE id_product = @Id";

            return await connection.ExecuteAsync(query) > 0;
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred while deleting product.", ex.Message);
            return false;
        }
    }

    public async Task<ProductModel> GetProduct(int id)
    {
        try
        {
            using IDbConnection connection = GetConnection();
            string query = @"
                            SELECT  id_product AS Id, 
                                    name, 
                                    description, 
                                    brand, 
                                    price, 
                                    stock, 
                                    active, 
                                    id_category AS CategoryId, 
                                    registration_date AS RegistrationDate, 
                                    modification_date AS ModificationDate
                            FROM product 
                            WHERE id_product = @Id";

            return await connection.QueryFirstAsync<ProductModel>(query, new { Id = id });
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred while fetching product.", ex.Message);
            return null;
        }
    }

    public async Task<IEnumerable<ProductModel>> GetPagedProducts(PaginationArgument pagination)
    {
        try
        {
            using IDbConnection connection = GetConnection();
            string query = @"
                            SELECT  id_product AS Id, 
                                    name, 
                                    description, 
                                    brand, 
                                    price, 
                                    stock, 
                                    active, 
                                    id_category AS CategoryId, 
                                    registration_date AS RegistrationDate, 
                                    modification_date AS ModificationDate
                            FROM product 
                            WHERE active = 1
                            OFFSET @Skip ROWS
                            FETCH NEXT @Size ROWS ONLY;";

            return await connection.QueryAsync<ProductModel>(query, pagination);
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred while fetching products.", ex.Message);
            return null;
        }
    }

    public async Task<IEnumerable<ProductModel>> GetProducts()
    {
        try
        {
            using IDbConnection connection = GetConnection();
            string query = @"
                            SELECT  id_product AS Id, 
                                    name, 
                                    description, 
                                    brand, 
                                    price, 
                                    stock, 
                                    active, 
                                    id_category AS CategoryId, 
                                    registration_date AS RegistrationDate, 
                                    modification_date AS ModificationDate
                            FROM product 
                            WHERE active = 1;";

            return await connection.QueryAsync<ProductModel>(query);
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred while fetching products.", ex.Message);
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
                            WHERE active = 1";

            return await connection.ExecuteScalarAsync<int>(query);
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred while getting total registered products.", ex.Message);
            return default;
        }
    }

    public async Task<ProductModel> UpdateProduct(ProductArgument Product)
    {
        try
        {
            using IDbConnection connection = GetConnection();
            string query = @"
                            UPDATE catalog
                            SET name = @Name, 
                                description = @Description, 
                                brand = @Brand, 
                                price = @Price, 
                                stock = @Stock, 
                                modification_date = CURRENT_TIMESTAMP
                            WHERE id_product = @Id;
                            RETURNING id_product AS Id, name, description, brand, price, stock, active, id_category AS CategoryId, registration_date AS RegistrationDate, modification_date AS ModificationDate";

            return await connection.QueryFirstOrDefaultAsync(query, Product);
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred while updating product.", ex.Message);
            return null;
        }
    }
}