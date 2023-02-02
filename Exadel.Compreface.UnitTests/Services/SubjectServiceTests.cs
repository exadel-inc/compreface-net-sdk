﻿using Exadel.Compreface.DTOs.SubjectDTOs.AddSubject;
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
        public async Task GetAllAsync_Executes_ReturnsProperResponseModel()
        {
            // Arrange
            SetupGetJson<GetAllSubjectResponse>();

            // Act
            var response = await _service.ListAsync();

            // Assert
            Assert.IsType<GetAllSubjectResponse>(response);

            VerifyGetJson<GetAllSubjectResponse>();
            ServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetAllAsync_Executes_ReturnsNotNull()
        {
            // Arrange
            SetupGetJson<GetAllSubjectResponse>();

            // Act
            var response = await _service.ListAsync();

            // Assert
            Assert.NotNull(response);

            VerifyGetJson<GetAllSubjectResponse>();
            ServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task AddAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new AddSubjectRequest();

            SetupPostJson<AddSubjectResponse, string>();

            // Act
            var response = await _service.AddAsync(request);

            // Assert
            Assert.IsType<AddSubjectResponse>(response);

            VerifyPostJson<AddSubjectResponse, string>();
            ServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task AddAsync_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            var request = new AddSubjectRequest();

            SetupPostJson<AddSubjectResponse, string>();

            // Act
            var response = await _service.AddAsync(request);

            // Assert
            Assert.NotNull(response);

            VerifyPostJson<AddSubjectResponse, string>();
            ServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task RenameAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new RenameSubjectRequest()
            {
                Subject = GetRandomString()
            };

            SetupPutJson<RenameSubjectResponse>();

            // Act
            var response = await _service.RenameAsync(request);

            // Assert
            Assert.IsType<RenameSubjectResponse>(response);

            VerifyPutJson<RenameSubjectResponse>();
            ServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task RenameAsync_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            var request = new RenameSubjectRequest()
            {
                Subject = GetRandomString()
            };

            SetupPutJson<RenameSubjectResponse>();

            // Act
            var response = await _service.RenameAsync(request);

            // Assert
            Assert.NotNull(response);

            VerifyPutJson<RenameSubjectResponse>();
            ServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task RenameAsync_TakesNullRequestModel_ThrowsArgumentNullException()
        {
            // Arrange
            SetupPutJson<RenameSubjectRequest>();

            // Act
            var func = async () => await _service.RenameAsync(null!);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(func);
        }

        [Fact]
        public async Task DeleteAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var request = new DeleteSubjectRequest();

            SetupDeleteJson<DeleteSubjectResponse>();

            // Act
            var response = await _service.DeleteAsync(request);

            // Assert
            Assert.IsType<DeleteSubjectResponse>(response);

            VerifyDeleteJson<DeleteSubjectResponse>();
            ServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DeleteAsync_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            var request = new DeleteSubjectRequest();

            SetupDeleteJson<DeleteSubjectResponse>();

            // Act
            var response = await _service.DeleteAsync(request);

            // Assert
            Assert.NotNull(response);

            VerifyDeleteJson<DeleteSubjectResponse>();
            ServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DeleteAsync_TakesNullRequestModel_ThrowsArgumentNullException()
        {
            // Arrange
            SetupDeleteJson<DeleteSubjectRequest>();

            // Act
            var func = async () => await _service.DeleteAsync(null!);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(func);
        }

        [Fact]
        public async Task DeleteAllAsync_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            SetupDeleteJson<DeleteAllSubjectsResponse>();

            // Act
            var response = await _service.DeleteAllAsync();

            // Assert
            Assert.IsType<DeleteAllSubjectsResponse>(response);

            VerifyDeleteJson<DeleteAllSubjectsResponse>();
            ServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DeleteAllAsync_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            SetupDeleteJson<DeleteAllSubjectsResponse>();

            // Act
            var response = await _service.DeleteAllAsync();

            // Assert
            Assert.NotNull(response);

            VerifyDeleteJson<DeleteAllSubjectsResponse>();
            ServiceMock.VerifyNoOtherCalls();
        }
    }
}
