namespace NalogGovBy.NET.DTO.Portal;

public enum StatusCode
{
    Unknown,
    Accepted = 6,
    NotAccepted = 8,
    ValidationFailed = 9,
    
    TnvedCodeNotFoundInTrackedGoods = 90242,
    RequiredFieldsMissing = 90245,
    InvalidTnvedCodeFormat = 90270,
    InvalidCorrectionDateTime = 90267,
    InconsistentCorrectionDate = 90266,
    NoDataForCorrection = 90300,
    InconsistentFieldValues = 90265,
    UnsupportedUnitOfMeasure = 90259,
    ExtraLineItemsPresent = 90257,
    MissingLineItems = 90256,
    OriginalDocMultipleGoods = 90255,
    DocMultipleGoods = 90254,
    CorrectionDocAlreadyRegistered = 90263,
    DocAlreadyRegistered = 90253,
    CorrectionTypeMismatch = 90262,
    CorrectionDataMismatch = 90261,
    InvalidSignature = 90295,
    InconsistentDocDates = 90252,
    InconsistentDocNumbers = 90251,
    DecodingError = 90850,
    InvalidInventoryAct = 90298,
    LineItemNumberMissing = 90240,
    InvalidSalesDoc = 90299,
    InvalidImportDoc = 90297,
    InvalidProductionDoc = 90296,
    InventoryLogicError = 70900
}