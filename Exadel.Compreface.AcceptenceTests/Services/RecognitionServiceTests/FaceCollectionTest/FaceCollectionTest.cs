using Exadel.Compreface.Clients.CompreFaceClient;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.AddSubjectExample;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.DeleteAllSubjectExamples;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.DeleteImageById;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.DeleteMultipleExamples;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.DownloadImageById;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.DownloadImageByIdFromSubject;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.ListAllExampleSubject;
using Exadel.Compreface.DTOs.HelperDTOs;
using Exadel.Compreface.Exceptions;
using Exadel.Compreface.Services.RecognitionService;
using static Exadel.Compreface.AcceptenceTests.UrlConstConfig;

namespace Exadel.Compreface.AcceptenceTests.Services.RecognitionServiceTests
{
    public class FaceCollectionTest
    {
        private readonly ICompreFaceClient _client;

        private readonly RecognitionService _recognitionService;

        private readonly AddBase64SubjectExampleRequest addBase64SubjectExampleRequest;

        public FaceCollectionTest()
        {
            _client = new CompreFaceClient(DOMAIN, PORT);
            _recognitionService = _client.GetCompreFaceService<RecognitionService>(API_KEY_RECOGNITION_SERVICE);

            addBase64SubjectExampleRequest = new AddBase64SubjectExampleRequest()
            {
                DetProbThreShold = 0.81m,
                File = IMAGE_BASE64_STRING
            };
        }

        [Fact]
        [FaceCollectionTestBeforeAfter]
        public async Task AddAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            var subjectExample = new AddSubjectExampleRequestByFilePath()
            {
                DetProbThreShold = 0.81m,
                FilePath = FILE_PATH,
                Subject = TEST_SUBJECT_EXAMPLE_NAME,
            };

            var expectedAddExampleSubjectResponse = await _recognitionService.FaceCollection.AddAsync(subjectExample);

            //Act
            var resultList = await _recognitionService.FaceCollection.ListAsync(
                new ListAllSubjectExamplesRequest() { Subject = TEST_SUBJECT_EXAMPLE_NAME });

            var actualSubjectExample = resultList.Faces
                .First(x => x.ImageId == expectedAddExampleSubjectResponse.ImageId & x.Subject == expectedAddExampleSubjectResponse.Subject);

            //Assert
            Assert.Equal(expectedAddExampleSubjectResponse.Subject, actualSubjectExample.Subject);
            Assert.Equal(expectedAddExampleSubjectResponse.ImageId, actualSubjectExample.ImageId);
        }

        //[Fact]
        //[FaceCollectionTestBeforeAfter]
        //public async Task AddAsync_TakesRequestModel_ReturnsNotNull()
        //{
        //    //Arrange
        //    var subjectExample = new AddSubjectExampleRequestByFilePath()
        //    {
        //        DetProbThreShold = 0.81m,
        //        FilePath = FILE_PATH,
        //        Subject = TEST_SUBJECT_EXAMPLE_NAME,
        //    };

        //    //Act
        //    var expectedAddExampleSubjectResponse = await _recognitionService.FaceCollection.AddAsync(subjectExample);

        //    // Assert
        //    Assert.NotNull(expectedAddExampleSubjectResponse);
        //}

        //[Fact]
        //public async Task AddAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        //{
        //    //Act
        //    var func = async () => await _recognitionService.FaceCollection.AddAsync((AddSubjectExampleRequestByFilePath)null!);

        //    // Assert
        //    await Assert.ThrowsAsync<NullReferenceException>(func);
        //}

        //[Fact]
        //public async Task AddAsync_TakesRequestModel_ThrowsServiceException()
        //{
        //    //Arrange
        //    var subjectExample = new AddSubjectExampleRequestByFilePath()
        //    {
        //        DetProbThreShold = 0.81m,
        //        FilePath = PATH_OF_WRONG_FILE,
        //        Subject = TEST_SUBJECT_EXAMPLE_NAME,
        //    };

