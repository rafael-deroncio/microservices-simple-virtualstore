using System.Text.Json.Serialization;

namespace VirtualStore.Identity.Domain.Requests;

public class PaginationRequest
{
    [JsonPropertyName("page")]
    public int Page { get; set; }

    [JsonPropertyName("size")]
    public int Size { get; set; }
}