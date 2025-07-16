using NalogGovBy.NET;
using NalogGovBy.NET.DTO.UnpReader;
using NalogGovBy.NET.Exceptions;

namespace NalogGovBy.Tests;

public class UnpReaderTests
{
    private readonly UnpReader _unpReader;
    
    public UnpReaderTests()
    {
        _unpReader = new UnpReader();
    }
    
    [Fact]
    public void GetCompanyInfo_With_Incorrect_Unp_Throws_Argument_Exception()
    {
        const string incorrectUnp = "123";

        Assert.ThrowsAsync<NalogGovByException>(() => _unpReader.GetCompanyInfoByUnp(incorrectUnp));
    }
    
    [Fact]
    public async Task GetCompanyInfo_With_Correct_Unp_Returns_Company_Info()
    {
        const string belarusbankUnp = "100325912";
        var expectedResult = new CompanyInfo
        {
            ShortName = "ОАО \"Акционерный Сберегательный банк \"Беларусбанк\" (ОАО \"АСБ Беларусбанк\")",
            FullName = "Открытое акционерное общество \"Сберегательный банк \"Беларусбанк\"",
            Address = "Беларусь, г. Минск, ПР. ДЗЕРЖИНСКОГО, дом 18",
            MNSNumber = "104",
            MNSName = "Инспекция МНС по Московскому району г.Минска",
            State = "Действующий",
            RegistrationDate = new DateTime(1994,4,13),
            UNPCode = "100325912"
        };

        var result = await _unpReader.GetCompanyInfoByUnp(belarusbankUnp);

        Assert.Equivalent(expectedResult, result);
    }
}