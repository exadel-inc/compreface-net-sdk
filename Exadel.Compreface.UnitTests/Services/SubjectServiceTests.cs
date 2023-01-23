using Exadel.Compreface.DTOs.SubjectDTOs.AddSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteAllSubjects;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.GetSubjectList;
using Exadel.Compreface.DTOs.SubjectDTOs.RenameSubject;
using Exadel.Compreface.Services;

namespace Exadel.Compreface.UnitTests.Services
{
    public class SubjectServiceTests : AbstractBaseServiceTests
    {
        private readonly SubjectService _subjectService;

        public SubjectServiceTests()
        {
            _subjectService = new SubjectService(Configuration, ApiClientMock.Object);
        }

        [Fact]
        public async Task GetAllSubject_Executes_ReturnsProperResponseModel()
        {
            // Arrange
            SetupGetJson<GetAllSubjectResponse>();

            // Act
            var response = await _subjectService.GetAllSubject();

            // Assert
            Assert.IsType<GetAllSubjectResponse>(response);

            VerifyGetJson<GetAllSubjectResponse>();
            ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetAllSubject_Executes_ReturnsNotNull()
        {
            // Arrange
            SetupGetJson<GetAllSubjectResponse>();

            // Act
            var response = await _subjectService.GetAllSubject();

            // Assert
            Assert.NotNull(response);

            VerifyGetJson<GetAllSubjectResponse>();
            ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task AddSubject_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new AddSubjectRequest();

            SetupPostJson<AddSubjectResponse, string>();

            // Act
            var response = await _subjectService.AddSubject(request);

            // Assert
            Assert.IsType<AddSubjectResponse>(response);

            VerifyPostJson<AddSubjectResponse, string>();
            ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task AddSubject_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            var request = new AddSubjectRequest();

            SetupPostJson<AddSubjectResponse, string>();

            // Act
            var response = await _subjectService.AddSubject(request);

            // Assert
            Assert.NotNull(response);

            VerifyPostJson<AddSubjectResponse, string>();
            ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task RenameSubject_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new RenameSubjectRequest();

            SetupPutJson<RenameSubjectResponse>();

            // Act
            var response = await _subjectService.RenameSubject(request);

            // Assert
            Assert.IsType<RenameSubjectResponse>(response);

            VerifyPutJson<RenameSubjectResponse>();
            ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task RenameSubject_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            var request = new RenameSubjectRequest();

            SetupPutJson<RenameSubjectResponse>();

            // Act
            var response = await _subjectService.RenameSubject(request);

            // Assert
            Assert.NotNull(response);

            VerifyPutJson<RenameSubjectResponse>();
            ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task RenameSubject_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Arrange
            SetupPutJson<RenameSubjectRequest>();

            // Act
            var func = async () => await _subjectService.RenameSubject(null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task DeleteSubject_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new DeleteSubjectRequest();

            SetupDeleteJson<DeleteSubjectResponse>();

            // Act
            var response = await _subjectService.DeleteSubject(request);

            // Assert
            Assert.IsType<DeleteSubjectResponse>(response);

            VerifyDeleteJson<DeleteSubjectResponse>();
            ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DeleteSubject_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            var request = new DeleteSubjectRequest();

            SetupDeleteJson<DeleteSubjectResponse>();

            // Act
            var response = await _subjectService.DeleteSubject(request);

            // Assert
            Assert.NotNull(response);

            VerifyDeleteJson<DeleteSubjectResponse>();
            ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DeleteSubject_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Arrange
            SetupDeleteJson<DeleteSubjectRequest>();

            // Act
            var func = async () => await _subjectService.DeleteSubject(null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task DeleteAllSubjects_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            SetupDeleteJson<DeleteAllSubjectsResponse>();

            // Act
            var response = await _subjectService.DeleteAllSubjects();

            // Assert
            Assert.IsType<DeleteAllSubjectsResponse>(response);

            VerifyDeleteJson<DeleteAllSubjectsResponse>();
            ApiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DeleteAllSubjects_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            SetupDeleteJson<DeleteAllSubjectsResponse>();

            // Act
            var response = await _subjectService.DeleteAllSubjects();

            // Assert
            Assert.NotNull(response);

            VerifyDeleteJson<DeleteAllSubjectsResponse>();
            ApiClientMock.VerifyNoOtherCalls();
        }
    }
}
