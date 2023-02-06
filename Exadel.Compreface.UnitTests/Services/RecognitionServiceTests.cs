using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFaceFromImage;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFacesFromImageWithBase64;
using Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImage;
using Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImageWithBase64;
using Exadel.Compreface.Services;
using Flurl;

namespace Exadel.Compreface.UnitTests.Services
{
    public class RecognitionServiceTests : AbstractBaseServiceTests<RecognitionService>
    {
        private readonly RecognitionService _service;

        public RecognitionServiceTests()
        {
            _service = ServiceMock.Object;
        }

        [Fact]
        public async Task RecognizeAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new RecognizeFaceFromImageRequest()
            {
                FacePlugins = new List<string>()
            };

            SetupPostJson<RecognizeFaceFromImageResponse>();

            // Act
            var response = await _service.RecognizeAsync(request);

            // Assert
            Assert.IsType<RecognizeFaceFromImageResponse>(response);

            VerifyPostJson<RecognizeFaceFromImageResponse>();
            ServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task RecognizeAsync_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            var request = new RecognizeFaceFromImageRequest()
            {
                FacePlugins = new List<string>()
            };

            SetupPostJson<RecognizeFaceFromImageResponse>();

            // Act
            var response = await _service.RecognizeAsync(request);

            // Assert
            Assert.NotNull(response);

            VerifyPostJson<RecognizeFaceFromImageResponse>();
            ServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task RecognizeAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Arrange
            SetupPostJson<RecognizeFaceFromImageResponse>();

            // Act
            var func = async () => await _service.RecognizeAsync(null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task RecognizeFaceFromImage_TakesIncorrectRequestModel_ThrowsArgumentNullException()
        {
            // Arrange
            var request = new RecognizeFaceFromImageRequest();

            SetupPostJson<RecognizeFaceFromImageResponse>();

            // Act
            var func = async () => await _service.RecognizeAsync(request);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(func);
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
            var response = await _service.RecognizeAsync(request);

            // Assert
            Assert.IsType<RecognizeFaceFromImageResponse>(response);

            VerifyPostJson<RecognizeFaceFromImageResponse, Url>();
            ServiceMock.VerifyNoOtherCalls();
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
            var response = await _service.RecognizeAsync(request);

            // Assert
            Assert.NotNull(response);

            VerifyPostJson<RecognizeFaceFromImageResponse, Url>();
            ServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task RecognizeBase64Async_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Arrange
            SetupPostJson<RecognizeFaceFromImageResponse, Url>();

            // Act
            var func = async () => await _service.RecognizeAsync(null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task VerifyAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new RecognizeFacesFromImageWithBase64Request();

            SetupPostJson<RecognizeFaceFromImageResponse, Url>();

            // Act
            var func = async () => await _service.RecognizeAsync(request);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(func);
        }

        [Fact]
        public async Task VerifyFacesFromImage_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new VerifyFacesFromImageRequest()
            {
                FacePlugins = new List<string>()
            };

            SetupPostJson<VerifyFacesFromImageResponse>();

            // Act
            var response = await _service.VerifyAsync(request);

            // Assert
            Assert.IsType<VerifyFacesFromImageResponse>(response);

            VerifyPostJson<VerifyFacesFromImageResponse>();
            ServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task VerifyAsync_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            var request = new VerifyFacesFromImageRequest()
            {
                FacePlugins = new List<string>()
            };

            SetupPostJson<VerifyFacesFromImageResponse>();

            // Act
            var response = await _service.VerifyAsync(request);

            // Assert
            Assert.NotNull(response);

            VerifyPostJson<VerifyFacesFromImageResponse>();
            ServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task VerifyAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Arrange
            SetupPostJson<VerifyFacesFromImageResponse>();

            // Act
            var func = async () => await _service.VerifyAsync((VerifyFacesFromImageRequest)null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task VerifyBase64Async_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new VerifyFacesFromImageRequest();

            SetupPostJson<VerifyFacesFromImageResponse>();

            // Act
            var func = async () => await _service.VerifyAsync(request);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(func);
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
            var response = await _service.VerifyAsync(request);

            // Assert
            Assert.IsType<VerifyFacesFromImageResponse>(response);

            VerifyPostJson<VerifyFacesFromImageResponse, Url>();
            ServiceMock.VerifyNoOtherCalls();
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
            var response = await _service.VerifyAsync(request);

            // Assert
            Assert.NotNull(response);

            VerifyPostJson<VerifyFacesFromImageResponse, Url>();
            ServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task VerifyBase64Async_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Arrange
            SetupPostJson<VerifyFacesFromImageResponse, Url>();

            // Act
            var func = async () => await _service.VerifyAsync((VerifyFacesFromImageWithBase64Request)null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task VerifyFacesFromBase64File_TakesIncorrectRequestModel_ThrowsArgumentNullException()
        {
            // Arrange
            var request = new VerifyFacesFromImageWithBase64Request();

            SetupPostJson<VerifyFacesFromImageResponse, Url>();

            // Act
            var func = async () => await _service.VerifyAsync(request);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(func);
        }
    }
}
