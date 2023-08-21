namespace VirtualStore.Identity.Domain.Responses;

public class SignInResponse
{
    public string Username { get; set; }

    public bool Result { get; set; }

    public string Message { get; set; }

    public string Role { get; set; }

    public string Token { get; set; }
}