        //    //Act
        //    var func = async () => await _recognitionService.FaceCollection.AddAsync(subjectExample);

        //    // Assert
        //    await Assert.ThrowsAsync<ServiceException>(func);
        //}

        //[Fact]
        //[FaceCollectionTestBeforeAfter]
        //public async Task AddFromURLAsync_TakesRequestModel_ReturnsProperResponseModel()
        //{
        //    //Arrange
        //    var subjectExample = new AddSubjectExampleRequestByFileUrl()
        //    {
        //        DetProbThreShold = 0.81m,
        //        FileUrl = FILE_URL,
        //        Subject = TEST_SUBJECT_EXAMPLE_NAME,
        //    };

        //    var expectedAddExampleSubjectResponse = await _recognitionService.FaceCollection.AddAsync(subjectExample);

        //    //Act
        //    var resultList = await _recognitionService.FaceCollection.ListAsync(
        //        new ListAllSubjectExamplesRequest() { Subject = TEST_SUBJECT_EXAMPLE_NAME });

        //    var actualSubjectExample = resultList.Faces
        //        .First(x => x.ImageId == expectedAddExampleSubjectResponse.ImageId & x.Subject == expectedAddExampleSubjectResponse.Subject);

        //    //Assert
        //    Assert.Equal(expectedAddExampleSubjectResponse.Subject, actualSubjectExample.Subject);
        //    Assert.Equal(expectedAddExampleSubjectResponse.ImageId, actualSubjectExample.ImageId);
        //}

        //[Fact]
        //[FaceCollectionTestBeforeAfter]
        //public async Task AddFromURLAsync_TakesRequestModel_ReturnsNotNull()
        //{
        //    //Arrange
        //    var subjectExample = new AddSubjectExampleRequestByFileUrl()
        //    {
        //        DetProbThreShold = 0.81m,
        //        FileUrl = FILE_URL,
        //        Subject = TEST_SUBJECT_EXAMPLE_NAME,
        //    };

        //    //Act
        //    var expectedAddExampleSubjectResponse = await _recognitionService.FaceCollection.AddAsync(subjectExample);

        //    // Assert
        //    Assert.NotNull(expectedAddExampleSubjectResponse);
        //}

        //[Fact]
        //public async Task AddFromURLAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        //{
        //    //Act
        //    var func = async () => await _recognitionService.FaceCollection.AddAsync((AddSubjectExampleRequestByFileUrl)null!);

        //    // Assert
        //    await Assert.ThrowsAsync<NullReferenceException>(func);
        //}

        //[Fact]
        //public async Task AddFromURLAsync_TakesRequestModel_ThrowsServiceException()
        //{
        //    //Arrange
        //    var subjectExample = new AddSubjectExampleRequestByFileUrl()
        //    {
        //        DetProbThreShold = 0.81m,
        //        FileUrl = WRONG_FILE_URL,
        //        Subject = TEST_SUBJECT_EXAMPLE_NAME,
        //    };

        //    //Act
        //    var func = async () => await _recognitionService.FaceCollection.AddAsync(subjectExample);

        //    // Assert
        //    await Assert.ThrowsAsync<ServiceException>(func);
        //}

        //[Fact]
        //[FaceCollectionTestBeforeAfter]
        //public async Task AddBase64Async_TakesRequestModel_ReturnsProperResponseModel()
        //{
        //    //Arrange
        //    addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

        //    var expectedAddBase64SubjectExampleResponse = await _recognitionService.FaceCollection.AddAsync(addBase64SubjectExampleRequest);

        //    //Act
        //    var resultList = await _recognitionService.FaceCollection.ListAsync(
        //        new ListAllSubjectExamplesRequest() { Subject = TEST_SUBJECT_EXAMPLE_NAME });

