using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using System.Net;
using VirtualStore.Identity.Core.Arguments;
using VirtualStore.Identity.Core.Configurations.Enums;
using VirtualStore.Identity.Core.Exceptions;
using VirtualStore.Identity.Core.Helpers;
using VirtualStore.Identity.Core.Models;
using VirtualStore.Identity.Core.Repositories.Interfaces;
using VirtualStore.Identity.Core.Responses;
using VirtualStore.Identity.Core.Services.Interfaces;
using VirtualStore.Identity.Domain.Requests;
using VirtualStore.Identity.Domain.Responses;

namespace VirtualStore.Identity.Core.Services;

public class AccountService : IAccountService
{
    private readonly IUserService _userService;
    private readonly ILogger<AccountService> _logger;
    private readonly IAuthorizeService _authorizeService;
    private readonly IAccountRepository _accountRepository;
    private readonly IConfiguration _configuration;

     public AccountService(
         IUserService userService, 
         ILogger<AccountService> logger, 
         IAuthorizeService authorizeService,
         IAccountRepository accountRepository,
         IConfiguration configuration)
    {
        _userService = userService;
        _logger = logger;
        _authorizeService = authorizeService;
        _accountRepository = accountRepository;
        _configuration = configuration;
    }
    public async Task<LogInResponse> LogIn(LogInRequest request, string userAgent, string ipAddress)
    {
        _logger.LogInformation($"Starting LogIn at {request.Username} - RequestID: {request.RequestId}");
        try 
        {
            UserLoginResponse user = await _userService.GetUserLogin(request.Username);

            if (await _accountRepository.UserAccessFailedBlock(user.UserName))
                throw new LogInException(message: "user blocked by attempts",
                         responseType: ExceptionType.Warning,
                         statusCode: HttpStatusCode.Unauthorized);

            if (user.Password != await PasswordHelper.GeneratePasswordHashSHA256(request.Password))
            {
                int changes = int.Parse(_configuration["InvalidLoginAttempt:ChangesNumber"]);

                if (await _accountRepository.GetUserAccessFailedCount(user.UserName) + 1 == changes)
                {
                    await _accountRepository.RegisterInvalidLoginAttempt(user.UserName, true);

                    throw new LogInException(message: "user blocked by attempts!",
                         responseType: ExceptionType.Warning,
                         statusCode: HttpStatusCode.Unauthorized);
                }
                else
                {
                    await _accountRepository.RegisterInvalidLoginAttempt(user.UserName, false);

                    throw new LogInException(message: "Login invalid!",
                             responseType: ExceptionType.Warning,
                             statusCode: HttpStatusCode.Unauthorized);
                }
            }


            LogInResponse response = new()
            {
                Message = "login success",
                Result = true,
                Username = request.Username,
                Role = user.Role.RoleName,
                Token = await _authorizeService.GetTokensAuthentication(new TokenRequest()
                {
                    Username = user.UserName,
                    Role = user.Role.RoleName,
                    Claims = user.Claims.Select(claim => claim.ClaimType)
                })
            };

            await _accountRepository.SaveLogIn(new LogInArgument()
            {
                UserName = user.UserName,
                LoginProvider = nameof(ProviderType.VirtualStoreIdentityProvider),
                ProviderKey = ProviderType.VirtualStoreIdentityProvider.GetDescription(),
                RequestIdentifier = request.RequestId.ToString(),
                IpAddressess = ipAddress,
                UserAgent = userAgent,
                CreatedDate = DateTime.UtcNow,
                LastModifiedDate = DateTime.UtcNow,
                IsActive = true,
            });

            _logger.LogInformation($"LogIn success at {request.Username} - RequestID: {request.RequestId}");

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(string.Format("Registrar Invalid login attempt. {0}", ex.Message));
            throw;
        }
    }

