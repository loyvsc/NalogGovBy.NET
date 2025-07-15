namespace NalogGovBy.NET.DTO.Portal;

public class DocumentResponse
{
    public DocumentResult Result { get; set; }
    public StatusCode StatusCode { get; set; }
    public int RecordId { get; set; }
    
    /// <summary>
    /// Confirmation of the portal's acceptance of the document (import information)
    /// </summary>
    public DocumentReply DocumentReply { get; set; }
}