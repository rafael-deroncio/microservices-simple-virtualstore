using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VirtualStore.Identity.Domain.Responses;

namespace VirtualStore.Identity.Domain.Requests;

public class SignOutRequest
{
    [JsonIgnore]
    public string RequestId { get => Guid.NewGuid().ToString(); }

    [Required(ErrorMessage = "The user field is required")]
    public string Username { get; set; }

    [Required(ErrorMessage = "The password field is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required(ErrorMessage = "The password field is required")]
    public string RefreshToken { get; set; }
}
