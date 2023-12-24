using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VirtualStore.Identity.Domain.Requests;

public class UnsubscribeRequest
{
    [JsonIgnore]
    public string RequestId => Guid.NewGuid().ToString();

    [Required(ErrorMessage = "The user field is required")]
    [DataType(DataType.EmailAddress)]
    public string Username { get; set; }

    [Required(ErrorMessage = "The confirmation code field is required")]
    public string ConfirmationCode { get; set; }
}
