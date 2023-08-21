namespace VirtualStore.Identity.Domain.Responses;

public class ApiResponse
{
    public string Username { get; set; }

    public bool Result { get; set; }

    public string Message { get; set; }

    public string Role { get; set; }

    public string Token { get; set; }
}