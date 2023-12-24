using Microsoft.Extensions.Configuration;
using System.Data;
using Dapper;
using VirtualStore.Identity.Core.Models;
using VirtualStore.Identity.Core.Repositories.Interfaces;
using VirtualStore.Identity.Core.Arguments;
using System.Text;
using Microsoft.Extensions.Logging;
using System.Transactions;

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

                WHERE U.UserName = @Username"
            ;

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
            _logger.LogError(ex, "Error getting user.");
            throw;
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
        catch(Exception ex)
        {
            transaction.Rollback();
            _logger.LogError(ex, "Error inserting user.");
            throw;
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
        catch (Exception ex)
        {
            transaction.Rollback();
            _logger.LogError(ex, "Error updating user.");
            throw;
        }
    }

    private async Task SaveAndAssociateTelephones(UserArgument argument, IDbConnection connection, IDbTransaction transaction)
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

    private async Task SaveAndAssociateAddresses(UserArgument argument, IDbConnection connection, IDbTransaction transaction)
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

    public async Task<bool> DeleteUser(string username)
    {
        using IDbConnection connection = GetConnection();
        using IDbTransaction transaction = connection.BeginTransaction();
        try
        {
            await DeleteUserAssociations(username, connection, transaction);

            string deleteUserQuery = @"DELETE FROM Users WHERE UserName = @UserName";
            await connection.ExecuteAsync(deleteUserQuery, new { UserName = username }, transaction);

            transaction.Commit();

            return true;
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            _logger.LogError(ex, "Error deleting user.");
            throw;
        }
    }
    public async Task<IEnumerable<AddressModel>> InsertAddresses(IEnumerable<AddressArgument> addressArguments, IDbConnection connection = null, IDbTransaction transaction = null)
    {
        string sql = @"INSERT INTO Addresses (Street, City, State, ZipCode, Country, CreatedDate, LastModifiedDate, IsActive)
                       VALUES (@Street, @City, @State, @ZipCode, @Country, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, true)
                       RETURNING AddressId, Street, City, State, ZipCode, Country, CreatedDate, LastModifiedDate, IsActive";

        List<AddressModel> addresses = new List<AddressModel>();

        if (connection == null)
            using (connection = GetConnection())

        if (transaction == null)
            using (connection.BeginTransaction())

        foreach (AddressArgument addressUpdate in addressArguments)
        {                            
            addresses.Add(await connection.QueryFirstOrDefaultAsync<AddressModel>(sql, addressUpdate, transaction: transaction));
        }

        transaction.Commit();

        return addresses.AsEnumerable();
    }

    public async Task<IEnumerable<UserAddressModel>> InsertUserAddresses(IEnumerable<UserAddressArgument> userAddressArguments, IDbConnection connection = null, IDbTransaction transaction = null)
    {
        string sql = @"INSERT INTO UserAddresses (UserId, AddressId, CreatedDate, LastModifiedDate, IsActive)
                       VALUES (@UserId, @AddressId, @CreatedDate, @LastModifiedDate, true)
                       RETURNING Id, UserId, AddressId, CreatedDate, LastModifiedDate, IsActive";

        List<UserAddressModel> userAddresses = new List<UserAddressModel>();
        
        if (connection == null)
            using (connection = GetConnection())

        if (transaction == null)
            using (connection.BeginTransaction())
        
        foreach (UserAddressArgument addressUpdate in userAddressArguments)
        {
            userAddresses.Add(await connection.QueryFirstOrDefaultAsync<UserAddressModel>(sql, addressUpdate, transaction: transaction));
        }

        transaction.Commit();

        return userAddresses.AsEnumerable();
    }

    public async Task<IEnumerable<TelephoneModel>> InsertTelephones(IEnumerable<TelephoneArgument> telephoneArguments, IDbConnection connection = null, IDbTransaction transaction = null)
    {
        string sql = @"INSERT INTO Telephones (PhoneNumber, PhoneType, CreatedDate, LastModifiedDate, IsActive)
                       VALUES (@PhoneNumber, @PhoneType, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, true)
                       RETURNING TelephoneId, PhoneNumber, PhoneType, CreatedDate, LastModifiedDate, IsActive";

        List<TelephoneModel> telephones = new List<TelephoneModel>();

        foreach (TelephoneArgument telephone in telephoneArguments)
        {
            if (connection == null)
                using (connection = GetConnection())
                    telephones.Add(await connection.QueryFirstOrDefaultAsync<TelephoneModel>(sql, telephone, transaction: transaction));
            else
                telephones.Add(await connection.QueryFirstOrDefaultAsync<TelephoneModel>(sql, telephone, transaction: transaction));
        }

        return telephones.AsEnumerable();
    }

    public async Task<IEnumerable<UserTelephoneModel>> InsertUserTelephones(IEnumerable<UserTelephoneArgument> userTelephoneArguments, IDbConnection connection = null, IDbTransaction transaction = null)
    {
        string sql = @"INSERT INTO UserTelephones (UserId, TelephoneId, CreatedDate, LastModifiedDate, IsActive)
                       VALUES (@UserId, @TelephoneId, @CreatedDate, @LastModifiedDate, true)
                       RETURNING Id, UserId, TelephoneId, CreatedDate, LastModifiedDate, IsActive";

        List<UserTelephoneModel> userTelephones = new List<UserTelephoneModel>();

        if (connection == null)
            using (connection = GetConnection())

        if (transaction == null)
            using (connection.BeginTransaction())
                        
        foreach (UserTelephoneArgument userTelephone in userTelephoneArguments)
        {
            userTelephones.Add(await connection.QueryFirstOrDefaultAsync<UserTelephoneModel>(sql, userTelephone, transaction: transaction));
        }

        return userTelephones.AsEnumerable();
    }

    public async Task<bool> UserNameExists(string username)
    {
        using IDbConnection connection = GetConnection();
        string query = @"SELECT Count(*) FROM Users WHERE UserName = @UserName";
        return await connection.ExecuteScalarAsync<int>(query, new { UserName = username }) > 0;
    }

    public async Task<bool> EmailExists(string email, string username = null)
    {
        StringBuilder queryBuilder = new StringBuilder();
        queryBuilder.Append("SELECT Count(*) FROM Users WHERE Email = @Email");

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

    public async Task<bool> CPFExists(string cpf, string username = null)
    {
        StringBuilder queryBuilder = new StringBuilder();
        queryBuilder.Append("SELECT Count(*) FROM Users WHERE CPF = @CPF");

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

    public async Task<int> GetCountUsers()
    {
        using IDbConnection connection = GetConnection();
        string query = @"SELECT Count(*) FROM Users";
        return await connection.ExecuteScalarAsync<int>(query);
    }
    
    private async Task DeleteUserAssociations(string username, IDbConnection connection, IDbTransaction transaction)
    {
        string deleteAssociationsQuery = @"
        DELETE FROM UserAddresses WHERE UserId = (SELECT UserId FROM Users WHERE UserName = @UserName);
        DELETE FROM UserTelephones WHERE UserId = (SELECT UserId FROM Users WHERE UserName = @UserName);";

        await connection.ExecuteAsync(deleteAssociationsQuery, new { UserName = username }, transaction);
    }
    #endregion
}