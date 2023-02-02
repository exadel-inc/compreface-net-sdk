using Exadel.Compreface.Clients.Config;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.Services;
using Microsoft.Extensions.Options;

namespace Exadel.Compreface.Clients
{
    public class FaceDetectionClient
    {
        private readonly IOptionsMonitor<ComprefaceConfiguration> _configuration;

        public FaceDetectionService FaceDetectionService { get; private set; }


        public FaceDetectionClient(IOptionsMonitor<ComprefaceConfiguration> configuration) 
        { 
            _configuration = configuration ?? throw new ArgumentNullException(nameof(ComprefaceConfiguration));
        }

        public FaceDetectionClient(ComprefaceConfiguration configuration)
        {
            var apiClient = new ApiClient(_configuration.CurrentValue.FaceDetectionApiKey);
            
            FaceDetectionService = new FaceDetectionService(apiClient: apiClient, configuration: _configuration);

            ConfigInitializer.InitializeSnakeCaseJsonConfigs();
        }
    }
}