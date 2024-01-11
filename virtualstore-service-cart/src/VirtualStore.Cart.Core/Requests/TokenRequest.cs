namespace VirtualStore.Cart.Core.Requests;

public class TokenRequest
{
    public string Username { get; set; }

    public string Role { get; set; }

    public IEnumerable<string> Claims { get; set; }

}