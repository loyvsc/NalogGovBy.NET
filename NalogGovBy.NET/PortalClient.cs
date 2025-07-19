using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Text.Json;
using NalogGovBy.NET.DTO.Portal;
using NalogGovBy.NET.Exceptions;
using NalogGovBy.NET.Extensions;
using NalogGovBy.NET.Interfaces;

namespace NalogGovBy.NET;

public class PortalClient : IPortalClient
{
    public static PortalClient Instance = new PortalClient();

    public virtual HttpClient HttpClient { get; private protected set; }
    
    private protected string BaseUrl = "https://portal.nalog.gov.by:8443";

    public PortalClient()
    {
        HttpClient = new HttpClient
        {
            BaseAddress = new Uri(BaseUrl)
        };
        HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
    
    public virtual DocumentResponse ImportDocument(DocumentRequest request)
    {
        return ImportDocumentAsync(request).ConfigureAwait(false).GetAwaiter().GetResult();
    }

    public virtual async Task<DocumentResponse> ImportDocumentAsync(DocumentRequest request)
    {
        ThrowIfValidationFained(request);
        
        HttpResponseMessage response;
        try
        {
            response = await HttpClient.GetAsync("/document/import");
        }
        catch (Exception ex)
        {
            throw new NalogGovByException("Exception occured when executing the request", ex);
        }
        
        var responseContent = await response.Content.ReadAsStringAsync();
        
        var result = JsonSerializer.Deserialize<DocumentResponse>(responseContent);
        ThrowIfFailed(result);
        return result;
    }

    public virtual DocumentResponse OfftakeDocument(DocumentRequest request)
    {
        return OfftakeDocumentAsync(request).ConfigureAwait(false).GetAwaiter().GetResult();
    }

    public virtual async Task<DocumentResponse> OfftakeDocumentAsync(DocumentRequest request)
    {
        ThrowIfValidationFained(request);
        
        HttpResponseMessage response;
        try
        {
            response = await HttpClient.GetAsync("/document/offtake");
        }
        catch (Exception ex)
        {
            throw new NalogGovByException("Exception occured when executing the request", ex);
        }
        
        var responseContent = await response.Content.ReadAsStringAsync();
        
        var result = JsonSerializer.Deserialize<DocumentResponse>(responseContent);
        ThrowIfFailed(result);
        return result;
    }

    public virtual DocumentResponse ProduceDocument(DocumentRequest request)
    {
        return ProduceDocumentAsync(request).ConfigureAwait(false).GetAwaiter().GetResult();
    }

    public virtual async Task<DocumentResponse> ProduceDocumentAsync(DocumentRequest request)
    {
        ThrowIfValidationFained(request);
        
        HttpResponseMessage response;
        try
        {
            response = await HttpClient.GetAsync("/document/produce");
        }
        catch (Exception ex)
        {
            throw new NalogGovByException("Exception occured when executing the request", ex);
        }
        
        var responseContent = await response.Content.ReadAsStringAsync();
        
        var result = JsonSerializer.Deserialize<DocumentResponse>(responseContent);
        ThrowIfFailed(result);
        return result;
    }

    public virtual DocumentResponse StocktakeDocument(DocumentRequest request)
    {
        return StocktakeDocumentAsync(request).ConfigureAwait(false).GetAwaiter().GetResult();
    }

    public virtual async Task<DocumentResponse> StocktakeDocumentAsync(DocumentRequest request)
    {
        ThrowIfValidationFained(request);
        
        HttpResponseMessage response;
        try
        {
            response = await HttpClient.GetAsync("/document/stocktake");
        }
        catch (Exception ex)
        {
            throw new NalogGovByException("Exception occured when executing the request", ex);
        }
        
        var responseContent = await response.Content.ReadAsStringAsync();
        
        var result = JsonSerializer.Deserialize<DocumentResponse>(responseContent);
        ThrowIfFailed(result);
        return result;
    }

    [DoesNotReturn]
    protected virtual void ThrowIfValidationFained(DocumentRequest request)
    {
        if (request == null)
        {
            throw new NalogGovByArgumentException("Request cannot be null");
        }
        
        if (request.Items?.Count() > 1000)
        {
            throw new NalogGovByArgumentException("Items count cannot be greater than 1000 per one request");
        }
    }

    [DoesNotReturn]
    protected virtual void ThrowIfFailed(DocumentResponse? result)
    {
        if (result?.StatusCode.IsSuccessful() == false)
        {
            var errorMessage = result.StatusCode switch
            {
                StatusCode.NotAccepted => "Was not accepted into the system",
                StatusCode.ValidationFailed => "Validation failed",
                StatusCode.TnvedCodeNotFoundInTrackedGoods => "In the commodity item {}, the HS code {} was not found in the directory of traceable goods",
                StatusCode.RequiredFieldsMissing => "In the product item, the ТНВЭД code was not found in the directory of traceable goods.",
                StatusCode.InvalidTnvedCodeFormat => "The specified ТНВЭД code has an incorrect format",
                StatusCode.InvalidCorrectionDateTime => "The date and time when the adjustment was created have an invalid value.",
                StatusCode.InconsistentCorrectionDate => "Inconsistent correction date value",
                StatusCode.NoDataForCorrection => "There is no data available for correction",
                StatusCode.InconsistentFieldValues => "The correction document contains inconsistent values for the heading with the original document",
                StatusCode.UnsupportedUnitOfMeasure => "The unit of measurement is not supported for the product code",
                StatusCode.ExtraLineItemsPresent => "The document contains the following product items that were not included in the original document: {0}",
                StatusCode.MissingLineItems => "The following product items are missing from the document compared to the original document: {0}",
                StatusCode.OriginalDocMultipleGoods => "The original document contains several products in the following product lines: {0}",
                StatusCode.DocMultipleGoods => "The document contains several products in the following product lines: {0}",
                StatusCode.CorrectionDocAlreadyRegistered => "The correction document has already been registered",
                StatusCode.DocAlreadyRegistered => "The document has already been registered",
                StatusCode.CorrectionTypeMismatch => "The type of the correction document does not match the type of the document being corrected",
                StatusCode.CorrectionDataMismatch => "The data of the correction document does not match the data of the corrected document",
                StatusCode.InvalidSignature => "The signature({0}) does not match the document",
                StatusCode.InconsistentDocDates => "The document contains inconsistent document date values: {0} and {1}",
                StatusCode.InconsistentDocNumbers => "The document contains inconsistent document number values: {0} and {1}",
                StatusCode.DecodingError => "Decoding error: {0}",
                StatusCode.InvalidInventoryAct => "The inventory report document does not match the form",
                StatusCode.LineItemNumberMissing => "One of the product items is missing the required lineItemNumber field.",
                StatusCode.InvalidSalesDoc => "The implementation document does not match the form",
                StatusCode.InvalidImportDoc => "The import document does not match the form",
                StatusCode.InvalidProductionDoc => "The production document does not match the form",
                StatusCode.InventoryLogicError => "Error in the format-logical control of inventory implementation:{}",
                _ => "Unknown error occurred"
            };
            throw new NalogGovByPortalException(result.StatusCode, result, errorMessage);
        }
    }
}