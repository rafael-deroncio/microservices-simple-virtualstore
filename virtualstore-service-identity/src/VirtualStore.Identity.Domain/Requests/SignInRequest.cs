using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VirtualStore.Identity.Domain.Requests;

public class SignInRequest : UserRequest
{
    [JsonIgnore]
    public string RequestId => Guid.NewGuid().ToString();
}