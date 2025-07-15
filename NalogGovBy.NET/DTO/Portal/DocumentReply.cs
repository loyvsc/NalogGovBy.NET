using System.Text.Json.Serialization;

namespace NalogGovBy.NET.DTO.Portal;

public class DocumentReply
{
    /// <summary>
    /// Date and time of the portal's confirmation of the document's acceptance (import information)
    /// </summary>
    [JsonPropertyName("DocumentReplyDateTime")] public DateTime ReplyDateTime { get; set; }
    
    /// <summary>
    /// XML document receipt confirmation of the portal's acceptance of the document (import information)
    /// </summary>
    [JsonPropertyName("Reply")] public string OriginalDocument { get; set; }
}