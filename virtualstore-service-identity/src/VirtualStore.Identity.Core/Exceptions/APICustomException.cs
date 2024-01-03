using System.Net;
using VirtualStore.Identity.Core.Configurations.Enums;

namespace VirtualStore.Identity.Core.Exceptions;

public class APICustomException : Exception
{
    public ExceptionType ResponseType { get; set; }
    public HttpStatusCode StatusCode { get; set; }

    public APICustomException(string message) : base(message)
    {
    }

    public APICustomException(string message, ExceptionType responseType = ExceptionType.Error, HttpStatusCode statusCode = HttpStatusCode.UnprocessableEntity) : base(message)
    {
        ResponseType = responseType;
        StatusCode = statusCode;
    }

    public APICustomException(string message, Exception innerException, ExceptionType responseType = ExceptionType.Error, HttpStatusCode statusCode = HttpStatusCode.UnprocessableEntity) : base(message, innerException)
    {
        ResponseType = responseType;
        StatusCode = statusCode;
    }

    public APICustomException(string message, Exception innerException) : base(message, innerException)
    {
        ResponseType = ExceptionType.Error;
        StatusCode = HttpStatusCode.UnprocessableEntity;
    }
}