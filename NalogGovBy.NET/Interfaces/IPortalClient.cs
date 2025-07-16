using NalogGovBy.NET.DTO.Portal;

namespace NalogGovBy.NET.Interfaces;

public interface IPortalClient
{
    public HttpClient HttpClient { get; }
    
    public DocumentResponse ImportDocument(DocumentRequest request);
    public Task<DocumentResponse> ImportDocumentAsync(DocumentRequest request);
    
    public DocumentResponse OfftakeDocument(DocumentRequest request);
    public Task<DocumentResponse> OfftakeDocumentAsync(DocumentRequest request);
    
    public DocumentResponse ProduceDocument(DocumentRequest request);
    public Task<DocumentResponse> ProduceDocumentAsync(DocumentRequest request);
    
    public DocumentResponse StocktakeDocument(DocumentRequest request);
    public Task<DocumentResponse> StocktakeDocumentAsync(DocumentRequest request);
}