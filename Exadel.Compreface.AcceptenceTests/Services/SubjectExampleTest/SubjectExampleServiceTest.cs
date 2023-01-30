using Exadel.Compreface.Clients;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddBase64ExampleSubject;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddExampleSubject;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteAllSubjectExamples;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteImageById;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteMultipleExamples;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DownloadImageById;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DownloadImageBySubjectId;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.ListAllExampleSubject;
using Exadel.Compreface.Exceptions;
using System;
using static Exadel.Compreface.AcceptenceTests.UrlConstConfig;

namespace Exadel.Compreface.AcceptenceTests.Services
{
    public class SubjectExampleServiceTest
    {
        private readonly FaceRecognitionClient faceRecognitionClient;
        private readonly AddBase64SubjectExampleRequest addBase64SubjectExampleRequest;
        public SubjectExampleServiceTest()
        {
            faceRecognitionClient = new FaceRecognitionClient(new ComprefaceConfiguration(API_KEY_RECOGNITION_SERVICE, DOMAIN, PORT));
            addBase64SubjectExampleRequest = new AddBase64SubjectExampleRequest()
            {
                DetProbThreShold = 0.81m,
                File = IMAGE_BASE64_STRING
            };
        }

        [Fact]
        [SubjectExampleTestBeforeAfter]
        public async Task AddAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            var subjectExample = new AddSubjectExampleRequest()
            {
                DetProbThreShold = 0.81m,
                File = FILE_PATH,
                Subject = TEST_SUBJECT_EXAMPLE_NAME,
            };

            var expectedAddExampleSubjectResponse = await faceRecognitionClient.SubjectExampleService.AddAsync(subjectExample);

            //Act
            var resultList = await faceRecognitionClient.SubjectExampleService.ListAsync(
                new ListAllSubjectExamplesRequest() { Subject = TEST_SUBJECT_EXAMPLE_NAME });

            var actualSubjectExample = resultList.Faces
                .First(x => x.ImageId == expectedAddExampleSubjectResponse.ImageId & x.Subject == expectedAddExampleSubjectResponse.Subject);

            //Assert
            Assert.Equal(expectedAddExampleSubjectResponse.Subject, actualSubjectExample.Subject);
            Assert.Equal(expectedAddExampleSubjectResponse.ImageId, actualSubjectExample.ImageId);
        }

        [Fact]
        [SubjectExampleTestBeforeAfter]
        public async Task AddAsync_TakesRequestModel_ReturnsNotNull()
        {
            //Arrange
            var subjectExample = new AddSubjectExampleRequest()
            {
                DetProbThreShold = 0.81m,
                File = FILE_PATH,
                Subject = TEST_SUBJECT_EXAMPLE_NAME,
            };

            //Act
            var expectedAddExampleSubjectResponse = await faceRecognitionClient.SubjectExampleService.AddAsync(subjectExample);

            // Assert
            Assert.NotNull(expectedAddExampleSubjectResponse);
        }

        [Fact]
        public async Task AddAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            //Act
            var func = async () => await faceRecognitionClient.SubjectExampleService.AddAsync((AddSubjectExampleRequest)null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task AddAsync_TakesRequestModel_ThrowsServiceException()
        {
            //Arrange
            var subjectExample = new AddSubjectExampleRequest()
            {
                DetProbThreShold = 0.81m,
                File = PATH_OF_WRONG_FILE,
                Subject = TEST_SUBJECT_EXAMPLE_NAME,
            };

            //Act
            var func = async () => await faceRecognitionClient.SubjectExampleService.AddAsync(subjectExample);

            // Assert
            await Assert.ThrowsAsync<ServiceException>(func);
        }

        [Fact]
        [SubjectExampleTestBeforeAfter]
        public async Task AddBase64Async_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

            var expectedAddBase64SubjectExampleResponse = await faceRecognitionClient.SubjectExampleService.AddAsync(addBase64SubjectExampleRequest);

            //Act
            var resultList = await faceRecognitionClient.SubjectExampleService.ListAsync(
                new ListAllSubjectExamplesRequest() { Subject = TEST_SUBJECT_EXAMPLE_NAME });

            var actualSubjectExample = resultList.Faces
                    .First(x => x.ImageId == expectedAddBase64SubjectExampleResponse.ImageId & x.Subject == expectedAddBase64SubjectExampleResponse.Subject);

            //Assert
            Assert.Equal(expectedAddBase64SubjectExampleResponse.Subject, actualSubjectExample.Subject);
            Assert.Equal(expectedAddBase64SubjectExampleResponse.ImageId, actualSubjectExample.ImageId);
        }

