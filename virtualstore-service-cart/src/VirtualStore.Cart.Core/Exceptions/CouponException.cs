using System.Net;
using VirtualStore.Cart.Core.Configurations.Enums;

namespace VirtualStore.Cart.Core.Exceptions;

public class CouponException : APICustomException
{

    public CouponException(string message, ExceptionType responseType = ExceptionType.Error, HttpStatusCode statusCode = HttpStatusCode.UnprocessableEntity) : base(message)
    {
        ResponseType = responseType;
        StatusCode = statusCode;
    }

    public CouponException(string message, Exception innerException, ExceptionType responseType = ExceptionType.Error, HttpStatusCode statusCode = HttpStatusCode.UnprocessableEntity) : base(message, innerException)
    {
        ResponseType = responseType;
        StatusCode = statusCode;
    }

    public CouponException(string message, Exception innerException) : base(message, innerException)
    {
        ResponseType = ExceptionType.Error;
        StatusCode = HttpStatusCode.UnprocessableEntity;
    }

    public CouponException(string message) : base(message)
    {
        ResponseType = ExceptionType.Error;
        StatusCode = HttpStatusCode.UnprocessableEntity;
    }
}
