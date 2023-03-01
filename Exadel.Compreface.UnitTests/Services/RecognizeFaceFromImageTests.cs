using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFaceFromImage;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFacesFromImageWithBase64;
using Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImage;
using Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImageWithBase64;
using static Exadel.Compreface.UnitTests.Helpers.GetRandomStringHelper;
using Exadel.Compreface.Services.RecognitionService;
using Exadel.Compreface.UnitTests.Helpers;
using Flurl;
using Exadel.Compreface.DTOs.RecognizeFaceFromImageDTOs.VerifyFacesFromImage;

namespace Exadel.Compreface.UnitTests.Services
{
    public class RecognizeFaceFromImageTests : SetupAndVerifyTests
    {
        private readonly IComprefaceConfiguration _comprefaceConfiguration;

        private readonly RecognizeFaceFromImage _recognizeFaceFromImage;

        public RecognizeFaceFromImageTests()
        {
            var apiKey = GetRandomString();
            var domain = GetRandomString();
            var port = GetRandomString();

            _comprefaceConfiguration = new ComprefaceConfiguration(apiKey, domain, port);

            _recognizeFaceFromImage = new RecognizeFaceFromImage(_comprefaceConfiguration, ApiClientMock.Object);
        }

        [Fact]
        public async Task RecognizeAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new RecognizeFaceFromImageRequestByFilePath()
            {
                FacePlugins = new List<string>()
            };

            SetupPostMultipart<RecognizeFaceFromImageResponse>();

            // Act
            var response = await _recognizeFaceFromImage.RecognizeAsync(request);

            // Assert
            Assert.IsType<RecognizeFaceFromImageResponse>(response);

            VerifyPostMultipart<RecognizeFaceFromImageResponse>();
            ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task RecognizeAsync_TakesRequestModelUsingUrl_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new RecognizeFaceFromImageRequestByFileUrl()
            {
                FacePlugins = new List<string>()
            };

            SetupPostJson<RecognizeFaceFromImageResponse>();
            SetupGetBytes();

            // Act
            var response = await _recognizeFaceFromImage.RecognizeAsync(request);

            // Assert
            Assert.IsType<RecognizeFaceFromImageResponse>(response);

            VerifyPostJson<RecognizeFaceFromImageResponse>();
            VerifySetupGetBytes();
            ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task RecognizeAsync_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            var request = new RecognizeFaceFromImageRequestByFilePath()
            {
                FacePlugins = new List<string>()
            };

            SetupPostMultipart<RecognizeFaceFromImageResponse>();

            // Act
            var response = await _recognizeFaceFromImage.RecognizeAsync(request);

            // Assert
            Assert.NotNull(response);

