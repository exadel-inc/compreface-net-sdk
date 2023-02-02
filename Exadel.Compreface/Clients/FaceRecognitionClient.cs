using Exadel.Compreface.Clients.Config;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Exadel.Compreface.Clients
{
    public class FaceRecognitionClient
    {
        private readonly IOptionsMonitor<ComprefaceConfiguration> _configuration;
        public SubjectExampleService SubjectExampleService { get; private set; }

        public SubjectService SubjectService { get; private set; }

        public RecognitionService RecognitionService { get; private set; }


        public FaceRecognitionClient(IOptionsMonitor<ComprefaceConfiguration> configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(ComprefaceConfiguration));
        }

        public FaceRecognitionClient(ComprefaceConfiguration configuration)
        {
            var apiClient = new ApiClient(configuration.FaceRecognitionApiKey);

            SubjectExampleService = new SubjectExampleService(apiClient: apiClient, configuration: _configuration);
            SubjectService = new SubjectService(apiClient: apiClient, configuration: _configuration);
            RecognitionService = new RecognitionService(apiClient: apiClient, configuration: _configuration);

            ConfigInitializer.InitializeSnakeCaseJsonConfigs();
        }
    }
}
