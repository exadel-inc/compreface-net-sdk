using Exadel.Compreface.Configuration;
using Microsoft.Extensions.Options;

namespace Exadel.Compreface.Clients.Factories
{
    public class FaceDetectionFactory : ClientFactory
    {
        private readonly IOptionsMonitor<ComprefaceConfiguration> _configuration;
        private readonly string _apiKey;
        public FaceDetectionFactory(string apiKey, IOptionsMonitor<ComprefaceConfiguration> configuration)
        {
            _apiKey= apiKey;
            _configuration= configuration;  
        }

        public override ICompreFaceClient GetClient()
        {
            FaceDetectionClient client = new FaceDetectionClient(_configuration);
            client.GetClient(_apiKey);
            return client;
        }
    }
}