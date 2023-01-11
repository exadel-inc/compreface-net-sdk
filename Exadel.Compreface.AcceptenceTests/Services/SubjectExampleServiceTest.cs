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
using Exadel.Compreface.DTOs.SubjectDTOs.AddSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteSubject;
using Exadel.Compreface.Exceptions;
using static Exadel.Compreface.AcceptenceTests.UrlConstConfig;

namespace Exadel.Compreface.AcceptenceTests.Services
{
    public class SubjectExampleServiceTest
    {
        private readonly ComprefaceClient comprefaceApiClient;
        public SubjectExampleServiceTest()
        {
            comprefaceApiClient = new ComprefaceClient(new ComprefaceConfiguration(API_KEY_SUBJECT_SERVICE, BASE_URL));
        }

        [Fact]
        public async Task AddSubjectExampleAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            var addNewSubjectResponse = await comprefaceApiClient.SubjectService.AddSubject(new AddSubjectRequest() { Subject = TEST_SUBJECT_NAME });
            var subjectExample = new AddSubjectExampleRequest()
            {
                DetProbThreShold = 0.81m,
                FilePath = FILE_PATH,
                Subject = addNewSubjectResponse.Subject,
                FileName = FILE_NAME
            };

            var expectedAddExampleSubjectResponse = await comprefaceApiClient.SubjectExampleService.AddSubjectExampleAsync(subjectExample);

            //Act
            var resultList = await comprefaceApiClient.SubjectExampleService.GetAllSubjectExamplesAsync(new ListAllSubjectExamplesRequest() { Subject = addNewSubjectResponse.Subject });

            var actualSubjectExample = resultList.Faces
                .First(x => x.ImageId == expectedAddExampleSubjectResponse.ImageId & x.Subject == expectedAddExampleSubjectResponse.Subject);

            //Assert
            Assert.Equal(expectedAddExampleSubjectResponse.Subject, actualSubjectExample.Subject);
            Assert.Equal(expectedAddExampleSubjectResponse.ImageId, actualSubjectExample.ImageId);

            await comprefaceApiClient.SubjectExampleService.ClearSubjectAsync(new DeleteAllExamplesRequest() { Subject = addNewSubjectResponse.Subject });
        }

        [Fact]
        public async Task AddBase64SubjectExampleAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            var addNewSubjectResponse = await comprefaceApiClient.SubjectService.AddSubject(new AddSubjectRequest() { Subject = TEST_SUBJECT_NAME });
            var addBase64ExampleSubjectRequest = new AddBase64SubjectExampleRequest()
            {
                DetProbThreShold = 0.81m,
                Subject = addNewSubjectResponse.Subject,
                File = IMAGE_BASE64_STRING
            };

            var expectedAddBase64SubjectExampleResponse = await comprefaceApiClient.SubjectExampleService.AddBase64SubjectExampleAsync(addBase64ExampleSubjectRequest);

            //Act
            var resultList = await comprefaceApiClient.SubjectExampleService.GetAllSubjectExamplesAsync(new ListAllSubjectExamplesRequest() { Subject = addNewSubjectResponse.Subject });
            var actualSubjectExample = resultList.Faces
                    .First(x => x.ImageId == expectedAddBase64SubjectExampleResponse.ImageId & x.Subject == expectedAddBase64SubjectExampleResponse.Subject);

            //Assert
            Assert.Equal(expectedAddBase64SubjectExampleResponse.Subject, actualSubjectExample.Subject);
            Assert.Equal(expectedAddBase64SubjectExampleResponse.ImageId, actualSubjectExample.ImageId);

