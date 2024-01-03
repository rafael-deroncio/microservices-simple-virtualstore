using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Security.Claims;
using System.Text;
using VirtualStore.Identity.Core.Arguments;
using VirtualStore.Identity.Core.Configurations.Enums;
using VirtualStore.Identity.Core.Exceptions;
using VirtualStore.Identity.Core.Models;
using VirtualStore.Identity.Core.Repositories.Interfaces;

namespace VirtualStore.Identity.Core.Repositories;

public class RoleManagerRepository : BaseRepository, IRoleManagerRepository
{
    private readonly ILogger<RoleManagerRepository> _logger;

    public RoleManagerRepository(
        ILogger<RoleManagerRepository> logger, 
        IConfiguration configuration) : base(configuration)
    {
        _logger = logger;
    }

    public async Task<IEnumerable<RoleModel>> GetRoles()
    {
        string query = @"
                         SELECT RoleId, 
                                RoleName, 
                                CreatedDate, 
                                LastModifiedDate, 
                                IsActive 
                         FROM Roles
                         WHERE IsActive;";

        try
        {
            using IDbConnection connection = GetConnection();
            return await connection.QueryAsync<RoleModel>(query);
        }
        catch (Exception ex)
        {
            string message = "Error getting roles.";
            _logger.LogError(ex, message);
            throw new UserRoleException(message, ex);
        }
    }

    public async Task<IEnumerable<ClaimModel>> GetClaims()
    {
        string query = @"
                         SELECT ClaimId, 
                                ClaimType, 
                                ClaimValue,
                                CreatedDate, 
                                LastModifiedDate, 
                                IsActive 
                         FROM Claims
                         WHERE IsActive;";

        try
        {
            using IDbConnection connection = GetConnection();
            return await connection.QueryAsync<ClaimModel>(query);
        }
        catch (Exception ex)
        {
            string message = "Error getting claims.";
            _logger.LogError(ex, message);
            throw new ClaimException(message, ex);
        }
    }

    public async Task<bool> SetRole(RoleType role, string username)
    {
        string query = @"
                        INSERT INTO UserRoles (UserId, RoleId)
                        VALUES (
                            (SELECT UserId FROM Users WHERE UserName = @UserName AND IsActive = true),
                            (SELECT RoleId FROM Roles WHERE RoleName = @RoleName)
                        )";
        try
        {
            using IDbConnection connection = GetConnection();
            var parameters = new { UserName = username, RoleName = role.ToString() };
            return await connection.ExecuteAsync(query, parameters) > 0;
        }
        catch (Exception ex)
        {
            string message = "Error setting user roles.";
            _logger.LogError(ex, message);
            throw new UserRoleException(message, ex);
        }
    }

    public async Task<bool> SetClaims(ClaimType claim, string username)
    {
        string query = @"
                INSERT INTO UserClaims (UserId, ClaimId)
                VALUES (
                    (SELECT UserId FROM Users WHERE UserName = @UserName AND IsActive = true),
                    (SELECT ClaimId FROM Claims WHERE ClaimType = @ClaimType)
                )";
        try
        {
            using IDbConnection connection = GetConnection();
            var parameters = new { UserName = username, ClaimType = claim.ToString() };
            return await connection.ExecuteAsync(query, parameters) > 0;
        }
        catch (Exception ex)
        {
            string message = "Error setting user claims.";
            _logger.LogError(ex, message);
            throw new ClaimException(message, ex);
        }
    }


    public async Task<bool> RemoveRole(RoleType role, string username)
    {
        string query = @"
                        UPDATE UserRoles 
                        SET IsActive = false,
                            LastModifiedDate = CURRENT_TIMESTAMP
                        WHERE RoleId = (SELECT RoleId FROM Roles WHERE RoleName = @RoleName)
                        AND UserId = (SELECT UserId FROM Users WHERE UserName = @UserName);";

        using IDbConnection connection = GetConnection();

        try
        {
            var parameters = new { UserName = username, RoleName = role.ToString() };
            return await connection.ExecuteAsync(query, parameters) > 1;
        }
        catch (Exception ex)
        {
            string message = "Error deleting user roles and claims.";
            _logger.LogError(ex, message);
            throw new UserRoleException(message, ex);
        }
    }

