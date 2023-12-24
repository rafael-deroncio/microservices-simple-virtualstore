using Microsoft.Extensions.Logging;
using VirtualStore.Identity.Core.Arguments;
using VirtualStore.Identity.Core.Configurations.Enums;
using VirtualStore.Identity.Core.Configurations.Mappers;
using VirtualStore.Identity.Core.Exceptions;
using VirtualStore.Identity.Core.Helpers;
using VirtualStore.Identity.Core.Models;
using VirtualStore.Identity.Core.Repositories.Interfaces;
using VirtualStore.Identity.Core.Services.Interfaces;
using VirtualStore.Identity.Domain.Requests;
using VirtualStore.Identity.Domain.Responses;

namespace VirtualStore.Identity.Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<UserService> _logger;
    private readonly IObjectConverter _objectConverter;

    public UserService(
        IUserRepository userRepository,
        ILogger<UserService> logger,
        IObjectConverter objectConverter)
    {
        _userRepository = userRepository;
        _logger = logger;
        _objectConverter = objectConverter;
    }

    public async Task<UserResponse> CreateUserProfile(UserRequest request)
    {
        try
        {
            _logger.LogInformation($"Starting user search at {request.Username}");

            await ValidateRequestToUpdateOrCreateUser(
                request.Username,
                new UserRequest()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    CPF = request.CPF,
                });

            request.Password = await PasswordHelper.GeneratePasswordHashSHA256(request.Password);

            UserModel user = await _userRepository.InsertUser(
                _objectConverter.Map<UserArgument>(request));

            return _objectConverter.Map<UserResponse>(user);
        }
        catch (UserException)
        {
            throw;
        }
        catch (Exception e)
        {
            _logger.LogError($"An error occurred while creating a user profile. {e.Message}");
            throw;
        }
    }

    public async Task<bool> DeleteUserProfile(string username)
    {
        try
        {
            _logger.LogInformation($"Starting user search at {username}");

            UserModel user = await _userRepository.GetUser(username) ??
                throw new UserException($"Username '{username}' not found!",
                    ExceptionResponseType.Error,
                    System.Net.HttpStatusCode.NotFound);

            return await _userRepository.DeleteUser(username);
        }
        catch (UserException)
        {
            throw; // No need to log or handle UserException, as it may be intentional.
        }
        catch (Exception e)
        {
            _logger.LogError($"An error occurred while deleting a user profile. {e.Message}");
            throw;
        }
    }

    public async Task<UserResponse> GetUserProfile(string username)
    {
        try
        {
            _logger.LogInformation($"Starting user search at {username}");

            UserModel user = await _userRepository.GetUser(username) ??
                throw new UserException($"Username '{username}' not found!",
                    ExceptionResponseType.Error,
                    System.Net.HttpStatusCode.NotFound);

            return _objectConverter.Map<UserResponse>(user);
        }
        catch (UserException)
        {
            throw; // No need to log or handle UserException, as it may be intentional.
        }
        catch (Exception e)
        {
            _logger.LogError($"An error occurred while retrieving a user profile. {e.Message}");
            throw;
        }
    }

    public async Task<UserResponse> UpdateUserProfile(string username, UserRequest request)
    {
        try
        {
            _logger.LogInformation($"Starting user search at {username}");

            await ValidateRequestToUpdateOrCreateUser(username, request);

            UserModel user = await _userRepository.GetUser(username) ??
                throw new UserException($"Username '{username}' not found!",
                    ExceptionResponseType.Error,
                    System.Net.HttpStatusCode.NotFound);

            UserArgument userUpdate = _objectConverter.Map<UserArgument>(request);
            userUpdate.UserId = user.UserId;

            ValidateAddressesForNewRegistrations(user, userUpdate);

            ValidateTelephonesForNewRegistrations(user, userUpdate);

            return _objectConverter.Map<UserResponse>(await _userRepository.UpdateUser(userUpdate));

        }
        catch (UserException e)
        {
            _logger.LogError($"Unable to update user '{username}' at this time. {e.Message}");
            throw;
        }
        catch (Exception e)
        {
            _logger.LogError($"An error occurred while updating a user profile. {e.Message}");
            throw;
        }
    }

    #region privates
    private void ValidateTelephonesForNewRegistrations(UserModel user, UserArgument userUpdate)
    {
        userUpdate.Telephones = userUpdate.Telephones
            .Where(telephoneUpdate => !user.Telephones.Any(
                telephoneModel =>
                    telephoneModel.PhoneNumber == telephoneUpdate.PhoneNumber &&
                    telephoneModel.PhoneType == telephoneUpdate.PhoneType
                ))
            .ToList();

        userUpdate.Telephones = userUpdate.Telephones.Count() == 0 ? null : userUpdate.Telephones;
    }

    private void ValidateAddressesForNewRegistrations(UserModel user, UserArgument userUpdate)
    {
        userUpdate.Addresses = userUpdate.Addresses
            .Where(addressUpdate => !user.Addresses.Any(
                addressModel =>
                    addressModel.Street == addressUpdate.Street &&
                    addressModel.City == addressUpdate.City &&
                    addressModel.State == addressUpdate.State &&
                    addressModel.ZipCode == addressUpdate.ZipCode &&
                    addressModel.Country == addressUpdate.Country
                ))
            .ToList();

        userUpdate.Addresses = userUpdate.Addresses.Count() == 0 ? null : userUpdate.Addresses;
    }

    private async Task ValidateRequestToUpdateOrCreateUser(string username, UserRequest request)
    {
        try
        {
            if (username != request.Username && !await _userRepository.UserNameExists(request.Username))
                throw new UserException($"Username {request.Username} is not available!",
                    ExceptionResponseType.Error,
                    System.Net.HttpStatusCode.NotFound);

            if (!await _userRepository.EmailExists(request.Email, request.Username))
                throw new UserException($"Email {request.Email} is not available!",
                    ExceptionResponseType.Error,
                    System.Net.HttpStatusCode.NotFound);

            if (!await _userRepository.CPFExists(request.CPF, request.Username))
                throw new UserException($"CPF {request.CPF} is not available!",
                    ExceptionResponseType.Error,
                    System.Net.HttpStatusCode.NotFound);
        }
        catch (UserException e)
        {
            _logger.LogError($"Validation error: {e.Message}");
            throw;
        }
        catch (Exception e)
        {
            _logger.LogError($"An unexpected error occurred during validation. {e.Message}");
            throw;
        }
    }
    #endregion
}