        //    var actualSubjectExample = resultList.Faces
        //            .First(x => x.ImageId == expectedAddBase64SubjectExampleResponse.ImageId & x.Subject == expectedAddBase64SubjectExampleResponse.Subject);

        //    //Assert
        //    Assert.Equal(expectedAddBase64SubjectExampleResponse.Subject, actualSubjectExample.Subject);
        //    Assert.Equal(expectedAddBase64SubjectExampleResponse.ImageId, actualSubjectExample.ImageId);
        //}

        //[Fact]
        //[FaceCollectionTestBeforeAfter]
        //public async Task AddBase64Async_TakesRequestModel_ReturnsNotNull()
        //{
        //    //Arrange
        //    addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

        //    //Act
        //    var expectedAddExampleSubjectResponse = await _recognitionService.FaceCollection.AddAsync(addBase64SubjectExampleRequest);

        //    // Assert
        //    Assert.NotNull(expectedAddExampleSubjectResponse);
        //}

        //[Fact]
        //public async Task AddBase64Async_TakesNullRequestModel_ThrowsNullReferenceException()
        //{
        //    //Act
        //    var func = async () => await _recognitionService.FaceCollection.AddAsync((AddBase64SubjectExampleRequest)null!);

        //    // Assert
        //    await Assert.ThrowsAsync<NullReferenceException>(func);
        //}

        //[Fact]
        //public async Task AddBase64Async_TakesRequestModel_ThrowsServiceException()
        //{
        //    //Arrange
        //    var request = new AddBase64SubjectExampleRequest()
        //    {
        //        DetProbThreShold = 0.81m,
        //        File = IMAGE_BASE64_STRING
        //    };
        //    request.Subject = TEST_SUBJECT_EXAMPLE_NAME;
        //    request.File = "Base64TestString";

        //    //Act
        //    var func = async () => await _recognitionService.FaceCollection.AddAsync(request);

        //    // Assert
        //    await Assert.ThrowsAsync<ServiceException>(func);
        //}

        //[Fact]
        //[FaceCollectionTestBeforeAfter]
        //public async Task GetAllAsync_TakesRequestModel_ReturnsProperResponseModel()
        //{
        //    //Arrange
        //    var allSubjectExamples = new ListAllSubjectExamplesRequest()
        //    {
        //        Page = 0,
        //        Size = 0,
        //        Subject = TEST_SUBJECT_EXAMPLE_NAME
        //    };

        //    addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

        //    var expectedCount = 3;
        //    for (int counter = expectedCount; counter > 0; counter--)
        //    {
        //        await _recognitionService.FaceCollection.AddAsync(addBase64SubjectExampleRequest);
        //    }

        //    //Act
        //    var actualAllSubjectExamplesResponse = await _recognitionService.FaceCollection.ListAsync(allSubjectExamples);
        //    var actualCount = actualAllSubjectExamplesResponse.Faces.Count;

        //    //Assert
        //    Assert.Equal(actualCount, expectedCount);
        //}

        //[Fact]
        //[FaceCollectionTestBeforeAfter]
        //public async Task GetAllAsync_TakesRequestModel_ReturnsNotNull()
        //{
        //    //Arrange
        //    var allSubjectExamples = new ListAllSubjectExamplesRequest()
        //    {
        //        Page = 0,
        //        Size = 0,
        //        Subject = TEST_SUBJECT_EXAMPLE_NAME
        //    };

        //    addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

        //    var expectedCount = 3;
        //    for (int counter = expectedCount; counter > 0; counter--)
        //    {
        //        await _recognitionService.FaceCollection.AddAsync(addBase64SubjectExampleRequest);
        //    }

        //    //Act
        //    var actualAllSubjectExamplesResponse = await _recognitionService.FaceCollection.ListAsync(allSubjectExamples);

        //    // Assert
        //    Assert.NotNull(actualAllSubjectExamplesResponse);
        //}

        //[Fact]
        //public async Task GetAllAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        //{
        //    //Act
        //    var func = async () => await _recognitionService.FaceCollection.ListAsync(null!);

