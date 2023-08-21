using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace VirtualStore.Web.Core.ViewModels;

public class UserViewModel
{
    [NotMapped]
    public int Id { get; set; }

    [Display(Name = "First Name")]
    [Required(ErrorMessage = "The {0} field is required.")]
    public string FirstName { get; set; }

    [Display(Name = "Last Name")]
    [Required(ErrorMessage = "The {0} field is required.")]
    public string LastName { get; set; }

    [NotMapped]
    public string FullName { get => $"{FirstName.Trim()} {LastName.Trim()}"; }

    [Display(Name = "Date of Birth")]
    [Required(ErrorMessage = "The {0} field is required.")]
    public DateTime DateOfBirth { get; set; }

    [NotMapped]
    public int Age { get => (int)Math.Floor((DateTime.Now - DateOfBirth).TotalDays / 365.25); }

    [Display(Name = "CPF")]
    [Required(ErrorMessage = "The {0} field is required.")]
    public string CPF { get; set; }

    [Display(Name = "Gender")]
    [Required(ErrorMessage = "The {0} field is required.")]
    public string Gender { get; set; }

    [Required(ErrorMessage = "The user field is required")]
    [DataType(DataType.EmailAddress)]
    public string Username { get; set; }

    [Required(ErrorMessage = "The password field is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [NotMapped]
    public string Role { get; set; }
}