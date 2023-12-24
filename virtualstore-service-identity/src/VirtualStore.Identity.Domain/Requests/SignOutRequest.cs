using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VirtualStore.Identity.Domain.Responses;

namespace VirtualStore.Identity.Domain.Requests;

public class SignOutRequest
{
    [JsonIgnore]
    public string RequestId => Guid.NewGuid().ToString();

    [Required(ErrorMessage = "The user field is required")]
    [DataType(DataType.EmailAddress)]
    public string Username { get; set; }
}
