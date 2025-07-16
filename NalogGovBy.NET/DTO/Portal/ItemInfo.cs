using System.Text.Json.Serialization;

namespace NalogGovBy.NET.DTO.Portal;

public class ItemInfo
{
    /// <summary>
    /// Serial number of the product item
    /// </summary>
    [JsonPropertyName("lineItemNumber")] public string Number { get; set; }
    
    /// <summary>
    /// The product code in accordance with the unified Commodity nomenclature of foreign economic activity of the Eurasian Economic Union
    /// </summary>
    [JsonPropertyName("itemCustomCode")] public string Code { get; set; }
    
    [JsonPropertyName("itemAdditionalCode")] public string AdditionalCode { get; set; }
    
    /// <summary>
    /// Global Trade Item Number
    /// </summary>
    [JsonPropertyName("gtinCode")] public string GtinCode { get; set; }
    
    /// <summary>
    /// The unit of measurement of the goods to be indicated in the electronic invoices
    /// </summary>
    [JsonPropertyName("lineItemQuantitySPT")] public string MeasurementUnit { get; set; }
    
    /// <summary>
    /// The quantity of goods in units of measurement to be indicated in electronic invoices
    /// </summary>
    [JsonPropertyName("quantityDespatchedSPT")] public string ItemQuantity { get; set; }
    
    /// <summary>
    /// Registration number of the transmitted information
    /// </summary>
    [JsonPropertyName("documentNumber")] public string DocumentNumber { get; set; }
}