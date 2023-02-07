using Exadel.Compreface.Clients.CompreFaceClient;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddBase64ExampleSubject;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddExampleSubject;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteAllSubjectExamples;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteImageById;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteMultipleExamples;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DownloadImageById;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DownloadImageBySubjectId;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.ListAllExampleSubject;
using Exadel.Compreface.DTOs.HelperDTOs;
using Exadel.Compreface.Exceptions;
using Exadel.Compreface.Services;
using static Exadel.Compreface.AcceptenceTests.UrlConstConfig;

namespace Exadel.Compreface.AcceptenceTests.Services
{
    public class SubjectExampleServiceTest
    {
        private readonly CompreFaceClient _client;
        private readonly AddBase64SubjectExampleRequest addBase64SubjectExampleRequest;

        public SubjectExampleServiceTest()
        {
            _client = new CompreFaceClient(new ComprefaceConfiguration(API_KEY_RECOGNITION_SERVICE,DOMAIN, PORT));
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

            var expectedAddExampleSubjectResponse = await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).AddAsync(subjectExample);

            //Act
            var resultList = await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).ListAsync(
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
            var expectedAddExampleSubjectResponse = await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).AddAsync(subjectExample);

            // Assert
            Assert.NotNull(expectedAddExampleSubjectResponse);
        }

        [Fact]
        public async Task AddAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            //Act
            var func = async () => await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).AddAsync((AddSubjectExampleRequest)null!);

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
            var func = async () => await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).AddAsync(subjectExample);

            // Assert
            await Assert.ThrowsAsync<ServiceException>(func);
        }

        [Fact]
        [SubjectExampleTestBeforeAfter]
        public async Task AddBase64Async_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

            var expectedAddBase64SubjectExampleResponse = await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).AddAsync(addBase64SubjectExampleRequest);

            //Act
            var resultList = await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).ListAsync(
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
            var expectedAddExampleSubjectResponse = await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).AddAsync(addBase64SubjectExampleRequest);

            // Assert
            Assert.NotNull(expectedAddExampleSubjectResponse);
        }

        [Fact]
        public async Task AddBase64Async_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            //Act
            var func = async () => await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).AddAsync((AddBase64SubjectExampleRequest)null!);

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
            var func = async () => await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).AddAsync(request);

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
                await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).AddAsync(addBase64SubjectExampleRequest);
            }

            //Act
            var actualAllSubjectExamplesResponse = await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).ListAsync(allSubjectExamples);
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
                await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).AddAsync(addBase64SubjectExampleRequest);
            }

            //Act
            var actualAllSubjectExamplesResponse = await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).ListAsync(allSubjectExamples);

            // Assert
            Assert.NotNull(actualAllSubjectExamplesResponse);
        }

        [Fact]
        public async Task GetAllAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            //Act
            var func = async () => await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).ListAsync(null!);

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
                Faces = new List<Face>(),
                PageNumber = 1,
                PageSize = 1,
                TotalElements = 0,
                TotalPages = 0,
            };

            //Act
            var actualResponse = await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).ListAsync(request);

            //Assert
            Assert.Equivalent(expectedDefaultResponse, actualResponse);
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
                await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).AddAsync(addBase64SubjectExampleRequest);
            }

            //Act
            var actualResponse = await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).DeleteAllAsync(
                new DeleteAllExamplesRequest() { Subject = TEST_SUBJECT_EXAMPLE_NAME });

            //Assert
            Assert.Equal(expectedCount, actualResponse.Deleted);
        }

        [Fact]
        [SubjectExampleTestBeforeAfter]
        public async Task DeleteAllAsync_TakesRequestModel_ReturnsNotNull()
        {
            //Arrange
            addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

            var expectedCount = 3;

            for (int counter = expectedCount; counter > 0; counter--)
            {
                await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).AddAsync(addBase64SubjectExampleRequest);
            }

            //Act
            var actualResponse = await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).DeleteAllAsync(
                new DeleteAllExamplesRequest() { Subject = TEST_SUBJECT_EXAMPLE_NAME });

            // Assert
            Assert.NotNull(actualResponse);
        }

        [Fact]
        public async Task DeleteAllAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            //Act
            var func = async () => await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).DeleteAllAsync(null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task DeleteAllAsync_TakesNullRequestModel_ThrowsServiceException()
        {
            //Act
            var func = async () => await _client.GetService<SubjectExampleService>(API_KEY_DETECTION_SERVICE).DeleteAllAsync(
                new DeleteAllExamplesRequest() { Subject = TEST_SUBJECT_EXAMPLE_NAME });

            // Assert
            await Assert.ThrowsAsync<ServiceException>(func);
        }

        [Fact]
        [SubjectExampleTestBeforeAfter]
        public async Task DeleteAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;
            var testImage = await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).AddAsync(addBase64SubjectExampleRequest);

            var deleteImageByIdRequest = new DeleteImageByIdRequest()
            {
                ImageId = testImage.ImageId
            };

            //Act
            var actualDeleteImageByIdResponse = await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).DeleteAsync(deleteImageByIdRequest);

            //Assert
            Assert.Equal(testImage.Subject, actualDeleteImageByIdResponse.Subject);
            Assert.Equal(testImage.ImageId, actualDeleteImageByIdResponse.ImageId);
        }

        [Fact]
        [SubjectExampleTestBeforeAfter]
        public async Task DeleteAsync_TakesRequestModel_ReturnsNotNull()
        {
            //Arrange
            addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;
            var testImage = await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).AddAsync(addBase64SubjectExampleRequest);

            var deleteImageByIdRequest = new DeleteImageByIdRequest()
            {
                ImageId = testImage.ImageId
            };

            //Act
            var actualDeleteImageByIdResponse = await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).DeleteAsync(deleteImageByIdRequest);

            // Assert
            Assert.NotNull(actualDeleteImageByIdResponse);
        }

        [Fact]
        public async Task DeleteAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            //Act
            var func = async () => await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).DeleteAsync((DeleteImageByIdRequest)null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        [SubjectExampleTestBeforeAfter]
        public async Task DeleteAsync_TakesRequestModel_ThrowsServiceException()
        {
            //Act
            var func = async () => await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).DeleteAsync(
                new DeleteImageByIdRequest() { ImageId = Guid.Parse("e1a7653d-af52-4b0b-a05f-ee3f7b667fba") });

            // Assert
            await Assert.ThrowsAsync<ServiceException>(func);
        }

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
                var response = await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).AddAsync(addBase64SubjectExampleRequest);

                unnecessaryExampleList.Add(response.ImageId);
            }

            var expectedFacesCount = expectedCount;

            //Act
            var actualResponse = await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).DeleteAsync(
                new DeleteMultipleExampleRequest() { ImageIdList = unnecessaryExampleList });

            var actualFacesCount = actualResponse.Faces.Count;

            //Assert
            Assert.Equal(expectedFacesCount, actualFacesCount);
        }

        [Fact]
        [SubjectExampleTestBeforeAfter]
        public async Task DeletMultipleAsync_TakesRequestModel_ReturnsNotNull()
        {
            //Arrange
            addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

            var count = 3;
            var unnecessaryExampleList = new List<Guid>();

            for (int counter = count; counter > 0; counter--)
            {
                var response = await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).AddAsync(addBase64SubjectExampleRequest);

                unnecessaryExampleList.Add(response.ImageId);
            }

            //Act
            var actualResponse = await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).DeleteAsync(
                new DeleteMultipleExampleRequest() { ImageIdList = unnecessaryExampleList });

            // Assert
            Assert.NotNull(actualResponse);
        }

        [Fact]
        public async Task DeletMultipleAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            //Act
            var func = async () => await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).DeleteAsync((DeleteMultipleExampleRequest)null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task DeletMultipleAsync_TakesNullRequestModel_ThrowsServiceException()
        {
            //Act
            var func = async() => await _client.GetService<SubjectExampleService>(API_KEY_DETECTION_SERVICE).DeleteAsync(
                new DeleteMultipleExampleRequest() { ImageIdList = new List<Guid>() });

            // Assert
            await Assert.ThrowsAsync<ServiceException>(func);
        }

        [Fact]
        [SubjectExampleTestBeforeAfter]
        public async Task DownloadAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

            var testImage = await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).AddAsync(addBase64SubjectExampleRequest);

            var expectedResult = Convert.FromBase64String(IMAGE_BASE64_STRING);

            //Act
            var actualResult = await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).DownloadAsync(
                new DownloadImageByIdRequest() { ImageId = testImage.ImageId, RecognitionApiKey = Guid.Parse(API_KEY_RECOGNITION_SERVICE) });

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public async Task DownloadAsync_TakesRequestModel_ReturnsNotNull()
        {
            //Arrange
            addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

            var testImage = await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).AddAsync(addBase64SubjectExampleRequest);

            //Act
            var actualResult = await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).DownloadAsync(
                new DownloadImageByIdRequest() { ImageId = testImage.ImageId, RecognitionApiKey = Guid.Parse(API_KEY_RECOGNITION_SERVICE) });

            // Assert
            Assert.NotNull(actualResult);
        }

        [Fact]
        public async Task DownloadAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            //Act
            var func = async () => await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).DownloadAsync((DownloadImageByIdRequest)null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        [SubjectExampleTestBeforeAfter]
        public async Task DownloadImageBySubjectIdAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

            var testImage = await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).AddAsync(addBase64SubjectExampleRequest);

            var expectedResult = Convert.FromBase64String(IMAGE_BASE64_STRING);

            //Act
            var actualResult = await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).DownloadAsync(
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

            var testImage = await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).AddAsync(addBase64SubjectExampleRequest);

            //Act
            var actualResult = await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).DownloadAsync(
                new DownloadImageBySubjectIdRequest() { ImageId = testImage.ImageId });

            // Assert
            Assert.NotNull(actualResult);
        }

        [Fact]
        public async Task DownloadImageBySubjectIdAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            //Act
            var func = async () => await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).DownloadAsync((DownloadImageBySubjectIdRequest)null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task DownloadImageBySubjectIdAsync_TakesNullRequestModel_ThrowsServiceException()
        {
            //Act
            var func = async () => await _client.GetService<SubjectExampleService>(API_KEY_DETECTION_SERVICE).DownloadAsync(
                new DownloadImageBySubjectIdRequest() { ImageId = Guid.NewGuid() });

            // Assert
            await Assert.ThrowsAsync<ServiceException>(func);
        }
    }
}
