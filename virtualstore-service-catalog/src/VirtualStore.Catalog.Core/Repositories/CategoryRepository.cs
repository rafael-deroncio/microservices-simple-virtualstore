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
                            INSERT INTO category (name, description, active, registration_date)
                            VALUES (@Name, @Description, @Ativo, @RegistrationDate)
                            RETURNING id_category AS Id, name, description, active, registration_date AS RegistrationDate";

            return await connection.QueryFirstOrDefaultAsync(query, category);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while creating category.");
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
                            SET active = 0
                            WHERE id_category = @Id";

            return await connection.ExecuteAsync(query) > 0;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while deleting category.");
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
                                id_category Id,
                                name Name,
                                name Description,
                                active Active,
                                registration_date RegistrationDate
                            FROM category 
                            WHERE id_category = @Id";

            return await connection.QueryFirstAsync<CategoryModel>(query, new { Id = id });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching category.");
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
                                id_category Id,
                                name Name,
                                name Description,
                                active Active,
                                registration_date RegistrationDate
                            FROM category 
                            WHERE active = 1";

            return await connection.QueryAsync<CategoryModel>(query);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching categorys.");
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
                            WHERE active = 1";

            return await connection.ExecuteScalarAsync<int>(query);
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred while getting total registered categories.", ex.Message);
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
                            SET name = @Name, description = @Description
                            WHERE id_category = @Id;
                            RETURNING id_category AS Id, name, description, active, registration_date AS RegistrationDate""";

            return await connection.QueryFirstOrDefaultAsync(query, category);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while updating category.");
            return null;
        }
    }
}