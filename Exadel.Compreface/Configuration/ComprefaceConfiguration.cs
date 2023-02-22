namespace Exadel.Compreface.Configuration;

public class ComprefaceConfiguration : IComprefaceConfiguration
{
    public string Domain { get; set; } 

    public string Port { get; set; } 

    public string ApiKey { get; set; }

    public ComprefaceConfiguration(string apiKey, string domain, string port)
    {
        Domain = domain ?? throw new ArgumentNullException($"{nameof(domain)} cannot be null!");
        Port = port ?? throw new ArgumentNullException($"{nameof(port)} cannot be null!");
        ApiKey = apiKey ?? throw new ArgumentNullException($"{nameof(apiKey)} cannot be null!");
    }
}