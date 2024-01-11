using VirtualStore.Discount.Core.Arguments;
using VirtualStore.Discount.Core.Models;

namespace VirtualStore.Discount.Core.Repositories.Interfaces;

/// <summary>
/// Repository interface for discount-related operations.
/// </summary>
public interface IDiscountRepository
{

    /// <summary>
    /// Retrieves a coupon based on its code.
    /// </summary>
    /// <param name="couponCode">The code of the coupon to retrieve.</param>
    /// <param name="getUsers">Optional parameter indicating whether to include user information.</param>
    /// <param name="getCategories">Optional parameter indicating whether to include category information.</param>
    /// <returns>A task representing the asynchronous operation and returning a <see cref="CouponModel"/>.</returns>
    Task<CouponModel> GetCoupon(string couponCode, bool getUsers = false, bool getCategories = false);


    /// <summary>
    /// Saves a new coupon with the specified code.
    /// </summary>
    /// <param name="argument">The argument containing information for creating the new coupon.</param>
    /// <returns>A task representing the asynchronous operation and returning a <see cref="CouponModel"/>.</returns>
    Task<CouponModel> SaveCoupon(CouponArgument argument);

    /// <summary>
    /// Updates a coupon based on the provided argument.
    /// </summary>
    /// <param name="argument">The argument containing information for updating the coupon.</param>
    /// <returns>A task representing the asynchronous operation and returning a <see cref="CouponModel"/>.</returns>
    Task<CouponModel> UpdateCoupon(CouponArgument argument);

    /// <summary>
    /// Disables a coupon with the specified code.
    /// </summary>
    /// <param name="couponCode">The code of the coupon to be disabled.</param>
    /// <returns>A task representing the asynchronous operation and returning a <see cref="bool"/>.</returns>
    Task<bool> DisableCoupon(string couponCode);

    /// <summary>
    /// Adiciona um registro de uso de cupom com base nos argumentos fornecidos.
    /// </summary>
    /// <param name="argument">Os argumentos necessários para adicionar o uso do cupom.</param>
    /// <returns>Um valor booleano indicando se o uso do cupom foi adicionado com sucesso.</returns>
    Task<bool> AddUsageCoupon(CouponUsageArgument argument);

    /// <summary>
    /// Remove um registro de uso de cupom com base nos argumentos fornecidos.
    /// </summary>
    /// <param name="argument">Os argumentos necessários para remover o uso do cupom.</param>
    /// <returns>Um valor booleano indicando se o uso do cupom foi removido com sucesso.</returns>
    Task<bool> RemoveUsageCoupon(CouponUsageArgument argument);
}
