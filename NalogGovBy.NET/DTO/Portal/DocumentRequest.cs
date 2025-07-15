using System.Text.Json.Serialization;

namespace NalogGovBy.NET.DTO.Portal;

public class DocumentRequest
{
    /// <summary>
    /// XML document (import information), base64 (UTF-8)
    /// </summary>
    [JsonPropertyName("originalDocument")] public string OriginalDocument { get; set; }
    
    /// <summary>
    /// The unique message number assigned by the sender
    /// </summary>
    [JsonPropertyName("DocumentId")] public string Id { get; set; }
    
    /// <summary>
    /// Registration number of the transmitted information (import information)
    /// </summary>
    [JsonPropertyName("DocumentNumber")] public string Number { get; set; }
    
    /// <summary>
    /// The account number of the payer who submitted the information
    /// </summary>
    [JsonPropertyName("VATRegistrationNumber")] public string VATRegistrationNumber { get; set; }
    
    /// <summary>
    /// MNS Inspection Code
    /// </summary>
    [JsonPropertyName("IMNS")] public string IMNS { get; set; }
    
    /// <summary>
    /// Date of the transmitted information (information about the import)
    /// </summary>
    [JsonPropertyName("DocumentDate")] public DateTime Date { get; set; }
    
    /// <summary>
    /// Name of the transmitted information (import information)
    /// </summary>
    [JsonPropertyName("DocumentDate")] public string DocumentName { get; set; }
    
    /// <summary>
    /// Unique identifier of the source document (import information)
    /// </summary>
    [JsonPropertyName("RefRecordId")] public int RefRecordId { get; set; }
    
    /// <summary>
    /// Date when changes were made to the transmitted information
    /// </summary>
    [JsonPropertyName("CorrectionDate")] public DateTime CorrectionDate { get; set; }
    
    /// <summary>
    /// Array of product information
    /// </summary>
    [JsonPropertyName("Items")] public IEnumerable<ItemInfo> Items { get; set; }
    
    /// <summary>
    /// An electronic digital signature (hereinafter referred to as an EDS) developed for the OriginalDocument element
    /// </summary>
    [JsonPropertyName("originalDocumentSign")] public string OriginalDocumentSign { get; set; }
    
    /// <summary>
    /// Date and time of creation of the electronic document
    /// </summary>
    [JsonPropertyName("CreationDateTime")] public DateTime CreationDateTime { get; set; }
}