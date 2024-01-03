namespace VirtualStore.Identity.Core.Arguments;

public class TokenArgument
{
    public string TokenValue { get; set; }
    public string TokenType { get; set; }
    public string Message { get; set; }
    public DateTime Expires { get; set; }
}