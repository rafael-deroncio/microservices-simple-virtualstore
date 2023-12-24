using System.ComponentModel.DataAnnotations;

namespace VirtualStore.Identity.Domain.Requests;

public class TelephoneRequest
{
    [Required(ErrorMessage = "The {0} field is required.")]
    [StringLength(20, ErrorMessage = "The {0} must be at most {1} characters long.")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "The {0} field is required.")]
    [RegularExpression(@"^(Mobile|Home)$", ErrorMessage = "Invalid {0} value. Use 'Mobile' or 'Home'.")]
    public string PhoneType { get; set; }
}
