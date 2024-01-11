using System.ComponentModel.DataAnnotations;

namespace VirtualStore.Cart.Domain.Requests;

/// <summary>
/// Represents a request for an item in a shopping cart.
/// </summary>
public class ItemRequest
{
    /// <summary>
    /// Gets or sets the quantity of the item.
    /// </summary>
    [Required(ErrorMessage = "Quantity is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than or equal to 1.")]
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the product associated with the item.
    /// </summary>
    [Required(ErrorMessage = "Product information is required.")]
    public ProductRequest Product { get; set; }
}