namespace VirtualStore.Discount.Core.Arguments;

public class CouponArgument
{
    public string Code { get; set; }
    public decimal DiscountPercent { get; set; }
    public DateTime ExpiresDate { get; set; }
    public List<CategoryCouponArgument> Categories { get; set; }
}
