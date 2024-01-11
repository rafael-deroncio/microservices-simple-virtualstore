using VirtualStore.Cart.Domain.Requests;
using VirtualStore.Cart.Domain.Responses;

namespace VirtualStore.Cart.Core.Services.Interfaces;

/// <summary>
/// Interface for managing shopping cart operations.
/// </summary>
public interface ICartService
{
    /// <summary>
    /// Retrieves the shopping cart for a given user.
    /// </summary>
    /// <param name="username">The username associated with the shopping cart.</param>
    /// <returns>Returns a Task representing the asynchronous operation with the resulting CartResponse.</returns>
    Task<CartResponse> GetCart(string username);

    /// <summary>
    /// Adds a new shopping cart for the specified user with the provided items.
    /// </summary>
    /// <param name="username">The username associated with the shopping cart.</param>
    /// <param name="request">The CartRequest containing the items to be added.</param>
    /// <returns>Returns a Task representing the asynchronous operation with the resulting CartResponse.</returns>
    Task<CartResponse> AddCart(string username, CartRequest request);

    /// <summary>
    /// Removes all items from the shopping cart for a given user.
    /// </summary>
    /// <param name="username">The username associated with the shopping cart.</param>
    /// <returns>Returns a Task representing the asynchronous operation. Returns true if the cart is cleaned successfully; otherwise, false.</returns>
    Task<bool> CleanCart(string username);

    /// <summary>
    /// Adds an item to the shopping cart for a given user.
    /// </summary>
    /// <param name="username">The username associated with the shopping cart.</param>
    /// <param name="request">The ItemRequest containing the item to be added.</param>
    /// <returns>Returns a Task representing the asynchronous operation with the resulting CartResponse.</returns>
    Task<CartResponse> AddItemCart(string username, ItemRequest request);

    /// <summary>
    /// Removes an item from the shopping cart for a given user.
    /// </summary>
    /// <param name="username">The username associated with the shopping cart.</param>
    /// <param name="request">The ItemRequest containing the item to be removed.</param>
    /// <returns>Returns a Task representing the asynchronous operation. Returns true if the item is removed successfully; otherwise, false.</returns>
    Task<bool> RemoveItemCart(string username, ItemRequest request);

    /// <summary>
    /// Applies a coupon to the shopping cart for a given user.
    /// </summary>
    /// <param name="username">The username associated with the shopping cart.</param>
    /// <param name="request">The CouponRequest containing the coupon to be applied.</param>
    /// <returns>Returns a Task representing the asynchronous operation. Returns true if the coupon is applied successfully; otherwise, false.</returns>
    Task<bool> ApplyCouponCart(string username, CouponRequest request);

    /// <summary>
    /// Removes a coupon from the shopping cart for a given user.
    /// </summary>
    /// <param name="username">The username associated with the shopping cart.</param>
    /// <param name="request">The CouponRequest containing the coupon to be removed.</param>
    /// <returns>Returns a Task representing the asynchronous operation. Returns true if the coupon is removed successfully; otherwise, false.</returns>
    Task<bool> RemoveCouponCart(string username, CouponRequest request);
}
