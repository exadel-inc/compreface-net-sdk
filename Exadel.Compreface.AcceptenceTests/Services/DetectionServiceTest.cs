//using Exadel.Compreface.Clients.CompreFaceClient;
//using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetection;
//using Exadel.Compreface.Exceptions;
//using Exadel.Compreface.Services;
//using Exadel.Compreface.Services.Interfaces;
//using static Exadel.Compreface.AcceptenceTests.UrlConstConfig;

//namespace Exadel.Compreface.AcceptenceTests.Services
//{
//    public class DetectionServiceTest
//    {
//        private readonly IDetectionService _faceDetectionService;

//        private readonly FaceDetectionRequestByFilePath _faceDetectionRequest;
//        private readonly FaceDetectionBase64Request _faceDetectionBase64Request;
//        private readonly FaceDetectionRequestByFileUrl _faceDetectionFromURIRequest;


//        public DetectionServiceTest()
//        {
//            var client = new CompreFaceClient(DOMAIN, PORT);
//            var detProbThreshold = 0.85m;
//            var status = true;
//            var limit = 0;
//            var facePlugins = new List<string>()
//            {
//                "landmarks",
//                "gender",
//                "age",
//                "detector",
//                "calculator"
//            };

//            _faceDetectionService = client.GetCompreFaceService<DetectionService>(API_KEY_DETECTION_SERVICE);
//            _faceDetectionRequest = new FaceDetectionRequestByFilePath
//            {
//                FilePath = FILE_PATH,
//                DetProbThreshold = detProbThreshold,
//                FacePlugins = facePlugins,
//                Status = status,
//                Limit = limit
//            };

//            _faceDetectionFromURIRequest = new FaceDetectionRequestByFileUrl
//            {
//                FileUrl = FILE_URL,
//                DetProbThreshold = detProbThreshold,
//                FacePlugins = facePlugins,
//                Status = status,
//                Limit = limit
//            };

//            _faceDetectionBase64Request = new FaceDetectionBase64Request()
//            {
//                File = IMAGE_BASE64_STRING,
//                DetProbThreshold = detProbThreshold,
//                FacePlugins = facePlugins,
//                Status = status,
//                Limit = limit
//            };
//        }

//        [Fact]
//        public async Task DetectAsync_TakesRequestModel_ReturnsProperResponseModel()
//        {
//            // Act
//            var response = await _faceDetectionService.DetectAsync(_faceDetectionRequest);

//            // Assert
//            Assert.IsType<FaceDetectionResponse>(response);
//        }

//        [Fact]
//        public async Task DetectAsync_TakesRequestModel_ReturnsNotNull()
//        {
//            // Act
//            var response = await _faceDetectionService.DetectAsync(_faceDetectionRequest);

//            // Assert
//            Assert.NotNull(response);
//        }

//        [Fact]
//        public async Task DetectAsync_TakesNullRequest_ThrowsException()
//        {
//            // Act
//            var func = async () => await _faceDetectionService.DetectAsync((FaceDetectionRequestByFilePath)null!);

//            // Assert
//            await Assert.ThrowsAsync<NullReferenceException>(func);
//        }

//        [Fact]
//        public async Task DetectAsync_TakesNullRequest_ThrowsServiceException()
//        {
//            // Act
//            var detectRequest = new FaceDetectionRequestByFilePath()
//            {
//                FilePath = PATH_OF_WRONG_FILE,
//                DetProbThreshold = 0.81m,
//                FacePlugins = new List<string>()
//            {
//                "landmarks",
//                "gender",
//                "age",
//                "detector",
//                "calculator"
//            },
//                Status = true,
//                Limit = 0
//            };

//            // Act
//            var func = async () => await _faceDetectionService.DetectAsync(detectRequest);

//            // Assert
//            await Assert.ThrowsAsync<ServiceException>(func);
//        }

//        [Fact]
//        public async Task DetectBase64Async_TakesRequestModel_ReturnsProperResponseModel()
//        {
//            // Act
//            var response = await _faceDetectionService.DetectAsync(_faceDetectionBase64Request);

//            // Assert
//            Assert.IsType<FaceDetectionResponse>(response);
//        }

//        [Fact]
//        public async Task DetectBase64Async_TakesRequestModel_ReturnsNotNull()
//        {
//            // Act
//            var response = await _faceDetectionService.DetectAsync(_faceDetectionBase64Request);

//            // Assert
//            Assert.NotNull(response);
//        }

//        [Fact]
//        public async Task DetectBase64Async_TakesNullRequest_ThrowsException()
//        {
//            // Act
//            var func = async () => await _faceDetectionService.DetectAsync((FaceDetectionBase64Request)null!);

//            // Assert
//            await Assert.ThrowsAsync<NullReferenceException>(func);
//        }

//        [Fact]
//        public async Task DetectBase64Async_TakesNullRequest_ThrowsServiceException()
//        {
//            // Act
//            var detectRequest = new FaceDetectionBase64Request()
//            {
//                File = WRONG_BASE64_IMAGE,
//                DetProbThreshold = 0.81m,
//                FacePlugins = new List<string>()
//            {
//                "landmarks",
//                "gender",
//                "age",
//                "detector",
//                "calculator"
//            },
//                Status = true,
//                Limit = 0
//            };

//            // Act
//            var func = async () => await _faceDetectionService.DetectAsync(detectRequest);

//            // Assert
//            await Assert.ThrowsAsync<ServiceException>(func);
//        }

//        [Fact]
//        public async Task DetectFromURIAsync_TakesRequestModel_ReturnsProperResponseModel()
//        {
//            // Act
//            var response = await _faceDetectionService.DetectAsync(_faceDetectionFromURIRequest);

//            // Assert
//            Assert.IsType<FaceDetectionResponse>(response);
//        }

//        [Fact]
//        public async Task DetectFromURIAsync_TakesRequestModel_ReturnsNotNull()
//        {
//            // Act
//            var response = await _faceDetectionService.DetectAsync(_faceDetectionFromURIRequest);

//            // Assert
//            Assert.NotNull(response);
//        }

//        [Fact]
//        public async Task DetectFromURIAsync_TakesNullRequest_ThrowsException()
//        {
//            // Act
//            var func = async () => await _faceDetectionService.DetectAsync((FaceDetectionRequestByFileUrl)null!);

//            // Assert
//            await Assert.ThrowsAsync<NullReferenceException>(func);
//        }

//        [Fact]
//        public async Task DetectFromURIAsync_TakesNullRequest_ThrowsServiceException()
//        {
//            // Act
//            var detectRequest = new FaceDetectionRequestByFileUrl()
//            {
//                FileUrl = WRONG_FILE_URL,
//                DetProbThreshold = 0.81m,
//                FacePlugins = new List<string>()
//            {
//                "landmarks",
//                "gender",
//                "age",
//                "detector",
//                "calculator"
//            },
//                Status = true,
//                Limit = 0
//            };

//            // Act
//            var func = async () => await _faceDetectionService.DetectAsync(detectRequest);

//            // Assert
//            await Assert.ThrowsAsync<ServiceException>(func);
//        }
//    }
//}
