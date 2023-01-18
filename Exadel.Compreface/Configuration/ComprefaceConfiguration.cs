using Microsoft.Extensions.Configuration;

namespace Exadel.Compreface.Configuration;

public class ComprefaceConfiguration : IComprefaceConfiguration
{
    public string Domain { get; set; }

    public string Port { get; set; }

    public string ApiKey { get; set; }

    public ComprefaceConfiguration()
    { }
    
    public ComprefaceConfiguration(string apiKey, string domain, string port)
    {
        Domain = domain ?? throw new ArgumentNullException($"{nameof(domain)} cannot be null!");
        Port = port ?? throw new ArgumentNullException($"{nameof(port)} cannot be null!");
        ApiKey = apiKey ?? throw new ArgumentNullException($"{nameof(apiKey)} cannot be null!");
    }

    public ComprefaceConfiguration(IConfiguration configuration, string sectionForApiKey, string sectionForDomain, string sectionForPort)
    {
        Domain = configuration.GetSection(sectionForDomain).Value ?? throw new ArgumentNullException($"Cannot read section: {sectionForDomain} from the given configuration appsettings.json file");
        Port = configuration.GetSection(sectionForPort).Value ?? throw new ArgumentNullException($"Cannot read section: {sectionForPort} from the given configuration appsettings.json file");
        ApiKey = configuration.GetSection(sectionForApiKey).Value ?? throw new ArgumentNullException($"Cannot read section: {sectionForApiKey} from the given configuration appsettings.json file");
    }
}