using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetection;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetectionBase64;
using static Exadel.Compreface.Tests.UrlConstConfig;

namespace Exadel.Compreface.Tests.Services
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
            //Arrange
            var faceDetectionRequest = new FaceDetectionRequest()
            {
                DetProbThreshold = 0.91m,
                FacePlugins = new List<string>()
            {
                "age",
                "gender",
                "mask",
                "calculator",
            },
                Status = true,
                FileName = FILE_NAME,
                FilePath = FILE_PATH,
                Limit = 0
            };

            //Act
           var faceDetectionResponse = await comprefaceApiClient.FaceDetectionService.FaceDetectionAsync(faceDetectionRequest);

            //Assert
            Assert.IsType<FaceDetectionResponse>(faceDetectionResponse);
        }

        [Fact]
        public async Task FaceDetectionBase64Async_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            var faceDetectionBase64Request = new FaceDetectionBase64Request()
            {
                DetProbThreshold = 0.91m,
                FacePlugins = new List<string>()
            {
                "age",
                "gender",
                "mask",
                "calculator",
            },
                Status = true,
                File = IMAGE_BASE64_STRING,
                Limit = 0
            };

            //Act
            var faceDetectionResponse = await comprefaceApiClient.FaceDetectionService.FaceDetectionBase64Async(faceDetectionBase64Request);

            //Assert
            Assert.IsType<FaceDetectionBase64Response>(faceDetectionResponse);
        }
    }
}
