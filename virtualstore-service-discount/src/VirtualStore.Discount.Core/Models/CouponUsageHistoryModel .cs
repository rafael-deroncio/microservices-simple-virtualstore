using VirtualStore.Discount.Core.Configurations.DTOs;

namespace VirtualStore.Discount.Core.Models;

public class CouponUsageHistoryModel : EntityConventionsDTO
{
    public int CouponUsageHistoryID { get; set; }
    public int CouponID { get; set; }
    public int CartID { get; set; }
    public int OrderId { get; set; }
    public decimal ValueOfProducts { get; set; }
    public decimal DiscountAmount { get; set; }

    public List<UserModel> Users { get; set; }
}