        //    // Assert
        //    await Assert.ThrowsAsync<NullReferenceException>(func);
        //}

        //[Fact]
        //public async Task GetAllAsync_TakesNonExistentSubject_ReturnsDefaultValue()
        //{
        //    //Arrange
        //    var request = new ListAllSubjectExamplesRequest()
        //    {
        //        Page = 1,
        //        Size = 1,
        //        Subject = TEST_SUBJECT_EXAMPLE_NAME
        //    };

        //    var expectedDefaultResponse = new ListAllSubjectExamplesResponse
        //    {
        //        Faces = new List<Face>(),
        //        PageNumber = 1,
        //        PageSize = 1,
        //        TotalElements = 0,
        //        TotalPages = 0,
        //    };

        //    //Act
        //    var actualResponse = await _recognitionService.FaceCollection.ListAsync(request);

        //    //Assert
        //    Assert.Equivalent(expectedDefaultResponse, actualResponse);
        //}

        //[Fact]
        //[FaceCollectionTestBeforeAfter]
        //public async Task DeleteAllAsync_TakesRequestModel_ReturnsProperResponseModel()
        //{
        //    //Arrange
        //    addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

        //    var expectedCount = 3;

        //    for (int counter = expectedCount; counter > 0; counter--)
        //    {
        //        await _recognitionService.FaceCollection.AddAsync(addBase64SubjectExampleRequest);
        //    }

        //    //Act
        //    var actualResponse = await _recognitionService.FaceCollection.DeleteAllAsync(
        //        new DeleteAllExamplesRequest() { Subject = TEST_SUBJECT_EXAMPLE_NAME });

        //    //Assert
        //    Assert.Equal(expectedCount, actualResponse.Deleted);
        //}

        //[Fact]
        //[FaceCollectionTestBeforeAfter]
        //public async Task DeleteAllAsync_TakesRequestModel_ReturnsNotNull()
        //{
        //    //Arrange
        //    addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

        //    var expectedCount = 3;

        //    for (int counter = expectedCount; counter > 0; counter--)
        //    {
        //        await _recognitionService.FaceCollection.AddAsync(addBase64SubjectExampleRequest);
        //    }

        //    //Act
        //    var actualResponse = await _recognitionService.FaceCollection.DeleteAllAsync(
        //        new DeleteAllExamplesRequest() { Subject = TEST_SUBJECT_EXAMPLE_NAME });

        //    // Assert
        //    Assert.NotNull(actualResponse);
        //}

        //[Fact]
        //public async Task DeleteAllAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        //{
        //    //Act
        //    var func = async () => await _recognitionService.FaceCollection.DeleteAllAsync(null!);

        //    // Assert
        //    await Assert.ThrowsAsync<NullReferenceException>(func);
        //}

        //[Fact]
        //public async Task DeleteAllAsync_TakesNullRequestModel_ThrowsServiceException()
        //{
        //    //Act
        //    var func = async () => await _recognitionService.FaceCollection.DeleteAllAsync(
        //        new DeleteAllExamplesRequest());

        //    // Assert
        //    await Assert.ThrowsAsync<ServiceException>(func);
        //}

        //[Fact]
        //[FaceCollectionTestBeforeAfter]
        //public async Task DeleteAsync_TakesRequestModel_ReturnsProperResponseModel()
        //{
        //    //Arrange
        //    addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;
        //    var testImage = await _recognitionService.FaceCollection.AddAsync(addBase64SubjectExampleRequest);

        //    var deleteImageByIdRequest = new DeleteImageByIdRequest()
        //    {
        //        ImageId = testImage.ImageId
        //    };

        //    //Act
        //    var actualDeleteImageByIdResponse = await _recognitionService.FaceCollection.DeleteAsync(deleteImageByIdRequest);