        [Fact]
        [SubjectExampleTestBeforeAfter]
        public async Task AddBase64Async_TakesRequestModel_ReturnsNotNull()
        {
            //Arrange
            addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

            //Act
            var expectedAddExampleSubjectResponse = await faceRecognitionClient.SubjectExampleService.AddAsync(addBase64SubjectExampleRequest);

            // Assert
            Assert.NotNull(expectedAddExampleSubjectResponse);
        }

        [Fact]
        public async Task AddBase64Async_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            //Act
            var func = async () => await faceRecognitionClient.SubjectExampleService.AddAsync((AddBase64SubjectExampleRequest)null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task AddBase64Async_TakesRequestModel_ThrowsServiceException()
        {
            //Arrange
            var request = new AddBase64SubjectExampleRequest()
            {
                DetProbThreShold = 0.81m,
                File = IMAGE_BASE64_STRING
            };
            request.Subject = TEST_SUBJECT_EXAMPLE_NAME;
            request.File = "Base64TestString";

            //Act
            var func = async () => await faceRecognitionClient.SubjectExampleService.AddAsync(request);

            // Assert
            await Assert.ThrowsAsync<ServiceException>(func);
        }

        [Fact]
        [SubjectExampleTestBeforeAfter]
        public async Task GetAllAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            var allSubjectExamples = new ListAllSubjectExamplesRequest()
            {
                Page = 0,
                Size = 0,
                Subject = TEST_SUBJECT_EXAMPLE_NAME
            };

            addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

            var expectedCount = 3;
            for (int counter = expectedCount; counter > 0; counter--)
            {
                await faceRecognitionClient.SubjectExampleService.AddAsync(addBase64SubjectExampleRequest);
            }

            //Act
            var actualAllSubjectExamplesResponse = await faceRecognitionClient.SubjectExampleService.ListAsync(allSubjectExamples);
            var actualCount = actualAllSubjectExamplesResponse.Faces.Count;

            //Assert
            Assert.Equal(actualCount, expectedCount);
        }

        [Fact]
        [SubjectExampleTestBeforeAfter]
        public async Task GetAllAsync_TakesRequestModel_ReturnsNotNull()
        {
            //Arrange
            var allSubjectExamples = new ListAllSubjectExamplesRequest()
            {
                Page = 0,
                Size = 0,
                Subject = TEST_SUBJECT_EXAMPLE_NAME
            };

            addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

            var expectedCount = 3;
            for (int counter = expectedCount; counter > 0; counter--)
            {
                await faceRecognitionClient.SubjectExampleService.AddAsync(addBase64SubjectExampleRequest);
            }

            //Act
            var actualAllSubjectExamplesResponse = await faceRecognitionClient.SubjectExampleService.ListAsync(allSubjectExamples);

            // Assert
            Assert.NotNull(actualAllSubjectExamplesResponse);
        }

        [Fact]
        public async Task GetAllAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            //Act
            var func = async () => await faceRecognitionClient.SubjectExampleService.ListAsync(null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task GetAllAsync_TakesNonExistentSubject_ReturnsDefaultValue()
        {
            //Arrange
            var request  = new ListAllSubjectExamplesRequest()
            {
                Page = 1,
                Size = 1,
                Subject = TEST_SUBJECT_EXAMPLE_NAME
            };

            var expectedDefaultResponse = new ListAllSubjectExamplesResponse
            {
                Faces = null,
                PageNumber = 0,
                PageSize = 20,
                TotalElements = 0,
                TotalPages = 0,
            };

            //Act
            var actualResponse = await faceRecognitionClient.SubjectExampleService.ListAsync(request);

            //Assert
            await Assert.Equal(expectedDefaultResponse, actualResponse);
        }

        [Fact]
        [SubjectExampleTestBeforeAfter]
        public async Task DeleteAllAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

            var expectedCount = 3;

            for (int counter = expectedCount; counter > 0; counter--)
            {
                await faceRecognitionClient.SubjectExampleService.AddAsync(addBase64SubjectExampleRequest);
            }

            //Act
            var actualResponse = await faceRecognitionClient.SubjectExampleService.DeleteAllAsync(
                new DeleteAllExamplesRequest() { Subject = TEST_SUBJECT_EXAMPLE_NAME });

            //Assert
            Assert.Equal(expectedCount, actualResponse.Deleted);
        }

