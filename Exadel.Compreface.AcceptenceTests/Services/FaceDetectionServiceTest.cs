using Exadel.Compreface.Clients;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetection;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetectionBase64;
using Exadel.Compreface.Services;
using static Exadel.Compreface.AcceptenceTests.UrlConstConfig;

namespace Exadel.Compreface.AcceptenceTests.Services
{
    [Collection("Sequential")]
    public class FaceDetectionServiceTest
    {
        private readonly FaceDetectionService _faceDetectionService;

        private readonly FaceDetectionRequest _faceDetectionRequest;
        private readonly FaceDetectionBase64Request _faceDetectionBase64Request;
     
        public FaceDetectionServiceTest()
        {
            var configuration = new ComprefaceConfiguration(API_KEY_DETECTION_SERVICE, DOMAIN, PORT);
            var client = new FaceDetectionClient(configuration);
            var detProbThreshold = 0.85m;
            var status = true;
            var limit = 0;
            var facePlugins = new List<string>()
            {
                "landmarks",
                "gender",
                "age",
                "detector",
                "calculator"
            };

            _faceDetectionService = client.FaceDetectionService;
            _faceDetectionRequest = new FaceDetectionRequest
            {
                FileName = FILE_NAME,
                FilePath = FILE_PATH,
                DetProbThreshold = detProbThreshold,
                FacePlugins = facePlugins,
                Status = status,
                Limit = limit
            };

            _faceDetectionBase64Request = new FaceDetectionBase64Request()
            {
                File = IMAGE_BASE64_STRING,
                DetProbThreshold = detProbThreshold,
                FacePlugins = facePlugins,
                Status = status,
                Limit = limit
            };
        }

        [Fact]
        public async Task FaceDetectionAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Act
            var response = await _faceDetectionService.FaceDetectionAsync(_faceDetectionRequest);

            // Assert
            Assert.IsType<FaceDetectionResponse>(response);
        }

        [Fact]
        public async Task FaceDetectionAsync_TakesRequestModel_ReturnsNotNull()
        {
            // Act
            var response = await _faceDetectionService.FaceDetectionAsync(_faceDetectionRequest);

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task FaceDetectionAsync_TakesNullRequest_ThrowsException()
        {
            // Act
            var func = async () => await _faceDetectionService.FaceDetectionAsync(null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task FaceDetectionBase64Async_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Act
            var response = await _faceDetectionService.FaceDetectionBase64Async(_faceDetectionBase64Request);

            // Assert
            Assert.IsType<FaceDetectionResponse>(response);
        }

        [Fact]
        public async Task FaceDetectionBase64Async_TakesRequestModel_ReturnsNotNull()
        {
            // Act
            var response = await _faceDetectionService.FaceDetectionBase64Async(_faceDetectionBase64Request);

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task FaceDetectionBase64Async_TakesNullRequest_ThrowsException()
        {
            // Act
            var func = async () => await _faceDetectionService.FaceDetectionBase64Async(null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }
    }
}
