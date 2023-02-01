using Exadel.Compreface.Clients;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.SubjectDTOs.AddSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteAllSubjects;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.GetSubjectList;
using Exadel.Compreface.DTOs.SubjectDTOs.RenameSubject;
using Exadel.Compreface.Exceptions;
using Exadel.Compreface.Services;
using static Exadel.Compreface.AcceptenceTests.UrlConstConfig;

namespace Exadel.Compreface.AcceptenceTests.Services
{
    public class SubjectServiceTests
    {
        private readonly SubjectService _subjectService;

        private readonly AddSubjectRequest _addSubjectRequest;
        private readonly RenameSubjectRequest _renameSubjectRequest;
        private readonly DeleteSubjectRequest _deleteSubjectRequest;
        private readonly DeleteSubjectRequest _renamedSubjectDeleteRequest;

        public SubjectServiceTests()
        {
            var configuration = new ComprefaceConfiguration(API_KEY_RECOGNITION_SERVICE, DOMAIN, PORT);
            var client = new CompreFaceClient(configuration);
            var subjectName = TEST_SUBJECT_NAME;
            var renamedSubjectName = RENAMED_SUBJECT_NAME;

            _subjectService = client.GetService<SubjectService>(API_KEY_RECOGNITION_SERVICE);

            _addSubjectRequest = new AddSubjectRequest
            {
                Subject = subjectName
            };

            _renameSubjectRequest = new RenameSubjectRequest
            {
                CurrentSubject = subjectName,
                Subject = renamedSubjectName
            };

            _deleteSubjectRequest = new DeleteSubjectRequest
            {
                ActualSubject = subjectName
            };

            _renamedSubjectDeleteRequest = new DeleteSubjectRequest
            {
                ActualSubject = renamedSubjectName
            };
        }

        [Fact]
        public async Task GetAllAsync_Executes_ReturnsProperResponseModel()
        {
            // Act
            var response = await _subjectService.ListAsync();

            // Assert
            Assert.IsType<GetAllSubjectResponse>(response);
        }

        [Fact]
        public async Task GetAllAsync_Executes_ReturnsNotNull()
        {
            // Act
            var response = await _subjectService.ListAsync();

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task AddAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Act
            var response = await _subjectService.AddAsync(_addSubjectRequest);

            // Assert
            Assert.IsType<AddSubjectResponse>(response);

            // Clear
            await _subjectService.DeleteAsync(new DeleteSubjectRequest { ActualSubject = _addSubjectRequest.Subject });
        }

        [Fact]
        public async Task AddAsync_TakesRequestModel_ReturnsNotNull()
        {
            // Act
            var response = await _subjectService.AddAsync(_addSubjectRequest);

            // Assert
            Assert.NotNull(response);
            await _subjectService.DeleteAsync(new DeleteSubjectRequest { ActualSubject = _addSubjectRequest.Subject });
        }

        [Fact]
        public async Task AddAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Act
            var func = async () => await _subjectService.AddAsync(null!);

            // Assert
            await Assert.ThrowsAsync<ServiceException>(func);
        }

        [Fact]
        public async Task AddAsync_TakesNullRequestModel_ThrowsServiceException()
        {
            //Arrange 
            var addSubjectRequest = new AddSubjectRequest
            {
                Subject = TEST_SUBJECT_NAME
            };
            await _subjectService.AddAsync(addSubjectRequest);

            // Act
            var func = async () => await _subjectService.AddAsync(null!);

            // Assert
            await Assert.ThrowsAsync<ServiceException>(func);

            // Clear
            await _subjectService.DeleteAsync(new DeleteSubjectRequest { ActualSubject = addSubjectRequest.Subject });
        }

        [Fact]
        public async Task RenameAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            await _subjectService.AddAsync(_addSubjectRequest);

            // Act
            var response = await _subjectService.RenameAsync(_renameSubjectRequest);
            await _subjectService.DeleteAsync(_renamedSubjectDeleteRequest);

            // Assert
            Assert.IsType<RenameSubjectResponse>(response);
        }

        [Fact]
        public async Task RenameAsync_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            await _subjectService.AddAsync(_addSubjectRequest);

            // Act
            var response = await _subjectService.RenameAsync(_renameSubjectRequest);
            await _subjectService.DeleteAsync(_renamedSubjectDeleteRequest);

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task RenameAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Act
            var func = async () => await _subjectService.RenameAsync(null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task RenameAsync_TakesNullRequestModel_ThrowsServiceException()
        {
            //Arrange 
            var addSubjectRequest = new AddSubjectRequest
            {
                Subject = TEST_SUBJECT_NAME
            };
            await _subjectService.AddAsync(addSubjectRequest);

            var renameSubjectRequest = new RenameSubjectRequest
            {
                CurrentSubject = addSubjectRequest.Subject,
                Subject = ""
            };

            // Act
            var func = async () => await _subjectService.RenameAsync(renameSubjectRequest);

            // Assert
            await Assert.ThrowsAsync<ServiceException>(func);

            // Clear
            await _subjectService.DeleteAsync(new DeleteSubjectRequest { ActualSubject = addSubjectRequest.Subject });
        }

        [Fact]
        public async Task DeleteAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            await _subjectService.AddAsync(_addSubjectRequest);

            // Act
            var response = await _subjectService.DeleteAsync(_deleteSubjectRequest);

            // Assert
            Assert.IsType<DeleteSubjectResponse>(response);
        }

        [Fact]
        public async Task DeleteAsync_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            await _subjectService.AddAsync(_addSubjectRequest);

            // Act
            var response = await _subjectService.DeleteAsync(_deleteSubjectRequest);

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task DeleteAsync_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Act
            var func = async () => await _subjectService.DeleteAsync(null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async Task DeleteAsync_TakesNullRequestModel_ThrowsServiceException()
        {
            // Act
            var func = async () => await _subjectService.DeleteAsync(_deleteSubjectRequest);

            // Assert
            await Assert.ThrowsAsync<ServiceException>(func);
        }

        [Fact]
        public async Task DeleteAllAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Act
            var response = await _subjectService.DeleteAllAsync();

            // Assert
            Assert.IsType<DeleteAllSubjectsResponse>(response);
        }

        [Fact]
        public async Task DeleteAllAsync_TakesRequestModel_ReturnsNotNull()
        {
            // Act
            var response = await _subjectService.DeleteAllAsync();

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task DeleteAllAsync_TakesNullRequestModel_ThrowsServiceException()
        {
            //Arrange
            var configuration = new ComprefaceConfiguration(API_KEY_DETECTION_SERVICE, DOMAIN, PORT);
            var client = new FaceRecognitionClient(configuration);

            var subjectService = client.SubjectService;

            // Act
            var func = async () => await subjectService.DeleteAllAsync();

            // Assert
            await Assert.ThrowsAsync<ServiceException>(func);
        }
    }
}
