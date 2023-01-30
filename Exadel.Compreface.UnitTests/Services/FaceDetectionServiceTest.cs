﻿using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetection;
using Exadel.Compreface.Services;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetectionBase64;
using Flurl;

namespace Exadel.Compreface.UnitTests.Services
{
    public class FaceDetectionServiceTest : AbstractBaseServiceTests
    {
        private readonly FaceDetectionService _faceDetectionService;

        public FaceDetectionServiceTest()
        {
            _faceDetectionService = new FaceDetectionService(Configuration, ApiClientMock.Object);
        }

        [Fact]
        public async Task DetectAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new FaceDetectionRequest()
            {
                FacePlugins = new List<string>()
            };

            SetupPostMultipart<FaceDetectionResponse>();

            // Act
            var response = await _faceDetectionService.DetectAsync(request);

            // Assert
            Assert.IsType<FaceDetectionResponse>(response);

            VerifyPostMultipart<FaceDetectionResponse>();
            ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DetectAsync_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            var request = new FaceDetectionRequest()
            {
                FacePlugins = new List<string>()
            };

            SetupPostMultipart<FaceDetectionResponse>();

            // Act
            var response = await _faceDetectionService.DetectAsync(request);

            // Assert
            Assert.NotNull(response);

            VerifyPostMultipart<FaceDetectionResponse>();
            ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DetectAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Arrange
            SetupPostMultipart<FaceDetectionResponse>();

            // Act
            var func = async () => await _faceDetectionService.DetectAsync((FaceDetectionRequest)null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task DetectBase64Async_TakesRequestModel_ReturnsProperResponseModel()
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

            VerifyPostJson<FaceDetectionResponse, Url>();
            ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DetectBase64Async_TakesRequestModel_ReturnsNotNull()
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
            Assert.NotNull(response);

            VerifyPostJson<FaceDetectionResponse, Url>();
            ApiClientMock.VerifyNoOtherCalls();
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

        [Fact]
        public async Task FaceDetectionBase64Async_TakesIncorrectRequestModel_ThrowsArgumentNullException()
        {
            // Arrange
            var request = new FaceDetectionBase64Request();

            SetupPostJson<FaceDetectionResponse, Url>();

            // Act
            var func = async () => await _faceDetectionService.FaceDetectionBase64Async(request);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(func);
        }
    }
}
