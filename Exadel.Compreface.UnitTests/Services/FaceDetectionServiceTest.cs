using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetection;
using Exadel.Compreface.Services;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetectionBase64;
using Flurl;
using static Exadel.Compreface.UnitTests.Helpers.GetRandomStringHelper;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.UnitTests.Helpers;

namespace Exadel.Compreface.UnitTests.Services
{
    public class FaceDetectionServiceTest : SetupAndVerifyTests
    {
        private readonly IComprefaceConfiguration _comprefaceConfiguration;

        private readonly FaceDetectionService _faceDetectionService;

        public FaceDetectionServiceTest()
        {
            var apiKey = GetRandomString();
            var domain = GetRandomString();
            var port = GetRandomString();

            _comprefaceConfiguration = new ComprefaceConfiguration(apiKey, domain, port);

            _faceDetectionService = new FaceDetectionService(_comprefaceConfiguration, ApiClientMock.Object);
        }

        [Fact]
        public async Task DetectAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new FaceDetectionRequestByFilePath()
            {
                FacePlugins = new List<string>()
            };

            SetupPostMultipart<FaceDetectionResponse>();

            // Act
            var response = await _faceDetectionService.DetectAsync(request);

            // Assert
            Assert.IsType<FaceDetectionResponse>(response);
            Assert.NotNull(response);

            VerifyPostMultipart<FaceDetectionResponse>();
            base.ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DetectAsync_TakesRequestModelUsingUrl_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new FaceDetectionRequestByFileUrl()
            {
                FacePlugins = new List<string>()
            };

            SetupPostJson<FaceDetectionResponse>();
            SetupGetBytes();

            // Act
            var response = await _faceDetectionService.DetectAsync(request);

            // Assert
            Assert.IsType<FaceDetectionResponse>(response);
            Assert.NotNull(response);

            VerifyPostJson<FaceDetectionResponse>();
            VerifySetupGetBytes();
            base.ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DetectAsync_TakesRequestModelUsingImageInBytes_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new FaceDetectionRequestByBytes()
            {
                FacePlugins = new List<string>(),
                ImageInBytes = new byte[] {},
            };

            SetupPostJson<FaceDetectionResponse>();

            // Act
            var response = await _faceDetectionService.DetectAsync(request);

            // Assert
            Assert.IsType<FaceDetectionResponse>(response);
            Assert.NotNull(response);

            VerifyPostJson<FaceDetectionResponse>();
            base.ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DetectAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Arrange
            SetupPostMultipart<FaceDetectionResponse>();

            // Act
            var func = async () => await _faceDetectionService.DetectAsync((FaceDetectionRequestByFilePath)null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task DetectAsync_TakesNullRequestModelUsingUrl_ThrowsNullReferenceException()
        {
            // Arrange
            SetupPostJson<FaceDetectionResponse>();
            SetupGetBytes();

            // Act
            var func = async () => await _faceDetectionService.DetectAsync((FaceDetectionRequestByFileUrl)null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task DetectAsync_TakesNullRequestModelUsingImageInBytes_ThrowsNullReferenceException()
        {
            // Arrange
            SetupPostJson<FaceDetectionResponse>();
            SetupGetBytes();

            // Act
            var func = async () => await _faceDetectionService.DetectAsync((FaceDetectionRequestByBytes)null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task FaceDetectionBase64Async_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new FaceDetectionBase64Request()
            {
                FacePlugins = new List<string>()
            };

            SetupPostJson<FaceDetectionResponse, Url>();

            // Act
            var response = await _faceDetectionService.DetectAsync(request);

            // Assert
            Assert.IsType<FaceDetectionResponse>(response);
            Assert.NotNull(response);

            VerifyPostJson<FaceDetectionResponse, Url>();
            base.ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DetectBase64Async_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Arrange
            SetupPostJson<FaceDetectionResponse, Url>();

            // Act
            var func = async () => await _faceDetectionService.DetectAsync((FaceDetectionBase64Request)null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }
    }
}