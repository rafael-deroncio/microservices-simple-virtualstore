using VirtualStore.Cart.Core.Configurations.Enums;

namespace VirtualStore.Cart.Core.Responses;

public class ExceptionResponse
{
    public ExceptionType ResponseType { get; set; }

    public string Tittle { get; set; }

    public string[] Messages { get; set; }
}