using Exadel.Compreface.Clients.Config;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.Services;
using Microsoft.Extensions.Options;

namespace Exadel.Compreface.Clients
{
    public class CompreFaceClient
    {
        private readonly IOptionsMonitor<ComprefaceConfiguration> _configuration;

        
        public FaceDetectionService FaceDetectionService { get; private set; }
        public SubjectExampleService SubjectExampleService { get; private set; }

        public SubjectService SubjectService { get; private set; }

        public RecognitionService RecognitionService { get; private set; }

        public FaceVerificationService FaceVerificationService { get; set; }

        public CompreFaceClient(IOptionsMonitor<ComprefaceConfiguration> configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(ComprefaceConfiguration));

        }

        public void GetClient()
        {
            var faceDetectionApiClient = new ApiClient(_configuration.CurrentValue.FaceDetectionApiKey);
            var faceVerificationApiClient = new ApiClient(_configuration.CurrentValue.FaceVerificationApiKey);
            var faceRecognitionApiClient = new ApiClient(_configuration.CurrentValue.FaceRecognitionApiKey);
            
            FaceDetectionService = new FaceDetectionService(apiClient: faceDetectionApiClient, configuration: _configuration);
            FaceVerificationService = new FaceVerificationService(apiClient: faceVerificationApiClient, configuration: _configuration);
            RecognitionService = new RecognitionService(apiClient: faceRecognitionApiClient, configuration: _configuration);
            SubjectExampleService = new SubjectExampleService(apiClient: faceRecognitionApiClient, configuration: _configuration);

            ConfigInitializer.InitializeSnakeCaseJsonConfigs();
        }
    }
}