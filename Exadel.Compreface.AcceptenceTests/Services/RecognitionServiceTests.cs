using Exadel.Compreface.Clients;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddExampleSubject;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFaceFromImage;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFacesFromImageWithBase64;
using Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImage;
using Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImageWithBase64;
using Exadel.Compreface.DTOs.SubjectDTOs.AddSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteSubject;
using Exadel.Compreface.Exceptions;
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
            var client = new CompreFaceClient(configuration);
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

            _subjectService = client.GetService<SubjectService>(API_KEY_RECOGNITION_SERVICE);
            _subjectExampleService = client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE);
            _recognitionService = client.GetService<RecognitionService>(API_KEY_RECOGNITION_SERVICE);

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
        public async Task RecognizeAsync_TakesRequestModel_ReturnsModelWithProperType()
        {
            // Act
            var response = await _recognitionService.RecognizeAsync(_request);

            // Assert
            Assert.IsType<RecognizeFaceFromImageResponse>(response);
        }

        [Fact]
        public async Task RecognizeAsync_TakesRequestModel_ReturnsNotNull()
        {
            // Act
            var response = await _recognitionService.RecognizeAsync(_request);

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task RecognizeAsync_TakesNullRequest_ThrowsArgumentNullException()
        {
            // Act
            var func = async () => await _recognitionService.RecognizeAsync(null!);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(func);
        }

        [Fact]
        public async Task RecognizeAsync_TakesNullRequest_ThrowsServiceException()
        {
            //Arrange
            var request = new RecognizeFaceFromImageRequest
            {
                FilePath = PATH_OF_WRONG_FILE,
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
            };

            // Act
            var func = async () => await _recognitionService.RecognizeAsync(request);

            // Assert
            await Assert.ThrowsAsync<ServiceException>(func);
        }

        [Fact]
        public async Task RecognizeBase64Async_TakesRequestModel_ReturnsModelWithProperType()
        {
            // Act
            var response = await _recognitionService.RecognizeAsync(_request64);

            // Assert
            Assert.IsType<RecognizeFaceFromImageResponse>(response);
        }

        [Fact]
        public async Task RecognizeBase64Async_TakesRequestModel_ReturnsNotNull()
        {
            // Act
            var response = await _recognitionService.RecognizeAsync(_request64);

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task RecognizeBase64Async_TakesNullRequest_ThrowsArgumentNullException()
        {
            // Act
            var func = async () => await _recognitionService.RecognizeAsync(null!);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(func);
        }

        [Fact]
        public async Task RecognizeBase64Async_TakesNullRequest_ThrowsServiceException()
        {
            //Arrange
            var request = new RecognizeFacesFromImageWithBase64Request
            {
                FileBase64Value = WRONG_BASE64_IMAGE,
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
            };

            // Act
            var func = async () => await _recognitionService.RecognizeAsync(request);

            // Assert
            await Assert.ThrowsAsync<ServiceException>(func);
        }

        [Fact]
        public async Task VerifyAsync_TakesRequestModel_ReturnsModelWithProperType()
        {
            // Assert
            await _subjectService.AddAsync(_addSubjectRequest);
            var addExampleResponse = await _subjectExampleService.AddAsync(_addSubjectExampleRequest);
            _verifyRequest.ImageId = addExampleResponse.ImageId;

            // Act
            var response = await _recognitionService.VerifyAsync(_verifyRequest);

            // Assert
            Assert.IsType<VerifyFacesFromImageResponse>(response);
            await _subjectService.DeleteAsync(_deleteSubjectRequest);
        }

        [Fact]
        public async Task VerifyAsync_TakesRequestModel_ReturnsNotNull()
        {
            // Assert
            await _subjectService.AddAsync(_addSubjectRequest);
            var addExampleResponse = await _subjectExampleService.AddAsync(_addSubjectExampleRequest);
            _verifyRequest.ImageId = addExampleResponse.ImageId;

            // Act
            var response = await _recognitionService.VerifyAsync(_verifyRequest);

            // Assert
            Assert.NotNull(response);
            await _subjectService.DeleteAsync(_deleteSubjectRequest);
        }

        [Fact]
        public async Task VerifyAsync_TakesNullRequest_ThrowsArgumentNullException()
        {
            // Act
            var func = async () => await _recognitionService.VerifyAsync((VerifyFacesFromImageRequest)null!);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(func);
        }

        [Fact]
        public async Task VerifyAsync_TakesNullRequest_ThrowsServiceException()
        {
            //Arrange
            var verifyRequest = new VerifyFacesFromImageRequest()
            {
                FilePath = TWO_FACES_IMAGE_PATH,
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
            };

            // Act
            var func = async () => await _recognitionService.VerifyAsync(verifyRequest);

            // Assert
            await Assert.ThrowsAsync<ServiceException>(func);
        }

        [Fact]
        public async Task VerifyBase64Async_TakesRequestModel_ReturnsModelWithProperType()
        {
            // Assert
            await _subjectService.AddAsync(_addSubjectRequest);
            var addExampleResponse = await _subjectExampleService.AddAsync(_addSubjectExampleRequest);
            _verifyRequest64.ImageId = addExampleResponse.ImageId;

            // Act
            var verifyResponse = await _recognitionService.VerifyAsync(_verifyRequest64);

            // Assert
            Assert.IsType<VerifyFacesFromImageResponse>(verifyResponse);
            await _subjectService.DeleteAsync(_deleteSubjectRequest);
        }

        [Fact]
        public async Task VerifyBase64Async_TakesRequestModel_ReturnsNotNull()
        {
            // Assert
            await _subjectService.AddAsync(_addSubjectRequest);
            var addExampleResponse = await _subjectExampleService.AddAsync(_addSubjectExampleRequest);
            _verifyRequest64.ImageId = addExampleResponse.ImageId;

            // Act
            var response = await _recognitionService.VerifyAsync(_verifyRequest64);

            // Assert
            Assert.NotNull(response);
            await _subjectService.DeleteAsync(_deleteSubjectRequest);
        }

        [Fact]
        public async Task VerifyBase64Async_TakesNullRequest_ThrowsArgumentNullException()
        {
            // Act
            var func = async () => await _recognitionService.VerifyAsync((VerifyFacesFromImageWithBase64Request)null!);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(func);
        }

        [Fact]
        public async Task VerifyBase64Async_TakesNullRequest_ThrowsServiceException()
        {
            //Arrange
            var verifyRequest = new VerifyFacesFromImageWithBase64Request()
            {
                FileBase64Value = TWO_FACES_IMAGE_BASE64,
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
            };

            // Act
            var func = async () => await _recognitionService.VerifyAsync(verifyRequest);

            // Assert
            await Assert.ThrowsAsync<ServiceException>(func);
        }
    }
}
