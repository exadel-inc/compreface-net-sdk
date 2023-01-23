using Exadel.Compreface.Clients.Config;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.Helpers;
using Exadel.Compreface.Services;
using Flurl.Http;
using Microsoft.Extensions.Configuration;

namespace Exadel.Compreface.Clients
{
    public class FaceVerificationClient
    {
        public FaceVerificationService FaceVerificationService { get; set; }

        public FaceVerificationClient(string apiKey, string domain, string port) : this(new ComprefaceConfiguration(apiKey, domain, port))
        { }

        public FaceVerificationClient(IConfiguration configuration, string sectionForApiKey, string sectionForDomain, string sectionForPort) : this(new ComprefaceConfiguration(configuration, sectionForApiKey, sectionForDomain, sectionForPort))
        { }

        public FaceVerificationClient(ComprefaceConfiguration configuration)
        {
            var apiClient = new ApiClient(configuration.ApiKey);

            FaceVerificationService = new FaceVerificationService(apiClient: apiClient, configuration: configuration);

            // ConfigInitializer.InitializeApiKeyInRequestHeader(configuration.ApiKey);
            ConfigInitializer.InitializeSnakeCaseJsonConfigs();
        }
    }
}
