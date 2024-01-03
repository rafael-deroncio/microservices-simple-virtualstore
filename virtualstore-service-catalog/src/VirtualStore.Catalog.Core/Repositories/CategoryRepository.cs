using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data;
using VirtualStore.Catalog.Core.Arguments;
using VirtualStore.Catalog.Core.Exceptions;
using VirtualStore.Catalog.Core.Model;
using VirtualStore.Catalog.Core.Repositories.Interfaces;
using VirtualStore.Catalog.Domain.Responses;

namespace VirtualStore.Catalog.Core.Repositories;

public class CategoryRepository : BaseRepository, ICategoryRepository
{
    private readonly ILogger<CategoryRepository> _logger;

    public CategoryRepository(IConfiguration configuration, ILogger<CategoryRepository> logger) : base(configuration)
    {
        _logger = logger;
    }

    public async Task<CategoryModel> CreateCategory(CategoryArgument category)
    {
        try
        {
            using IDbConnection connection = GetConnection();
            string query = @"
                            INSERT INTO Categories (Name, Description, IsActive, CreatedDate, LastModifiedDate)
                            VALUES (@Name, @Description, @IsActive, @CreatedDate, @LastModifiedDate)
                            RETURNING CategoryId, Name, Description, IsActive, CreatedDate";

            return await connection.QueryFirstOrDefaultAsync(query, category);
        }
        catch (Exception ex)
        {
            string message = string.Format("An error occurred while creating category.", ex.Message);
            _logger.LogError(ex, message);
            throw new CategoryException(message, ex);
        }
    }

    public async Task<bool> DeleteCategory(int id)
    {
        try
        {
            using IDbConnection connection = GetConnection();
            string query = @"
                            UPDATE Categories
                            SET IsActive = false
                            WHERE CategoryId = @Id";

            return await connection.ExecuteAsync(query) > 0;
        }
        catch (Exception ex)
        {
            string message = string.Format("An error occurred while deleting category.", ex.Message);
            _logger.LogError(ex, message);
            throw new CategoryException(message, ex);
        }
    }

    public async Task<CategoryModel> GetCategory(int id)
    {
        try
        {
            using IDbConnection connection = GetConnection();
            string query = @"
                            SELECT 
                                CategoryId,
                                Name,
                                Description,
                                IsActive,
                                CreatedDate
                            FROM Categories 
                            WHERE CategoryId = @Id AND IsActive = true";


            return await connection.QueryFirstOrDefaultAsync<CategoryModel>(query, new { Id = id });
        }
        catch (Exception ex)
        {
            string message = string.Format("An error occurred while fetching category.", ex.Message);
            _logger.LogError(ex, message);
            throw new CategoryException(message, ex);
        }
    }

    public async Task<IEnumerable<CategoryModel>> GetCategories(PaginationArgument argument)
    {
        try
        {
            using IDbConnection connection = GetConnection();
            string query = @"
                        SELECT 
                            CategoryId,
                            Name,
                            Description,
                            IsActive,
                            CreatedDate
                        FROM Categories 
                        WHERE IsActive = true
                        ORDER BY CategoryId
                        OFFSET @Skip ROWS
                        FETCH NEXT @Size ROWS ONLY"; ;

            return await connection.QueryAsync<CategoryModel>(query, argument);
        }
        catch (Exception ex)
        {
            string message = string.Format("An error occurred while fetching categories. {0}", ex.Message);
            _logger.LogError(ex, message);
            throw new CategoryException(message, ex);
        }
    }

    public async Task<IEnumerable<CategoryModel>> GetCategories()
    {
        try
        {
            using IDbConnection connection = GetConnection();
            string query = @"
                        SELECT 
                            CategoryId,
                            Name,
                            Description,
                            IsActive,
                            CreatedDate
                        FROM Categories 
                        WHERE IsActive = true
                        ORDER BY CategoryId";

            return await connection.QueryAsync<CategoryModel>(query);
        }
        catch (Exception ex)
        {
            string message = string.Format("An error occurred while fetching categories. {0}", ex.Message);
            _logger.LogError(ex, message);
            throw new CategoryException(message, ex);
        }
    }

    public async Task<int> GetTotalRegisteredCategories()
    {
        try
        {
            using IDbConnection connection = GetConnection();
            string query = @"
                            SELECT Count(*)
                            FROM Categories
                            WHERE IsActive = true";

            return await connection.ExecuteScalarAsync<int>(query);
        }
        catch (Exception ex)
        {
            string message = string.Format("An error occurred while getting total registered categories. {0}", ex.Message);
            _logger.LogError(ex, message);
            throw new CategoryException(message, ex);
        }
    }

    public async Task<CategoryModel> UpdateCategory(CategoryArgument category)
    {
        try
        {
            using IDbConnection connection = GetConnection();
            string query = @"
                            UPDATE Categories
                            SET Name = @Name, Description = @Description, LastModifiedDate = @LastModifiedDate
                            WHERE CategoryId = @CategoryId
                            RETURNING CategoryId, Name, Description, IsActive, CreatedDate";

            return await connection.QueryFirstOrDefaultAsync(query, category);
        }
        catch (Exception ex)
        {
            string message = string.Format("An error occurred while updating category. {0}", ex.Message);
            _logger.LogError(ex, message);
            throw new CategoryException(message, ex);
        }
    }

    public async Task<bool> CategoryExists(string category)
    {
        try
        {
            using IDbConnection connection = GetConnection();
            string query = @"
                            SELECT 
                                CategoryId, 
                                Name, 
                                Description, 
                                IsActive, 
                                CreatedDate,
                                LastModifiedDate
                            FROM Categories
                            WHERE ToLower(Name) = @Name AND IsActive = true;";

            return await connection.QueryFirstOrDefaultAsync(query, new { Name = category.ToLower().Trim() }) != null;
        }
        catch (Exception ex)
        {
            string message = string.Format("An error occurred while getting category. {0}", ex.Message);
            _logger.LogError(ex, message);
            throw new CategoryException(message, ex);
        }
    }

    public Task<CategoryResponse> GetCategoryByProduct(int productId)
    {
        using IDbConnection connection = GetConnection();

        try
        {
            string query = @"
                            SELECT 
                                CA.CategoryId,
                                CA.Name,
                                CA.Description,
                                CA.CreatedDate,
                                CA.LastModifiedDate,
                                CA.IsActive
                            FROM Categories CA
                            JOIN CategoryProducts CP ON CA.CategoryId = CP.CategoryId AND CP.ProductId = @ProductId";

            return connection.QueryFirstOrDefaultAsync<CategoryResponse>(query, new { ProductId = productId });
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred while getting category. {0}", ex.Message);
            throw new CategoryException("An error occurred while getting category.", ex);
        }
    }
}