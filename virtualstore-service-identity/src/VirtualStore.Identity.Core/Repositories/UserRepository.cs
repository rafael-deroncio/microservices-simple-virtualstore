using Microsoft.Extensions.Configuration;
using System.Data;
using Dapper;
using VirtualStore.Identity.Core.Models;
using VirtualStore.Identity.Core.Repositories.Interfaces;
using VirtualStore.Identity.Core.Arguments;
using System.Text;
using Microsoft.Extensions.Logging;
using System.Transactions;
using VirtualStore.Identity.Core.Exceptions;

namespace VirtualStore.Identity.Core.Repositories;

public class UserRepository : BaseRepository, IUserRepository
{
    private readonly ILogger<UserRepository> _logger;

    public UserRepository(IConfiguration configuration, ILogger<UserRepository> logger) : base(configuration)
    {
        _logger  = logger; 
    }

    #region user
    public async Task<UserModel> GetUser(string username)
    {
        try
        {
            string query = @"
                SELECT
	                U.UserId,
	                U.Name,
	                U.CPF,
	                U.DateOfBirth,
	                U.Gender,
	                U.Email,
	                U.UserName,
	                U.Email,
	                U.PasswordHash,
	                U.SecurityStamp,
	                U.TwoFactorEnabled,
	                U.LockoutEndDateUtc,
	                U.LockoutEnabled,
	                U.AccessFailedCount,
	                U.CreatedDate,
	                U.LastModifiedDate,
	                U.IsActive,

                    A.AddressId,
                    A.Street,
                    A.City,
                    A.State,
                    A.ZipCode,
                    A.Country,
	                UA.CreatedDate,
	                UA.LastModifiedDate,
	                UA.IsActive,
	
	                P.TelephoneId,
	                P.PhoneNumber,
	                P.PhoneType,
	                UP.CreatedDate,
	                UP.LastModifiedDate,
	                UP.IsActive,

                    R.RoleId,
                    R.RoleName,
                    UR.CreatedDate,
                    UR.LastModifiedDate,
                    UR.IsActive,
	
	                C.ClaimId,
	                C.ClaimType,
	                C.ClaimValue,
	                UC.CreatedDate,
	                UC.LastModifiedDate,
	                UC.IsActive,
	
	                T.TokenId,
	                T.TokenValue,
	                T.Message,
	                T.Expires,
	                UT.CreatedDate,
	                UT.LastModifiedDate,
	                UT.IsActive,
	
	                L.LoginId,
	                L.LoginProvider,
	                L.ProviderKey,
	                UL.CreatedDate,
	                UL.LastModifiedDate,
	                UL.IsActive

                FROM Users U

                LEFT JOIN UserRoles UR ON U.UserId = UR.UserId
                LEFT JOIN Roles R ON UR.RoleId = R.RoleId

                LEFT JOIN UserClaims UC ON U.UserId = UC.UserId
                LEFT JOIN Claims C ON UC.ClaimId = C.ClaimId

                LEFT JOIN UserTokens UT ON U.UserId = UT.UserId
                LEFT JOIN Tokens T ON UT.TokenId = T.TokenId

                LEFT JOIN UserLogins UL ON U.UserId = UL.UserId
                LEFT JOIN Logins L ON UL.LoginId = L.LoginId

                LEFT JOIN UserAddresses UA ON U.UserId = UA.UserId
                LEFT JOIN Addresses A ON UA.AddressId = A.AddressId

                LEFT JOIN UserTelephones UP ON U.UserId = UP.UserId
                LEFT JOIN Telephones P ON UP.TelephoneId = P.TelephoneId

                WHERE U.UserName = @Username
                    AND U.IsActive = true";

            Dictionary<int, UserModel> dataUserDict = new Dictionary<int, UserModel>();

            using IDbConnection connection = GetConnection();
            IEnumerable<UserModel> result = await connection.QueryAsync(
                sql: query,
                types: new[]
                {
                typeof(UserModel),
                typeof(AddressModel),
                typeof(TelephoneModel),
                typeof(RoleModel),
                typeof(ClaimModel),
                typeof(TokenModel),
                typeof(LoginModel),
                },
                map: obj =>
                {
                    UserModel userTemp;
                    UserModel user = obj[0] as UserModel;
                    AddressModel address = obj[1] as AddressModel;
                    TelephoneModel telephone = obj[2] as TelephoneModel;
                    RoleModel role = obj[3] as RoleModel;
                    ClaimModel claim = obj[4] as ClaimModel;
                    TokenModel token = obj[5] as TokenModel;
                    LoginModel login = obj[6] as LoginModel;

                    if (!dataUserDict.TryGetValue(user.UserId, out userTemp))
                    {
                        userTemp = user;

                        userTemp.Roles ??= new List<RoleModel>();
                        userTemp.Claims ??= new List<ClaimModel>();
                        userTemp.Tokens ??= new List<TokenModel>();
                        userTemp.Logins ??= new List<LoginModel>();
                        userTemp.Telephones ??= new List<TelephoneModel>();
                        userTemp.Addresses ??= new List<AddressModel>();

                        dataUserDict.Add(user.UserId, userTemp);
                    }

                    if (role != null && !userTemp.Roles.Any(x => x.RoleId == role.RoleId))
                        userTemp.Roles.Add(role);

                    if (claim != null && !userTemp.Claims.Any(x => x.ClaimId == claim.ClaimId))
                        userTemp.Claims.Add(claim);

                    if (token != null && !userTemp.Tokens.Any(x => x.TokenId == token.TokenId))
                        userTemp.Tokens.Add(token);

                    if (login != null && !userTemp.Logins.Any(x => x.LoginId == login.LoginId))
                        userTemp.Logins.Add(login);

                    if (telephone != null && !userTemp.Telephones.Any(x => x.TelephoneId == telephone.TelephoneId))
                        userTemp.Telephones.Add(telephone);

                    if (address != null && !userTemp.Addresses.Any(x => x.AddressId == address.AddressId))
                        userTemp.Addresses.Add(address);

                    return userTemp;
                },
                param: new { Username = username },
                transaction: null,
                buffered: true,
                splitOn: "AddressId,TelephoneId,RoleId,ClaimId,TokenId,LoginId").ConfigureAwait(false);

            return result.Distinct().FirstOrDefault();
        }
        catch(Exception ex)
        {
            string message = "Error getting user.";
            _logger.LogError(ex, message);
            throw new UserException(message, ex);
        }
    }

