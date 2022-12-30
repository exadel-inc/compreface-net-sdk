using Microsoft.Extensions.Configuration;

namespace Exadel.Compreface.Configuration;

public class ComprefaceConfiguration : IComprefaceConfiguration
{
    public string BaseUrl { get; set; }
    
    public string ApiKey { get; set; }

    public ComprefaceConfiguration()
    { }
    
    public ComprefaceConfiguration(string apiKey, string baseUrl)
    {
        BaseUrl = baseUrl ?? throw new ArgumentNullException($"{nameof(baseUrl)} cannot be null!");
        ApiKey = apiKey ?? throw new ArgumentNullException($"{nameof(apiKey)} cannot be null!");
    }

    public ComprefaceConfiguration(IConfiguration configuration, string sectionForApiKey, string sectionForBaseUrl)
    {
        BaseUrl = configuration.GetSection(sectionForBaseUrl).Value ?? throw new ArgumentNullException($"Cannot read section: {sectionForBaseUrl} from the given configuration appsettings.json file");
        ApiKey = configuration.GetSection(sectionForApiKey).Value ?? throw new ArgumentNullException($"Cannot read section: {sectionForApiKey} from the given configuration appsettings.json file");
    }
}