            VerifyPostMultipart<RecognizeFaceFromImageResponse>();
            ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task RecognizeAsync_TakesRequestModelUsingUrl_ReturnsNotNull()
        {
            // Arrange
            var request = new RecognizeFaceFromImageRequestByFileUrl()
            {
                FacePlugins = new List<string>()
            };

            SetupPostJson<RecognizeFaceFromImageResponse>();
            SetupGetBytes();

            // Act
            var response = await _recognizeFaceFromImage.RecognizeAsync(request);

            // Assert
            Assert.NotNull(response);

            VerifyPostJson<RecognizeFaceFromImageResponse>();
            VerifySetupGetBytes();
            ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task RecognizeAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Arrange
            SetupPostMultipart<RecognizeFaceFromImageResponse>();

            // Act
            var func = async () => await _recognizeFaceFromImage.RecognizeAsync((RecognizeFaceFromImageRequestByFilePath)null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task RecognizeAsync_TakesNullRequestModelUsingUrl_ThrowsNullReferenceException()
        {
            // Arrange
            SetupPostJson<RecognizeFaceFromImageResponse>();

            // Act
            var func = async () => await _recognizeFaceFromImage.RecognizeAsync((RecognizeFaceFromImageRequestByFileUrl)null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task RecognizeFaceFromBase64File_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new RecognizeFacesFromImageWithBase64Request()
            {
                FacePlugins = new List<string>()
            };

            SetupPostJson<RecognizeFaceFromImageResponse, Url>();

            // Act
            var response = await _recognizeFaceFromImage.RecognizeAsync(request);

            // Assert
            Assert.IsType<RecognizeFaceFromImageResponse>(response);

            VerifyPostJson<RecognizeFaceFromImageResponse, Url>();
            ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task RecognizeBase64Async_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            var request = new RecognizeFacesFromImageWithBase64Request()
            {
                FacePlugins = new List<string>()
            };

            SetupPostJson<RecognizeFaceFromImageResponse, Url>();

            // Act
            var response = await _recognizeFaceFromImage.RecognizeAsync(request);

            // Assert
            Assert.NotNull(response);

            VerifyPostJson<RecognizeFaceFromImageResponse, Url>();
            ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task RecognizeBase64Async_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Arrange
            SetupPostJson<RecognizeFaceFromImageResponse, Url>();

            // Act
            var func = async () => await _recognizeFaceFromImage.RecognizeAsync((RecognizeFacesFromImageWithBase64Request)null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task VerifyFacesFromImage_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new VerifyFacesFromImageByFilePathRequest()
            {
                FacePlugins = new List<string>()
            };

            SetupPostMultipart<VerifyFacesFromImageResponse>();

            // Act
            var response = await _recognizeFaceFromImage.VerifyAsync(request);

            // Assert
            Assert.IsType<VerifyFacesFromImageResponse>(response);

            VerifyPostMultipart<VerifyFacesFromImageResponse>();
            ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task VerifyAsync_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            var request = new VerifyFacesFromImageByFilePathRequest()
            {
                FacePlugins = new List<string>()
            };

            SetupPostMultipart<VerifyFacesFromImageResponse>();

            // Act
            var response = await _recognizeFaceFromImage.VerifyAsync(request);

            // Assert
            Assert.NotNull(response);

            VerifyPostMultipart<VerifyFacesFromImageResponse>();
            ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task VerifyAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Arrange
            SetupPostMultipart<VerifyFacesFromImageResponse>();

            // Act
            var func = async () => await _recognizeFaceFromImage.VerifyAsync((VerifyFacesFromImageByFilePathRequest)null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task VerifyFacesFromBase64File_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new VerifyFacesFromImageWithBase64Request()
            {
                FacePlugins = new List<string>()
            };

            SetupPostJson<VerifyFacesFromImageResponse, Url>();

            // Act
            var response = await _recognizeFaceFromImage.VerifyAsync(request);

            // Assert
            Assert.IsType<VerifyFacesFromImageResponse>(response);

            VerifyPostJson<VerifyFacesFromImageResponse, Url>();
            ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task VerifyBase64Async_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            var request = new VerifyFacesFromImageWithBase64Request()
            {
                FacePlugins = new List<string>()
            };

            SetupPostJson<VerifyFacesFromImageResponse, Url>();

            // Act
            var response = await _recognizeFaceFromImage.VerifyAsync(request);

            // Assert
            Assert.NotNull(response);

            VerifyPostJson<VerifyFacesFromImageResponse, Url>();
            ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task VerifyBase64Async_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Arrange
            SetupPostJson<VerifyFacesFromImageResponse, Url>();

            // Act
            var func = async () => await _recognizeFaceFromImage.VerifyAsync((VerifyFacesFromImageWithBase64Request)null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task VerifyFacesFromImageUrl_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new VerifyFacesFromImageByFileUrlRequest();

            SetupPostJson<VerifyFacesFromImageResponse, Url>();
            SetupGetBytes();

            // Act
            var response = await _recognizeFaceFromImage.VerifyAsync(request);

            // Assert
            Assert.IsType<VerifyFacesFromImageResponse>(response);

            VerifyPostJson<VerifyFacesFromImageResponse, Url>();
            VerifySetupGetBytes();
            ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task VerifyFacesFromImageUrl_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            var request = new VerifyFacesFromImageByFileUrlRequest();

            SetupPostJson<VerifyFacesFromImageResponse, Url>();
            SetupGetBytes();

            // Act
            var response = await _recognizeFaceFromImage.VerifyAsync(request);

            // Assert
            Assert.NotNull(response);

            VerifyPostJson<VerifyFacesFromImageResponse, Url>();
            VerifySetupGetBytes();
            ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task VerifyFacesFromImageUrl_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Arrange
            SetupPostJson<VerifyFacesFromImageResponse, Url>();

            // Act
            var func = async () => await _recognizeFaceFromImage.VerifyAsync((VerifyFacesFromImageByFileUrlRequest)null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }
    }
}
