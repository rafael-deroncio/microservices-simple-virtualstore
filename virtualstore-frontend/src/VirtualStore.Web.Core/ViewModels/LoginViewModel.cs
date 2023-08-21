using System.ComponentModel.DataAnnotations;

namespace VirtualStore.Web.Core.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "The user field is required")]
    [DataType(DataType.EmailAddress)]
    public string Username { get; set; }

    [Required(ErrorMessage = "The password field is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public bool Remember { get; set; }

    public string ReturnUrl { get; set; }
}