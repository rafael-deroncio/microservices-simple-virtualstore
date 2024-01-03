using VirtualStore.Identity.Core.Configurations.Enums;

namespace VirtualStore.Identity.Core.Responses;

public class ExceptionResponse
{
    public ExceptionType ResponseType { get; set; }

    public string Tittle { get; set; }

    public string[] Messages { get; set; }
}