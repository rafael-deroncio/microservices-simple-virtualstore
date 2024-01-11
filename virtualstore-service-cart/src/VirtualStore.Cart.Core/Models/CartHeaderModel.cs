using VirtualStore.Cart.Core.Configurations.DTOs;

namespace VirtualStore.Cart.Core.Models;

public class CartHeaderModel : EntityConventionsDTO
{
    public int CartHeaderId { get; set; }
    public UserModel User { get; set; }
    public CouponModel Coupon { get; set; }
    public decimal TotalAmount { get; set; }
}