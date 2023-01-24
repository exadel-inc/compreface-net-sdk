using Exadel.Compreface.Clients.Config;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.Helpers;
using Exadel.Compreface.Services;
using Microsoft.Extensions.Configuration;

namespace Exadel.Compreface.Clients
{
    public class FaceDetectionClient
    {
        public FaceDetectionService FaceDetectionService { get; private set; }

        public FaceDetectionClient(string apiKey, string domain, string port) : this(new ComprefaceConfiguration(apiKey, domain, port))
        { }

        public FaceDetectionClient(IConfiguration configuration, string sectionForApiKey, string sectionForDomain, string sectionForPort) : this(new ComprefaceConfiguration(configuration, sectionForApiKey, sectionForDomain, sectionForPort))
        { }

        public FaceDetectionClient(ComprefaceConfiguration configuration)
        {
            var apiClient = new ApiClient(configuration.ApiKey);

            FaceDetectionService = new FaceDetectionService(apiClient: apiClient, configuration: configuration);

            ConfigInitializer.InitializeSnakeCaseJsonConfigs();
        }
    }
}
