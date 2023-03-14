﻿using Exadel.Compreface.Clients.CompreFaceClient;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.AddSubjectExample;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFaceFromImage;
using Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImage;
using Exadel.Compreface.DTOs.RecognizeFaceFromImageDTOs.RecognizeFaceFromImage;
using Exadel.Compreface.DTOs.RecognizeFaceFromImageDTOs.VerifyFacesFromImage;
using Exadel.Compreface.DTOs.SubjectDTOs.AddSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteSubject;
using Exadel.Compreface.Exceptions;
using Exadel.Compreface.Services.Interfaces;
using Exadel.Compreface.Services.RecognitionService;
using static Exadel.Compreface.AcceptenceTests.UrlConstConfig;

namespace Exadel.Compreface.AcceptenceTests.Services.RecognitionServiceTests
{
    public class RecognizeFaceFromImageTest
    {
        private readonly ISubject _subjectSubService;
        private readonly IFaceCollection _faceCollectionSubService;
        private readonly IRecognizeFaceFromImage _recognizeFaceFromImageSubService;

        private readonly AddSubjectRequest _addSubjectRequest;
        private readonly DeleteSubjectRequest _deleteSubjectRequest;

        private readonly AddSubjectExampleRequestByFilePath _addSubjectExampleRequest;

        private readonly RecognizeFaceFromImageRequestByFilePath _requestFromFile;
        private readonly RecognizeFaceFromImageRequestByFileUrl _requestFromURL;
        private readonly RecognizeFacesFromImageWithBase64Request _request64;

