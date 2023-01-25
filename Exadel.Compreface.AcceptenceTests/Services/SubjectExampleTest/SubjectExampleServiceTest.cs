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
using Exadel.Compreface.Services;
using static Exadel.Compreface.AcceptenceTests.UrlConstConfig;

namespace Exadel.Compreface.AcceptenceTests.Services
{
    public class SubjectExampleServiceTest
    {
        private readonly ApiClient _apiClient;
        private readonly AddBase64SubjectExampleRequest addBase64SubjectExampleRequest;
        public SubjectExampleServiceTest()
        {
            _apiClient = new ApiClient(new ComprefaceConfiguration(API_KEY_RECOGNITION_SERVICE, DOMAIN, PORT));
            addBase64SubjectExampleRequest = new AddBase64SubjectExampleRequest()
            {
                DetProbThreShold = 0.81m,
                File = IMAGE_BASE64_STRING
            };
        }

        [Fact]
        [SubjectExampleTestBeforeAfter]
        public async Task AddSubjectExampleAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            var subjectExample = new AddSubjectExampleRequest()
            {
                DetProbThreShold = 0.81m,
                FilePath = FILE_PATH,
                Subject = TEST_SUBJECT_EXAMPLE_NAME,
                FileName = FILE_NAME
            };

            var expectedAddExampleSubjectResponse = await _apiClient.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).AddSubjectExampleAsync(subjectExample);

            //Act
            var resultList = await _apiClient.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).GetAllSubjectExamplesAsync(
                new ListAllSubjectExamplesRequest() { Subject = TEST_SUBJECT_EXAMPLE_NAME });

            var actualSubjectExample = resultList.Faces
                .First(x => x.ImageId == expectedAddExampleSubjectResponse.ImageId & x.Subject == expectedAddExampleSubjectResponse.Subject);

            //Assert
            Assert.Equal(expectedAddExampleSubjectResponse.Subject, actualSubjectExample.Subject);
            Assert.Equal(expectedAddExampleSubjectResponse.ImageId, actualSubjectExample.ImageId);
        }

        [Fact]
        [SubjectExampleTestBeforeAfter]
        public async Task AddBase64SubjectExampleAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

            var expectedAddBase64SubjectExampleResponse = await _apiClient.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).AddBase64SubjectExampleAsync(addBase64SubjectExampleRequest);

            //Act
            var resultList = await _apiClient.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).GetAllSubjectExamplesAsync(
                new ListAllSubjectExamplesRequest() { Subject = TEST_SUBJECT_EXAMPLE_NAME });

            var actualSubjectExample = resultList.Faces
                    .First(x => x.ImageId == expectedAddBase64SubjectExampleResponse.ImageId & x.Subject == expectedAddBase64SubjectExampleResponse.Subject);

            //Assert
            Assert.Equal(expectedAddBase64SubjectExampleResponse.Subject, actualSubjectExample.Subject);
            Assert.Equal(expectedAddBase64SubjectExampleResponse.ImageId, actualSubjectExample.ImageId);
        }

        [Fact]
        [SubjectExampleTestBeforeAfter]
        public async Task GetAllSubjectExamplesAsync_TakesRequestModel_ReturnsProperResponseModel()
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
                await _apiClient.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).AddBase64SubjectExampleAsync(addBase64SubjectExampleRequest);
            }

            //Act
            var actualAllSubjectExamplesResponse = await _apiClient.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).GetAllSubjectExamplesAsync(allSubjectExamples);
            var actualCount = actualAllSubjectExamplesResponse.Faces.Count;

            //Assert
            Assert.Equal(actualCount, expectedCount);
        }

        [Fact]
        [SubjectExampleTestBeforeAfter]
        public async Task ClearSubjectAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

            var expectedCount = 3;

            for (int counter = expectedCount; counter > 0; counter--)
            {
                await _apiClient.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).AddBase64SubjectExampleAsync(addBase64SubjectExampleRequest);
            }

            //Act
            var actualResponse = await _apiClient.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).ClearSubjectAsync(
                new DeleteAllExamplesRequest() { Subject = TEST_SUBJECT_EXAMPLE_NAME });

            //Assert
            Assert.Equal(expectedCount, actualResponse.Deleted);
        }

        [Fact]
        [SubjectExampleTestBeforeAfter]
        public async Task DeleteImageByIdAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;
            var testImage = await _apiClient.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).AddBase64SubjectExampleAsync(addBase64SubjectExampleRequest);

            var deleteImageByIdRequest = new DeleteImageByIdRequest()
            {
                ImageId = testImage.ImageId
            };

            //Act
            var actualDeleteImageByIdResponse = await _apiClient.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).DeleteImageByIdAsync(deleteImageByIdRequest);

            //Assert
            Assert.Equal(testImage.Subject, actualDeleteImageByIdResponse.Subject);
            Assert.Equal(testImage.ImageId, actualDeleteImageByIdResponse.ImageId);
        }

        [Fact]
        [SubjectExampleTestBeforeAfter]
        public async Task DeletMultipleExamplesAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

            var expectedCount = 3;
            var unnecessaryExampleList = new List<Guid>();

            for (int counter = expectedCount; counter > 0; counter--)
            {
                var response = await _apiClient.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).AddBase64SubjectExampleAsync(addBase64SubjectExampleRequest);

                unnecessaryExampleList.Add(response.ImageId);
            }

            var expectedFacesCount = expectedCount;

            //Act
            var actualResponse = await _apiClient.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).DeletMultipleExamplesAsync(
                new DeleteMultipleExampleRequest() { ImageIdList = unnecessaryExampleList });

            var actualFacesCount = actualResponse.Faces.Count;

            //Assert
            Assert.Equal(expectedFacesCount, actualFacesCount);
        }

        [Fact]
        [SubjectExampleTestBeforeAfter]
        public async Task DownloadImageByIdAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

            var testImage = await _apiClient.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).AddBase64SubjectExampleAsync(addBase64SubjectExampleRequest);

            var expectedResult = Convert.FromBase64String(IMAGE_BASE64_STRING);

            //Act
            var actualResult = await _apiClient.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).DownloadImageByIdAsync(
                new DownloadImageByIdRequest() { ImageId = testImage.ImageId, RecognitionApiKey = Guid.Parse(API_KEY_RECOGNITION_SERVICE) });

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        [SubjectExampleTestBeforeAfter]
        public async Task DownloadImageBySubjectIdAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            addBase64SubjectExampleRequest.Subject = TEST_SUBJECT_EXAMPLE_NAME;

            var testImage = await _apiClient.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).AddBase64SubjectExampleAsync(addBase64SubjectExampleRequest);

            var expectedResult = Convert.FromBase64String(IMAGE_BASE64_STRING);

            //Act
            var actualResult = await _apiClient.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).DownloadImageBySubjectIdAsync(
                new DownloadImageBySubjectIdRequest() { ImageId = testImage.ImageId });

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
