using System.Text.Json.Serialization;

namespace NalogGovBy.NET.DTO.UnpReader;

internal class DataRow
{
    [JsonPropertyName("row")] public CompanyInfo Data { get; set; }
}