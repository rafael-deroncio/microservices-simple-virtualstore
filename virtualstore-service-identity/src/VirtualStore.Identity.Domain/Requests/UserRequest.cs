using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VirtualStore.Identity.Domain.Extensions;

namespace VirtualStore.Identity.Domain.Requests;

public class UserRequest
{
    [Required(ErrorMessage = "The {0} field is required.")]
    public string FirstName { get => _firstName; set => _firstName = value.Trim().ToTitleCase(); }
    private string _firstName;

    [Required(ErrorMessage = "The {0} field is required.")]
    public string LastName { get => _lastName; set => _lastName = value.Trim().ToTitleCase(); }
    private string _lastName;

    [Required(ErrorMessage = "The {0} field is required.")]
    public DateTime DateOfBirth { get; set; }

    [Required(ErrorMessage = "The {0} field is required.")]
    public string CPF { get; set; }

    [Required(ErrorMessage = "The {0} field is required.")]
    [RegularExpression(@"^(M|F|O)$", ErrorMessage = "Invalid {0} value. Use 'M', 'F' or 'O'.")]
    public string Gender { get => _gender; set => _gender = value.Trim().ToUpper(); }
    private string _gender;

    [Required(ErrorMessage = "The {0} field is required")]
    [DataType(DataType.EmailAddress)]
    public string Email { get => _email; set => _email = value.Trim().Trim().ToLower(); }
    private string _email;

    [Required(ErrorMessage = "The {0} field is required.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required(ErrorMessage = "The Confirm Password field is required.")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "The Password and Confirm Password fields must match.")]
    public string ConfirmPassword { get; set; }

    [Required(ErrorMessage = "The {0} field is required.")]
    public List<AddressRequest> Addresses { get; set; }

    [Required(ErrorMessage = "The {0} field is required.")]
    public List<TelephoneRequest> Telephones { get; set; }

    [NotMapped]
    public string Name { get => $"{FirstName.Trim().ToTitleCase()} {LastName.Trim().ToTitleCase()}"; }
    
    [NotMapped]
    public string Username { get => $"{FirstName.Trim().ToTitleCase()}{LastName.Trim().ToTitleCase()}"; }
}