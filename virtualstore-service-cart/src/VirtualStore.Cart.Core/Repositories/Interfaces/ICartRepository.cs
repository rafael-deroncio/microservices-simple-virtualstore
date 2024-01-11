using VirtualStore.Cart.Core.Arguments;
using VirtualStore.Cart.Core.Models;

namespace VirtualStore.Cart.Core.Repositories.Interfaces;

/// <summary>
/// Interface for interacting with the shopping cart data in the repository.
/// </summary>
public interface ICartRepository
{
    /// <summary>
    /// Retrieves the shopping cart for a given user.
    /// </summary>
    /// <param name="username">The username associated with the shopping cart.</param>
    /// <returns>Returns a Task representing the asynchronous operation with the resulting CartModel.</returns>
    Task<CartModel> GetCart(string username);

    /// <summary>
    /// Creates a new shopping cart based on the provided arguments.
    /// </summary>
    /// <param name="argument">The CartArgument containing the necessary information for cart creation.</param>
    /// <returns>Returns a Task representing the asynchronous operation with the resulting CartModel.</returns>
    Task<CartModel> CreateCart(CartArgument argument);

    /// <summary>
    /// Updates an existing shopping cart based on the provided arguments.
    /// </summary>
    /// <param name="argument">The CartArgument containing the necessary information for cart update.</param>
    /// <returns>Returns a Task representing the asynchronous operation with the resulting CartModel.</returns>
    Task<CartModel> UpdateCart(CartArgument argument);

    /// <summary>
    /// Deletes the shopping cart for a given user.
    /// </summary>
    /// <param name="username">The username associated with the shopping cart to be deleted.</param>
    /// <returns>Returns a Task representing the asynchronous operation. Returns true if the cart is deleted successfully; otherwise, false.</returns>
    Task<bool> DeleteCart(string username);
}