    public async Task<UserModel> InsertUser(UserArgument argument)
    {
        using IDbConnection connection = GetConnection();
        using IDbTransaction transaction = connection.BeginTransaction();
        try
        {
            string query = @"
                         INSERT INTO Users (Name, CPF, DateOfBirth, Gender, UserName, Email, PasswordHash, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount)
                         VALUES(@Name, @CPF, @DateOfBirth, @Gender, @UserName, @Email, @PasswordHash, false, null, false, 0)
                         RETURNING UserId";

            argument.UserId = await connection.ExecuteScalarAsync<int>(query, argument, transaction);

            if (argument.Addresses != null)
                await SaveAndAssociateAddresses(argument, connection, transaction);

            if (argument.Telephones != null)
                await SaveAndAssociateTelephones(argument, connection, transaction);

            transaction.Commit();

            return await GetUser(argument.UserName);
        }
        catch(UserAddressException)
        {
            throw;
        }
        catch (UserTelephoneException)
        {
            throw;
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            string message = "Error inserting user.";
            _logger.LogError(ex, message);
            throw new UserException(message, ex);
        }
    }
    
    public async Task<UserModel> UpdateUser(UserArgument argument)
    {
        using IDbConnection connection = GetConnection();
        using IDbTransaction transaction = connection.BeginTransaction();
        try
        {
            string query = @"
                            UPDATE Users
                            SET Name = @Name,
                                CPF = @CPF,
                                DateOfBirth = @DateOfBirth,
                                Gender = @Gender,
                                UserName = @UserName,
                                Email = @Email,
                                LastModifiedDate = CURRENT_TIMESTAMP
                            WHERE UserName = @UserName AND UserId = @UserId
                            RETURNING UserName";

            await connection.ExecuteAsync(query, argument, transaction);

            if (argument.Addresses != null)
                await SaveAndAssociateAddresses(argument, connection, transaction);

            if (argument.Telephones != null)
                await SaveAndAssociateTelephones(argument, connection, transaction);

            transaction.Commit();

            return await GetUser(argument.UserName);
        }
        catch (UserAddressException)
        {
            throw;
        }
        catch (UserTelephoneException)
        {
            throw;
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            string message = "Error updating user.";
            _logger.LogError(ex, message);
            throw new UserException(message, ex);
        }
    }

