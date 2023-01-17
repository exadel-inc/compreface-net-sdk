using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.SubjectDTOs.AddSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteAllSubjects;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.GetSubjectList;
using Exadel.Compreface.DTOs.SubjectDTOs.RenameSubject;
using Exadel.Compreface.Services;
using Moq;
using Tynamix.ObjectFiller;

namespace Exadel.Compreface.UnitTests.Services
{
    public class SubjectServiceTests
    {
        private readonly Mock<IApiClient> _apiClientMock;
        private readonly SubjectService _subjectService;

        public SubjectServiceTests()
        {
            var apiKey = GetRandomString();
            var baseUrl = GetRandomString();
            var configuration = new ComprefaceConfiguration(apiKey, baseUrl);

            _apiClientMock = new Mock<IApiClient>();
            _subjectService = new SubjectService(configuration, _apiClientMock.Object);
        }

        [Fact]
        public async void GetAllSubject_Executes_ReturnsProperResponseModel()
        {
            // Arrange
            SetupGetJson<GetAllSubjectResponse>();

            // Act
            var response = await _subjectService.GetAllSubject();

            // Assert
            Assert.IsType<GetAllSubjectResponse>(response);

            VerifyGetJson<GetAllSubjectResponse>();
            _apiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async void GetAllSubject_Executes_ReturnsNotNull()
        {
            // Arrange
            SetupGetJson<GetAllSubjectResponse>();

            // Act
            var response = await _subjectService.GetAllSubject();

            // Assert
            Assert.NotNull(response);

            VerifyGetJson<GetAllSubjectResponse>();
            _apiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async void AddSubject_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new AddSubjectRequest();

            SetupPostJson<AddSubjectResponse>();

            // Act
            var response = await _subjectService.AddSubject(request);

            // Assert
            Assert.IsType<AddSubjectResponse>(response);

            VerifyPostJson<AddSubjectResponse>();
            _apiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async void AddSubject_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            var request = new AddSubjectRequest();

            SetupPostJson<AddSubjectResponse>();

            // Act
            var response = await _subjectService.AddSubject(request);

            // Assert
            Assert.NotNull(response);

            VerifyPostJson<AddSubjectResponse>();
            _apiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async void RenameSubject_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new RenameSubjectRequest();

            SetupPutJson<RenameSubjectResponse>();

            // Act
            var response = await _subjectService.RenameSubject(request);

            // Assert
            Assert.IsType<RenameSubjectResponse>(response);

            VerifyPutJson<RenameSubjectResponse>();
            _apiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async void RenameSubject_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            var request = new RenameSubjectRequest();

            SetupPutJson<RenameSubjectResponse>();

            // Act
            var response = await _subjectService.RenameSubject(request);

            // Assert
            Assert.NotNull(response);

            VerifyPutJson<RenameSubjectResponse>();
            _apiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async void RenameSubject_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Arrange
            SetupPutJson<RenameSubjectRequest>();

            // Act
            var func = async () => await _subjectService.RenameSubject(null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async void DeleteSubject_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new DeleteSubjectRequest();

            SetupDeleteJson<DeleteSubjectResponse>();

            // Act
            var response = await _subjectService.DeleteSubject(request);

            // Assert
            Assert.IsType<DeleteSubjectResponse>(response);

            VerifyDeleteJson<DeleteSubjectResponse>();
            _apiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async void DeleteSubject_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            var request = new DeleteSubjectRequest();

            SetupDeleteJson<DeleteSubjectResponse>();

            // Act
            var response = await _subjectService.DeleteSubject(request);

            // Assert
            Assert.NotNull(response);

            VerifyDeleteJson<DeleteSubjectResponse>();
            _apiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async void DeleteSubject_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Arrange
            SetupDeleteJson<DeleteSubjectRequest>();

            // Act
            var func = async () => await _subjectService.DeleteSubject(null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async void DeleteAllSubjects_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            SetupDeleteJson<DeleteAllSubjectsResponse>();

            // Act
            var response = await _subjectService.DeleteAllSubjects();

            // Assert
            Assert.IsType<DeleteAllSubjectsResponse>(response);

            VerifyDeleteJson<DeleteAllSubjectsResponse>();
            _apiClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async void DeleteAllSubjects_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            SetupDeleteJson<DeleteAllSubjectsResponse>();

            // Act
            var response = await _subjectService.DeleteAllSubjects();

            // Assert
            Assert.NotNull(response);

            VerifyDeleteJson<DeleteAllSubjectsResponse>();
            _apiClientMock.VerifyNoOtherCalls();
        }

        private static string GetRandomString()
        {
            return new Filler<string>().Create();
        }

        private void SetupGetJson<TResponse>() where TResponse : new()
        {
            _apiClientMock.Setup(apiClient =>
                apiClient.GetJsonAsync<TResponse>(
                    It.IsAny<string>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TResponse());
        }

        private void VerifyGetJson<TResponse>()
        {
            _apiClientMock.Verify(apiClient =>
                apiClient.GetJsonAsync<TResponse>(
                    It.IsAny<string>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()), Times.Once);
        }

        private void SetupPostJson<TResponse>() where TResponse : class, new()
        {
            _apiClientMock.Setup(apiClient =>
                apiClient.PostJsonAsync<TResponse>(
                    It.IsAny<string>(),
                    It.IsAny<object>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TResponse());
        }

        private void VerifyPostJson<TResponse>() where TResponse : class
        {
            _apiClientMock.Verify(apiClient =>
                apiClient.PostJsonAsync<TResponse>(
                    It.IsAny<string>(),
                    It.IsAny<object>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()), Times.Once);
        }

        private void SetupPutJson<TResponse>() where TResponse : class, new()
        {
            _apiClientMock.Setup(apiClient =>
                apiClient.PutJsonAsync<TResponse>(
                    It.IsAny<string>(),
                    It.IsAny<object>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TResponse());
        }

        private void VerifyPutJson<TResponse>() where TResponse : class
        {
            _apiClientMock.Verify(apiClient =>
                apiClient.PutJsonAsync<TResponse>(
                    It.IsAny<string>(),
                    It.IsAny<object>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()), Times.Once);
        }

        private void SetupDeleteJson<TResponse>() where TResponse : class, new()
        {
            _apiClientMock.Setup(apiClient =>
                apiClient.DeleteJsonAsync<TResponse>(
                    It.IsAny<string>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TResponse());
        }

        private void VerifyDeleteJson<TResponse>() where TResponse : class
        {
            _apiClientMock.Verify(apiClient =>
                apiClient.DeleteJsonAsync<TResponse>(
                    It.IsAny<string>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
