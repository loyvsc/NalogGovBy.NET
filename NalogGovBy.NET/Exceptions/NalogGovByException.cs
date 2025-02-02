using System.Net;

namespace NalogGovBy.NET.Exceptions;

public class NalogGovByException : Exception
{
    public HttpStatusCode StatusCode { get; set; }

    public NalogGovByException(HttpStatusCode statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }
    
    public NalogGovByException(string message) : base(message){}
    
    public NalogGovByException(string message, Exception innerException) : base(message, innerException){}
}