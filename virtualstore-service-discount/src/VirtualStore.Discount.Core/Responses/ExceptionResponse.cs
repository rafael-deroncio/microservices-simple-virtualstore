using VirtualStore.Discount.Core.Configurations.Enums;

namespace VirtualStore.Discount.Core.Responses;

public class ExceptionResponse
{
    public ExceptionType ResponseType { get; set; }

    public string Tittle { get; set; }

    public string[] Messages { get; set; }
}