using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using System.Net;
using System.Security.Claims;
using VirtualStore.Cart.Core.Responses;
using VirtualStore.Cart.Core.Services.Interfaces;
using VirtualStore.Cart.Domain.Requests;
using VirtualStore.Cart.Domain.Responses;

namespace VirtualStore.Cart.API.Controllers;

/// <summary>
/// API controller for managing shopping cart operations.
/// </summary>
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
//[Authorize]
public class CartController : ControllerBase
{
    private readonly ICartService _cartService;

    /// <summary>
    /// Initializes a new instance of the <see cref="CartController"/> class.
    /// </summary>
    /// <param name="cartService">The service responsible for managing shopping cart operations.</param>
    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    /// <summary>
    /// Retrieves the shopping cart for the authenticated user.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(CartResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.UnprocessableEntity)]
    [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetCart()
        => Ok(await _cartService.GetCart(GetUsername()));

    /// <summary>
    /// Adds a new shopping cart for the authenticated user with the provided items.
    /// </summary>
    /// <param name="request">The CartRequest containing the items to be added.</param>
    [HttpPost]
    [ProducesResponseType(typeof(CartResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.UnprocessableEntity)]
    [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> AddCart([FromBody] CartRequest request)
        => Ok(await _cartService.AddCart(GetUsername(), request));

    /// <summary>
    /// Removes all items from the shopping cart for the authenticated user.
    /// </summary>
    [HttpPut]
    [ProducesResponseType(typeof(CartResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.UnprocessableEntity)]
    [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> CleanCart()
        => Ok(await _cartService.CleanCart(GetUsername()));

    /// <summary>
    /// Adds an item to the shopping cart for the authenticated user.
    /// </summary>
    /// <param name="request">The ItemRequest containing the item to be added.</param>
    [HttpPut("item/add")]
    [ProducesResponseType(typeof(CartResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.UnprocessableEntity)]
    [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> AddItemCart([FromBody] ItemRequest request)
        => Ok(await _cartService.AddItemCart(GetUsername(), request));

    /// <summary>
    /// Removes an item from the shopping cart for the authenticated user.
    /// </summary>
    /// <param name="request">The ItemRequest containing the item to be removed.</param>
    [HttpPut("item/remove")]
    [ProducesResponseType(typeof(CartResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.UnprocessableEntity)]
    [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> RemoveItemCart([FromBody] ItemRequest request)
        => Ok(await _cartService.RemoveItemCart(GetUsername(), request));

    /// <summary>
    /// Applies a coupon to the shopping cart for the authenticated user.
    /// </summary>
    /// <param name="request">The CouponRequest containing the coupon to be applied.</param>
    [HttpPut("coupon/apply")]
    [ProducesResponseType(typeof(CartResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.UnprocessableEntity)]
    [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> ApplyCouponCart([FromBody] CouponRequest request)
        => Ok(await _cartService.ApplyCouponCart(GetUsername(), request));

    /// <summary>
    /// Removes a coupon from the shopping cart for the authenticated user.
    /// </summary>
    /// <param name="request">The CouponRequest containing the coupon to be removed.</param>
    [HttpPut("coupon/remove")]
    [ProducesResponseType(typeof(CartResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.UnprocessableEntity)]
    [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> RemoveCouponCart([FromBody] CouponRequest request)
        => Ok(await _cartService.RemoveCouponCart(GetUsername(), request));

    #region privates
    /// <summary>
    /// Gets the username of the authenticated user from the claims.
    /// </summary>
    private string GetUsername() => User.FindFirst(ClaimTypes.Name)?.Value;
    #endregion
}
