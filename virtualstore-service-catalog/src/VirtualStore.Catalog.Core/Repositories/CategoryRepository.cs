using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data;
using VirtualStore.Catalog.Core.Arguments;
using VirtualStore.Catalog.Core.Model;
using VirtualStore.Catalog.Core.Repositories.Interfaces;

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
                            INSERT INTO category (Name, Description, IsActive, CreatedDate, LastModifiedDate)
                            VALUES (@Name, @Description, @IsActive, @CreatedDate, @LastModifiedDate)
                            RETURNING CategoryId, Name, Description, IsActive, CreatedDate";

            return await connection.QueryFirstOrDefaultAsync(query, category);
        }
        catch (Exception ex)
        {
            _logger.LogError(string.Format("An error occurred while creating category.", ex.Message));
            return null;
        }
    }

    public async Task<bool> DeleteCategory(int id)
    {
        try
        {
            using IDbConnection connection = GetConnection();
            string query = @"
                            UPDATE category
                            SET IsActive = false
                            WHERE CategoryId = @Id";

            return await connection.ExecuteAsync(query) > 0;
        }
        catch (Exception ex)
        {
            _logger.LogError(string.Format("An error occurred while deleting category.", ex.Message));
            return false;
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
                            FROM category 
                            WHERE CategoryId = @Id AND IsActive = true";


            return await connection.QueryFirstAsync<CategoryModel>(query, new { Id = id });
        }
        catch (Exception ex)
        {
            _logger.LogError(string.Format("An error occurred while fetching category.", ex.Message));
            return null;
        }
    }

    public async Task<IEnumerable<CategoryModel>> GetCategorys()
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
                            FROM category 
                            WHERE IsActive = true";

            return await connection.QueryAsync<CategoryModel>(query);
        }
        catch (Exception ex)
        {
            _logger.LogError(string.Format("An error occurred while fetching categorys. {0}", ex.Message));
            return null;
        }
    }

    public async Task<int> GetTotalRegisteredCategories()
    {
        try
        {
            using IDbConnection connection = GetConnection();
            string query = @"
                            SELECT Count(*)
                            FROM category
                            WHERE IsActive = true";

            return await connection.ExecuteScalarAsync<int>(query);
        }
        catch (Exception ex)
        {
            _logger.LogError(string.Format("An error occurred while getting total registered categories. {0}", ex.Message));
            return default;
        }
    }

    public async Task<CategoryModel> UpdateCategory(CategoryArgument category)
    {
        try
        {
            using IDbConnection connection = GetConnection();
            string query = @"
                            UPDATE category
                            SET Name = @Name, Description = @Description, LastModifiedDate = @LastModifiedDate
                            WHERE CategoryId = @CategoryId
                            RETURNING CategoryId, Name, Description, IsActive, CreatedDate";

            return await connection.QueryFirstOrDefaultAsync(query, category);
        }
        catch (Exception ex)
        {
            _logger.LogError(string.Format("An error occurred while updating category. {0}", ex.Message));
            return null;
        }
    }
}