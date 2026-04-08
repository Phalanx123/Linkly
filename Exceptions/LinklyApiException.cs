using System.Net;

namespace Linkly.Exceptions;

public class LinklyApiException : Exception
{
    public HttpStatusCode StatusCode { get; }

    public LinklyApiException(string message, HttpStatusCode statusCode)
        : base(message)
    {
        StatusCode = statusCode;
    }

    public LinklyApiException(string message, HttpStatusCode statusCode, Exception innerException)
        : base(message, innerException)
    {
        StatusCode = statusCode;
    }
}
