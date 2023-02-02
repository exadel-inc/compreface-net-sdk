using Exadel.Compreface.Clients.Config;
using Exadel.Compreface.Clients.Interfaces;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.Services;
using Microsoft.Extensions.Options;

namespace Exadel.Compreface.Clients
{
    public class FaceDetectionClient: ICompreFaceClient
    {
        private readonly IOptionsMonitor<ComprefaceConfiguration> _configuration;

        public FaceDetectionService FaceDetectionService { get; private set; }


        public FaceDetectionClient(IOptionsMonitor<ComprefaceConfiguration> configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(ComprefaceConfiguration));
        }

        public void GetClient(string apiKey)
        {
            var apiClient = new ApiClient(apiKey);

            FaceDetectionService = new FaceDetectionService(apiClient: apiClient, configuration: _configuration);

            ConfigInitializer.InitializeSnakeCaseJsonConfigs();
        }
    }
}