using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualStore.Identity.Domain.Requests;

public class AddressRequest
{
    [Required(ErrorMessage = "The {0} field is required.")]
    [StringLength(255, ErrorMessage = "The {0} must be at most {1} characters long.")]
    public string Street { get; set; }

    [Required(ErrorMessage = "The {0} field is required.")]
    [StringLength(20, ErrorMessage = "The {0} must be at most {1} characters long.")]
    public string HouseNumber { get; set; }

    [Required(ErrorMessage = "The {0} field is required.")]
    [StringLength(100, ErrorMessage = "The {0} must be at most {1} characters long.")]
    public string City { get; set; }

    [Required(ErrorMessage = "The {0} field is required.")]
    [StringLength(50, ErrorMessage = "The {0} must be at most {1} characters long.")]
    public string State { get; set; }

    [Required(ErrorMessage = "The {0} field is required.")]
    [StringLength(100, ErrorMessage = "The {0} must be at most {1} characters long.")]
    public string Country { get; set; }

    [Required(ErrorMessage = "The {0} field is required.")]
    [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "Invalid ZIP Code format. Use XXXXX-XXX.")]
    [StringLength(9, ErrorMessage = "The {0} must be {1} characters long.", MinimumLength = 9)]
    public string ZipCode { get; set; }
}
