using Microsoft.AspNetCore.Http;
using System.Net;
using VirtualStore.Catalog.Core.Configurations.Enums;

namespace VirtualStore.Catalog.Core.Exceptions;

public class ProductException : Exception
{
    public ExceptionType ResponseType { get; set; }
    public HttpStatusCode StatusCode { get; set; }


    public ProductException(string message, ExceptionType responseType = ExceptionType.Error, HttpStatusCode statusCode = HttpStatusCode.UnprocessableEntity) : base(message)
    {
        ResponseType = responseType;
        StatusCode = statusCode;
    }

    public ProductException(string message, Exception innerException, ExceptionType responseType = ExceptionType.Error, HttpStatusCode statusCode = HttpStatusCode.UnprocessableEntity) : base(message, innerException)
    {
        ResponseType = responseType;
        StatusCode = statusCode;
    }

    public ProductException(string message, Exception innerException) : base(message, innerException)
    {
        ResponseType = ExceptionType.Error;
        StatusCode = HttpStatusCode.UnprocessableEntity;
    }
}