using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFaceFromImage;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFacesFromImageWithBase64;
using Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImage;
using Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImageWithBase64;
using Exadel.Compreface.Services;
using Flurl;
using Flurl.Http.Content;
using Moq;
using Tynamix.ObjectFiller;

namespace Exadel.Compreface.UnitTests.Services
{
    public class RecognitionServiceTests
    {
        private readonly Mock<IApiClient> _apiClientMock;
        private readonly RecognitionService _recognitionService;

        public RecognitionServiceTests()
        {
            var apiKey = GetRandomString();
            var baseUrl = GetRandomString();
            var configuration = new ComprefaceConfiguration(apiKey, baseUrl);

            _apiClientMock = new Mock<IApiClient>();
            _recognitionService = new RecognitionService(configuration, _apiClientMock.Object);
        }

        [Fact]
        public async void RecognizeFaceFromImage_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new RecognizeFaceFromImageRequest()
            {
                FacePlugins = new List<string>()
            };

            SetupPostMultipart<RecognizeFaceFromImageResponse>();

            // Act
            var response = await _recognitionService.RecognizeFaceFromImage(request);

            // Assert
            Assert.IsType<RecognizeFaceFromImageResponse>(response);

            VerifyPostMultipart<RecognizeFaceFromImageResponse>();
            _apiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async void RecognizeFaceFromImage_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            var request = new RecognizeFaceFromImageRequest()
            {
                FacePlugins = new List<string>()
            };

            SetupPostMultipart<RecognizeFaceFromImageResponse>();

            // Act
            var response = await _recognitionService.RecognizeFaceFromImage(request);

            // Assert
            Assert.NotNull(response);

            VerifyPostMultipart<RecognizeFaceFromImageResponse>();
            _apiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async void RecognizeFaceFromImage_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Arrange
            SetupPostMultipart<RecognizeFaceFromImageResponse>();

            // Act
            var func = async () => await _recognitionService.RecognizeFaceFromImage(null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async void RecognizeFaceFromBase64File_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new RecognizeFacesFromImageWithBase64Request()
            {
                FacePlugins = new List<string>()
            };

            SetupPostJson<RecognizeFaceFromImageResponse>();

            // Act
            var response = await _recognitionService.RecognizeFaceFromBase64File(request);

            // Assert
            Assert.IsType<RecognizeFaceFromImageResponse>(response);

            VerifyPostJson<RecognizeFaceFromImageResponse>();
            _apiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async void RecognizeFaceFromBase64File_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            var request = new RecognizeFacesFromImageWithBase64Request()
            {
                FacePlugins = new List<string>()
            };

            SetupPostJson<RecognizeFaceFromImageResponse>();

            // Act
            var response = await _recognitionService.RecognizeFaceFromBase64File(request);

            // Assert
            Assert.NotNull(response);

            VerifyPostJson<RecognizeFaceFromImageResponse>();
            _apiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async void RecognizeFaceFromBase64File_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Arrange
            SetupPostJson<RecognizeFaceFromImageResponse>();

            // Act
            var func = async () => await _recognitionService.RecognizeFaceFromBase64File(null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async void VerifyFacesFromImage_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new VerifyFacesFromImageRequest()
            {
                FacePlugins = new List<string>()
            };

            SetupPostMultipart<VerifyFacesFromImageResponse>();

            // Act
            var response = await _recognitionService.VerifyFacesFromImage(request);

            // Assert
            Assert.IsType<VerifyFacesFromImageResponse>(response);

            VerifyPostMultipart<VerifyFacesFromImageResponse>();
            _apiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async void VerifyFacesFromImage_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            var request = new VerifyFacesFromImageRequest()
            {
                FacePlugins = new List<string>()
            };

            SetupPostMultipart<VerifyFacesFromImageResponse>();

            // Act
            var response = await _recognitionService.VerifyFacesFromImage(request);

            // Assert
            Assert.NotNull(response);

            VerifyPostMultipart<VerifyFacesFromImageResponse>();
            _apiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async void VerifyFacesFromImage_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Arrange
            SetupPostMultipart<VerifyFacesFromImageResponse>();

            // Act
            var func = async () => await _recognitionService.VerifyFacesFromImage(null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async void VerifyFacesFromBase64File_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new VerifyFacesFromImageWithBase64Request()
            {
                FacePlugins = new List<string>()
            };

            SetupPostJson<VerifyFacesFromImageResponse>();

            // Act
            var response = await _recognitionService.VerifyFacesFromBase64File(request);

            // Assert
            Assert.IsType<VerifyFacesFromImageResponse>(response);

            VerifyPostJson<VerifyFacesFromImageResponse>();
            _apiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async void VerifyFacesFromBase64File_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            var request = new VerifyFacesFromImageWithBase64Request()
            {
                FacePlugins = new List<string>()
            };

            SetupPostJson<VerifyFacesFromImageResponse>();

            // Act
            var response = await _recognitionService.VerifyFacesFromBase64File(request);

            // Assert
            Assert.NotNull(response);

            VerifyPostJson<VerifyFacesFromImageResponse>();
            _apiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async void VerifyFacesFromBase64File_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Arrange
            SetupPostJson<VerifyFacesFromImageResponse>();

            // Act
            var func = async () => await _recognitionService.VerifyFacesFromBase64File(null!);

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