        //    //Assert
        //    Assert.Equal(testImage.Subject, actualDeleteImageByIdResponse.Subject);
        //    Assert.Equal(testImage.ImageId, actualDeleteImageByIdResponse.ImageId);
        //}

        //[Fact]
        //[FaceCollectionTestBeforeAfter]
        //public async Task DeleteAsync_TakesRequestModel_ReturnsNotNull()
        //{
        //    //Arrange
        //    addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;
        //    var testImage = await _recognitionService.FaceCollection.AddAsync(addBase64SubjectExampleRequest);

        //    var deleteImageByIdRequest = new DeleteImageByIdRequest()
        //    {
        //        ImageId = testImage.ImageId
        //    };

        //    //Act
        //    var actualDeleteImageByIdResponse = await _recognitionService.FaceCollection.DeleteAsync(deleteImageByIdRequest);

        //    // Assert
        //    Assert.NotNull(actualDeleteImageByIdResponse);
        //}

        //[Fact]
        //public async Task DeleteAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        //{
        //    //Act
        //    var func = async () => await _recognitionService.FaceCollection.DeleteAsync((DeleteImageByIdRequest)null!);

        //    // Assert
        //    await Assert.ThrowsAsync<NullReferenceException>(func);
        //}

        //[Fact]
        //[FaceCollectionTestBeforeAfter]
        //public async Task DeleteAsync_TakesRequestModel_ThrowsServiceException()
        //{
        //    //Act
        //    var func = async () => await _recognitionService.FaceCollection.DeleteAsync(
        //        new DeleteImageByIdRequest() { ImageId = Guid.Parse("e1a7653d-af52-4b0b-a05f-ee3f7b667fba") });

        //    // Assert
        //    await Assert.ThrowsAsync<ServiceException>(func);
        //}

        //[Fact]
        //[FaceCollectionTestBeforeAfter]
        //public async Task DeletMultipleAsync_TakesRequestModel_ReturnsProperResponseModel()
        //{
        //    //Arrange
        //    addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

        //    var expectedCount = 3;
        //    var unnecessaryExampleList = new List<Guid>();

        //    for (int counter = expectedCount; counter > 0; counter--)
        //    {
        //        var response = await _recognitionService.FaceCollection.AddAsync(addBase64SubjectExampleRequest);

        //        unnecessaryExampleList.Add(response.ImageId);
        //    }

        //    var expectedFacesCount = expectedCount;

        //    //Act
        //    var actualResponse = await _recognitionService.FaceCollection.DeleteAsync(
        //        new DeleteMultipleExampleRequest() { ImageIdList = unnecessaryExampleList });

        //    var actualFacesCount = actualResponse.Faces.Count;

        //    //Assert
        //    Assert.Equal(expectedFacesCount, actualFacesCount);
        //}

        //[Fact]
        //[FaceCollectionTestBeforeAfter]
        //public async Task DeletMultipleAsync_TakesRequestModel_ReturnsNotNull()
        //{
        //    //Arrange
        //    addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

        //    var count = 3;
        //    var unnecessaryExampleList = new List<Guid>();

        //    for (int counter = count; counter > 0; counter--)
        //    {
        //        var response = await _recognitionService.FaceCollection.AddAsync(addBase64SubjectExampleRequest);

        //        unnecessaryExampleList.Add(response.ImageId);
        //    }

        //    //Act
        //    var actualResponse = await _recognitionService.FaceCollection.DeleteAsync(
        //        new DeleteMultipleExampleRequest() { ImageIdList = unnecessaryExampleList });

        //    // Assert
        //    Assert.NotNull(actualResponse);
        //}

        //[Fact]
        //public async Task DeletMultipleAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        //{
        //    //Act
        //    var func = async () => await _recognitionService.FaceCollection.DeleteAsync((DeleteMultipleExampleRequest)null!);

        //    // Assert
        //    await Assert.ThrowsAsync<NullReferenceException>(func);
        //}

