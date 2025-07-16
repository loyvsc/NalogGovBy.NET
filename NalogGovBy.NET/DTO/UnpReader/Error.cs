using System.Net;
using System.Text.Json.Serialization;

namespace NalogGovBy.NET.DTO.UnpReader;

internal class Error
{
    [JsonPropertyName("timestamp")] public DateTime Timestamp { get; set; }
    [JsonPropertyName("status")] public HttpStatusCode StatusCode { get; set; }
    [JsonPropertyName("error")] public string Description { get; set; } = string.Empty;
    [JsonPropertyName("message")] public string Message { get; set; } = string.Empty;
}