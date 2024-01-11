using System.ComponentModel.DataAnnotations;

namespace VirtualStore.Discount.Domain.Requests;

/// <summary>
/// Represents the request for applying or removing a coupon.
/// </summary>
public class RemoveCouponRequest
{
    private string _code;

    /// <summary>
    /// Gets or sets the coupon code, automatically formatted to uppercase and trimmed.
    /// </summary>
    [Required(ErrorMessage = "Coupon code is required.")]
    [StringLength(50, ErrorMessage = "Coupon code cannot exceed 50 characters.")]
    public string Code { get => _code?.ToUpper()?.Trim(); set => _code = value; }

    /// <summary>
    /// Gets or sets the username associated with the coupon usage.
    /// </summary>
    [Required(ErrorMessage = "Username is required.")]
    public string Username { get; set; }

    /// <summary>
    /// Gets or sets the cart ID related to the coupon usage.
    /// </summary>
    [Required(ErrorMessage = "Cart ID is required.")]
    [Range(0, int.MaxValue, ErrorMessage = "Cart ID must be non-negative.")]
    public int CartId { get; set; }

    /// <summary>
    /// Gets or sets the order ID related to the coupon usage.
    /// </summary>
    [StringLength(50, ErrorMessage = "Order number cannot exceed 50 characters.")]
    public string? OrderNumber { get; set; }
}