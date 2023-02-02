using Exadel.Compreface.Clients.Interfaces;
using Exadel.Compreface.Configuration;
using Microsoft.Extensions.Options;

namespace Exadel.Compreface.Clients.Factories
{
    public class FaceRecognitionFactory : ClientFactory
    {
        private readonly IOptionsMonitor<ComprefaceConfiguration> _configuration;
        private readonly string _apiKey;
        public FaceRecognitionFactory(string apiKey, IOptionsMonitor<ComprefaceConfiguration> configuration)
        {
            _apiKey = apiKey;
            _configuration = configuration;
        }

        public override ICompreFaceClient GetClient()
        {
            FaceRecognitionClient client = new FaceRecognitionClient(_configuration);
            client.GetClient(_apiKey);
            return client;
        }
    }
}