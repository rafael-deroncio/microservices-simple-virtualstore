namespace VirtualStore.Discount.Domain.Responses;

public class CouponDetailsResponse
{
    public string Code { get; set; }
    public decimal DiscountPercent { get; set; }
    public DateTime ExpiresDate { get; set; }
    public List<string> Categires { get; set; }
    public int TotalUses { get; set; }
    public bool IsActive { get; set; }
}