using NalogGovBy.NET.DTO.Portal;

namespace NalogGovBy.NET.Exceptions;

public class NalogGovByPortalException : Exception
{
    public StatusCode StatusCode { get; }
    public DocumentResponse Response { get; }

    public NalogGovByPortalException(StatusCode statusCode, DocumentResponse response, string message) : base(message)
    {
        StatusCode = statusCode;
        Response = response;
    }
}