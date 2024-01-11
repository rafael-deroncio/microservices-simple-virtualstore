using VirtualStore.Discount.Core.Configurations.DTOs;

namespace VirtualStore.Discount.Core.Models;

public class CouponModel : EntityConventionsDTO
{
    public int CouponId { get; set; }
    public string Code { get; set; }
    public decimal DiscountPercent { get; set; }
    public DateTime ExpiresDate { get; set; }

    public List<CategoryModel> Categories { get; set; }

    public CouponUsageHistoryModel Usagehistory { get; set; }
}