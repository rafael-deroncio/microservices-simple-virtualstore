using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data;
using VirtualStore.Identity.Core.Arguments;
using VirtualStore.Identity.Core.Configurations.Enums;
using VirtualStore.Identity.Core.Exceptions;
using VirtualStore.Identity.Core.Models;
using VirtualStore.Identity.Core.Repositories.Interfaces;
using YamlDotNet.Core.Tokens;

namespace VirtualStore.Identity.Core.Repositories;

public class TokenRepository : BaseRepository, ITokenRepository
{
    private readonly ILogger<TokenRepository> _logger;

    public TokenRepository(IConfiguration configuration, ILogger<TokenRepository> logger) : base(configuration)
    {
        _logger = logger;
    }
    
    public async Task<TokenModel> GetUserToken(TokenType type, string username)
    {
        string sql = @"
                        SELECT 
                            TOK.TokenId,
                            TOK.TokenValue,
                            TOK.TokenType,
                            TOK.Message,
                            TOK.Expires,
                            TOK.IsActive,
                            TOK.CreatedDate,
                            TOK.LastModifiedDate
                        FROM Tokens TOK
                        JOIN UserTokens UTO ON TOK.TokenId = UTO.TokenId 
                        WHERE UTO.UserId = (SELECT USR.UserId FROM Users USR WHERE USR.UserName = @UserName)
                            AND TOK.TokenType = @TokenType
                            AND TOK.IsActive";
        try
        {
            using IDbConnection connection = GetConnection();
            object parameters = new { UserName = username, TokenType = type.GetDescription() };
            return await connection.QueryFirstOrDefaultAsync<TokenModel>(sql, parameters);
        }
        catch (Exception ex)
        {
            string message = $"Unable to obtain {type.GetDescription()} for user {username}.";
            _logger.LogError(ex, message);
            throw new TokenException(message, ex);
        }
    }

    public async Task<TokenModel> SaveUserToken(string username, TokenArgument argument)
    {
        using IDbConnection connection = GetConnection();
        using IDbTransaction transaction = connection.BeginTransaction();

        try
        {
            TokenModel tokenModel = await SaveToken(argument, transaction);
            UserTokenModel userTokenModel = await SaveUserToken(username, tokenModel.TokenId, transaction);
            transaction.Commit();
            return tokenModel;
        }
        catch (UserClaimException)  { transaction.Rollback(); throw; }
        catch (TokenException) { transaction.Rollback(); throw; }
        catch (Exception ex)
        {
            transaction.Rollback();
            string message = $"Unable to save {argument.TokenType} for user {username} in database.";
            _logger.LogError(ex, message);
            throw new TokenException(message, ex);
        }

    }

    public async Task DisableTokens(string username, TokenType tokenType)
    {
        using IDbConnection connection = GetConnection();
        using IDbTransaction transaction = connection.BeginTransaction();

        try
        {
            await DisableToken(username, tokenType.GetDescription(), transaction);
            await DisableUserToken(username, tokenType.GetDescription(), transaction);
            transaction.Commit();
        }
        catch (TokenException) { transaction.Rollback(); throw; }
        catch (SignOutException) { transaction.Rollback(); throw; }
    }

    #region Privates
    private async Task DisableToken(string username, string tokenType, IDbTransaction transaction)
    {
        string sql = @"
            WITH UserTokenIds AS (
                SELECT UT.UserId, T.TokenId
                FROM Users U
                JOIN UserTokens UT ON U.UserId = UT.UserId
                JOIN Tokens T ON UT.TokenId = T.TokenId
                WHERE U.UserName = @UserName
                  AND T.TokenType = @TokenType
            )
            UPDATE Tokens
            SET IsActive = false
            WHERE TokenId IN (SELECT TokenId FROM UserTokenIds);";

        try
        {
            var parameters = new { UserName = username, TokenType = tokenType };
            await transaction.Connection.ExecuteAsync(sql, parameters, transaction);

            _logger.LogInformation(string.Format("Tokens of type {0} for user {1} disabled.", tokenType, username));
        }
        catch (Exception ex)
        {
            string message = $"Error disabling {tokenType}";
            _logger.LogError(ex, message);
            throw new TokenException(message, ex);
        }
    }

    private async Task DisableUserToken(string username, string tokenType, IDbTransaction transaction)
    {
        string sql = @"
            WITH UserTokenIds AS (
                SELECT UT.UserId, T.TokenId
                FROM Users U
                JOIN UserTokens UT ON U.UserId = UT.UserId
                JOIN Tokens T ON UT.TokenId = T.TokenId
                WHERE U.UserName = @UserName
                  AND T.TokenType = @TokenType
            )
            UPDATE UserTokens
            SET IsActive = false
            WHERE UserId IN (SELECT UserId FROM UserTokens);";

        try
        {
            var parameters = new { UserName = username, TokenType = tokenType };
            await transaction.Connection.ExecuteAsync(sql, parameters, transaction);

            _logger.LogInformation(string.Format("User tokens of type {0} for user {1} disabled.", tokenType, username));
        }
        catch (Exception ex)
        {
            string message = $"Error disabling user token {tokenType} for {username}";
            _logger.LogError(ex, message);
            throw new UserTokenException(message, ex);
        }
    }

    private async Task<TokenModel> SaveToken(TokenArgument argument, IDbTransaction transaction)
    {
        string sql = @"
                        INSERT INTO Tokens (TokenValue, TokenType, Expires, Message, CreatedDate)
                        VALUES (@TokenValue, @TokenType, @Expires, @Message, CURRENT_TIMESTAMP)
                        RETURNING TokenId, TokenValue, TokenType, Expires, Message, IsActive, CreatedDate, LastModifiedDate;";

        try
        {
            using IDbConnection connection = GetConnection();
            return await connection.QueryFirstOrDefaultAsync<TokenModel>(sql, argument, transaction);
        }
        catch (Exception ex)
        {
            string message = $"Unable to save {argument.TokenType} in database.";
            _logger.LogError(ex, message);
            throw new TokenException(message, ex);
        }
    }

    private async Task<UserTokenModel> SaveUserToken(string username, int tokenId, IDbTransaction transaction)
    {
        string sql = @"
                        INSERT INTO UserTokens (UserId, TokenId, CreatedDate)
                        VALUES ((SELECT USR.UserId FROM Users USR WHERE USR.UserName = @UserName), @TokenId, CURRENT_TIMESTAMP)
                        RETURNING UserTokenId, UserId, TokenId, IsActive, CreatedDate, LastModifiedDate;";

        try
        {
            using IDbConnection connection = GetConnection();
            object parameters = new { UserName = username, TokenId = tokenId };
            return await connection.QueryFirstOrDefaultAsync<UserTokenModel>(sql, parameters, transaction);
        }
        catch (Exception ex)
        {
            string message = $"Unable to associate token id {tokenId} to user {username} in database.";
            _logger.LogError(ex, message);
            throw new UserTokenException(message, ex);
        }
    }
    #endregion
}