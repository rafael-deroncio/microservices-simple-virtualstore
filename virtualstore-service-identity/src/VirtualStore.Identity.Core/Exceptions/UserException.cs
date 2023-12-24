using System.Net;
using VirtualStore.Identity.Core.Configurations.Enums;

namespace VirtualStore.Identity.Core.Exceptions;

public class UserException : Exception
{
    public ExceptionResponseType ResponseType { get; set; }
    public HttpStatusCode StatusCode { get; set; }


    public UserException(string message, ExceptionResponseType responseType, HttpStatusCode statusCode) : base(message)
    {
        ResponseType = responseType;
        StatusCode = statusCode;
    }

    public UserException(string message, ExceptionResponseType responseType, Exception innerException, HttpStatusCode statusCode) : base(message, innerException)
    {
        ResponseType = responseType;
        StatusCode = statusCode;
    }

    public UserException(string message, Exception innerException) : base(message, innerException)
    {

    }
}