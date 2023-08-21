using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VirtualStore.Identity.Domain.Requests;

public class SignInRequest
{
    [JsonIgnore]
    public string RequestId => Guid.NewGuid().ToString();

    [Required(ErrorMessage = "The user field is required")]
    [DataType(DataType.EmailAddress)]
    public string Username { get; set; }

    [Required(ErrorMessage = "The password field is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}