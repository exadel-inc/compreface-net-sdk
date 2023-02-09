using Exadel.Compreface.Clients;
using Exadel.Compreface.Clients.Interfaces;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.Services;
using Exadel.Compreface.Services.RecognitionService;
using Microsoft.Extensions.Options;

namespace Exadel.Compreface.Builder
{
    public class CompreFaceBuilder : ICompreFaceBuilder
    {
        private readonly IOptionsMonitor<ComprefaceConfiguration> _configuration;
        private List<IApiClient> _apiClientDetection = new List<IApiClient>();
        private List<IApiClient> _apiClientVerification = new List<IApiClient>();
        private List<IApiClient> _apiClientRecognition = new List<IApiClient>();

        public CompreFaceBuilder(IOptionsMonitor<ComprefaceConfiguration> configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(ComprefaceConfiguration));

            var services = _configuration.CurrentValue.ServicesConfiguration;
            if (services != null)
            {
                Initialize(services);
            }
            else
                throw new ArgumentNullException("ServicesConfiguration are empty");
        }
        public CompreFaceBuilder(List<ServicesConfiguration> services)
        {
            if (services != null)
            {
                Initialize(services);
            }
            else
                throw new ArgumentNullException("ServicesConfiguration are empty");
        }

        public List<FaceDetectionService> BuildFaceDetection()
        {
            var services = new List<FaceDetectionService>();
            if(_apiClientDetection != null)
            {
               foreach (var apiClient in _apiClientDetection)
               {
                   var service = new FaceDetectionService(_configuration, apiClient);
                   services.Add(service);
               }
               return services;
            }
            else
               throw new ArgumentNullException("There are no face detection services with this ApiKey!");
        }

        public List<RecognitionService> BuildRecognition()
        {
            var services = new List<RecognitionService>();
            if (_apiClientRecognition != null)
            {
                foreach (var apiClient in _apiClientRecognition)
                {
                    var service = new RecognitionService(_configuration, apiClient);
                    services.Add(service);
                }
                return services;
            }
            else
                throw new ArgumentNullException("There are no recognition services with this ApiKey!");
        }

        public List<FaceVerificationService> BuildVerification()
        {
            var services = new List<FaceVerificationService>();
            if (_apiClientRecognition != null)
            {
                foreach (var apiClient in _apiClientVerification)
                {
                    var service = new FaceVerificationService(_configuration, apiClient);
                    services.Add(service);
                }
                return services;
            }
            else
                throw new ArgumentNullException("There are no face verification services with this ApiKey");
        }

        private void Initialize(List<ServicesConfiguration> services)
        {

            foreach (var service in services)
            {
                if (service.TypeService == TypeService.Detection)
                {
                    if (service.ApiKey != null)
                    {
                        var detectionApiClient = new ApiClient(service.ApiKey);
                        _apiClientDetection.Add(detectionApiClient);
                    }
                    else
                        throw new ArgumentNullException("ApiKey in this service is empty!");

                }
                else if (service.TypeService == TypeService.Verification)
                {
                    if (service.ApiKey != null)
                    {
                        var verificationApiClient = new ApiClient(service.ApiKey);
                        _apiClientVerification.Add(verificationApiClient);
                    }
                    else
                        throw new ArgumentNullException("ApiKey in this service is empty!");

                }
                else if (service.TypeService == TypeService.Recognition)
                {
                    if (service.ApiKey != null)
                    {
                        var recognitionApiClient = new ApiClient(service.ApiKey);
                        _apiClientRecognition.Add(recognitionApiClient);
                    }
                    else
                        throw new ArgumentNullException("ApiKey in this service is empty!");
                }
            }
        }
    }
}