        //[Fact]
        //[SubjectExampleTestBeforeAfter]
        //public async Task DeleteAllAsync_TakesRequestModel_ReturnsNotNull()
        //{
        //    //Arrange
        //    addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

        //    var expectedCount = 3;

        //    for (int counter = expectedCount; counter > 0; counter--)
        //    {
        //        await faceRecognitionClient.SubjectExampleService.AddAsync(addBase64SubjectExampleRequest);
        //    }

        //    //Act
        //    var actualResponse = await faceRecognitionClient.SubjectExampleService.DeleteAllAsync(
        //        new DeleteAllExamplesRequest() { Subject = TEST_SUBJECT_EXAMPLE_NAME });

        //    // Assert
        //    Assert.NotNull(actualResponse);
        //}

        //[Fact]
        //[SubjectExampleTestBeforeAfter]
        //public async Task DeleteAllAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        //{
        //    //Act
        //    var func = async () => await faceRecognitionClient.SubjectExampleService.DeleteAllAsync((DeleteAllExamplesRequest)null!);

        //    // Assert
        //    await Assert.ThrowsAsync<NullReferenceException>(func);
        //}

        [Fact]
        [SubjectExampleTestBeforeAfter]
        public async Task DeleteAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;
            var testImage = await faceRecognitionClient.SubjectExampleService.AddAsync(addBase64SubjectExampleRequest);

            var deleteImageByIdRequest = new DeleteImageByIdRequest()
            {
                ImageId = testImage.ImageId
            };

            //Act
            var actualDeleteImageByIdResponse = await faceRecognitionClient.SubjectExampleService.DeleteAsync(deleteImageByIdRequest);

