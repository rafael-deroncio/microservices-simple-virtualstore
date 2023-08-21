using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VirtualStore.Identity.Domain.Requests;

public class UserRequest
{
    [Required(ErrorMessage = "The {0} field is required.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "The {0} field is required.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "The {0} field is required.")]
    public DateTime DateOfBirth { get; set; }

    [Required(ErrorMessage = "The {0} field is required.")]
    public string CPF { get; set; }

    [Required(ErrorMessage = "The {0} field is required.")]
    public string Gender { get; set; }

    [Required(ErrorMessage = "The {0} field is required")]
    [DataType(DataType.EmailAddress)]
    public string Username { get; set; }

    [Required(ErrorMessage = "The {0} field is required.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required(ErrorMessage = "The Confirm Password field is required.")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "The Password and Confirm Password fields must match.")]
    public string ConfirmPassword { get; set; }

    [NotMapped]
    public int Id { get; set; }

    [NotMapped]
    public string Role { get; set; }

    [NotMapped]
    public int Age { get => (int)Math.Floor((DateTime.Now - DateOfBirth).TotalDays / 365.25); }

    [NotMapped]
    public string FullName { get => $"{FirstName.Trim()} {LastName.Trim()}"; }
}