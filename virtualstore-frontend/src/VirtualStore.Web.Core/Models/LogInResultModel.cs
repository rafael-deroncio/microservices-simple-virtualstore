namespace VirtualStore.Web.Core.Models;

public class LogInResultModel
{
    public string Username { get; set; }

    public bool Result { get; set; }

    public string Message { get; set; }

    public string Token { get; set; }
}