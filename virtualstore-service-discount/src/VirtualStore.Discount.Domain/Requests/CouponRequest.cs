namespace VirtualStore.Discount.Domain.Requests;

using System;
using System.ComponentModel.DataAnnotations;

public class CouponRequest
{
    private string _code;

    /// <summary>
    /// Gets or sets the code of the coupon.
    /// </summary>
    [Required(ErrorMessage = "Coupon code is required.")]
    [StringLength(255, ErrorMessage = "Coupon code must not exceed 255 characters.")]
    public string Code
    {
        get => _code?.ToUpper()?.Trim();
        set => _code = value;
    }

    /// <summary>
    /// Gets or sets the discount percentage of the coupon.
    /// </summary>
    [Required(ErrorMessage = "Discount percentage is required.")]
    [Range(1, 100, ErrorMessage = "Discount percentage must be between 1 and 100.")]
    public decimal DiscountPercent { get; set; }

    /// <summary>
    /// Gets or sets the expiration date of the coupon.
    /// </summary>
    [Required(ErrorMessage = "Expiration date is required.")]
    [DataType(DataType.DateTime, ErrorMessage = "Invalid date format.")]
    [CustomValidation(typeof(CouponRequest), "ValidateExpiresDate")]
    public DateTime ExpiresDate { get; set; }

    /// <summary>
    /// Gets or sets the valids categories of the use coupon.
    /// </summary>
    public List<CategoryRequest> Categories { get; set; }

    /// <summary>
    /// Custom validation method for ExpiresDate.
    /// </summary>
    public static ValidationResult ValidateExpiresDate(DateTime expiresDate, ValidationContext context)
    {
        if (expiresDate < DateTime.Now)
            return new ValidationResult("Expiration date must be greater than or equal to the current date.");

        return ValidationResult.Success;
    }
}
