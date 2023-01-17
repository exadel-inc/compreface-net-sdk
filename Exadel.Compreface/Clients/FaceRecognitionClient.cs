using Exadel.Compreface.Clients.Config;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.Services;
using Microsoft.Extensions.Configuration;

namespace Exadel.Compreface.Clients
{
    public class FaceRecognitionClient
    {
        public SubjectExampleService SubjectExampleService { get; private set; }

        public SubjectService SubjectService { get; private set; }

        public RecognitionService RecognitionService { get; private set; }

        public FaceRecognitionClient(string apiKey, string domain, string port) : this(new ComprefaceConfiguration(apiKey, domain, port))
        { }

        public FaceRecognitionClient(IConfiguration configuration, string sectionForApiKey, string sectionForDomain, string sectionForPort) : this(new ComprefaceConfiguration(configuration, sectionForApiKey, sectionForDomain, sectionForPort))
        { }

        public FaceRecognitionClient(ComprefaceConfiguration configuration)
        {
            var apiClient = new ApiClient();

            ConfigInitializer.InitializeApiKeyInRequestHeader(configuration.ApiKey);
            ConfigInitializer.InitializeSnakeCaseJsonConfigs();

            SubjectExampleService = new SubjectExampleService(apiClient: apiClient, configuration: configuration);
            SubjectService = new SubjectService(apiClient: apiClient, configuration: configuration);
            RecognitionService = new RecognitionService(apiClient: apiClient, configuration: configuration);
        }
    }
}
