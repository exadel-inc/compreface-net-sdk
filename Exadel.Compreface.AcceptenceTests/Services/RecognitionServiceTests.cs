using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFaceFromImage;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFacesFromImageWithBase64;
using Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImage;
using Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImageWithBase64;
using Exadel.Compreface.Services;

namespace Exadel.Compreface.AcceptenceTests.Services
{
    public class RecognitionServiceTests
    {
        private const string BASE_URL = "http://localhost:8000/api/v1/";
        private const string API_KEY = "1c4ed2f6-beb6-45c0-8126-547d26bde205";
        private const string FILE_PATH = @"..\..\..\Resources\Images\brad-pitt_24.jpg";
        private const string FILE_NAME = "brad-pitt_24.jpg";

        private RecognitionService _recognitionService;

        private RecognizeFaceFromImageRequest _request;
        private RecognizeFacesFromImageWithBase64Request _request64;

        private VerifyFacesFromImageRequest _verifyRequest;
        private VerifyFacesFromImageWithBase64Request _verifyRequest64;

        public RecognitionServiceTests()
        {
            var configuration = new ComprefaceConfiguration(API_KEY, BASE_URL);
            var client = new ComprefaceClient(configuration);
            var imageId = "f7588e3d-f7ed-4e6f-8b9e-8580d30e8a2c";
            var detProbThreshold = 0.85m;
            var status = true;
            var facePlugins = new List<string>()
            {
                "landmarks",
                "gender",
                "age",
                "detector",
                "calculator"
            };

            _recognitionService = client.RecognitionService;
            _request = new RecognizeFaceFromImageRequest
            {
                FileName = FILE_NAME,
                FilePath = FILE_PATH,
                DetProbThreshold = detProbThreshold,
                FacePlugins = facePlugins,
                Status = status,
            };
            _request64 = new RecognizeFacesFromImageWithBase64Request()
            {
                FileBase64Value = Convert.ToBase64String(File.ReadAllBytes(FILE_PATH)),
                DetProbThreshold = detProbThreshold,
                FacePlugins = facePlugins,
                Status = status,
            };
            _verifyRequest = new VerifyFacesFromImageRequest()
            {
                FileName = FILE_NAME,
                FilePath = FILE_PATH,
                DetProbThreshold = detProbThreshold,
                FacePlugins = facePlugins,
                Status = status,
                ImageId = new Guid(imageId)
            };
            _verifyRequest64 = new VerifyFacesFromImageWithBase64Request()
            {
                FileBase64Value = Convert.ToBase64String(File.ReadAllBytes(FILE_PATH)),
                DetProbThreshold = detProbThreshold,
                FacePlugins = facePlugins,
                Status = status,
                ImageId = new Guid(imageId)
            };
        }

        [Fact]
        public async void RecognizeFaceFromImage_TakesRequestModel_ReturnsModelWithProperType()
        {
            // Act
            var response = await _recognitionService.RecognizeFaceFromImage(_request);

            // Assert
            Assert.IsType<RecognizeFaceFromImageResponse>(response);
        }

        [Fact]
        public async void RecognizeFaceFromImage_TakesRequestModel_ReturnsNotNull()
        {
            // Act
            var response = await _recognitionService.RecognizeFaceFromImage(_request);

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async void RecognizeFaceFromImage_TakesNullRequest_ThrowsException()
        {
            // Act
            var func = async () => await _recognitionService.RecognizeFaceFromImage(null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async void RecognizeFaceFromBase64File_TakesRequestModel_ReturnsModelWithProperType()
        {
            // Act
            var response = await _recognitionService.RecognizeFaceFromBase64File(_request64);

            // Assert
            Assert.IsType<RecognizeFaceFromImageResponse>(response);
        }

        [Fact]
        public async void RecognizeFaceFromBase64File_TakesRequestModel_ReturnsNotNull()
        {
            // Act
            var response = await _recognitionService.RecognizeFaceFromBase64File(_request64);

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async void RecognizeFaceFromBase64File_TakesNullRequest_ThrowsException()
        {
            // Act
            var func = async () => await _recognitionService.RecognizeFaceFromBase64File(null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async void VerifyFacesFromImage_TakesRequestModel_ReturnsModelWithProperType()
        {
            // Act
            var response = await _recognitionService.VerifyFacesFromImage(_verifyRequest);

            // Assert
            Assert.IsType<VerifyFacesFromImageResponse>(response);
        }

        [Fact]
        public async void VerifyFacesFromImage_TakesRequestModel_ReturnsNotNull()
        {
            // Act
            var response = await _recognitionService.VerifyFacesFromImage(_verifyRequest);

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async void VerifyFacesFromImage_TakesNullRequest_ThrowsException()
        {
            // Act
            var func = async () => await _recognitionService.VerifyFacesFromImage(null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async void VerifyFacesFromBase64File_TakesRequestModel_ReturnsModelWithProperType()
        {
            // Act
            var response = await _recognitionService.VerifyFacesFromBase64File(_verifyRequest64);

            // Assert
            Assert.IsType<VerifyFacesFromImageResponse>(response);
        }

        [Fact]
        public async void VerifyFacesFromBase64File_TakesRequestModel_ReturnsNotNull()
        {
            // Act
            var response = await _recognitionService.VerifyFacesFromBase64File(_verifyRequest64);

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async void VerifyFacesFromBase64File_TakesNullRequest_ThrowsException()
        {
            // Act
            var func = async () => await _recognitionService.VerifyFacesFromBase64File(null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }
    }
}
