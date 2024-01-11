using Refit;

namespace VirtualStore.Cart.Core.Services.Clients;

public interface IDiscountClientService
{
    [Get( "/{coupon}")]
    Task<int> GetCoupon([AliasAs("coupon")] string coupon);
}