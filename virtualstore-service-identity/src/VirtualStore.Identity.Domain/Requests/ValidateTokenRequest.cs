using System.ComponentModel.DataAnnotations;

namespace VirtualStore.Identity.Domain.Requests;

public class ValidateTokenRequest
{
    [Required(ErrorMessage = "The refresh token field is required")]
    public string RefreshToken { get; set; }
}