        //[Fact]
        //public async Task DeletMultipleAsync_TakesNullRequestModel_ThrowsServiceException()
        //{
        //    //Act
        //    var func = async () => await _recognitionService.FaceCollection.DeleteAsync(
        //        new DeleteMultipleExampleRequest() { });

        //    // Assert
        //    await Assert.ThrowsAsync<ServiceException>(func);
        //}

        //[Fact]
        //[FaceCollectionTestBeforeAfter]
        //public async Task DownloadAsync_TakesRequestModel_ReturnsProperResponseModel()
        //{
        //    //Arrange
        //    addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

        //    var testImage = await _recognitionService.FaceCollection.AddAsync(addBase64SubjectExampleRequest);

        //    var expectedResult = Convert.FromBase64String(IMAGE_BASE64_STRING);

        //    //Act
        //    var actualResult = await _recognitionService.FaceCollection.DownloadAsync(
        //        new DownloadImageByIdDirectlyRequest() { ImageId = testImage.ImageId, RecognitionApiKey = Guid.Parse(API_KEY_RECOGNITION_SERVICE) });

        //    //Assert
        //    Assert.Equal(expectedResult, actualResult);
        //}

        //[Fact]
        //public async Task DownloadAsync_TakesRequestModel_ReturnsNotNull()
        //{
        //    //Arrange
        //    addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

        //    var testImage = await _recognitionService.FaceCollection.AddAsync(addBase64SubjectExampleRequest);

        //    //Act
        //    var actualResult = await _recognitionService.FaceCollection.DownloadAsync(
        //        new DownloadImageByIdDirectlyRequest() { ImageId = testImage.ImageId, RecognitionApiKey = Guid.Parse(API_KEY_RECOGNITION_SERVICE) });

        //    // Assert
        //    Assert.NotNull(actualResult);
        //}

        //[Fact]
        //public async Task DownloadAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        //{
        //    //Act
        //    var func = async () => await _recognitionService.FaceCollection.DownloadAsync((DownloadImageByIdDirectlyRequest)null!);

        //    // Assert
        //    await Assert.ThrowsAsync<NullReferenceException>(func);
        //}

        //[Fact]
        //[FaceCollectionTestBeforeAfter]
        //public async Task DownloadAnImageExampleOfTheSubjectByIDAsync_TakesRequestModel_ReturnsProperResponseModel()
        //{
        //    //Arrange
        //    addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

        //    var testImage = await _recognitionService.FaceCollection.AddAsync(addBase64SubjectExampleRequest);

        //    var expectedResult = Convert.FromBase64String(IMAGE_BASE64_STRING);

        //    //Act
        //    var actualResult = await _recognitionService.FaceCollection.DownloadAsync(
        //        new DownloadImageByIdFromSubjectRequest() { ImageId = testImage.ImageId });

        //    //Assert
        //    Assert.Equal(expectedResult, actualResult);
        //}

        //[Fact]
        //[FaceCollectionTestBeforeAfter]
        //public async Task DownloadAnImageExampleOfTheSubjectByIDAsync_TakesRequestModel_ReturnsNotNull()
        //{
        //    //Arrange
        //    addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

        //    var testImage = await _recognitionService.FaceCollection.AddAsync(addBase64SubjectExampleRequest);

        //    //Act
        //    var actualResult = await _recognitionService.FaceCollection.DownloadAsync(
        //        new DownloadImageByIdFromSubjectRequest() { ImageId = testImage.ImageId });

        //    // Assert
        //    Assert.NotNull(actualResult);
        //}

        //[Fact]
        //public async Task DownloadAnImageExampleOfTheSubjectByIDAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        //{
        //    //Act
        //    var func = async () => await _recognitionService.FaceCollection.DownloadAsync((DownloadImageByIdFromSubjectRequest)null!);

        //    // Assert
        //    await Assert.ThrowsAsync<NullReferenceException>(func);
        //}
    }
}
