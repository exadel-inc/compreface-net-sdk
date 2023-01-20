using Exadel.Compreface.Clients;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.FaceVerificationDTOs;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerification;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerificationWithBase64;
using Exadel.Compreface.Services;
using static Exadel.Compreface.FaceVerivicationServiceTest.UrlConstConfig;

namespace Exadel.Compreface.FaceVerivicationServiceTest.Services
{
    public class FaceVerificationServiceTest
    {
        private readonly FaceVerificationService _faceVerificationService;

        private readonly FaceVerificationRequest _faceVerificationRequest;
        private readonly FaceVerificationWithBase64Request _faceVerificationBase64Request;

        public FaceVerificationServiceTest()
        {
            var configuration = new ComprefaceConfiguration(API_KEY_VERIFICATION_SERVICE, DOMAIN, PORT);
            var client = new FaceVerificationClient(configuration);
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

            _faceVerificationService = client.FaceVerificationService;
            _faceVerificationRequest = new FaceVerificationRequest
            {
                SourceImageFileName = FILE_NAME,
                SourceImageFilePath = FILE_PATH,
                TargetImageFileName = FILE_NAME,
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
        public async Task VerifyImageAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Act
            var response = await _faceVerificationService.VerifyImageAsync(_faceVerificationRequest);

            // Assert
            Assert.IsType<FaceVerificationResponse>(response);
        }

        [Fact]
        public async Task VerifyImageAsync_TakesRequestModel_ReturnsNotNull()
        {
            // Act
            var response = await _faceVerificationService.VerifyImageAsync(_faceVerificationRequest);

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async void VerifyImageAsync_TakesNullRequest_ThrowsException()
        {
            // Act
            var func = async () => await _faceVerificationService.VerifyImageAsync(null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task VerifyBase64ImageAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Act
            var response = await _faceVerificationService.VerifyBase64ImageAsync(_faceVerificationBase64Request);

            // Assert
            Assert.IsType<FaceVerificationResponse>(response);
        }

        [Fact]
        public async Task VerifyBase64ImageAsync_TakesRequestModel_ReturnsNotNull()
        {
            // Act
            var response = await _faceVerificationService.VerifyBase64ImageAsync(_faceVerificationBase64Request);

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async void VerifyBase64ImageAsync_TakesNullRequest_ThrowsException()
        {
            // Act
            var func = async () => await _faceVerificationService.VerifyBase64ImageAsync(null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }
    }
}
