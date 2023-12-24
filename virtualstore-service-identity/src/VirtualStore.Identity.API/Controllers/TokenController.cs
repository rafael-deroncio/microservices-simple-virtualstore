using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualStore.Identity.Core.Responses;
using VirtualStore.Identity.Core.Services.Interfaces;
using VirtualStore.Identity.Domain.Requests;
using VirtualStore.Identity.Domain.Responses;

namespace VirtualStore.Identity.API.Controllers;

/// <summary>
/// Controller for handling authentication and authorization operations.
/// </summary>
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly IAuthorizeService _authorizeService;

    /// <summary>
    /// Initializes a new instance of the <see cref="TokenController"/> class.
    /// </summary>
    /// <param name="authorizeService">The service responsible for authentication and authorization.</param>
    public TokenController(IAuthorizeService authorizeService)
    {
        _authorizeService = authorizeService;
    }

    /// <summary>
    /// Gets an authentication token.
    /// </summary>
    /// <param name="request">The authentication request data.</param>
    /// <returns>An object containing the authentication token.</returns>
    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(TokenResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetTokenAuthentication([FromBody] TokenRequest request)
        => Ok(await _authorizeService.GetTokenAuthentication(request));

    /// <summary>
    /// Validates an authentication token.
    /// </summary>
    /// <param name="request">The token validation request data.</param>
    /// <returns>An object containing the result of the token validation.</returns>
    [HttpPost("valid")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(TokenResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ValidateTokenAuthentication([FromBody] ValidateTokenRequest request)
        => Ok(await _authorizeService.ValidateTokenAuthentication(request));
}