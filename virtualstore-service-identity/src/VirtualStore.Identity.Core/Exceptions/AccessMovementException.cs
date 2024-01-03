using System.Net;
using VirtualStore.Identity.Core.Configurations.Enums;

namespace VirtualStore.Identity.Core.Exceptions;

public class AccessMovementException : APICustomException
{
    public AccessMovementException(string message) : base(message)
    {

    }

    public AccessMovementException(string message, ExceptionType responseType = ExceptionType.Error, HttpStatusCode statusCode = HttpStatusCode.UnprocessableEntity) : base(message)
    {
        ResponseType = responseType;
        StatusCode = statusCode;
    }

    public AccessMovementException(string message, Exception innerException, ExceptionType responseType = ExceptionType.Error, HttpStatusCode statusCode = HttpStatusCode.UnprocessableEntity) : base(message, innerException)
    {
        ResponseType = responseType;
        StatusCode = statusCode;
    }

    public AccessMovementException(string message, Exception innerException) : base(message, innerException)
    {
        ResponseType = ExceptionType.Error;
        StatusCode = HttpStatusCode.UnprocessableEntity;
    }
}