    public async Task<bool> DeleteUser(string username)
    {
        using IDbConnection connection = GetConnection();
        using IDbTransaction transaction = connection.BeginTransaction();
        try
        {
            await DisableUserAddresses(username, connection, transaction);
            await DisableUserTelephones(username, connection, transaction);
            await DisableUserRoles(username, connection, transaction);
            await DisableUserClaims(username, connection, transaction);
            await DisableUserLogins(username, connection, transaction);
            await DisableUserTokens(username, connection, transaction);

            string query = @"
                            UPDATE Users 
                            SET IsActive = false,
                                LastModifiedDate = CURRENT_TIMESTAMP
                            WHERE UserName = @UserName";

            if (await connection.ExecuteAsync(query, new { UserName = username }, transaction) > 0)
            {
                transaction.Commit();
                return true;
            }

            throw new UserException(
                "Error deleting user.", 
                Configurations.Enums.ExceptionType.Error, 
                System.Net.HttpStatusCode.UnprocessableEntity);

        }
        catch (UserException ex)
        {
            transaction.Rollback();
            throw new UserException(ex.Message, ex);
        }
        catch (UserAddressException) { transaction.Rollback(); throw; }
        catch (UserTelephoneException) { transaction.Rollback(); throw; }
        catch (UserRoleException) { transaction.Rollback(); throw; }
        catch (UserClaimException) { transaction.Rollback(); throw; }
        catch (UserLogInException) { transaction.Rollback(); throw; }
        catch (UserTokenException) { transaction.Rollback(); throw; }
        catch (Exception ex)
        {
            string message = string.Format("Error deleting user. {0}", ex.Message);
            _logger.LogInformation(ex, message);
            throw new UserException(message, ex);
        }
    }

