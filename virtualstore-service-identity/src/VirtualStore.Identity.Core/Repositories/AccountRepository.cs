using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.Common;
using System.Transactions;
using VirtualStore.Identity.Core.Arguments;
using VirtualStore.Identity.Core.Exceptions;
using VirtualStore.Identity.Core.Models;
using VirtualStore.Identity.Core.Repositories.Interfaces;

namespace VirtualStore.Identity.Core.Repositories;
public class AccountRepository : BaseRepository, IAccountRepository
{
    private readonly ILogger<AccountRepository> _logger;
    public AccountRepository(IConfiguration configuration, ILogger<AccountRepository> logger) : base(configuration)
    {
        _logger = logger;
    }

    public async Task<int> GetUserAccessFailedCount(string username)
    {
        string sql = @"
                        SELECT AccessFailedCount 
                        FROM Users 
                        WHERE UserName = @Username
                        AND IsActive = true;";

        try
        {
            using IDbConnection connection = GetConnection();
            return await connection.QueryFirstOrDefaultAsync<int>(sql, new { Username = username });

        }
        catch (Exception ex)
        {

            string message = $"Error when obtaining number of user {username} access attempts";
            _logger.LogError(ex, message);
            throw new AccessAccountException(message, ex);
        }
    }

    public async Task RegisterInvalidLoginAttempt(string username, bool block)
    {
        string sql = @"
                        UPDATE Users 
                        SET AccessFailedCount = AccessFailedCount + 1
                        WHERE UserName = @Username;" +
                        (!block ? "" :@"
                        UPDATE Users 
                        SET LockoutEnabled = true, LockoutEndDateUtc = CURRENT_TIMESTAMP
                        WHERE UserName = @Username;");

        try
        {
            using IDbConnection connection = GetConnection();
            await connection.ExecuteAsync(sql, new { Username = username });
        }
        catch (Exception ex)
        {

            string message = $"Error registering user {username} access attempt";
            _logger.LogError(ex, message);
            throw new AccessAccountException(message, ex);
        }
    }

    public async Task<bool> UserAccessFailedBlock(string username)
    {
        string sql = @"
                        SELECT 
                            LockoutEnabled 
                        FROM Users 
                        WHERE UserName = @Username 
                        AND IsActive = true;";

        try
        {
            using IDbConnection connection = GetConnection();
            return await connection.QueryFirstOrDefaultAsync<bool>(sql, new { Username = username });
        }
        catch (Exception ex)
        {

            string message = $"Error when checking whether the user {username} is blocked due to access attempts";
            _logger.LogError(ex, message);
            throw new AccessAccountException(message, ex);
        }
    }

    public async Task<bool> SaveLogIn(LogInArgument argument)
    {
        using IDbConnection connection = GetConnection();
        using IDbTransaction transaction = connection.BeginTransaction();

        try
        {
            LoginModel loginModel = await SaveAccessMovement<LogInArgument>(transaction, argument);
            argument.LoginId = loginModel.LoginId;
            UserLoginModel userLoginModel= await SaveUserLogin<LogInArgument>(transaction, argument);
            transaction.Commit();

            return true;
        }
        catch(AccessMovementException ex)
        {
            transaction.Rollback();
            string message = $"{ex.Message} login '{argument.UserName}'";
            _logger.LogError(message);
            throw new LogInException(message, ex.InnerException??null);
        }
        catch(UserAccessMovementException ex)
        {
            transaction.Rollback();
            string message = $"{ex.Message} user login '{argument.UserName}'";
            _logger.LogError(message);
            throw new UserLogInException(message, ex.InnerException ?? null);
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            string message = $"Error registering user login {argument.UserName}: {ex.Message}";
            _logger.LogError(ex, message);
            throw new AccessAccountException(message, ex);
        }
    }

    public async Task<bool> SaveLogOut(LogOutArgument argument)
    {
        using IDbConnection connection = GetConnection();
        using IDbTransaction transaction = connection.BeginTransaction();

        try
        {
            LoginModel loginModel = await SaveAccessMovement<LogOutArgument>(transaction, argument);
            argument.LoginId = loginModel.LoginId;
            UserLoginModel userLoginModel = await SaveUserLogin<LogOutArgument>(transaction, argument);
            transaction.Commit();

            return true;
        }
        catch (AccessMovementException ex)
        {
            transaction.Rollback();
            string message = $"{ex.Message} logout '{argument.UserName}'";
            _logger.LogError(message);
            throw new LogOutException(message, ex.InnerException ?? null);
        }
        catch (UserAccessMovementException ex)
        {
            transaction.Rollback();
            string message = $"{ex.Message} user logout '{argument.UserName}'";
            _logger.LogError(message);
            throw new UserLogOutException(message, ex.InnerException ?? null);
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            string message = $"Error registering user logout {argument.UserName}: {ex.Message}";
            _logger.LogError(ex, message);
            throw new AccessAccountException(message, ex);
        }
    }

    public async Task<bool> SaveSignIn(SignInArgument argument)
    {
        using IDbConnection connection = GetConnection();
        using IDbTransaction transaction = connection.BeginTransaction();

        try
        {
            LoginModel loginModel = await SaveAccessMovement<SignInArgument>(transaction, argument);
            argument.LoginId = loginModel.LoginId;
            UserLoginModel userLoginModel = await SaveUserLogin<SignInArgument>(transaction, argument);
            transaction.Commit();

            return true;
        }
        catch (AccessMovementException ex)
        {
            transaction.Rollback();
            string message = $"{ex.Message} sigin '{argument.UserName}'";
            _logger.LogError(message);
            throw new SignInException(message, ex.InnerException ?? null);
        }
        catch (UserAccessMovementException ex)
        {
            transaction.Rollback();
            string message = $"{ex.Message} user sigin '{argument.UserName}'";
            _logger.LogError(message);
            throw new UserSignInException(message, ex.InnerException ?? null);
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            string message = $"Error registering user signin {argument.UserName}: {ex.Message}";
            _logger.LogError(ex, message);
            throw new AccessAccountException(message, ex);
        }
    }

    public async Task<bool> SaveSignOut(SignOutArgument argument)
    {
        using IDbConnection connection = GetConnection();
        using IDbTransaction transaction = connection.BeginTransaction();

        try
        {
            LoginModel loginModel = await SaveAccessMovement<SignOutArgument>(transaction, argument);
            argument.LoginId = loginModel.LoginId;
            UserLoginModel userLoginModel = await SaveUserLogin<SignOutArgument>(transaction, argument);
            transaction.Commit();

            return true;
        }
        catch (AccessMovementException ex)
        {
            transaction.Rollback();
            string message = $"{ex.Message} signout '{argument.UserName}'";
            _logger.LogError(message);
            throw new SignOutException(message, ex.InnerException ?? null);
        }
        catch (UserAccessMovementException ex)
        {
            transaction.Rollback();
            string message = $"{ex.Message} user signout '{argument.UserName}'";
            _logger.LogError(message);
            throw new UserSignOutException(message, ex.InnerException ?? null);
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            string message = $"Error registering user signout {argument.UserName}: {ex.Message}";
            _logger.LogError(ex, message);
            throw new AccessAccountException(message, ex);
        }
    }

    private async Task<LoginModel> SaveAccessMovement<T>(IDbTransaction transaction, T argument)
    {
        string sql = @"
                        INSERT INTO Logins (LoginProvider, ProviderKey, RequestIdentifier, ActionType, IpAddressess, UserAgent, CreatedDate, LastModifiedDate, IsActive)
                        VALUES (@LoginProvider, @ProviderKey, @RequestIdentifier, @ActionType, @IpAddressess, @UserAgent, @CreatedDate, CURRENT_TIMESTAMP, true)
                        RETURNING LoginId, LoginProvider, ProviderKey, RequestIdentifier, ActionType, IpAddressess, UserAgent, CreatedDate, LastModifiedDate, IsActive;";

        using IDbConnection connection = GetConnection();

        try
        {
            return await connection.QueryFirstOrDefaultAsync<LoginModel>(sql, argument, transaction);
        }
        catch (Exception ex)
        {
            throw new AccessMovementException("Error registering ", ex);
        }
    }

    private async Task<UserLoginModel> SaveUserLogin<T>(IDbTransaction transaction, T argument)
    {
        string sql = @"
                        INSERT INTO UserLogins (UserId, LoginId, CreatedDate, LastModifiedDate, IsActive)
                        VALUES ((SELECT UserId FROM Users WHERE UserName = @UserName), @LoginId, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, true)
                        RETURNING UserLoginId, UserId, LoginId, CreatedDate, LastModifiedDate, IsActive;";

        using IDbConnection connection = GetConnection();

        try
        {
            return await connection.QueryFirstOrDefaultAsync<UserLoginModel>(sql, argument, transaction);
        }
        catch (Exception ex)
        {
            throw new UserAccessMovementException("Error registering ", ex);
        }
    }
}