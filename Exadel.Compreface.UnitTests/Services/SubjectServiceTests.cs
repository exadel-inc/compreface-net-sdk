using Exadel.Compreface.DTOs.SubjectDTOs.AddSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteAllSubjects;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.GetSubjectList;
using Exadel.Compreface.DTOs.SubjectDTOs.RenameSubject;
using Exadel.Compreface.Services;

namespace Exadel.Compreface.UnitTests.Services
{
    public class SubjectServiceTests : AbstractBaseServiceTests<SubjectService>
    {
        private readonly SubjectService _service;

        public SubjectServiceTests()
        {
            _service = ServiceMock.Object;
        }

        [Fact]
        public async Task GetAllSubject_Executes_ReturnsProperResponseModel()
        {
            // Arrange
            SetupGetJson<GetAllSubjectResponse>();

            // Act
            var response = await _service.GetAllSubject();

            // Assert
            Assert.IsType<GetAllSubjectResponse>(response);

            VerifyGetJson<GetAllSubjectResponse>();
            ServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetAllSubject_Executes_ReturnsNotNull()
        {
            // Arrange
            SetupGetJson<GetAllSubjectResponse>();

            // Act
            var response = await _service.GetAllSubject();

            // Assert
            Assert.NotNull(response);

            VerifyGetJson<GetAllSubjectResponse>();
            ServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task AddSubject_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new AddSubjectRequest();

            SetupPostJson<AddSubjectResponse, string>();

            // Act
            var response = await _service.AddSubject(request);

            // Assert
            Assert.IsType<AddSubjectResponse>(response);

            VerifyPostJson<AddSubjectResponse, string>();
            ServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task AddSubject_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            var request = new AddSubjectRequest();

            SetupPostJson<AddSubjectResponse, string>();

            // Act
            var response = await _service.AddSubject(request);

            // Assert
            Assert.NotNull(response);

            VerifyPostJson<AddSubjectResponse, string>();
            ServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task RenameSubject_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new RenameSubjectRequest();

            SetupPutJson<RenameSubjectResponse>();

            // Act
            var response = await _service.RenameSubject(request);

            // Assert
            Assert.IsType<RenameSubjectResponse>(response);

            VerifyPutJson<RenameSubjectResponse>();
            ServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task RenameSubject_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            var request = new RenameSubjectRequest();

            SetupPutJson<RenameSubjectResponse>();

            // Act
            var response = await _service.RenameSubject(request);

            // Assert
            Assert.NotNull(response);

            VerifyPutJson<RenameSubjectResponse>();
            ServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task RenameSubject_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Arrange
            SetupPutJson<RenameSubjectRequest>();

            // Act
            var func = async () => await _service.RenameSubject(null!);

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
            var response = await _service.DeleteSubject(request);

            // Assert
            Assert.IsType<DeleteSubjectResponse>(response);

            VerifyDeleteJson<DeleteSubjectResponse>();
            ServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DeleteSubject_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            var request = new DeleteSubjectRequest();

            SetupDeleteJson<DeleteSubjectResponse>();

            // Act
            var response = await _service.DeleteSubject(request);

            // Assert
            Assert.NotNull(response);

            VerifyDeleteJson<DeleteSubjectResponse>();
            ServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DeleteSubject_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Arrange
            SetupDeleteJson<DeleteSubjectRequest>();

            // Act
            var func = async () => await _service.DeleteSubject(null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task DeleteAllSubjects_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            SetupDeleteJson<DeleteAllSubjectsResponse>();

            // Act
            var response = await _service.DeleteAllSubjects();

            // Assert
            Assert.IsType<DeleteAllSubjectsResponse>(response);

            VerifyDeleteJson<DeleteAllSubjectsResponse>();
            ServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DeleteAllSubjects_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            SetupDeleteJson<DeleteAllSubjectsResponse>();

            // Act
            var response = await _service.DeleteAllSubjects();

            // Assert
            Assert.NotNull(response);

            VerifyDeleteJson<DeleteAllSubjectsResponse>();
            ServiceMock.VerifyNoOtherCalls();
        }
    }
}
