using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VirtualStore.Cart.Domain.Requests
{
    /// <summary>
    /// Represents a request for a shopping cart.
    /// </summary>
    public class CartRequest
    {
        /// <summary>
        /// Gets or sets the header information of the cart.
        /// </summary>
        [Required(ErrorMessage = "Cart header information is required.")]
        public CartHeaderRequest Header { get; set; }

        /// <summary>
        /// Gets or sets the items in the cart.
        /// </summary>
        [Required(ErrorMessage = "Cart items are required.")]
        [MinLength(1, ErrorMessage = "At least one item should be in the cart.")]
        public IEnumerable<ItemRequest> Items { get; set; } = new List<ItemRequest>();
    }
}
