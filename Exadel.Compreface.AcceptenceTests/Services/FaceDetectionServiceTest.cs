﻿using Exadel.Compreface.Clients;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetection;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetectionBase64;
using Exadel.Compreface.Services;
using static Exadel.Compreface.AcceptenceTests.UrlConstConfig;

namespace Exadel.Compreface.AcceptenceTests.Services
{
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
        public async Task DetectAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Act
            var response = await _faceDetectionService.DetectAsync(_faceDetectionRequest);

            // Assert
            Assert.IsType<FaceDetectionResponse>(response);
        }

        [Fact]
        public async Task DetectAsync_TakesRequestModel_ReturnsNotNull()
        {
            // Act
            var response = await _faceDetectionService.DetectAsync(_faceDetectionRequest);

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task DetectAsync_TakesNullRequest_ThrowsException()
        {
            // Act
            var func = async () => await _faceDetectionService.DetectAsync((FaceDetectionRequest)null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task DetectBase64Async_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Act
            var response = await _faceDetectionService.DetectAsync(_faceDetectionBase64Request);

            // Assert
            Assert.IsType<FaceDetectionResponse>(response);
        }

        [Fact]
        public async Task DetectBase64Async_TakesRequestModel_ReturnsNotNull()
        {
            // Act
            var response = await _faceDetectionService.DetectAsync(_faceDetectionBase64Request);

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task DetectBase64Async_TakesNullRequest_ThrowsException()
        {
            // Act
            var func = async () => await _faceDetectionService.DetectAsync((FaceDetectionBase64Request)null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }
    }
}
