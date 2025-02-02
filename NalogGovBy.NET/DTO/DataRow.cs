using System.Text.Json.Serialization;

namespace NalogGovBy.NET.DTO;

internal class DataRow
{
    [JsonPropertyName("row")] public CompanyInfo Data { get; set; }
}