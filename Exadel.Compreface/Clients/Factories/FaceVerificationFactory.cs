using Exadel.Compreface.Configuration;
using Microsoft.Extensions.Options;

namespace Exadel.Compreface.Clients.Factories
{
    public class FaceVerificationFactory : ClientFactory
    {
        private readonly IOptionsMonitor<ComprefaceConfiguration> _configuration;
        private readonly string _apiKey;
        public FaceVerificationFactory(string apiKey, IOptionsMonitor<ComprefaceConfiguration> configuration)
        {
            _apiKey = apiKey;
            _configuration = configuration;
        }

        public override ICompreFaceClient GetClient()
        {
            FaceVerificationClient client = new FaceVerificationClient(_configuration);
            client.GetClient(_apiKey);
            return client;
        }
    }
}