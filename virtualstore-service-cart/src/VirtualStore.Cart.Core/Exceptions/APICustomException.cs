using Microsoft.AspNetCore.Http;
using System.Net;
using VirtualStore.Cart.Core.Configurations.Enums;

namespace VirtualStore.Cart.Core.Exceptions;

public class APICustomException : Exception
{
    public ExceptionType ResponseType { get; set; }
    public HttpStatusCode StatusCode { get; set; }

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

    public APICustomException(string message) : base(message)
    {
        ResponseType = ExceptionType.Error;
        StatusCode = HttpStatusCode.UnprocessableEntity;
    }
}