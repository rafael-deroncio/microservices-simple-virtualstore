using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualStore.Catalog.Core.Responses;
using VirtualStore.Catalog.Core.Services.Interfaces;
using VirtualStore.Catalog.Domain.Responses;

namespace VirtualStore.Catalog.API.Controllers;

/// <summary>
/// Controller for authorization and token retrieval.
/// </summary>
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class AuthorizeController : ControllerBase
{
    private readonly IAuthorizeService _authorizeService;

    /// <summary>
    /// Constructor for the authorization controller.
    /// </summary>
    /// <param name="authorizeService">The authorization service.</param>
    public AuthorizeController(IAuthorizeService authorizeService)
    {
        _authorizeService = authorizeService;
    }

    /// <summary>
    /// Gets an authorization token.
    /// </summary>
    /// <returns>An ActionResult containing the authorization token.</returns>
    [HttpGet]
    [Route("token")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(TokenAuthorizationResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetToken() => Ok(await _authorizeService.GetAuthorizationToken());
}