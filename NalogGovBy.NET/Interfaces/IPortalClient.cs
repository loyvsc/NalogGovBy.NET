using NalogGovBy.NET.DTO.Portal;

namespace NalogGovBy.NET.Interfaces;

public interface IPortalClient
{
    public DocumentResponse ImportDocument(DocumentRequest request);
    public DocumentResponse OfftakeDocument(DocumentRequest request);
    public DocumentResponse ProduceDocument(DocumentRequest request);
    public DocumentResponse StocktakeDocument(DocumentRequest request);
}