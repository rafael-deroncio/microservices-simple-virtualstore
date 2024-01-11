using System.ComponentModel.DataAnnotations;

namespace VirtualStore.Cart.Domain.Requests;

public class CouponRequest
{
    [Required(ErrorMessage = "Coupon code is required.")]
    [StringLength(20, ErrorMessage = "Coupon code cannot exceed 20 characters.")]
    public string CouponCode { get; set; }
}