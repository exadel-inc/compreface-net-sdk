using Exadel.Compreface.Configuration;
using static Exadel.Compreface.AcceptenceTests.UrlConstConfig;

namespace Exadel.Compreface.AcceptenceTests.Services
{
    public class FaceDetectionServiceTest
    {
        private readonly ComprefaceClient comprefaceApiClient;
        public FaceDetectionServiceTest()
        {
            comprefaceApiClient = new ComprefaceClient(new ComprefaceConfiguration(API_KEY_DETECTION_SERVICE, BASE_URL));
        }

        [Fact]
        public async Task FaceDetectionAsync_TakesRequestModel_ReturnsProperResponseModel()
        {

        }

        [Fact]
        public async Task FaceDetectionBase64Async_TakesRequestModel_ReturnsProperResponseModel()
        {

        }
    }
}