    public async Task<bool> RemoveClaim(ClaimType claim, string username)
    {
        string query = @"
                        UPDATE UserClaims
                        SET IsActive = false,
                            LastModifiedDate = CURRENT_TIMESTAMP
                        WHERE ClaimId = (SELECT ClaimId FROM Roles WHERE RoleName = @RoleName)
                        AND UserId = (SELECT UserId FROM Users WHERE UserName = @UserName);";

        using IDbConnection connection = GetConnection();

        try
        {
            var parameters = new { UserName = username, RoleName = claim.ToString() };
            return await connection.ExecuteAsync(query, parameters) > 1;
        }
        catch (Exception ex)
        {
            string message = "Error deleting user roles and claims.";
            _logger.LogError(ex, message);
            throw new UserRoleException(message, ex);
        }
    }

    public async Task<bool> ContainsRole(RoleType role, string username)
    {
        string query = @"
                        SELECT UserName
                        FROM UserRoles UR 
                        JOIN Users US ON US.UserId = UR.UserId
                        JOIN Roles RO ON RO.RoleId = UR.RoleId
                        WHERE US.UserName = @UserName
                        AND RO.RoleName = @RoleName
                        ";

        try
        {
            using IDbConnection connection = GetConnection();
            var parameters = new { UserName = username, RoleName = role.ToString() };
            return await connection.QueryFirstAsync<string>(query, parameters) == username;
        }
        catch (Exception ex)
        {
            string message = "Error checking user roles.";
            _logger.LogError(ex, message);
            throw new UserRoleException(message, ex);
        }
    }

    public async Task<bool> ContainsClaim(ClaimType claim, string username)
    {
        using IDbConnection connection = GetConnection();
        try
        {
            string query = @"
                        SELECT UserName
                        FROM UserClaims UC 
                        JOIN Users US ON US.UserId = UC.UserId
                        JOIN Claims CL ON CL.ClaimId = UC.ClaimId
                        WHERE US.UserName = @UserName
                        AND CL.ClaimType = @ClaimType
                        ";

            var parameters = new { UserName = username, ClaimType = claim.ToString() };
            return await connection.QueryFirstAsync<string>(query, parameters) == username;
        }
        catch (Exception ex)
        {
            string message = "Error checking user claims.";
            _logger.LogError(ex, message);
            throw new ClaimException(message, ex);
        }
    }

    public async Task<bool> RoleExists(RoleType roleType)
    {
        string sql = "SELECT * FROM Roles WHERE RoleName = @RoleName";
        try
        {
            using IDbConnection connection = GetConnection();
            var parameters = new { RoleName = roleType.ToString() };
            var result = await connection.QueryFirstOrDefaultAsync<RoleModel>(sql, parameters);
            return result == null;
        }
        catch (Exception ex)
        {
            string message = "Error checking role exists.";
            _logger.LogError(ex, message);
            throw new UserRoleException(message, ex);
        }
    }

    public async Task<bool> ClaimExists(ClaimType claimType)
    {
        string sql = "SELECT * FROM Claims WHERE ClaimType = @ClaimType";
        try
        {
            using IDbConnection connection = GetConnection();
            var parameters = new { ClaimType = claimType.ToString() };
            return await connection.QueryFirstOrDefaultAsync<ClaimModel>(sql, parameters) == null;
        }
        catch (Exception ex)
        {
            string message = "Error checking claims exists.";
            _logger.LogError(ex, message);
            throw new ClaimException(message, ex);
        }
    }

    public async Task SaveRoles(IEnumerable<RoleArgument> roles)
    {
        string sql = "INSERT INTO Roles (RoleName) VALUES (@RoleName) ON CONFLICT (RoleName) DO NOTHING";
        try
        {
            using IDbConnection connection = GetConnection();
            await connection.ExecuteAsync(sql, roles);
            roles.ToList().ForEach(role => _logger.LogInformation(string.Format("Claim to be saved: {0}", role.RoleName)));
        }
        catch (Exception ex)
        {
            throw new UserRoleException(ex.Message, ex);
        }
    }

    public async Task SaveClaims(IEnumerable<ClaimArgument> claims)
    {
        string sql = "INSERT INTO Claims (ClaimType, ClaimValue) VALUES (@ClaimType, @ClaimValue) ON CONFLICT (ClaimType, ClaimValue) DO NOTHING";
        try
        {
            using IDbConnection connection = GetConnection();
            await connection.ExecuteAsync(sql, claims);
            claims.ToList().ForEach(claim => _logger.LogInformation(string.Format("Claim to be saved: {0}", claim.ClaimType)));
        }
        catch (Exception ex)
        {
            throw new UserClaimException(ex.Message, ex);
        }
    }
}