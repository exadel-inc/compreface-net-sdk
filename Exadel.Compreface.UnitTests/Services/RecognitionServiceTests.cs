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

            _apiClientMock.Setup(apiClient =>
                apiClient.PostMultipartAsync<RecognizeFaceFromImageResponse>(
                    It.IsAny<Url>(),
                    It.IsAny<Action<CapturedMultipartContent>>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new RecognizeFaceFromImageResponse());

            // Act
            var response = await _recognitionService.RecognizeFaceFromImage(request);

            // Assert
            Assert.IsType<RecognizeFaceFromImageResponse>(response);

            _apiClientMock.Verify(apiClient =>
            apiClient.PostMultipartAsync<RecognizeFaceFromImageResponse>(
                It.IsAny<Url>(),
                It.IsAny<Action<CapturedMultipartContent>>(),
                It.IsAny<HttpCompletionOption>(),
                It.IsAny<CancellationToken>()), Times.Once);

            _apiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async void RecognizeFaceFromBase64File_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new RecognizeFacesFromImageWithBase64Request()
            {
                FacePlugins = new List<string>()
            };

            _apiClientMock.Setup(apiClient =>
                apiClient.PostJsonAsync<RecognizeFaceFromImageResponse>(
                    It.IsAny<Url>(),
                    It.IsAny<object>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new RecognizeFaceFromImageResponse());

            // Act
            var response = await _recognitionService.RecognizeFaceFromBase64File(request);

            // Assert
            Assert.IsType<RecognizeFaceFromImageResponse>(response);

            _apiClientMock.Verify(apiClient =>
            apiClient.PostJsonAsync<RecognizeFaceFromImageResponse>(
                It.IsAny<Url>(),
                It.IsAny<object>(),
                It.IsAny<HttpCompletionOption>(),
                It.IsAny<CancellationToken>()), Times.Once);

            _apiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async void VerifyFacesFromImage_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new VerifyFacesFromImageRequest()
            {
                FacePlugins = new List<string>()
            };

            _apiClientMock.Setup(apiClient =>
                apiClient.PostMultipartAsync<VerifyFacesFromImageResponse>(
                    It.IsAny<Url>(),
                    It.IsAny<Action<CapturedMultipartContent>>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new VerifyFacesFromImageResponse());

            // Act
            var response = await _recognitionService.VerifyFacesFromImage(request);

            // Assert
            Assert.IsType<VerifyFacesFromImageResponse>(response);

            _apiClientMock.Verify(apiClient =>
            apiClient.PostMultipartAsync<VerifyFacesFromImageResponse>(
                It.IsAny<Url>(),
                It.IsAny<Action<CapturedMultipartContent>>(),
                It.IsAny<HttpCompletionOption>(),
                It.IsAny<CancellationToken>()), Times.Once);

            _apiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async void VerifyFacesFromBase64File_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new VerifyFacesFromImageWithBase64Request()
            {
                FacePlugins = new List<string>()
            };

            _apiClientMock.Setup(apiClient =>
                apiClient.PostJsonAsync<VerifyFacesFromImageResponse>(
                    It.IsAny<Url>(),
                    It.IsAny<object>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new VerifyFacesFromImageResponse());

            // Act
            var response = await _recognitionService.VerifyFacesFromBase64File(request);

            // Assert
            Assert.IsType<VerifyFacesFromImageResponse>(response);

            _apiClientMock.Verify(apiClient =>
            apiClient.PostJsonAsync<VerifyFacesFromImageResponse>(
                It.IsAny<Url>(),
                It.IsAny<object>(),
                It.IsAny<HttpCompletionOption>(),
                It.IsAny<CancellationToken>()), Times.Once);

            _apiClientMock.VerifyNoOtherCalls();
        }

        private string GetRandomString()
        {
            return new Filler<string>().Create();
        }
    }
}
