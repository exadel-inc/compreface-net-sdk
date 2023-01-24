using Exadel.Compreface.Clients;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddExampleSubject;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFaceFromImage;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFacesFromImageWithBase64;
using Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImage;
using Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImageWithBase64;
using Exadel.Compreface.DTOs.SubjectDTOs.AddSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteSubject;
using Exadel.Compreface.Services;
using static Exadel.Compreface.AcceptenceTests.UrlConstConfig;

namespace Exadel.Compreface.AcceptenceTests.Services
{
    public class RecognitionServiceTests
    {
        private readonly SubjectService _subjectService;
        private readonly SubjectExampleService _subjectExampleService;
        private readonly RecognitionService _recognitionService;

        private readonly AddSubjectRequest _addSubjectRequest;
        private readonly DeleteSubjectRequest _deleteSubjectRequest;

        private readonly AddSubjectExampleRequest _addSubjectExampleRequest;

        private readonly RecognizeFaceFromImageRequest _request;
        private readonly RecognizeFacesFromImageWithBase64Request _request64;

        private readonly VerifyFacesFromImageRequest _verifyRequest;
        private readonly VerifyFacesFromImageWithBase64Request _verifyRequest64;

        public RecognitionServiceTests()
        {
            var configuration = new ComprefaceConfiguration(API_KEY_RECOGNITION_SERVICE, DOMAIN, PORT);
            var client = new FaceRecognitionClient(configuration);
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
            var subjectName = TEST_SUBJECT_RECOGNITION_NAME;

            _subjectService = client.SubjectService;
            _subjectExampleService = client.SubjectExampleService;
            _recognitionService = client.RecognitionService;

            _addSubjectRequest = new AddSubjectRequest
            {
                Subject = subjectName
            };
            _deleteSubjectRequest = new DeleteSubjectRequest
            {
                ActualSubject = subjectName
            };

            _addSubjectExampleRequest = new AddSubjectExampleRequest
            {
                Subject = subjectName,
                File = FILE_PATH,
                DetProbThreShold = detProbThreshold
            };

            _request = new RecognizeFaceFromImageRequest
            {
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
                FilePath = FILE_PATH,
                DetProbThreshold = detProbThreshold,
                FacePlugins = facePlugins,
                Status = status,
            };
            _verifyRequest64 = new VerifyFacesFromImageWithBase64Request()
            {
                FileBase64Value = Convert.ToBase64String(File.ReadAllBytes(FILE_PATH)),
                DetProbThreshold = detProbThreshold,
                FacePlugins = facePlugins,
                Status = status,
            };
        }

        [Fact]
        public async Task RecognizeFaceFromImage_TakesRequestModel_ReturnsModelWithProperType()
        {
            // Act
            var response = await _recognitionService.RecognizeFaceFromImage(_request);

            // Assert
            Assert.IsType<RecognizeFaceFromImageResponse>(response);
        }

        [Fact]
        public async Task RecognizeFaceFromImage_TakesRequestModel_ReturnsNotNull()
        {
            // Act
            var response = await _recognitionService.RecognizeFaceFromImage(_request);

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task RecognizeFaceFromImage_TakesNullRequest_ThrowsException()
        {
            // Act
            var func = async () => await _recognitionService.RecognizeFaceFromImage(null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task RecognizeFaceFromBase64File_TakesRequestModel_ReturnsModelWithProperType()
        {
            // Act
            var response = await _recognitionService.RecognizeFaceFromBase64File(_request64);

            // Assert
            Assert.IsType<RecognizeFaceFromImageResponse>(response);
        }

        [Fact]
        public async Task RecognizeFaceFromBase64File_TakesRequestModel_ReturnsNotNull()
        {
            // Act
            var response = await _recognitionService.RecognizeFaceFromBase64File(_request64);

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task RecognizeFaceFromBase64File_TakesNullRequest_ThrowsException()
        {
            // Act
            var func = async () => await _recognitionService.RecognizeFaceFromBase64File(null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task VerifyFacesFromImage_TakesRequestModel_ReturnsModelWithProperType()
        {
            // Assert
            await _subjectService.AddSubject(_addSubjectRequest);
            var addExampleResponse = await _subjectExampleService.AddSubjectExampleAsync(_addSubjectExampleRequest);
            _verifyRequest.ImageId = addExampleResponse.ImageId;

            // Act
            var response = await _recognitionService.VerifyFacesFromImage(_verifyRequest);

            // Assert
            Assert.IsType<VerifyFacesFromImageResponse>(response);
            await _subjectService.DeleteSubject(_deleteSubjectRequest);
        }

        [Fact]
        public async Task VerifyFacesFromImage_TakesRequestModel_ReturnsNotNull()
        {
            // Assert
            await _subjectService.AddSubject(_addSubjectRequest);
            var addExampleResponse = await _subjectExampleService.AddSubjectExampleAsync(_addSubjectExampleRequest);
            _verifyRequest.ImageId = addExampleResponse.ImageId;

            // Act
            var response = await _recognitionService.VerifyFacesFromImage(_verifyRequest);

            // Assert
            Assert.NotNull(response);
            await _subjectService.DeleteSubject(_deleteSubjectRequest);
        }

        [Fact]
        public async Task VerifyFacesFromImage_TakesNullRequest_ThrowsException()
        {
            // Act
            var func = async () => await _recognitionService.VerifyFacesFromImage(null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task VerifyFacesFromBase64File_TakesRequestModel_ReturnsModelWithProperType()
        {
            // Assert
            await _subjectService.AddSubject(_addSubjectRequest);
            var addExampleResponse = await _subjectExampleService.AddSubjectExampleAsync(_addSubjectExampleRequest);
            _verifyRequest64.ImageId = addExampleResponse.ImageId;

            // Act
            var verifyResponse = await _recognitionService.VerifyFacesFromBase64File(_verifyRequest64);

            // Assert
            Assert.IsType<VerifyFacesFromImageResponse>(verifyResponse);
            await _subjectService.DeleteSubject(_deleteSubjectRequest);
        }

        [Fact]
        public async Task VerifyFacesFromBase64File_TakesRequestModel_ReturnsNotNull()
        {
            // Assert
            await _subjectService.AddSubject(_addSubjectRequest);
            var addExampleResponse = await _subjectExampleService.AddSubjectExampleAsync(_addSubjectExampleRequest);
            _verifyRequest64.ImageId = addExampleResponse.ImageId;

            // Act
            var response = await _recognitionService.VerifyFacesFromBase64File(_verifyRequest64);

            // Assert
            Assert.NotNull(response);
            await _subjectService.DeleteSubject(_deleteSubjectRequest);
        }

        [Fact]
        public async Task VerifyFacesFromBase64File_TakesNullRequest_ThrowsException()
        {
            // Act
            var func = async () => await _recognitionService.VerifyFacesFromBase64File(null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }
    }
}
