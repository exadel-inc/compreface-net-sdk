using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.SubjectDTOs.AddSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteAllSubjects;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.GetSubjectList;
using Exadel.Compreface.DTOs.SubjectDTOs.RenameSubject;
using static Exadel.Compreface.UnitTests.Helpers.GetRandomStringHelper;
using Exadel.Compreface.Services.RecognitionService;
using Exadel.Compreface.UnitTests.Helpers;

namespace Exadel.Compreface.UnitTests.Services
{
    public class SubjectTests : SetupAndVerifyTests
    {
        private readonly IComprefaceConfiguration _comprefaceConfiguration;

        private readonly Subject _subject;

        public SubjectTests()
        {
            var apiKey = GetRandomString();
            var domain = GetRandomString();
            var port = GetRandomString();

            _comprefaceConfiguration = new ComprefaceConfiguration(apiKey, domain, port);

            _subject = new Subject(_comprefaceConfiguration);

            _subject.ApiClient = ApiClientMock.Object;
        }

        [Fact]
        public async Task GetAllAsync_Executes_ReturnsProperResponseModel()
        {
            // Arrange
            SetupGetJson<GetAllSubjectResponse>();

            // Act
            var response = await _subject.ListAsync();

            // Assert
            Assert.IsType<GetAllSubjectResponse>(response);

            VerifyGetJson<GetAllSubjectResponse>();
            ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetAllAsync_Executes_ReturnsNotNull()
        {
            // Arrange
            SetupGetJson<GetAllSubjectResponse>();

            // Act
            var response = await _subject.ListAsync();

            // Assert
            Assert.NotNull(response);

            VerifyGetJson<GetAllSubjectResponse>();
            ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task AddAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new AddSubjectRequest();

            SetupPostJson<AddSubjectResponse, string>();

            // Act
            var response = await _subject.AddAsync(request);

            // Assert
            Assert.IsType<AddSubjectResponse>(response);

            VerifyPostJson<AddSubjectResponse, string>();
            ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task AddAsync_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            var request = new AddSubjectRequest();

            SetupPostJson<AddSubjectResponse, string>();

            // Act
            var response = await _subject.AddAsync(request);

            // Assert
            Assert.NotNull(response);

            VerifyPostJson<AddSubjectResponse, string>();
            ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task RenameAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new RenameSubjectRequest();

            SetupPutJson<RenameSubjectResponse>();

            // Act
            var response = await _subject.RenameAsync(request);

            // Assert
            Assert.IsType<RenameSubjectResponse>(response);

            VerifyPutJson<RenameSubjectResponse>();
            ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task RenameAsync_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            var request = new RenameSubjectRequest();

            SetupPutJson<RenameSubjectResponse>();

            // Act
            var response = await _subject.RenameAsync(request);

            // Assert
            Assert.NotNull(response);

            VerifyPutJson<RenameSubjectResponse>();
            ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task RenameAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Arrange
            SetupPutJson<RenameSubjectRequest>();

            // Act
            var func = async () => await _subject.RenameAsync(null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task DeleteAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new DeleteSubjectRequest();

            SetupDeleteJson<DeleteSubjectResponse>();

            // Act
            var response = await _subject.DeleteAsync(request);

            // Assert
            Assert.IsType<DeleteSubjectResponse>(response);

            VerifyDeleteJson<DeleteSubjectResponse>();
            ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DeleteAsync_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            var request = new DeleteSubjectRequest();

            SetupDeleteJson<DeleteSubjectResponse>();

            // Act
            var response = await _subject.DeleteAsync(request);

            // Assert
            Assert.NotNull(response);

            VerifyDeleteJson<DeleteSubjectResponse>();
            ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DeleteAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Arrange
            SetupDeleteJson<DeleteSubjectRequest>();

            // Act
            var func = async () => await _subject.DeleteAsync(null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task DeleteAllAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            SetupDeleteJson<DeleteAllSubjectsResponse>();

            // Act
            var response = await _subject.DeleteAllAsync();

            // Assert
            Assert.IsType<DeleteAllSubjectsResponse>(response);

            VerifyDeleteJson<DeleteAllSubjectsResponse>();
            ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DeleteAllAsync_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            SetupDeleteJson<DeleteAllSubjectsResponse>();

            // Act
            var response = await _subject.DeleteAllAsync();

            // Assert
            Assert.NotNull(response);

            VerifyDeleteJson<DeleteAllSubjectsResponse>();
            ApiClientMock.VerifyNoOtherCalls();
        }
    }
}
