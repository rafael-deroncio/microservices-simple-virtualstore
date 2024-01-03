using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VirtualStore.Identity.Domain.Requests;

public class LogOutRequest
{
    [JsonIgnore]
    public string RequestId => Guid.NewGuid().ToString();

    [Required(ErrorMessage = "The user field is required")]
    public string Username { get; set; }

    [Required(ErrorMessage = "The refresh token field is required")]
    public string RefreshToken { get; set; }
}
