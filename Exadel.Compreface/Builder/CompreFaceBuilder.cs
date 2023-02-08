using Exadel.Compreface.Clients;
using Exadel.Compreface.Clients.Interfaces;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.Services;
using Exadel.Compreface.Services.Interfaces;
using Exadel.Compreface.Services.RecognitionService;
using Microsoft.Extensions.Options;

namespace Exadel.Compreface.Builder
{
    public class CompreFaceBuilder : ICompreFaceBuilder
    {
        private readonly IOptionsMonitor<ComprefaceConfiguration> _configuration;
        private readonly IApiClient _apiClientDetection ;
        private readonly IApiClient _apiClientVerification;
        private List<IApiClient> _apiClientRecognition;
       
        public CompreFaceBuilder(IOptionsMonitor<ComprefaceConfiguration> configuration)
        {
            _configuration = configuration;
            var services = _configuration.CurrentValue.ServicesConfiguration;
            _apiClientRecognition = new List<IApiClient>(){ };
            foreach (var service in services)
            {
                if (service.TypeService == TypeService.Detection)
                    _apiClientDetection = new ApiClient(service.ApiKey);
                else if (service.TypeService == TypeService.Verification)
                    _apiClientVerification = new ApiClient(service.ApiKey);
                else if (service.TypeService == TypeService.Recognition)
                {
                    var t = new ApiClient(service.ApiKey);
                    _apiClientRecognition.Add(t);
                }
            }
        }

        public IFaceDetectionService BuildFaceDetection()
        {
            return new FaceDetectionService(_configuration, _apiClientDetection);
        }

        public List<IRecognitionService> BuildRecognition()
        {
            var services = new List<IRecognitionService>();  
           foreach(var apiClient in _apiClientRecognition) 
           { 
                var service = new RecognitionService(_configuration, apiClient);  
                services.Add(service);  
           }
           return services;
        }

        public IFaceVerificationService BuildVerification()
        {
            return new FaceVerificationService(_configuration, _apiClientVerification);
        }
    }
}
