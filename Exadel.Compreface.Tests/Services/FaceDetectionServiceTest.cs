using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetection;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetectionBase64;
using static Exadel.Compreface.Tests.UrlConstConfig;

namespace Exadel.Compreface.Tests.Services
{
    public class FaceDetectionServiceTest
    {
        [Fact]
        public async Task FaceDetectionAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            var apiClient = new ComprefaceClient(new ComprefaceConfiguration(API_KEY_DETECTION_SERVICE, BASE_URL));
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
           var faceDetectionResponse = await apiClient.FaceDetectionService.FaceDetectionAsync(faceDetectionRequest);

            //Assert
            Assert.IsType<FaceDetectionResponse>(faceDetectionResponse);
        }

        [Fact]
        public async Task FaceDetectionBase64Async_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            var apiClient = new ComprefaceClient(new ComprefaceConfiguration(API_KEY_DETECTION_SERVICE, BASE_URL));
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
            var faceDetectionResponse = await apiClient.FaceDetectionService.FaceDetectionBase64Async(faceDetectionBase64Request);

            //Assert
            Assert.IsType<FaceDetectionBase64Response>(faceDetectionResponse);
        }
    }
}
