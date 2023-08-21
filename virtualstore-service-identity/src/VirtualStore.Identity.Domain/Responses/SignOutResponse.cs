namespace VirtualStore.Identity.Domain.Responses;

public class SignOutResponse
{
    public string Username { get; set; }
    public bool Result { get; set; }
    public bool Message { get; set; }
}