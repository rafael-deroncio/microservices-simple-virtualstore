using Microsoft.Extensions.Logging;
using System.Data;
using System.IO;
using VirtualStore.Identity.Core.Arguments;
using VirtualStore.Identity.Core.Configurations.Enums;
using VirtualStore.Identity.Core.Configurations.Mappers;
using VirtualStore.Identity.Core.Exceptions;
using VirtualStore.Identity.Core.Managers.Interfaces;
using VirtualStore.Identity.Core.Models;
using VirtualStore.Identity.Core.Repositories.Interfaces;

namespace VirtualStore.Identity.Core.Managers;

public class RoleManager : IRoleManager
{
    private readonly IRoleManagerRepository _roleManagerRepository;
    private readonly IObjectConverter _objectConverter;
    private readonly ILogger<RoleManager> _logger;

    private readonly IEnumerable<ClaimType> _userClaims = new ClaimType[] 
    {
        ClaimType.ReadProduct,
        ClaimType.ReadCatalog,
        ClaimType.CreateUser,
        ClaimType.ReadUser,
        ClaimType.UpdateUser,
        ClaimType.DeleteUser,
    };
    private readonly IEnumerable<ClaimType> _administratorClaims = new ClaimType[]
    {
        ClaimType.CreateProduct,
        ClaimType.ReadProduct,
        ClaimType.UpdateProduct,
        ClaimType.DeleteProduct,

        ClaimType.CreateCatalog,
        ClaimType.ReadCatalog,
        ClaimType.UpdateCatalog,
        ClaimType.DeleteCatalog,

        ClaimType.CreateUser,
        ClaimType.ReadUser,
        ClaimType.DeleteUser,
    };
    private readonly IEnumerable<ClaimType> _managerClaims = new ClaimType[]
    {
        ClaimType.CreateProduct,
        ClaimType.ReadProduct,
        ClaimType.UpdateProduct,
        ClaimType.DeleteProduct,

        ClaimType.CreateCatalog,
        ClaimType.ReadCatalog,
        ClaimType.UpdateCatalog,
        ClaimType.DeleteCatalog,

        ClaimType.CreateUser,
        ClaimType.ReadUser,
        ClaimType.UpdateUser,
        ClaimType.DeleteUser,
    };

    public RoleManager(IRoleManagerRepository roleManagerRepository, IObjectConverter objectConverter, ILogger<RoleManager> logger)
    {
        _roleManagerRepository = roleManagerRepository;
        _objectConverter = objectConverter;
        _logger = logger;

    }

    public async Task<IEnumerable<RoleModel>> GetRoles()
    {
        return await _roleManagerRepository.GetRoles(); 
    }

    public async Task<IEnumerable<ClaimModel>> GetClaims()
    {
        return await _roleManagerRepository.GetClaims();
    }

    public async Task<bool> SetRole(RoleType role, string username)
    {
        return await _roleManagerRepository.SetRole(role, username);
    }

    public async Task<bool> RemoveRole(RoleType role, string username)
    {
        return await _roleManagerRepository.RemoveRole(role, username); ;
    }

    public async Task<bool> RemoveClaim(ClaimType claim, string username)
    {
        return await _roleManagerRepository.RemoveClaim(claim, username); ;
    }

    public async Task<bool> ContainsRole(RoleType role, string username)
    {
        return await _roleManagerRepository.ContainsRole(role, username);
    }

    public async Task<bool> ContainsClaim(ClaimType claim, string username)
    {
        return await _roleManagerRepository.ContainsClaim(claim, username);
    }

    public async Task<bool> SetClaimByRole(RoleType role, string username)
    {
        switch (role)
        {
            case RoleType.Customer:
                _userClaims.ToList().ForEach(async claim =>
                {
                    await _roleManagerRepository.SetClaims(claim, username);
                });
                return await Task.FromResult(true);

            case RoleType.Admin:
                _administratorClaims.ToList().ForEach(async claim =>
                {
                    await _roleManagerRepository.SetClaims(claim, username);
                });
                return await Task.FromResult(true);

            case RoleType.Manager:
                _managerClaims.ToList().ForEach(async claim =>
                {
                    await _roleManagerRepository.SetClaims(claim, username);
                });
                return await Task.FromResult(true);
        }

        return await Task.FromResult(false);
    }

