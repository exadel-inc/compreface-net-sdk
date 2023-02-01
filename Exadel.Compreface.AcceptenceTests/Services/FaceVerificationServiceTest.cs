using Exadel.Compreface.Clients;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.FaceVerificationDTOs;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerification;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerificationWithBase64;
using Exadel.Compreface.Exceptions;
using Exadel.Compreface.Services;
using static Exadel.Compreface.AcceptenceTests.UrlConstConfig;

namespace Exadel.Compreface.AcceptenceTests.Services
{
    public class FaceVerificationServiceTest
    {
        private readonly FaceVerificationService _faceVerificationService;

        private readonly FaceVerificationRequest _faceVerificationRequest;
        private readonly FaceVerificationWithBase64Request _faceVerificationBase64Request;

        public FaceVerificationServiceTest()
        {
            var configuration = new ComprefaceConfiguration(API_KEY_VERIFICATION_SERVICE, DOMAIN, PORT);
            var client = new CompreFaceClient(configuration);
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

            _faceVerificationService = client.GetService<FaceVerificationService>(API_KEY_VERIFICATION_SERVICE);
            _faceVerificationRequest = new FaceVerificationRequest
            {
                SourceImageFilePath = FILE_PATH,
                TargetImageFilePath = FILE_PATH,
                DetProbThreshold = detProbThreshold,
                FacePlugins = facePlugins,
                Status = status,
                Limit = limit
            };

            _faceVerificationBase64Request = new FaceVerificationWithBase64Request()
            {
                SourceImageWithBase64 = IMAGE_BASE64_STRING,
                TargetImageWithBase64 = IMAGE_BASE64_STRING,
                DetProbThreshold = detProbThreshold,
                FacePlugins = facePlugins,
                Status = status,
                Limit = limit
            };
        }

        [Fact]
        public async Task VerifyAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Act
            var response = await _faceVerificationService.VerifyAsync(_faceVerificationRequest);

            // Assert
            Assert.IsType<FaceVerificationResponse>(response);
        }

        [Fact]
        public async Task VerifyAsync_TakesRequestModel_ReturnsNotNull()
        {
            // Act
            var response = await _faceVerificationService.VerifyAsync(_faceVerificationRequest);

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task VerifyAsync_TakesNullRequest_ThrowsException()
        {
            // Act
            var func = async () => await _faceVerificationService.VerifyAsync((FaceVerificationRequest)null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task VerifyAsync_TakesNullRequest_ThrowsServiceException()
        {
            //Arrange
            var request = new FaceVerificationRequest
            {
                SourceImageFilePath = TWO_FACES_IMAGE_PATH,
                TargetImageFilePath = FILE_PATH,
                DetProbThreshold = 0.81m,
                FacePlugins = new List<string>()
            {
                "landmarks",
                "gender",
                "age",
                "detector",
                "calculator"
            },
                Status = true,
                Limit = 0
            };

            // Act
            var func = async () => await _faceVerificationService.VerifyAsync(request);

            // Assert
            await Assert.ThrowsAsync<ServiceException>(func);
        }

        [Fact]
        public async Task VerifyBase64Async_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Act
            var response = await _faceVerificationService.VerifyAsync(_faceVerificationBase64Request);

            // Assert
            Assert.IsType<FaceVerificationResponse>(response);
        }

        [Fact]
        public async Task VerifyBase64Async_TakesRequestModel_ReturnsNotNull()
        {
            // Act
            var response = await _faceVerificationService.VerifyAsync(_faceVerificationBase64Request);

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task VerifyBase64Async_TakesNullRequest_ThrowsException()
        {
            // Act
            var func = async () => await _faceVerificationService.VerifyAsync((FaceVerificationWithBase64Request)null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task VerifyBase64Async_TakesNullRequest_ThrowsServiceException()
        {
            //Arrange
            var request = new FaceVerificationWithBase64Request()
            {
                SourceImageWithBase64 = TWO_FACES_IMAGE_BASE64,
                TargetImageWithBase64 = IMAGE_BASE64_STRING,
                DetProbThreshold = 0.81m,
                FacePlugins = new List<string>()
            {
                "landmarks",
                "gender",
                "age",
                "detector",
                "calculator"
            },
                Status = true,
                Limit = 0
            };

            // Act
            var func = async () => await _faceVerificationService.VerifyAsync(request);

            // Assert
            await Assert.ThrowsAsync<ServiceException>(func);
        }
    }
}
