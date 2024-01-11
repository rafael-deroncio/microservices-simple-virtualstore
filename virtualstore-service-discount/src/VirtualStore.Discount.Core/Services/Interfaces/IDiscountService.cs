using VirtualStore.Discount.Domain.Requests;
using VirtualStore.Discount.Domain.Responses;

namespace VirtualStore.Discount.Core.Services.Interfaces;

/// <summary>
/// Service interface for discount-related operations.
/// </summary>
public interface IDiscountService
{
    /// <summary>
    /// Retrieves detailed information about a coupon based on its code.
    /// </summary>
    /// <param name="coupon">The code of the coupon to retrieve details for.</param>
    /// <returns>A task representing the asynchronous operation and returning a response containing coupon details.</returns>
    Task<CouponDetailsResponse> GetCouponDetails(string coupon);

    /// <summary>
    /// Retrieves information about a coupon based on its code.
    /// </summary>
    /// <param name="coupon">The code of the coupon to retrieve.</param>
    /// <returns>A task representing the asynchronous operation and returning a response containing coupon information.</returns>
    Task<CouponResponse> GetCoupon(string coupon);

    /// <summary>
    /// Creates a new coupon based on the provided request.
    /// </summary>
    /// <param name="request">The request containing information for creating the coupon.</param>
    /// <returns>A task representing the asynchronous operation and returning a response containing the created coupon.</returns>
    Task<CouponResponse> CreateCoupon(CouponRequest request);

    /// <summary>
    /// Updates an existing coupon based on the provided request.
    /// </summary>
    /// <param name="coupon">The code of the coupon to retrieve.</param>
    /// <param name="request">The request containing information for updating the coupon.</param>
    /// <returns>A task representing the asynchronous operation and returning a response containing the updated coupon.</returns>
    Task<CouponResponse> UpdateCoupon(string coupon, CouponRequest request);

    /// <summary>
    /// Disables a coupon with the specified code.
    /// </summary>
    /// <param name="coupon">The code of the coupon to be disabled.</param>
    /// <returns>A task representing the asynchronous operation and returning a boolean indicating the success of disabling the coupon.</returns>
    Task<bool> DisableCoupon(string coupon);

    /// <summary>
    /// Applies a coupon based on the provided usage request.
    /// </summary>
    /// <param name="request">The request containing information for applying the coupon.</param>
    /// <returns>A task representing the asynchronous operation and returning a boolean indicating the success of applying the coupon.</returns>
    Task<bool> ApplyCoupon(ApplyCouponRequest request);

    /// <summary>
    /// Removes a coupon based on the provided usage request.
    /// </summary>
    /// <param name="request">The request containing information for removing the coupon.</param>
    /// <returns>A task representing the asynchronous operation and returning a boolean indicating the success of removing the coupon.</returns>
    Task<bool> RemoveCoupon(RemoveCouponRequest request);
}

