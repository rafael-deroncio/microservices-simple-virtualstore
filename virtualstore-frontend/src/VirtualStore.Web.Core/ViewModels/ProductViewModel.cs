using System.ComponentModel.DataAnnotations;

namespace VirtualStore.Web.Core.ViewModels;

public class ProductViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The Name field is required.")]
    [StringLength(100, ErrorMessage = "The Name field must have a maximum of 100 characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "The Description field is required.")]
    [StringLength(500, ErrorMessage = "The Description field must have a maximum of 500 characters.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "The Brand field is required.")]
    [StringLength(100, ErrorMessage = "The Brand field must have a maximum of 100 characters.")]
    public string Brand { get; set; }

    [Required(ErrorMessage = "The Price field is required.")]
    [Range(0.01, 999.99, ErrorMessage = "The Price must be between 0.01 and 999.99.")]
    public decimal? Price { get; set; }

    [Required(ErrorMessage = "The Stock field is required.")]
    [Range(1, 999, ErrorMessage = "The Stock must be between 1 and 999.")]
    public int? Stock { get; set; }

    public bool Active { get; set; }

    [Display(Name = "Category")]
    public string CategoryName { get; set; }

    [Required(ErrorMessage = "The Category ID is required.")]
    [Display(Name = "Category")]
    public int CategoryId { get; set; }
}