using Exadel.Compreface.Clients.Interfaces;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace Exadel.Compreface.Services.RecognitionService
{
    public class RecognitionService : IRecognitionService
    {
        private readonly IOptionsMonitor<ComprefaceConfiguration> _configuration;
        public readonly IApiClient _apiClient;
        public IFaceCollection FaceCollection { get; private set; }
        public ISubject Subject { get; private set; }
        public IRecognizeFaceFromImage RecognizeFaceFromImage { get; private set; }

        public RecognitionService(IOptionsMonitor<ComprefaceConfiguration> configuration, IApiClient apiClient)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(ComprefaceConfiguration));
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(IApiClient));

            FaceCollection = new FaceCollection(_configuration, _apiClient);
            Subject = new Subject(_configuration, _apiClient);
            RecognizeFaceFromImage = new RecognizeFaceFromImage(_configuration, _apiClient);
        }
    }
}