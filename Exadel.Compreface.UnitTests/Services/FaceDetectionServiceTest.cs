using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetection;
using Exadel.Compreface.Services;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetectionBase64;
using Flurl;

namespace Exadel.Compreface.UnitTests.Services
{
    public class FaceDetectionServiceTest : AbstractBaseServiceTests<FaceDetectionService>
    {
        private readonly FaceDetectionService _service;

        public FaceDetectionServiceTest()
        {
            _service = ServiceMock.Object;
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
            var response = await _service.FaceDetectionAsync(request);

            // Assert
            Assert.IsType<FaceDetectionResponse>(response);

            VerifyPostMultipart<FaceDetectionResponse>();
            base.ServiceMock.VerifyNoOtherCalls();
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
            var response = await _service.FaceDetectionAsync(request);

            // Assert
            Assert.NotNull(response);

            VerifyPostMultipart<FaceDetectionResponse>();
            base.ServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task FaceDetectionAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Arrange
            SetupPostMultipart<FaceDetectionResponse>();

            // Act
            var func = async () => await _service.FaceDetectionAsync(null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task FaceDetectionAsync_TakesIncorrectRequestModel_ThrowsArgumentNullException()
        {
            // Arrange
            var request = new FaceDetectionRequest();

            SetupPostMultipart<FaceDetectionResponse>();

            // Act
            var func = async () => await _service.FaceDetectionAsync(request);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(func);
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
            var response = await _service.FaceDetectionBase64Async(request);

            // Assert
            Assert.IsType<FaceDetectionResponse>(response);

            VerifyPostJson<FaceDetectionResponse, Url>();
            base.ServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task FaceDetectionBase64Async_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            var request = new FaceDetectionBase64Request()
            {
                FacePlugins = new List<string>()
            };

            SetupPostJson<FaceDetectionResponse, Url>();

            // Act
            var response = await _service.FaceDetectionBase64Async(request);

            // Assert
            Assert.NotNull(response);

            VerifyPostJson<FaceDetectionResponse, Url>();
            ServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task FaceDetectionBase64Async_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Arrange
            SetupPostJson<FaceDetectionResponse, Url>();

            // Act
            var func = async () => await _service.FaceDetectionBase64Async(null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task FaceDetectionBase64Async_TakesIncorrectRequestModel_ThrowsArgumentNullException()
        {
            // Arrange
            var request = new FaceDetectionBase64Request();

            SetupPostJson<FaceDetectionResponse, Url>();

            // Act
            var func = async () => await _service.FaceDetectionBase64Async(request);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(func);
        }
    }
}