    public async Task<LogOutResponse> LogOut(LogOutRequest request, string userAgent, string ipAddress)
    {
        _logger.LogInformation($"Starting Logout at {request.Username} - RequestID: {request.RequestId}");
        try
        {
            UserLoginResponse user = await _userService.GetUserLogin(request.Username);

            if (!await _authorizeService.ValidateRefreshToken(request.RefreshToken, request.Username))
            {
                throw new LogOutException(message: "Logout invalid!",
                                         responseType: ExceptionType.Warning,
                                         statusCode: HttpStatusCode.Unauthorized);
            }

            await _authorizeService.DisableUserTokens(request.Username);

            LogOutResponse response = new()
            {
                Message = "signout success",
                Result = true,
                Username = null,
                Role = null,
                Token = null
            };

            await _accountRepository.SaveSignOut(new SignOutArgument()
            {
                UserName = user.UserName,
                LoginProvider = nameof(ProviderType.VirtualStoreIdentityProvider),
                ProviderKey = ProviderType.VirtualStoreIdentityProvider.GetDescription(),
                RequestIdentifier = request.RequestId.ToString(),
                IpAddressess = ipAddress,
                UserAgent = userAgent,
                CreatedDate = DateTime.UtcNow,
                LastModifiedDate = DateTime.UtcNow,
                IsActive = true,
            });

            _logger.LogInformation($"Logout success at {request.Username} - RequestID: {request.RequestId}");

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(string.Format("Registrar Invalid login attempt. {0}", ex.Message));
            throw;
        }
    }

    public async Task<SignInResponse> SignIn(SignInRequest request, string userAgent, string ipAddress)
    {
        _logger.LogInformation($"Starting Sigin at {request.Username} - RequestID: {request.RequestId}");
        try
        {
            UserResponse user = await _userService.CreateUserProfile(new UserRequest()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                CPF = request.CPF,
                Gender = request.Gender,
                Email = request.Email,
                Password = request.Password,
                ConfirmPassword = request.ConfirmPassword,
                Addresses = request.Addresses,
                Telephones = request.Telephones
            });

            SignInResponse response = new()
            {
                Message = "signin success",
                Result = true,
                Username = request.Username,
                Role = nameof(RoleType.Customer),
                Token = null
            };

            await _accountRepository.SaveSignIn(new SignInArgument()
            {
                UserName = user.UserName,
                LoginProvider = nameof(ProviderType.VirtualStoreIdentityProvider),
                ProviderKey = ProviderType.VirtualStoreIdentityProvider.GetDescription(),
                RequestIdentifier = request.RequestId.ToString(),
                IpAddressess = ipAddress,
                UserAgent = userAgent,
                CreatedDate = DateTime.UtcNow,
                LastModifiedDate = DateTime.UtcNow,
                IsActive = true,
            });

            _logger.LogInformation($"Signin success at {request.Username} - RequestID: {request.RequestId}");

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(string.Format("Registrar Invalid signin attempt. {0}", ex.Message));
            throw;
        }
    }

    public async Task<SignOutResponse> SignOut(SignOutRequest request, string userAgent, string ipAddress)
    {
        _logger.LogInformation($"Starting signout at {request.Username} - RequestID: {request.RequestId}");

        UserLoginResponse user = await _userService.GetUserLogin(request.Username);

        if (user.Password != await PasswordHelper.GeneratePasswordHashSHA256(request.Password))
            throw new LogInException(message: "Signout invalid!",
                     responseType: ExceptionType.Warning,
                     statusCode: HttpStatusCode.Unauthorized);

        if (!await _authorizeService.ValidateRefreshToken(request.RefreshToken, request.Username))
        {
            throw new LogOutException(message: "Signout invalid!",
                                     responseType: ExceptionType.Warning,
                                     statusCode: HttpStatusCode.Unauthorized);
        }

        await _userService.DeleteUserProfile(request.Username);

        SignOutResponse response = new();

        await _accountRepository.SaveSignOut(new SignOutArgument()
        {
            UserName = user.UserName,
            LoginProvider = nameof(ProviderType.VirtualStoreIdentityProvider),
            ProviderKey = ProviderType.VirtualStoreIdentityProvider.GetDescription(),
            RequestIdentifier = request.RequestId.ToString(),
            IpAddressess = ipAddress,
            UserAgent = userAgent,
            CreatedDate = DateTime.UtcNow,
            LastModifiedDate = DateTime.UtcNow,
            IsActive = true,
        });

        _logger.LogInformation($"Signout success at {request.Username} - RequestID: {request.RequestId}");

        return response;
    }
}