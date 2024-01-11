namespace VirtualStore.Discount.Domain.Responses;

public class CouponResponse
{
    public string Code { get; set; }
    public decimal DiscountPercent { get; set; }
    public DateTime ExpiresDate { get; set; }
    public bool IsActive { get; set; }
}
