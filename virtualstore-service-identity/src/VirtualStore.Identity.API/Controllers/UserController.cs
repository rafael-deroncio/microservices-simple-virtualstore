using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualStore.Identity.Core.Services.Interfaces;
using VirtualStore.Identity.Core.Responses;
using VirtualStore.Identity.Domain.Requests;
using VirtualStore.Identity.Domain.Responses;
using VirtualStore.Identity.Core.Configurations.Enums;

namespace VirtualStore.Identity.API.Controllers;

/// <summary>
/// Controller to manage user profiles.
/// </summary>
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _userProfileService;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserController"/> class.
    /// </summary>
    /// <param name="userProfileService">The user profile service.</param>
    public UserController(IUserService userProfileService)
    {
        _userProfileService = userProfileService;
    }

    /// <summary>
    /// Gets a user by their username.
    /// </summary>
    /// <param name="username">The username of the user to retrieve.</param>
    /// <returns>Returns a user response if successful, or an exception response if failed.</returns>
    [HttpGet("{username}")]
    [Authorize(Roles = "Admin, Manager")]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetUser(string username)
        => Ok(await _userProfileService.GetUserProfile(username));

    /// <summary>
    /// Creates a new user.
    /// </summary>
    /// <param name="request">The user creation request.</param>
    /// <returns>Returns a user response if successful, or an exception response if failed.</returns>
    [HttpPost]
    [Authorize(Roles = "Admin, Manager")]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> PostUser(UserRequest request)
        => Ok(await _userProfileService.CreateUserProfile(request));

    /// <summary>
    /// Updates an existing user.
    /// </summary>
    /// <param name="username"></param>
    /// <param name="request">The user update request.</param>
    /// <returns>Returns a user response if successful, or an exception response if failed.</returns>
    [HttpPut("{username}")]
    [Authorize(Roles = "Customer, Admin, Manager")]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> UpdateUser(string username, [FromBody] UserRequest request)
        => Ok(await _userProfileService.UpdateUserProfile(username, request));

    /// <summary>
    /// Deletes a user.
    /// </summary>
    /// <param name="username">The ID of the user to delete.</param>
    /// <returns>Returns a user response if successful, or an exception response if failed.</returns>
    [HttpDelete("{username}")]
    [Authorize(Roles = "Admin, Manager")]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> DeleteUser(string username)
        => Ok(await _userProfileService.DeleteUserProfile(username));

}