            await comprefaceApiClient.SubjectExampleService.ClearSubjectAsync(new DeleteAllExamplesRequest() { Subject = addNewSubjectResponse.Subject });
        }

        [Fact]
        public async Task GetAllSubjectExamplesAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            var addNewSubjectResponse = await comprefaceApiClient.SubjectService.AddSubject(new AddSubjectRequest() { Subject = TEST_SUBJECT_NAME });
            var allSubjectExamples = new ListAllSubjectExamplesRequest()
            {
                Page = 0,
                Size = 0,
                Subject = addNewSubjectResponse.Subject
            };

            var actualListAllExampleSubjectResponse = await comprefaceApiClient.SubjectExampleService.GetAllSubjectExamplesAsync(allSubjectExamples);
            var actualCount = actualListAllExampleSubjectResponse.Faces.Count;

            var difference = 3;

            for (int counter = difference; counter > 0; counter--)
            {
                await comprefaceApiClient.SubjectExampleService.AddBase64SubjectExampleAsync(
                    new AddBase64SubjectExampleRequest()
                    {
                        DetProbThreShold = 0.81m,
                        Subject = addNewSubjectResponse.Subject,
                        File = IMAGE_BASE64_STRING
                    });
            }

            //Act
            var expectedAllSubjectExamplesResponse = await comprefaceApiClient.SubjectExampleService.GetAllSubjectExamplesAsync(allSubjectExamples);
            var expectedCount = expectedAllSubjectExamplesResponse.Faces.Count;

            //Assert
            Assert.Equal(expectedCount, difference);

            await comprefaceApiClient.SubjectExampleService.ClearSubjectAsync(new DeleteAllExamplesRequest() { Subject = addNewSubjectResponse.Subject });
        }

        [Fact]
        public async Task ClearSubjectAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            var addNewSubjectResponse = await comprefaceApiClient.SubjectService.AddSubject(new AddSubjectRequest() { Subject = TEST_SUBJECT_NAME });

            var difference = 3;

            for (int counter = difference; counter > 0; counter--)
            {
                await comprefaceApiClient.SubjectExampleService.AddBase64SubjectExampleAsync(
                    new AddBase64SubjectExampleRequest()
                    {
                        DetProbThreShold = 0.81m,
                        Subject = addNewSubjectResponse.Subject,
                        File = IMAGE_BASE64_STRING
                    });
            }

            //Act
            var actualResponse = await comprefaceApiClient.SubjectExampleService.ClearSubjectAsync(new DeleteAllExamplesRequest() { Subject = addNewSubjectResponse.Subject });

            //Assert
            Assert.Equal(difference, actualResponse.Deleted);
        }

        [Fact]
        public async Task DeleteImageByIdAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            var addNewSubjectResponse = await comprefaceApiClient.SubjectService.AddSubject(new AddSubjectRequest() { Subject = TEST_SUBJECT_NAME });
            var testImage = await comprefaceApiClient.SubjectExampleService.AddBase64SubjectExampleAsync(
                new AddBase64SubjectExampleRequest()
                {
                    DetProbThreShold = 0.81m,
                    Subject = addNewSubjectResponse.Subject,
                    File = IMAGE_BASE64_STRING
                });

            var deleteImageByIdRequest = new DeleteImageByIdRequest()
            {
                ImageId = testImage.ImageId
            };

            //Act
            var deleteImageByIdResponse = await comprefaceApiClient.SubjectExampleService.DeleteImageByIdAsync(deleteImageByIdRequest);

            //Assert
            Assert.Equal(testImage.Subject, deleteImageByIdResponse.Subject);
            Assert.Equal(testImage.ImageId, deleteImageByIdResponse.ImageId);

            await comprefaceApiClient.SubjectService.DeleteSubject(new DeleteSubjectRequest() { ActualSubject = testImage.Subject });
        }

        [Fact]
        public async Task DeletMultipleExamplesAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            var addNewSubjectResponse = await comprefaceApiClient.SubjectService.AddSubject(new AddSubjectRequest() { Subject = TEST_SUBJECT_NAME });

            var difference = 3;
            List<Guid> unnecessaryExampleList = new List<Guid>();

            for (int counter = difference; counter > 0; counter--)
            {
                var response = await comprefaceApiClient.SubjectExampleService.AddBase64SubjectExampleAsync(
                    new AddBase64SubjectExampleRequest()
                    {
                        DetProbThreShold = 0.81m,
                        Subject = SUBJECT_NAME,
                        File = IMAGE_BASE64_STRING
                    });

                unnecessaryExampleList.Add(response.ImageId);
            }

            var expectedFacesCount = difference;

            //Act
            var actualResponse = await comprefaceApiClient.SubjectExampleService.DeletMultipleExamplesAsync(new DeleteMultipleExampleRequest() { ImageIdList = unnecessaryExampleList });
            var actualFacesCount = actualResponse.Faces.Count;

            //Assert
            Assert.Equal(expectedFacesCount, actualFacesCount);

            await comprefaceApiClient.SubjectService.DeleteSubject(new DeleteSubjectRequest() { ActualSubject = addNewSubjectResponse.Subject });
        }

        [Fact]
        public async Task DownloadImageByIdAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            var addNewSubjectResponse = await comprefaceApiClient.SubjectService.AddSubject(new AddSubjectRequest() { Subject = TEST_SUBJECT_NAME });
            var testImage = await comprefaceApiClient.SubjectExampleService.AddBase64SubjectExampleAsync(
                new AddBase64SubjectExampleRequest()
                {
                    DetProbThreShold = 0.81m,
                    Subject = addNewSubjectResponse.Subject,
                    File = IMAGE_BASE64_STRING
                });

            var expectedImage = Convert.FromBase64String(IMAGE_BASE64_STRING);

            //Act
            var actualResult = await comprefaceApiClient.SubjectExampleService.DownloadImageByIdAsync(new DownloadImageByIdRequest() { ImageId = testImage.ImageId, RecognitionApiKey = Guid.Parse(API_KEY_SUBJECT_SERVICE) });

            //Assert
            Assert.Equal(expectedImage, actualResult);

            await comprefaceApiClient.SubjectExampleService.ClearSubjectAsync(new DeleteAllExamplesRequest() { Subject = addNewSubjectResponse.Subject });
        }

        [Fact]
        public async Task DownloadImageBySubjectIdAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            var addNewSubjectResponse = await comprefaceApiClient.SubjectService.AddSubject(new AddSubjectRequest() { Subject = TEST_SUBJECT_NAME });
            var testImage = await comprefaceApiClient.SubjectExampleService.AddBase64SubjectExampleAsync(
                new AddBase64SubjectExampleRequest()
                {
                    DetProbThreShold = 0.81m,
                    Subject = addNewSubjectResponse.Subject,
                    File = IMAGE_BASE64_STRING
                });

            var expectedImage = Convert.FromBase64String(IMAGE_BASE64_STRING);

            //Act
            var actualResult = await comprefaceApiClient.SubjectExampleService.DownloadImageBySubjectIdAsync(new DownloadImageBySubjectIdRequest() { ImageId = testImage.ImageId });

            //Assert
            Assert.Equal(expectedImage, actualResult);

            await comprefaceApiClient.SubjectExampleService.ClearSubjectAsync(new DeleteAllExamplesRequest() { Subject = addNewSubjectResponse.Subject });
        }
    }
}
