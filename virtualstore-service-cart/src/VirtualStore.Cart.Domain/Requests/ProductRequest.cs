using System.ComponentModel.DataAnnotations;

namespace VirtualStore.Cart.Domain.Requests;

/// <summary>
/// Represents a request for product information.
/// </summary>
public class ProductRequest
{
    /// <summary>
    /// Gets or sets the product ID.
    /// </summary>
    [Required(ErrorMessage = "Product ID is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Product ID must be greater than or equal to 1.")]
    public int ProductId { get; set; }

    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    [Required(ErrorMessage = "Product name is required.")]
    [StringLength(100, ErrorMessage = "Product name length must be between 1 and 100 characters.")]
    public string Name { get; set; }
}