        private readonly VerifyFacesFromImageByFilePathRequest _verifyRequest;
        private readonly VerifyFacesFromImageWithBase64Request _verifyRequest64;
        private readonly VerifyFacesFromImageByFileUrlRequest _verifyByUrlRequest;
        public RecognizeFaceFromImageTest()
        {
            var client = new CompreFaceClient(DOMAIN, PORT);

            var recognitionService = client.GetCompreFaceService<RecognitionService>(API_KEY_RECOGNITION_SERVICE);

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

            _subjectSubService = recognitionService.Subject;
            _faceCollectionSubService = recognitionService.FaceCollection;
            _recognizeFaceFromImageSubService = recognitionService.RecognizeFaceFromImage;

            _addSubjectRequest = new AddSubjectRequest
            {
                Subject = subjectName
            };

            _deleteSubjectRequest = new DeleteSubjectRequest
            {
                ActualSubject = subjectName
            };

            _addSubjectExampleRequest = new AddSubjectExampleRequestByFilePath
            {
                Subject = subjectName,
                FilePath = FILE_PATH,
                DetProbThreShold = detProbThreshold
            };

            _requestFromFile = new RecognizeFaceFromImageRequestByFilePath
            {
                FilePath = FILE_PATH,
                DetProbThreshold = detProbThreshold,
                FacePlugins = facePlugins,
                Status = status,
            };

            _requestFromURL = new RecognizeFaceFromImageRequestByFileUrl
            {
                FileUrl = FILE_URL,
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

            _verifyRequest = new VerifyFacesFromImageByFilePathRequest()
            {
                FilePath = FILE_PATH,
                DetProbThreshold = detProbThreshold,
                FacePlugins = facePlugins,
                Status = status,
            };

            _verifyByUrlRequest = new VerifyFacesFromImageByFileUrlRequest()
            {
                FileUrl = FILE_URL,
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
            var response = await _recognizeFaceFromImageSubService.RecognizeAsync(_requestFromFile);

            // Assert
            Assert.IsType<RecognizeFaceFromImageResponse>(response);
        }

        [Fact]
        public async Task RecognizeAsync_TakesRequestModel_ReturnsNotNull()
        {
            // Act
            var response = await _recognizeFaceFromImageSubService.RecognizeAsync(_requestFromFile);

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task RecognizeAsync_TakesNullRequest_ThrowsException()
        {
            // Act
            var func = async () => await _recognizeFaceFromImageSubService.RecognizeAsync((RecognizeFaceFromImageRequestByFilePath)null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task RecognizeAsync_TakesNullRequest_ThrowsServiceException()
        {
            //Arrange
            var request = new RecognizeFaceFromImageRequestByFilePath
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
            var func = async () => await _recognizeFaceFromImageSubService.RecognizeAsync(request);

            // Assert
            await Assert.ThrowsAsync<ServiceException>(func);
        }

        [Fact]
        public async Task RecognizeFromURLAsync_TakesRequestModel_ReturnsModelWithProperType()
        {
            // Act
            var response = await _recognizeFaceFromImageSubService.RecognizeAsync(_requestFromURL);

            // Assert
            Assert.IsType<RecognizeFaceFromImageResponse>(response);
        }

        [Fact]
        public async Task RecognizeFromURLAsync_TakesRequestModel_ReturnsNotNull()
        {
            // Act
            var response = await _recognizeFaceFromImageSubService.RecognizeAsync(_requestFromURL);

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task RecognizeFromURLAsync_TakesNullRequest_ThrowsException()
        {
            // Act
            var func = async () => await _recognizeFaceFromImageSubService.RecognizeAsync((RecognizeFaceFromImageRequestByFileUrl)null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task RecognizeFromURLAsync_TakesNullRequest_ThrowsServiceException()
        {
            //Arrange
            var request = new RecognizeFaceFromImageRequestByFileUrl
            {
                FileUrl = WRONG_FILE_URL,
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
            var func = async () => await _recognizeFaceFromImageSubService.RecognizeAsync(request);

            // Assert
            await Assert.ThrowsAsync<ServiceException>(func);
        }

        [Fact]
        public async Task RecognizeBase64Async_TakesRequestModel_ReturnsModelWithProperType()
        {
            // Act
            var response = await _recognizeFaceFromImageSubService.RecognizeAsync(_request64);

            // Assert
            Assert.IsType<RecognizeFaceFromImageResponse>(response);
        }

        [Fact]
        public async Task RecognizeBase64Async_TakesRequestModel_ReturnsNotNull()
        {
            // Act
            var response = await _recognizeFaceFromImageSubService.RecognizeAsync(_request64);

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task RecognizeBase64Async_TakesNullRequest_ThrowsException()
        {
            // Act
            var func = async () => await _recognizeFaceFromImageSubService.RecognizeAsync((RecognizeFacesFromImageWithBase64Request)null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
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
            var func = async () => await _recognizeFaceFromImageSubService.RecognizeAsync(request);

            // Assert
            await Assert.ThrowsAsync<ServiceException>(func);
        }

        [Fact]
        public async Task VerifyAsync_TakesRequestModel_ReturnsModelWithProperType()
        {
            // Assert
            await _subjectSubService.AddAsync(_addSubjectRequest);
            var addExampleResponse = await _faceCollectionSubService.AddAsync(_addSubjectExampleRequest);
            _verifyRequest.ImageId = addExampleResponse.ImageId;

            // Act
            var response = await _recognizeFaceFromImageSubService.VerifyAsync(_verifyRequest);

            // Assert
            Assert.IsType<VerifyFacesFromImageResponse>(response);
            await _subjectSubService.DeleteAsync(_deleteSubjectRequest);
        }

        [Fact]
        public async Task VerifyAsync_TakesRequestModel_ReturnsNotNull()
        {
            // Assert
            await _subjectSubService.AddAsync(_addSubjectRequest);
            var addExampleResponse = await _faceCollectionSubService.AddAsync(_addSubjectExampleRequest);
            _verifyRequest.ImageId = addExampleResponse.ImageId;

            // Act
            var response = await _recognizeFaceFromImageSubService.VerifyAsync(_verifyRequest);

            // Assert
            Assert.NotNull(response);
            await _subjectSubService.DeleteAsync(_deleteSubjectRequest);
        }

        [Fact]
        public async Task VerifyAsync_TakesNullRequest_ThrowsException()
        {
            // Act
            var func = async () => await _recognizeFaceFromImageSubService.VerifyAsync((VerifyFacesFromImageByFilePathRequest)null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task VerifyAsync_TakesNullRequest_ThrowsServiceException()
        {
            //Arrange
            var verifyRequest = new VerifyFacesFromImageByFilePathRequest()
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
            var func = async () => await _recognizeFaceFromImageSubService.VerifyAsync(verifyRequest);

            // Assert
            await Assert.ThrowsAsync<ServiceException>(func);
        }

        [Fact]
        public async Task VerifyBase64Async_TakesRequestModel_ReturnsModelWithProperType()
        {
            // Assert
            await _subjectSubService.AddAsync(_addSubjectRequest);
            var addExampleResponse = await _faceCollectionSubService.AddAsync(_addSubjectExampleRequest);
            _verifyRequest64.ImageId = addExampleResponse.ImageId;

            // Act
            var verifyResponse = await _recognizeFaceFromImageSubService.VerifyAsync(_verifyRequest64);

            // Assert
            Assert.IsType<VerifyFacesFromImageResponse>(verifyResponse);
            await _subjectSubService.DeleteAsync(_deleteSubjectRequest);
        }

        [Fact]
        public async Task VerifyBase64Async_TakesRequestModel_ReturnsNotNull()
        {
            // Assert
            await _subjectSubService.AddAsync(_addSubjectRequest);
            var addExampleResponse = await _faceCollectionSubService.AddAsync(_addSubjectExampleRequest);
            _verifyRequest64.ImageId = addExampleResponse.ImageId;

            // Act
            var response = await _recognizeFaceFromImageSubService.VerifyAsync(_verifyRequest64);

            // Assert
            Assert.NotNull(response);
            await _subjectSubService.DeleteAsync(_deleteSubjectRequest);
        }

        [Fact]
        public async Task VerifyBase64Async_TakesNullRequest_ThrowsException()
        {
            // Act
            var func = async () => await _recognizeFaceFromImageSubService.VerifyAsync((VerifyFacesFromImageWithBase64Request)null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
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
            var func = async () => await _recognizeFaceFromImageSubService.VerifyAsync(verifyRequest);

            // Assert
            await Assert.ThrowsAsync<ServiceException>(func);
        }

        [Fact]
        public async Task VerifyFromUrlAsync_TakesRequestModel_ReturnsModelWithProperType()
        {
            // Assert
            await _subjectSubService.AddAsync(_addSubjectRequest);
            var addExampleResponse = await _faceCollectionSubService.AddAsync(_addSubjectExampleRequest);
            _verifyByUrlRequest.ImageId = addExampleResponse.ImageId;

            // Act
            var verifyResponse = await _recognizeFaceFromImageSubService.VerifyAsync(_verifyByUrlRequest);

            // Assert
            Assert.IsType<VerifyFacesFromImageResponse>(verifyResponse);
            await _subjectSubService.DeleteAsync(_deleteSubjectRequest);
        }

        [Fact]
        public async Task VerifyFromUrlAsync_TakesRequestModel_ReturnsNotNull()
        {
            // Assert
            await _subjectSubService.AddAsync(_addSubjectRequest);
            var addExampleResponse = await _faceCollectionSubService.AddAsync(_addSubjectExampleRequest);
            _verifyByUrlRequest.ImageId = addExampleResponse.ImageId;

            // Act
            var response = await _recognizeFaceFromImageSubService.VerifyAsync(_verifyByUrlRequest);

            // Assert
            Assert.NotNull(response);
            await _subjectSubService.DeleteAsync(_deleteSubjectRequest);
        }

        [Fact]
        public async Task VerifyFromUrlAsync_TakesNullRequest_ThrowsException()
        {
            // Act
            var func = async () => await _recognizeFaceFromImageSubService.VerifyAsync((VerifyFacesFromImageByFileUrlRequest)null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task VerifyFromUrlAsync_TakesNullRequest_ThrowsServiceException()
        {
            //Arrange
            var verifyRequest = new VerifyFacesFromImageByFileUrlRequest()
            {
                FileUrl = WRONG_FILE_URL,
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
            var func = async () => await _recognizeFaceFromImageSubService.VerifyAsync(verifyRequest);

            // Assert
            await Assert.ThrowsAsync<ServiceException>(func);
        }
    }
}
