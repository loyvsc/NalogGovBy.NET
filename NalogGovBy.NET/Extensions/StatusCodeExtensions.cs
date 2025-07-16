using NalogGovBy.NET.DTO.Portal;

namespace NalogGovBy.NET.Extensions;

public static class StatusCodeExtensions
{
    public static bool IsSuccessful(this StatusCode statusCode)
    {
        return statusCode == StatusCode.Accepted;
    }
}