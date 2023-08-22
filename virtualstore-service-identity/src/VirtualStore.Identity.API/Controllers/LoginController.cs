using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualStore.Identity.Core.Services.Interfaces;
using VirtualStore.Identity.Core.Responses;
using VirtualStore.Identity.Domain.Requests;
using VirtualStore.Identity.Domain.Responses;

namespace VirtualStore.Identity.API.Controllers;

/// <summary>
/// Controller to handle user login.
/// </summary>
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
[Authorize]
public class LogInController : ControllerBase
{
    private readonly IAccountService _accountService;

    /// <summary>
    /// Initializes a new instance of the <see cref="LogInController"/> class.
    /// </summary>
    /// <param name="accountService">The account service.</param>
    public LogInController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    /// <summary>
    /// Logs in a user.
    /// </summary>
    /// <param name="request">The log-in request.</param>
    /// <returns>Returns a log-in response if successful, or an exception response if failed.</returns>
    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(LogInResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> LogIn(LogInRequest request)
        => Ok(await _accountService.LogIn(request));
}