            //Assert
            Assert.Equal(testImage.Subject, actualDeleteImageByIdResponse.Subject);
            Assert.Equal(testImage.ImageId, actualDeleteImageByIdResponse.ImageId);
        }

        //[Fact]
        //[SubjectExampleTestBeforeAfter]
        //public async Task DeleteAsync_TakesRequestModel_ReturnsNotNull()
        //{
        //    //Arrange
        //    addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;
        //    var testImage = await faceRecognitionClient.SubjectExampleService.AddAsync(addBase64SubjectExampleRequest);

        //    var deleteImageByIdRequest = new DeleteImageByIdRequest()
        //    {
        //        ImageId = testImage.ImageId
        //    };

        //    //Act
        //    var actualDeleteImageByIdResponse = await faceRecognitionClient.SubjectExampleService.DeleteAsync(deleteImageByIdRequest);

        //    // Assert
        //    Assert.NotNull(actualDeleteImageByIdResponse);
        //}

        //[Fact]
        //[SubjectExampleTestBeforeAfter]
        //public async Task DeleteAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        //{
        //    //Act
        //    var func = async () => await faceRecognitionClient.SubjectExampleService.DeleteAsync((DeleteImageByIdRequest)null!);

        //    // Assert
        //    await Assert.ThrowsAsync<NullReferenceException>(func);
        //}

        //[Fact]
        //[SubjectExampleTestBeforeAfter]
        //public async Task DeleteAsync_TakesRequestModel_ThrowsServiceException()
        //{
        //    //Act
        //    var func = async () => await faceRecognitionClient.SubjectExampleService.DeleteAsync(
        //        new DeleteImageByIdRequest() { ImageId = Guid.Parse("e1a7653d-af52-4b0b-a05f-ee3f7b667fba") });

        //    // Assert
        //    await Assert.ThrowsAsync<ServiceException>(func);
        //}

        [Fact]
        [SubjectExampleTestBeforeAfter]
        public async Task DeletMultipleAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

            var expectedCount = 3;
            var unnecessaryExampleList = new List<Guid>();

            for (int counter = expectedCount; counter > 0; counter--)
            {
                var response = await faceRecognitionClient.SubjectExampleService.AddAsync(addBase64SubjectExampleRequest);

                unnecessaryExampleList.Add(response.ImageId);
            }

            var expectedFacesCount = expectedCount;

            //Act
            var actualResponse = await faceRecognitionClient.SubjectExampleService.DeleteAsync(
                new DeleteMultipleExampleRequest() { ImageIdList = unnecessaryExampleList });

            var actualFacesCount = actualResponse.Faces.Count;

            //Assert
            Assert.Equal(expectedFacesCount, actualFacesCount);
        }

        //[Fact]
        //[SubjectExampleTestBeforeAfter]
        //public async Task DeletMultipleAsync_TakesRequestModel_ReturnsNotNull()
        //{
        //    //Arrange
        //    addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

        //    var count = 3;
        //    var unnecessaryExampleList = new List<Guid>();

        //    for (int counter = count; counter > 0; counter--)
        //    {
        //        var response = await faceRecognitionClient.SubjectExampleService.AddAsync(addBase64SubjectExampleRequest);

        //        unnecessaryExampleList.Add(response.ImageId);
        //    }

        //    //Act
        //    var actualResponse = await faceRecognitionClient.SubjectExampleService.DeleteAsync(
        //        new DeleteMultipleExampleRequest() { ImageIdList = unnecessaryExampleList });

        //    // Assert
        //    Assert.NotNull(actualResponse);
        //}

        //[Fact]
        //[SubjectExampleTestBeforeAfter]
        //public async Task DeletMultipleAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        //{
        //    //Act
        //    var func = async () => await faceRecognitionClient.SubjectExampleService.DeleteAsync((DeleteMultipleExampleRequest)null!);

        //    // Assert
        //    await Assert.ThrowsAsync<NullReferenceException>(func);
        //}

        [Fact]
        [SubjectExampleTestBeforeAfter]
        public async Task DownloadAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

            var testImage = await faceRecognitionClient.SubjectExampleService.AddAsync(addBase64SubjectExampleRequest);

            var expectedResult = Convert.FromBase64String(IMAGE_BASE64_STRING);

            //Act
            var actualResult = await faceRecognitionClient.SubjectExampleService.DownloadAsync(
                new DownloadImageByIdRequest() { ImageId = testImage.ImageId, RecognitionApiKey = Guid.Parse(API_KEY_RECOGNITION_SERVICE) });

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }

        //[Fact]
        //[SubjectExampleTestBeforeAfter]
        //public async Task DownloadAsync_TakesRequestModel_ReturnsNotNull()
        //{
        //    //Arrange
        //    addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

        //    var testImage = await faceRecognitionClient.SubjectExampleService.AddAsync(addBase64SubjectExampleRequest);

        //    //Act
        //    var actualResult = await faceRecognitionClient.SubjectExampleService.DownloadAsync(
        //        new DownloadImageByIdRequest() { ImageId = testImage.ImageId, RecognitionApiKey = Guid.Parse(API_KEY_RECOGNITION_SERVICE) });

        //    // Assert
        //    Assert.NotNull(actualResult);
        //}

        //[Fact]
        //[SubjectExampleTestBeforeAfter]
        //public async Task DownloadAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        //{
        //    //Act
        //    var func = async () => await faceRecognitionClient.SubjectExampleService.DownloadAsync((DownloadImageByIdRequest)null!);

        //    // Assert
        //    await Assert.ThrowsAsync<NullReferenceException>(func);
        //}

        [Fact]
        [SubjectExampleTestBeforeAfter]
        public async Task DownloadImageBySubjectIdAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

            var testImage = await faceRecognitionClient.SubjectExampleService.AddAsync(addBase64SubjectExampleRequest);

            var expectedResult = Convert.FromBase64String(IMAGE_BASE64_STRING);

            //Act
            var actualResult = await faceRecognitionClient.SubjectExampleService.DownloadAsync(
                new DownloadImageBySubjectIdRequest() { ImageId = testImage.ImageId });

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        [SubjectExampleTestBeforeAfter]
        public async Task DownloadImageBySubjectIdAsync_TakesRequestModel_ReturnsNotNull()
        {
            //Arrange
            addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

            var testImage = await faceRecognitionClient.SubjectExampleService.AddAsync(addBase64SubjectExampleRequest);

            //Act
            var actualResult = await faceRecognitionClient.SubjectExampleService.DownloadAsync(
                new DownloadImageBySubjectIdRequest() { ImageId = testImage.ImageId });

            // Assert
            Assert.NotNull(actualResult);
        }

        [Fact]
        [SubjectExampleTestBeforeAfter]
        public async Task DownloadImageBySubjectIdAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            //Act
            var func = async () => await faceRecognitionClient.SubjectExampleService.DownloadAsync((DownloadImageBySubjectIdRequest)null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }
    }
}