    public async Task InitializeSeedRoles()
    {
        try
        {
            _logger.LogInformation("Initializing seed roles");
            IEnumerable<RoleModel> nonExistingRoles = await GetNonExistingRoles(new()
            {
                new () { RoleName = nameof(RoleType.Customer) },
                new () { RoleName = nameof(RoleType.Admin) },
                new () { RoleName = nameof(RoleType.Manager) },
            });
            if (nonExistingRoles.Any())
                await _roleManagerRepository.SaveRoles(_objectConverter.Map<IEnumerable<RoleArgument>>(nonExistingRoles));
            _logger.LogInformation("Roles seeded successfully.");

            _logger.LogInformation("Initializing seed claims");
            IEnumerable<ClaimModel> nonExistingClaims = await GetNonExistingClaims(new()
            {
                new() { ClaimType = ClaimType.CreateUser.ToString(), ClaimValue = ClaimType.CreateUser.GetDescription() },
                new() { ClaimType = ClaimType.ReadUser.ToString(), ClaimValue = ClaimType.ReadUser.GetDescription() },
                new() { ClaimType = ClaimType.UpdateUser.ToString(), ClaimValue = ClaimType.UpdateUser.GetDescription() },
                new() { ClaimType = ClaimType.DeleteUser.ToString(), ClaimValue = ClaimType.DeleteUser.GetDescription() },

                new() { ClaimType = ClaimType.CreateProduct.ToString(), ClaimValue = ClaimType.CreateProduct.GetDescription() },
                new() { ClaimType = ClaimType.ReadProduct.ToString(), ClaimValue = ClaimType.ReadProduct.GetDescription() },
                new() { ClaimType = ClaimType.UpdateProduct.ToString(), ClaimValue = ClaimType.UpdateProduct.GetDescription() },
                new() { ClaimType = ClaimType.DeleteProduct.ToString(), ClaimValue = ClaimType.DeleteProduct.GetDescription() },

                new() { ClaimType = ClaimType.CreateCatalog.ToString(), ClaimValue = ClaimType.CreateCatalog.GetDescription() },
                new() { ClaimType = ClaimType.ReadCatalog.ToString(), ClaimValue = ClaimType.ReadCatalog.GetDescription() },
                new() { ClaimType = ClaimType.UpdateCatalog.ToString(), ClaimValue = ClaimType.UpdateCatalog.GetDescription() },
                new() { ClaimType = ClaimType.DeleteCatalog.ToString(), ClaimValue = ClaimType.DeleteCatalog.GetDescription() }
            });
            if (nonExistingClaims.Any())
                await _roleManagerRepository.SaveClaims(_objectConverter.Map<IEnumerable<ClaimArgument>>(nonExistingClaims));
            _logger.LogInformation("Seed claims completed successfully.");
        }
        catch (UserRoleException ex)
        {
            _logger.LogError(ex, $"Roles seeded failed. {ex.Message}.");
            throw;
        }
        catch (UserClaimException ex) 
        {
            _logger.LogError(ex, $"Claims seeded failed. {ex.Message}.");
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Initialize Seed and Roles fail. {ex.Message}.");
            throw;
        }
    }

    private async Task<IEnumerable<RoleModel>> GetNonExistingRoles(List<RoleModel> roles)
    {
        List<RoleModel> nonExistingRoles = new();

        foreach (var role in roles)
        {
            if (await _roleManagerRepository.RoleExists((RoleType)Enum.Parse(typeof(RoleType), role.RoleName)))
                nonExistingRoles.Add(role);
        }

        return nonExistingRoles.AsEnumerable();
    }

    private async Task<IEnumerable<ClaimModel>> GetNonExistingClaims(List<ClaimModel> claims)
    {
        List<ClaimModel> nonExistingClaims = new();

        foreach (var claim in claims)
        {
            if (await _roleManagerRepository.ClaimExists((ClaimType)Enum.Parse(typeof(ClaimType), claim.ClaimType)))
                nonExistingClaims.Add(claim);
        }

        return nonExistingClaims.AsEnumerable();
    }
}