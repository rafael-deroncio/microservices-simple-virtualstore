
using YamlDotNet.Core.Tokens;

namespace VirtualStore.Discount.Core.Arguments;

public class CouponUsageArgument
{
    public int CouponId { get; set; }

    public int CartId { get; set; }

    public int OrderId { get; set; }

    public int UserId { get; set; }

    public decimal TotalValueOfProducts { get; set; }
    
    public decimal DiscountAmount { get; set; }
    
    public string Username { get; set; }
}
