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
        public async Task AddSubjectExampleAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            var subjectExample = new AddSubjectExampleRequest()
            {
                DetProbThreShold = 0.81m,
                FilePath = FILE_PATH,
                Subject = TEST_SUBJECT_NAME,
                FileName = FILE_NAME
            };

            var expectedAddExampleSubjectResponse = await faceRecognitionClient.SubjectExampleService.AddSubjectExampleAsync(subjectExample);

            //Act
            var resultList = await faceRecognitionClient.SubjectExampleService.GetAllSubjectExamplesAsync(
                new ListAllSubjectExamplesRequest() { Subject = TEST_SUBJECT_NAME });

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

            var expectedAddBase64SubjectExampleResponse = await faceRecognitionClient.SubjectExampleService.AddBase64SubjectExampleAsync(addBase64SubjectExampleRequest);

            //Act
            var resultList = await faceRecognitionClient.SubjectExampleService.GetAllSubjectExamplesAsync(
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
                await faceRecognitionClient.SubjectExampleService.AddBase64SubjectExampleAsync(addBase64SubjectExampleRequest);
            }

            //Act
            var actualAllSubjectExamplesResponse = await faceRecognitionClient.SubjectExampleService.GetAllSubjectExamplesAsync(allSubjectExamples);
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
                await faceRecognitionClient.SubjectExampleService.AddBase64SubjectExampleAsync(addBase64SubjectExampleRequest);
            }

            //Act
            var actualResponse = await faceRecognitionClient.SubjectExampleService.ClearSubjectAsync(
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
            var testImage = await faceRecognitionClient.SubjectExampleService.AddBase64SubjectExampleAsync(addBase64SubjectExampleRequest);

            var deleteImageByIdRequest = new DeleteImageByIdRequest()
            {
                ImageId = testImage.ImageId
            };

            //Act
            var actualDeleteImageByIdResponse = await faceRecognitionClient.SubjectExampleService.DeleteImageByIdAsync(deleteImageByIdRequest);

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
            List<Guid> unnecessaryExampleList = new List<Guid>();

            for (int counter = expectedCount; counter > 0; counter--)
            {
                var response = await faceRecognitionClient.SubjectExampleService.AddBase64SubjectExampleAsync(addBase64SubjectExampleRequest);

                unnecessaryExampleList.Add(response.ImageId);
            }

            var expectedFacesCount = expectedCount;

            //Act
            var actualResponse = await faceRecognitionClient.SubjectExampleService.DeletMultipleExamplesAsync(
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

            var testImage = await faceRecognitionClient.SubjectExampleService.AddBase64SubjectExampleAsync(addBase64SubjectExampleRequest);

            var expectedResult = Convert.FromBase64String(IMAGE_BASE64_STRING);

            //Act
            var actualResult = await faceRecognitionClient.SubjectExampleService.DownloadImageByIdAsync(
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

            var testImage = await faceRecognitionClient.SubjectExampleService.AddBase64SubjectExampleAsync(addBase64SubjectExampleRequest);

            var expectedResult = Convert.FromBase64String(IMAGE_BASE64_STRING);

            //Act
            var actualResult = await faceRecognitionClient.SubjectExampleService.DownloadImageBySubjectIdAsync(
                new DownloadImageBySubjectIdRequest() { ImageId = testImage.ImageId });

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
