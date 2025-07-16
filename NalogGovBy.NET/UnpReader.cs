using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.RegularExpressions;
using NalogGovBy.NET.DTO.UnpReader;
using NalogGovBy.NET.Exceptions;

namespace NalogGovBy.NET;

public partial class UnpReader : IDisposable
{
    public HttpClient HttpClient { get; set; }
    
    [GeneratedRegex("[a-zA-Zа-яА-Я]")]
    private static partial Regex CompanyUnpRegex();

    public UnpReader()
    {
        HttpClient = new HttpClient
        {
            BaseAddress = new Uri("http://grp.nalog.gov.by/api/grp-public/data")
        };
        HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    /// <summary>
    /// Returns a DTO containing information about the organization in accordance with the UNP
    /// </summary>
    /// <exception cref="NalogGovByException">An exception is thrown for errors during the request</exception>
    /// <exception cref="NalogGovByArgumentException">An exception is raised when the unp is incorrect</exception>
    public virtual async Task<CompanyInfo> GetCompanyInfoByUnp(string unp)
    {
        if (CompanyUnpRegex().IsMatch(unp))
        {
            throw new NalogGovByArgumentException("Unp can't contain letters");
        }
        
        HttpResponseMessage response;
        try
        {
            response = await HttpClient.GetAsync("?unp=" + unp);
        }
        catch (Exception ex)
        {
            throw new NalogGovByException("Exception occured when executing the request", ex);
        }
        
        string responseContent = await response.Content.ReadAsStringAsync();
        
        var result = JsonSerializer.Deserialize<DataRow>(responseContent);
        if (result == null)
        {
            var errorResponse = JsonSerializer.Deserialize<Error>(responseContent);
            if (errorResponse == null)
                throw new NalogGovByException("Unknown error occured");
            
            throw new NalogGovByException(errorResponse.StatusCode, errorResponse.Message);
        }
        
        return result.Data;
    }

    public virtual void Dispose()
    {
        HttpClient.Dispose();
    }
}