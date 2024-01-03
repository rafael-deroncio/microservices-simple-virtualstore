using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualStore.Identity.Core.Responses;
using VirtualStore.Identity.Core.Services.Interfaces;
using VirtualStore.Identity.Domain.Requests;
using VirtualStore.Identity.Domain.Responses;

namespace VirtualStore.Identity.API.Controllers;

/// <summary>
/// Controller for managing user accounts and authentication operations.
/// </summary>
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
[Authorize]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    /// <summary>
    /// Initializes a new instance of the <see cref="AccountController"/> class.
    /// </summary>
    /// <param name="accountService">The service responsible for managing user accounts.</param>
    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    /// <summary>
    /// LogIn a user.
    /// </summary>
    /// <param name="request">The login request data.</param>
    /// <returns>An object containing the result of the login operation.</returns>
    [HttpPost("login")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(LogInResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> LogIn(LogInRequest request)
        => Ok(await _accountService.LogIn(request, GetUserAgent(), GetIpAddresses()));

    /// <summary>
    /// LogOut a user.
    /// </summary>
    /// <param name="request">The unsubscribe request data.</param>
    /// <returns>An object containing the result of the unsubscribe operation.</returns>
    [HttpPost("logout")]
    [Authorize(Roles = "Customer, Admin, Manager")]
    [ProducesResponseType(typeof(SignOutResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> LogOut(LogOutRequest request)
        => Ok(await _accountService.LogOut(request, GetUserAgent(), GetIpAddresses()));

    /// <summary>
    /// Signs in a user.
    /// </summary>
    /// <param name="request">The sign-in request data.</param>
    /// <returns>An object containing the result of the sign-in operation.</returns>
    [HttpPost("signin")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(SignInResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> SignIn(SignInRequest request)
        => Ok(await _accountService.SignIn(request, GetUserAgent(), GetIpAddresses()));

    /// <summary>
    /// Signs out a user.
    /// </summary>
    /// <param name="request">The sign-out request data.</param>
    /// <returns>An object containing the result of the sign-out operation.</returns>
    [HttpPost("signout")]
    [Authorize(Roles = "Customer, Admin, Manager")]
    [ProducesResponseType(typeof(SignOutResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> SignOut(SignOutRequest request)
        => Ok(await _accountService.SignOut(request, GetUserAgent(), GetIpAddresses()));

    private string GetUserAgent() => HttpContext.Request.Headers["User-Agent"];
    private string GetIpAddresses() => HttpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault()?.Trim() ?? 
                                       HttpContext.Connection.RemoteIpAddress?.ToString();
}