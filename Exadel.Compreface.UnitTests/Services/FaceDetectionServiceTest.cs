using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetection;
using Exadel.Compreface.Services;
using Flurl.Http.Content;
using Flurl;
using Moq;
using Tynamix.ObjectFiller;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetectionBase64;
using Exadel.Compreface.Clients.Interfaces;

namespace Exadel.Compreface.UnitTests.Services
{
    public class FaceDetectionServiceTest
    {
        private readonly Mock<IApiClient> _apiClientMock;
        private readonly FaceDetectionService _faceDetectionService;

        public FaceDetectionServiceTest()
        {
            var apiKey = GetRandomString();
            var domain = GetRandomString();
            var port = new Random().Next().ToString();
            var configuration = new ComprefaceConfiguration(apiKey, domain, port);

            _apiClientMock = new Mock<IApiClient>();
            _faceDetectionService = new FaceDetectionService(configuration, _apiClientMock.Object);
        }

        [Fact]
        public async Task FaceDetectionAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new FaceDetectionRequest()
            {
                FacePlugins = new List<string>()
            };

            SetupPostMultipart<FaceDetectionResponse>();

            // Act
            var response = await _faceDetectionService.FaceDetectionAsync(request);

            // Assert
            Assert.IsType<FaceDetectionResponse>(response);

            VerifyPostMultipart<FaceDetectionResponse>();
            _apiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task FaceDetectionAsync_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            var request = new FaceDetectionRequest()
            {
                FacePlugins = new List<string>()
            };

            SetupPostMultipart<FaceDetectionResponse>();

            // Act
            var response = await _faceDetectionService.FaceDetectionAsync(request);

            // Assert
            Assert.NotNull(response);

            VerifyPostMultipart<FaceDetectionResponse>();
            _apiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task FaceDetectionAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Arrange
            SetupPostMultipart<FaceDetectionResponse>();

            // Act
            var func = async () => await _faceDetectionService.FaceDetectionAsync(null!);

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

            SetupPostJson<FaceDetectionBase64Response>();

            // Act
            var response = await _faceDetectionService.FaceDetectionBase64Async(request);

            // Assert
            Assert.IsType<FaceDetectionBase64Response>(response);

            VerifyPostJson<FaceDetectionBase64Response>();
            _apiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task FaceDetectionBase64Async_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            var request = new FaceDetectionBase64Request()
            {
                FacePlugins = new List<string>()
            };

            SetupPostJson<FaceDetectionBase64Response>();

            // Act
            var response = await _faceDetectionService.FaceDetectionBase64Async(request);

            // Assert
            Assert.NotNull(response);

            VerifyPostJson<FaceDetectionBase64Response>();
            _apiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task FaceDetectionBase64Async_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Arrange
            SetupPostJson<FaceDetectionBase64Response>();

            // Act
            var func = async () => await _faceDetectionService.FaceDetectionBase64Async(null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        private static string GetRandomString()
        {
            return new Filler<string>().Create();
        }

        private void SetupPostMultipart<TResponse>() where TResponse : new()
        {
            _apiClientMock.Setup(apiClient =>
                apiClient.PostMultipartAsync<TResponse>(
                    It.IsAny<Url>(),
                    It.IsAny<Action<CapturedMultipartContent>>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TResponse());
        }

        private void VerifyPostMultipart<TResponse>()
        {
            _apiClientMock.Verify(apiClient =>
            apiClient.PostMultipartAsync<TResponse>(
                It.IsAny<Url>(),
                It.IsAny<Action<CapturedMultipartContent>>(),
                It.IsAny<HttpCompletionOption>(),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        private void SetupPostJson<TResponse>() where TResponse : class, new()
        {
            _apiClientMock.Setup(apiClient =>
                apiClient.PostJsonAsync<TResponse>(
                    It.IsAny<Url>(),
                    It.IsAny<object>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TResponse());
        }

        private void VerifyPostJson<TResponse>() where TResponse : class, new()
        {
            _apiClientMock.Verify(apiClient =>
                apiClient.PostJsonAsync<TResponse>(
                    It.IsAny<Url>(),
                    It.IsAny<object>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
