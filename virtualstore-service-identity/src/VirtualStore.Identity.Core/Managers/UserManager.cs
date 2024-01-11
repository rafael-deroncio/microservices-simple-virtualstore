using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using VirtualStore.Identity.Core.Arguments;
using VirtualStore.Identity.Core.Configurations.Enums;
using VirtualStore.Identity.Core.Configurations.Mappers;
using VirtualStore.Identity.Core.Helpers;
using VirtualStore.Identity.Core.Managers.Interfaces;
using VirtualStore.Identity.Core.Models;
using VirtualStore.Identity.Core.Repositories.Interfaces;

namespace VirtualStore.Identity.Core.Managers;

public class UserManager : IUserManager
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<UserManager> _logger;
    private readonly IObjectConverter _objectConverter;
    private readonly IRoleManager _roleManager;

    public UserManager(IUserRepository userRepository, ILogger<UserManager> logger, IObjectConverter objectConverter, IRoleManager roleManager)
    {
        _userRepository = userRepository;
        _logger = logger;
        _objectConverter = objectConverter;
        _roleManager = roleManager;
    }

    public async Task InitializeSeedUsers()
    {
        _logger.LogInformation("Initializing seed default users");
        AddressModel defaultAddresses = new()
        {
            Street = "default_Street",
            City = "default_City",
            State = "default_State",
            ZipCode = "00000-000",
            Country = "default_Country"
        };

        TelephoneModel defaultTelephones = new()
        {
            PhoneNumber = "1234567890",
            PhoneType = "Mobile"
        };

        List<UserModel> users = new()
        {
            new()
            {
                Name = RoleType.Customer.GetDescription(),
                CPF = "USERCUSTCPF",
                DateOfBirth = DateTime.Now,
                Gender = "O",
                UserName = nameof(RoleType.Customer),
                Email = $"{RoleType.Customer.GetDescription().ToLower()}@virtualstore.com.br",
                PasswordHash = PasswordHelper.GeneratePasswordHashSHA256($"auhgmlacurhglau34783259@^&%#49021hspadf{RoleType.Customer.GetDescription()}").Result,
                SecurityStamp = Guid.NewGuid().ToString(),
                TwoFactorEnabled = true,
                LockoutEndDateUtc = null,
                LockoutEnabled = false,
                AccessFailedCount = 0,

                Addresses = new()
                {
                    defaultAddresses
                },

                Telephones = new()
                {
                    defaultTelephones
                }
            },
            new()
            {
                Name = RoleType.Admin.GetDescription(),
                CPF = "USERADMICPF",
                DateOfBirth = DateTime.Now,
                Gender = "O",
                UserName = nameof(RoleType.Admin),
                Email = $"{RoleType.Admin.GetDescription().ToLower()}@virtualstore.com.br",
                PasswordHash = PasswordHelper.GeneratePasswordHashSHA256($"auhgmlacurhglau34783259@^&%#49021hspadf{RoleType.Admin.GetDescription()}").Result,
                SecurityStamp = Guid.NewGuid().ToString(),
                TwoFactorEnabled = true,
                LockoutEndDateUtc = null,
                LockoutEnabled = false,
                AccessFailedCount = 0,

                Addresses = new()
                {
                    defaultAddresses
                },

                Telephones = new()
                {
                    defaultTelephones
                }
            },
            new()
            {
                Name = RoleType.Manager.GetDescription(),
                CPF = "USERMANACPF",
                DateOfBirth = DateTime.Now,
                Gender = "O",
                UserName = nameof(RoleType.Manager),
                Email = $"{RoleType.Manager.GetDescription().ToLower()}@virtualstore.com.br",
                PasswordHash = PasswordHelper.GeneratePasswordHashSHA256($"auhgmlacurhglau34783259@^&%#49021hspadf{RoleType.Manager.GetDescription()}").Result,
                SecurityStamp = Guid.NewGuid().ToString(),
                TwoFactorEnabled = true,
                LockoutEndDateUtc = null,
                LockoutEnabled = false,
                AccessFailedCount = 0,

                Addresses = new()
                {
                    defaultAddresses
                },

                Telephones = new()
                {
                    defaultTelephones
                }
            }
        };

        users = await GetNonExistingUsers(users);

        users.ForEach(user =>
        {
            switch (user.UserName)
            {
                case nameof(RoleType.Customer):
                    _roleManager.SetRole(RoleType.Customer, user.UserName);
                    _roleManager.SetClaimByRole(RoleType.Customer, user.UserName);
                    break;

                case nameof(RoleType.Admin):
                    _roleManager.SetRole(RoleType.Admin, user.UserName);
                    _roleManager.SetClaimByRole(RoleType.Admin, user.UserName);
                    break;

                case nameof(RoleType.Manager):
                    _roleManager.SetRole(RoleType.Manager, user.UserName);
                    _roleManager.SetClaimByRole(RoleType.Manager, user.UserName);
                    break; 
            }

            _logger.LogInformation(string.Format("User to be saved: {0}", user.UserName));
        });
        _logger.LogInformation("Default users seeded successfully.");
    }

    private async Task<List<UserModel>> GetNonExistingUsers(List<UserModel> users)
    {
        List<UserModel> usersNonRegisted = new();

        foreach (UserModel user in users)
        {
            var userModel = await _userRepository.GetUser(username: user.UserName);
            if (userModel == null)
                usersNonRegisted.Add(await _userRepository.InsertUser(_objectConverter.Map<UserArgument>(user)));
        }

        return usersNonRegisted;
    }
}