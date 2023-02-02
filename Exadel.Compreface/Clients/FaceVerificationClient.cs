//using Exadel.Compreface.Clients.Config;
//using Exadel.Compreface.Configuration;
//using Exadel.Compreface.Services;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Options;

//namespace Exadel.Compreface.Clients
//{
//    public class FaceVerificationClient
//    {
//        private readonly IOptionsMonitor<ComprefaceConfiguration> _configuration;
//        public FaceVerificationService FaceVerificationService { get; set; }


//        public FaceVerificationClient(IOptionsMonitor<ComprefaceConfiguration> configuration)
//        { 
//            _configuration = configuration ?? throw new ArgumentNullException(nameof(ComprefaceConfiguration));
//        }

//        public FaceVerificationClient(ComprefaceConfiguration configuration)
//        {
//            var apiClient = new ApiClient(configuration.FaceVerificationApiKey);

//            FaceVerificationService = new FaceVerificationService(apiClient: apiClient, configuration: _configuration);

//            ConfigInitializer.InitializeSnakeCaseJsonConfigs();
//        }
//    }
//}