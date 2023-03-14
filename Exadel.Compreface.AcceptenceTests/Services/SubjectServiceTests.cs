//using Exadel.Compreface.Clients;
//using Exadel.Compreface.Configuration;
//using Exadel.Compreface.DTOs.SubjectDTOs.AddSubject;
//using Exadel.Compreface.DTOs.SubjectDTOs.DeleteAllSubjects;
//using Exadel.Compreface.DTOs.SubjectDTOs.DeleteSubject;
//using Exadel.Compreface.DTOs.SubjectDTOs.GetSubjectList;
//using Exadel.Compreface.DTOs.SubjectDTOs.RenameSubject;
//using Exadel.Compreface.Exceptions;
//using Exadel.Compreface.Services;
//using static Exadel.Compreface.AcceptenceTests.UrlConstConfig;

//namespace Exadel.Compreface.AcceptenceTests.Services
//{
//    public class SubjectServiceTests
//    {
//        private readonly SubjectService _subjectService;

//        private readonly AddSubjectRequest _addSubjectRequest;
//        private readonly RenameSubjectRequest _renameSubjectRequest;
//        private readonly DeleteSubjectRequest _deleteSubjectRequest;
//        private readonly DeleteSubjectRequest _renamedSubjectDeleteRequest;

//        public SubjectServiceTests()
//        {
//            var configuration = new ComprefaceConfiguration(API_KEY_RECOGNITION_SERVICE, DOMAIN, PORT);
//            var client = new FaceRecognitionClient(configuration);
//            var subjectName = TEST_SUBJECT_NAME;
//            var renamedSubjectName = RENAMED_SUBJECT_NAME;

//            _subjectService = client.SubjectService;

//            _addSubjectRequest = new AddSubjectRequest
//            {
//                Subject = subjectName
//            };
//            _renameSubjectRequest = new RenameSubjectRequest
//            {
//                CurrentSubject = subjectName,
//                Subject = renamedSubjectName
//            };
//            _deleteSubjectRequest = new DeleteSubjectRequest
//            {
//                ActualSubject = subjectName
//            };
//            _renamedSubjectDeleteRequest = new DeleteSubjectRequest
//            {
//                ActualSubject = renamedSubjectName
//            };
//        }

//        [Fact]
//        public async Task GetAllSubject_Executes_ReturnsProperResponseModel()
//        {
//            // Act
//            var response = await _subjectService.GetAllSubject();

//            // Assert
//            Assert.IsType<GetAllSubjectResponse>(response);
//        }

//        [Fact]
//        public async Task GetAllSubject_Executes_ReturnsNotNull()
//        {
//            // Act
//            var response = await _subjectService.GetAllSubject();

//            // Assert
//            Assert.NotNull(response);
//        }

//        [Fact]
//        public async Task AddSubject_TakesRequestModel_ReturnsProperResponseModel()
//        {
//            // Act
//            var response = await _subjectService.AddSubject(_addSubjectRequest);

//            // Assert
//            Assert.IsType<AddSubjectResponse>(response);

//            // Clear
//            await _subjectService.DeleteSubject(new DeleteSubjectRequest { ActualSubject = _addSubjectRequest.Subject });
//        }

//        [Fact]
//        public async Task AddSubject_TakesRequestModel_ReturnsNotNull()
//        {
//            // Act
//            var response = await _subjectService.AddSubject(_addSubjectRequest);

//            // Assert
//            Assert.NotNull(response);
//            await _subjectService.DeleteSubject(new DeleteSubjectRequest { ActualSubject = _addSubjectRequest.Subject });
//        }

//        [Fact]
//        public async Task AddSubject_TakesNullRequestModel_ThrowsNullReferenceException()
//        {
//            // Act
//            var func = async () => await _subjectService.AddSubject(null!);

//            // Assert
//            await Assert.ThrowsAsync<ServiceException>(func);
//        }

//        [Fact]
//        public async Task RenameSubject_TakesRequestModel_ReturnsProperResponseModel()
//        {
//            // Arrange
//            await _subjectService.AddSubject(_addSubjectRequest);

//            // Act
//            var response = await _subjectService.RenameSubject(_renameSubjectRequest);
//            await _subjectService.DeleteSubject(_renamedSubjectDeleteRequest);

//            // Assert
//            Assert.IsType<RenameSubjectResponse>(response);
//        }

//        [Fact]
//        public async Task RenameSubject_TakesRequestModel_ReturnsNotNull()
//        {
//            // Arrange
//            await _subjectService.AddSubject(_addSubjectRequest);

//            // Act
//            var response = await _subjectService.RenameSubject(_renameSubjectRequest);
//            await _subjectService.DeleteSubject(_renamedSubjectDeleteRequest);

//            // Assert
//            Assert.NotNull(response);
//        }

//        [Fact]
//        public async Task RenameSubject_TakesNullRequestModel_ThrowsNullReferenceException()
//        {
//            // Act
//            var func = async () => await _subjectService.RenameSubject(null!);

//            // Assert
//            await Assert.ThrowsAsync<NullReferenceException>(func);
//        }

//        [Fact]
//        public async Task DeleteSubject_TakesRequestModel_ReturnsProperResponseModel()
//        {
//            // Arrange
//            await _subjectService.AddSubject(_addSubjectRequest);

//            // Act
//            var response = await _subjectService.DeleteSubject(_deleteSubjectRequest);

//            // Assert
//            Assert.IsType<DeleteSubjectResponse>(response);
//        }

//        [Fact]
//        public async Task DeleteSubject_TakesRequestModel_ReturnsNotNull()
//        {
//            // Arrange
//            await _subjectService.AddSubject(_addSubjectRequest);

//            // Act
//            var response = await _subjectService.DeleteSubject(_deleteSubjectRequest);

//            // Assert
//            Assert.NotNull(response);
//        }

//        [Fact]
//        public async Task DeleteSubject_TakesNullRequestModel_ThrowsNullReferenceException()
//        {
//            // Act
//            var func = async () => await _subjectService.DeleteSubject(null!);

//            // Assert
//            await Assert.ThrowsAsync<NullReferenceException>(func);
//        }

//        [Fact]
//        public async Task DeleteAllSubjects_TakesRequestModel_ReturnsProperResponseModel()
//        {
//            // Act
//            var response = await _subjectService.DeleteAllSubjects();

//            // Assert
//            Assert.IsType<DeleteAllSubjectsResponse>(response);
//        }

//        [Fact]
//        public async Task DeleteAllSubjects_TakesRequestModel_ReturnsNotNull()
//        {
//            // Act
//            var response = await _subjectService.DeleteAllSubjects();

//            // Assert
//            Assert.NotNull(response);
//        }
//    }
//}
