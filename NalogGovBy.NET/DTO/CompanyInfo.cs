using System.Text.Json.Serialization;

namespace NalogGovBy.NET.DTO;

public class CompanyInfo
{
    [JsonPropertyName("vunp")] public string UNPCode { get; set; }
    [JsonPropertyName("vnaimp")] public string? FullName { get; set; }
    [JsonPropertyName("vnaimk")] public string? ShortName { get; set; }
    [JsonPropertyName("dreg")] public DateTime? RegistrationDate { get; set; }
    [JsonPropertyName("nmns")] public string? MNSNumber { get; set; }
    [JsonPropertyName("vmns")] public string? MNSName { get; set; }
    [JsonPropertyName("vpadres")] public string? Address { get; set; }
    [JsonPropertyName("vkods")] public string? State { get; set; }
    [JsonPropertyName("dlikv")] public DateTime? StateChangeDate { get; set; }
    [JsonPropertyName("vlikv")] public string? StateChangeReason { get; set; }
}