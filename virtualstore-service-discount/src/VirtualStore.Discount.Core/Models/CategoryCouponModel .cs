using VirtualStore.Discount.Core.Configurations.DTOs;

namespace VirtualStore.Discount.Core.Models;

public class CouponCategoryModel : EntityConventionsDTO
{
    public int CouponCategoryID { get; set; }
    public int CouponID { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}