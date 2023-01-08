using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddBase64ExampleSubject;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddExampleSubject;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteAllSubjectExamples;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteImageById;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteMultipleExamples;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DownloadImageById;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DownloadImageBySubjectId;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.ListAllExampleSubject;
using static Exadel.Compreface.Tests.UrlConstConfig;

namespace Exadel.Compreface.Tests.Services
{
    public class ExampleSubjectServiceTest
    {
        private readonly ComprefaceClient comprefaceApiClient;
        public ExampleSubjectServiceTest()
        {
            comprefaceApiClient = new ComprefaceClient(new ComprefaceConfiguration(API_KEY_SUBJECT_SERVICE, BASE_URL));
        }

        [Fact]
        public async Task AddExampleSubjectAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            var exampleSubject = new AddExampleSubjectRequest()
            {
                DetProbThreShold = 0.81m,
                FilePath = FILE_PATH,
                Subject = SUBJECT_NAME,
                FileName = FILE_NAME
            };
            //Act
            var addExampleSubjectResponse = await comprefaceApiClient.ExampleSubjectService.AddExampleSubjectAsync(exampleSubject);

            //Assert
            Assert.IsType<AddExampleSubjectResponse>(addExampleSubjectResponse);
        }

        [Fact]
        public async Task AddBase64ExampleSubjectAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            var addBase64ExampleSubjectRequest = new AddBase64ExampleSubjectRequest()
            {
                DetProbThreShold = 0.81m,
                Subject = SUBJECT_NAME,
                File = IMAGE_BASE64_STRING
            };

            //Act
            var addExampleSubjectBase64Response = await comprefaceApiClient.ExampleSubjectService.AddBase64ExampleSubjectAsync(addBase64ExampleSubjectRequest);

            //Assert
            Assert.IsType<AddBase64ExampleSubjectResponse>(addExampleSubjectBase64Response);
        }

        [Fact]
        public async Task GetAllExampleSubjectsAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            var allExampleSubject = new ListAllExampleSubjectRequest()
            {
                Page = 0,
                Size = 0,
                Subject = SUBJECT_NAME
            };

            //Act
            var getAllExampleSubjectsResponse = await comprefaceApiClient.ExampleSubjectService.GetAllExampleSubjectsAsync(allExampleSubject);

            //Assert
            Assert.IsType<ListAllExampleSubjectResponse>(getAllExampleSubjectsResponse);
        }

        [Fact]
        public async Task ClearSubjectAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            var subject = new DeleteAllExamplesRequest()
            {
                Subject = SUBJECT_NAME
            };

            //Act
            var clearAllExampleSubjectsResponse = await comprefaceApiClient.ExampleSubjectService.ClearSubjectAsync(subject);

            //Assert
            Assert.IsType<DeleteAllExamplesResponse>(clearAllExampleSubjectsResponse);
        }

        [Fact]
        public async Task DeleteImageByIdAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            var deleteImageByIdRequest = new DeleteImageByIdRequest()
            {
                ImageId = Guid.Parse(IMAGE_ID)
            };

            //Act
            var deleteImageByIdResponse = await comprefaceApiClient.ExampleSubjectService.DeleteImageByIdAsync(deleteImageByIdRequest);

            //Assert
            Assert.IsType<DeleteImageByIdResponse>(deleteImageByIdResponse);
        }

        [Fact]
        public async Task DeletMultipleExamplesAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            var deleteMultipleExampleRequest = new DeleteMultipleExampleRequest()
            {
                ImageIdList = new List<Guid>
                {
                    Guid.Parse(IMAGE_ID),
                    Guid.Parse(IMAGE_ID_SECOND)
                }
            };

            //Act
            var deleteMultipleExamplesResponse = await comprefaceApiClient.ExampleSubjectService.DeletMultipleExamplesAsync(deleteMultipleExampleRequest);

            //Assert
            Assert.IsType<DeleteMultipleExamplesResponse>(deleteMultipleExamplesResponse);
        }

        [Fact]
        public async Task DownloadImageByIdAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            var downloadImageByIdRequest = new DownloadImageByIdRequest()
            {
                RecognitionApiKey = Guid.Parse(API_KEY_RECOGNITION_SERVICE),
                ImageId = Guid.Parse(IMAGE_ID)
            };

            //Act
            var bytes = await comprefaceApiClient.ExampleSubjectService.DownloadImageByIdAsync(downloadImageByIdRequest);

            //Assert
            Assert.IsType<byte[]>(bytes);
        }

        [Fact]
        public async Task DownloadImageBySubjectIdAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            //Arrange
            var downloadImageBySubjectIdRequest = new DownloadImageBySubjectIdRequest()
            {
                ImageId = Guid.Parse(IMAGE_ID)
            };

            //Act
            var bytes = await comprefaceApiClient.ExampleSubjectService.DownloadImageBySubjectIdAsync(downloadImageBySubjectIdRequest);

            //Assert
            Assert.IsType<byte[]>(bytes);
        }
    }
}