    private async Task SaveAndAssociateTelephones(UserArgument argument, IDbConnection connection, IDbTransaction transaction)
    {
        try
        {
            string sql = string.Format(
                        @"WITH inserted_telephone AS (
                          INSERT INTO Telephones (PhoneNumber, PhoneType, CreatedDate, LastModifiedDate, IsActive)
                          VALUES (@PhoneNumber, @PhoneType, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, true)
                          RETURNING TelephoneId, PhoneNumber, PhoneType, CreatedDate, LastModifiedDate, IsActive
                        )
                        INSERT INTO UserTelephones (UserId, TelephoneId, CreatedDate, LastModifiedDate, IsActive)
                        VALUES ({0}, (SELECT TelephoneId FROM inserted_telephone), CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, true)",
                        argument.UserId);

            await connection.ExecuteAsync(sql, argument.Telephones, transaction: transaction);
        }
        catch (Exception ex)
        {
            string message = "Error inserting or associate user telephones.";
            _logger.LogError(ex, message);
            throw new UserAddressException(message, ex);
        }
    }

    private async Task SaveAndAssociateAddresses(UserArgument argument, IDbConnection connection, IDbTransaction transaction)
    {
        try
        {
            string sql = string.Format(
                        @"WITH inserted_address AS (
                          INSERT INTO Addresses (Street, City, State, ZipCode, Country, CreatedDate, LastModifiedDate, IsActive)
                          VALUES (@Street, @City, @State, @ZipCode, @Country, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, true)
                          RETURNING AddressId, Street, City, State, ZipCode, Country, CreatedDate, LastModifiedDate, IsActive
                        )
                        INSERT INTO UserAddresses (UserId, AddressId, CreatedDate, LastModifiedDate, IsActive)
                        VALUES ({0}, (SELECT AddressId FROM inserted_address), CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, true)",
                        argument.UserId);

            await connection.ExecuteAsync(sql, argument.Addresses, transaction: transaction);
        }
        catch (Exception ex)
        {
            string message = "Error inserting or associate user address.";
            _logger.LogError(ex, message);
            throw new UserAddressException(message, ex);
        }
    }

    private async Task DisableUserAddresses(string username, IDbConnection connection, IDbTransaction transaction)
    {
        try
        {
            string query = @"
                            UPDATE UserAddresses 
                            SET IsActive = false, 
                                LastModifiedDate = CURRENT_TIMESTAMP
                            WHERE UserId = (SELECT UserId FROM Users WHERE UserName = @UserName);";

            await connection.ExecuteAsync(query, new { UserName = username }, transaction);
        }
        catch (Exception ex)
        {
            string message = "Error when disassociating the user's address";
            _logger.LogError(ex, message);
            throw new UserAddressException(message, ex);
        }
    }

    private async Task DisableUserTelephones(string username, IDbConnection connection, IDbTransaction transaction)
    {
        try
        {
            string query = @"
                            UPDATE UserTelephones
                            SET IsActive = false, 
                                LastModifiedDate = CURRENT_TIMESTAMP
                            WHERE UserId = (SELECT UserId FROM Users WHERE UserName = @UserName);";

            await connection.ExecuteAsync(query, new { UserName = username }, transaction);
        }
        catch (Exception ex)
        {
            string message = "Error when disassociating the user's number telephones";
            _logger.LogError(ex, message);
            throw new UserTelephoneException(message, ex);
        }
    }

    private async Task DisableUserRoles(string username, IDbConnection connection, IDbTransaction transaction)
    {
        try
        {
            string query = @"
                            UPDATE UserRoles
                            SET IsActive = false, 
                                LastModifiedDate = CURRENT_TIMESTAMP
                            WHERE UserId = (SELECT UserId FROM Users WHERE UserName = @UserName);";

            await connection.ExecuteAsync(query, new { UserName = username }, transaction);
        }
        catch (Exception ex)
        {
            string message = "Error when disassociating the user's roles";
            _logger.LogError(ex, message);
            throw new UserRoleException(message, ex);
        }
    }

    private async Task DisableUserClaims(string username, IDbConnection connection, IDbTransaction transaction)
    {
        try
        {
            string query = @"
                            UPDATE UserClaims
                            SET IsActive = false, 
                                LastModifiedDate = CURRENT_TIMESTAMP
                            WHERE UserId = (SELECT UserId FROM Users WHERE UserName = @UserName);";

            await connection.ExecuteAsync(query, new { UserName = username }, transaction);
        }
        catch (Exception ex)
        {
            string message = "Error when disassociating the user's claims";
            _logger.LogError(ex, message);
            throw new UserClaimException(message, ex);
        }
    }

    private async Task DisableUserLogins(string username, IDbConnection connection, IDbTransaction transaction)
    {
        try
        {
            string query = @"
                            UPDATE UserLogins
                            SET IsActive = false, 
                                LastModifiedDate = CURRENT_TIMESTAMP
                            WHERE UserId = (SELECT UserId FROM Users WHERE UserName = @UserName);";

            await connection.ExecuteAsync(query, new { UserName = username }, transaction);
        }
        catch (Exception ex)
        {
            string message = "Error when disassociating the user's logins";
            _logger.LogError(ex, message);
            throw new UserLogInException(message, ex);
        }
    }

    private async Task DisableUserTokens(string username, IDbConnection connection, IDbTransaction transaction)
    {
        try
        {
            string query = @"
                            UPDATE UserTokens
                            SET IsActive = false, 
                                LastModifiedDate = CURRENT_TIMESTAMP
                            WHERE UserId = (SELECT UserId FROM Users WHERE UserName = @UserName);";

            await connection.ExecuteAsync(query, new { UserName = username }, transaction);
        }
        catch (Exception ex)
        {
            string message = "Error when disassociating the user's tokens";
            _logger.LogError(ex, message);
            throw new UserTokenException(message, ex);
        }
    }

    public async Task<bool> UserNameExists(string username)
    {
        try
        {
            using IDbConnection connection = GetConnection();
            string query = @"SELECT UserId FROM Users WHERE UserName = @UserName AND IsActive = true";
            var result = await connection.ExecuteScalarAsync<int>(query, new { UserName = username });
            return result > 0;
        }
        catch(Exception ex)
        {
            string message = "Error when checking if the user already exists.";
            _logger.LogError(ex, message);
            throw new UserException(message, ex);
        }
    }

    public async Task<bool> EmailExists(string email, string username = null)
    {
        try
        {
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append("SELECT Count(*) FROM Users WHERE Email = @Email AND IsActive = true");

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Email", email);

            if (!string.IsNullOrEmpty(username))
            {
                queryBuilder.Append(" AND UserName = @UserName");
                parameters.Add("UserName", username);
            }

            using IDbConnection connection = GetConnection();
            return await connection.ExecuteScalarAsync<int>(queryBuilder.ToString(), parameters) > 0;
        }
        catch (Exception ex)
        {
            string message = "Error when checking if the e-mail already exists.";
            _logger.LogError(ex, message);
            throw new UserException(message, ex);
        }
    }

    public async Task<bool> CPFExists(string cpf, string username = null)
    {
        try
        {
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append("SELECT Count(*) FROM Users WHERE CPF = @CPF AND IsActive = true");

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("CPF", cpf);

            if (!string.IsNullOrEmpty(username))
            {
                queryBuilder.Append(" AND UserName = @UserName");
                parameters.Add("UserName", username);
            }

            using IDbConnection connection = GetConnection();
            return await connection.ExecuteScalarAsync<int>(queryBuilder.ToString(), parameters) > 0;
        }
        catch (Exception ex)
        {
            string message = "Error when checking if the cpf already exists.";
            _logger.LogError(ex, message);
            throw new UserException(message, ex);
        }
    }

    public async Task<int> GetCountUsers()
    {
        try
        {
            using IDbConnection connection = GetConnection();
            string query = @"SELECT Count(*) FROM Users WHERE IsActive = true";
            return await connection.ExecuteScalarAsync<int>(query);
        }
        catch (Exception ex)
        {
            string message = "Error when checking number of users.";
            _logger.LogError(ex, message);
            throw new UserException(message, ex);
        }
    }
    #endregion
}