using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualStore.Discount.Core.Responses;
using VirtualStore.Discount.Core.Services.Interfaces;
using VirtualStore.Discount.Domain.Requests;
using VirtualStore.Discount.Domain.Responses;

namespace VirtualStore.Discount.API.Controllers;


/// <summary>
/// Controller for handling discount-related operations.
/// </summary>
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
[Authorize]
public class CouponController : ControllerBase
{
    private readonly IDiscountService _discountService;

    /// <summary>
    /// Initializes a new instance of the <see cref="CouponController"/> class.
    /// </summary>
    /// <param name="discountService">The discount service.</param>
    public CouponController(IDiscountService discountService)
    {
        _discountService = discountService;
    }

    /// <summary>
    /// Retrieves detailed information about a coupon based on its code.
    /// </summary>
    /// <param name="coupon">The code of the coupon to retrieve details for.</param>
    /// <returns>An asynchronous task that returns an action result containing coupon details.</returns>
    [HttpGet("{coupon}")]
    [Authorize(Roles = "Admin, Manager")]
    [ProducesResponseType(typeof(CouponResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetCoupon(string coupon)
        => Ok(await _discountService.GetCoupon(coupon));

    /// <summary>
    /// Retrieves information about a coupon based on its code.
    /// </summary>
    /// <param name="coupon">The code of the coupon to retrieve.</param>
    /// <returns>An asynchronous task that returns an action result containing coupon information.</returns>
    [HttpGet("details/{coupon}")]
    [Authorize(Roles = "Admin, Manager")]
    [ProducesResponseType(typeof(CouponResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetCouponDetails(string coupon)
        => Ok(await _discountService.GetCouponDetails(coupon));

    /// <summary>
    /// Creates a new coupon based on the provided request.
    /// </summary>
    /// <param name="request">The request containing information for creating the coupon.</param>
    /// <returns>An asynchronous task that returns an action result containing the created coupon.</returns>
    [HttpPost]
    [Authorize(Roles = "Admin, Manager")]
    [ProducesResponseType(typeof(CouponResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateCoupon([FromBody] CouponRequest request)
        => Ok(await _discountService.CreateCoupon(request));

    /// <summary>
    /// Updates an existing coupon based on the provided request.
    /// </summary>
    /// <param name="request">The request containing information for updating the coupon.</param>
    /// <param name="coupon">The code of the coupon to retrieve.</param>
    /// <returns>An asynchronous task that returns an action result containing the updated coupon.</returns>
    [HttpPut("{coupon}")]
    [Authorize(Roles = "Admin, Manager")]
    [ProducesResponseType(typeof(CouponResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateCoupon(string coupon, [FromBody] CouponRequest request)
        => Ok(await _discountService.UpdateCoupon(coupon, request));

    /// <summary>
    /// Disables a coupon with the specified code.
    /// </summary>
    /// <param name="coupon">The code of the coupon to be disabled.</param>
    /// <returns>An asynchronous task that returns an action result containing the result of disabling the coupon.</returns>
    [HttpDelete("{coupon}")]
    [Authorize(Roles = "Admin, Manager")]
    [ProducesResponseType(typeof(CouponResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DisableCoupon(string coupon)
        => Ok(await _discountService.DisableCoupon(coupon));

    /// <summary>
    /// Applies a coupon based on the provided usage request.
    /// </summary>
    /// <param name="request">The request containing information for applying the coupon.</param>
    /// <returns>An asynchronous task that returns an action result containing the result of applying the coupon.</returns>
    [HttpPost("apply")]
    //[Authorize(Roles = "Admin, Manager")]
    [ProducesResponseType(typeof(CouponResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ApplyCoupon([FromBody] ApplyCouponRequest request)
        => Ok(await _discountService.ApplyCoupon(request));

    /// <summary>
    /// Removes a coupon based on the provided usage request.
    /// </summary>
    /// <param name="request">The request containing information for removing the coupon.</param>
    /// <returns>An asynchronous task that returns an action result containing the result of removing the coupon.</returns>
    [HttpPost("remove")]
    [Authorize(Roles = "Admin, Manager")]
    [ProducesResponseType(typeof(CouponResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RemoveCoupon([FromBody] RemoveCouponRequest request)
        => Ok(await _discountService.RemoveCoupon(request));
}
