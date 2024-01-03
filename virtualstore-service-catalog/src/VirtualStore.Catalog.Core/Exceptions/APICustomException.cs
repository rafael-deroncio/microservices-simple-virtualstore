using System.Net;
using VirtualStore.Catalog.Core.Configurations.Enums;

namespace VirtualStore.Catalog.Core.Exceptions;

public class APICustomException : Exception
{
    public ExceptionType ResponseType { get; set; }
    public HttpStatusCode StatusCode { get; set; }


    public APICustomException(string message, ExceptionType responseType, HttpStatusCode statusCode) : base(message)
    {
        ResponseType = responseType;
        StatusCode = statusCode;
    }

    public APICustomException(string message, ExceptionType responseType, Exception innerException, HttpStatusCode statusCode) : base(message, innerException)
    {
        ResponseType = responseType;
        StatusCode = statusCode;
    }

    public APICustomException(string message, Exception innerException) : base(message, innerException)
    {

    }
}