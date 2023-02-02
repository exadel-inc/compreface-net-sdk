using Exadel.Compreface.Clients.Config;
using Exadel.Compreface.Clients.Interfaces;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.Services;
using Microsoft.Extensions.Options;

namespace Exadel.Compreface.Clients
{
    public class FaceVerificationClient: ICompreFaceClient
    {
        private readonly IOptionsMonitor<ComprefaceConfiguration> _configuration;
        public FaceVerificationService FaceVerificationService { get; set; }


        public FaceVerificationClient(IOptionsMonitor<ComprefaceConfiguration> configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(ComprefaceConfiguration));
        }

        public void GetClient(string apiKey)
        {
            var apiClient = new ApiClient(_configuration.CurrentValue.FaceVerificationApiKey);

            FaceVerificationService = new FaceVerificationService(apiClient: apiClient, configuration: _configuration);

            ConfigInitializer.InitializeSnakeCaseJsonConfigs();
        }
    }
}