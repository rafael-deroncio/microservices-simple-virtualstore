using System.ComponentModel.DataAnnotations;

namespace VirtualStore.Cart.Domain.Requests
{
    /// <summary>
    /// Represents a request for cart header information.
    /// </summary>
    public class CartHeaderRequest
    {
        /// <summary>
        /// Gets or sets the username associated with the cart.
        /// </summary>
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, ErrorMessage = "Username length must be between 1 and 50 characters.")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the coupon code applied to the cart.
        /// </summary>
        [StringLength(20, ErrorMessage = "Coupon code length must be between 1 and 20 characters.")]
        public string CouponCode { get; set; }
    }
}
