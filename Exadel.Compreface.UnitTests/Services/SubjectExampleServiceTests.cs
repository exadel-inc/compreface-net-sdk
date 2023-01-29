using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddBase64ExampleSubject;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddExampleSubject;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteAllSubjectExamples;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteImageById;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteMultipleExamples;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DownloadImageById;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DownloadImageBySubjectId;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.ListAllExampleSubject;
using Exadel.Compreface.DTOs.HelperDTOs;
using Exadel.Compreface.Services;
using Flurl;

namespace Exadel.Compreface.UnitTests.Services;

public class SubjectExampleServiceTests : AbstractBaseServiceTests<SubjectExampleService>
{
    private readonly SubjectExampleService _service;

    public SubjectExampleServiceTests()
    {
        _service = ServiceMock.Object;
    }

    [Fact]
    public async Task AddSubjectExampleAsync_TakesRequestModel_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new AddSubjectExampleRequest();

        SetupPostMultipart<AddSubjectExampleResponse>();
        
        // Act
        var response = await _service.AddSubjectExampleAsync(request);
        
        // Assert
        Assert.IsType<AddSubjectExampleResponse>(response);

        VerifyPostMultipart<AddSubjectExampleResponse>();
        ServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task AddSubjectExampleAsync_TakesRequestModel_ReturnsNotNull()
    {
        // Arrange
        var request = new AddSubjectExampleRequest();

        SetupPostMultipart<AddSubjectExampleResponse>();

        // Act
        var response = await _service.AddSubjectExampleAsync(request);

        // Assert
        Assert.NotNull(response);

        VerifyPostMultipart<AddSubjectExampleResponse>();
        ServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task AddSubjectExampleAsync_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupPostMultipart<AddSubjectExampleResponse>();

        // Act
        var func = async () => await _service.AddSubjectExampleAsync(null!);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(func);
    }

    [Fact]
    public async Task AddBase64SubjectExampleAsync_TakesRequestModel_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new AddBase64SubjectExampleRequest();

        SetupPostJson<AddBase64SubjectExampleResponse, Url>();
        
        //Act
        var response = await _service.AddBase64SubjectExampleAsync(request);
        
        // Assert
        Assert.IsType<AddBase64SubjectExampleResponse>(response);

        VerifyPostJson<AddBase64SubjectExampleResponse, Url>();
        ServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task AddBase64SubjectExampleAsync_TakesRequestModel_ReturnsNotNull()
    {
        // Arrange
        var request = new AddBase64SubjectExampleRequest();

        SetupPostJson<AddBase64SubjectExampleResponse, Url>();

        // Act
        var response = await _service.AddBase64SubjectExampleAsync(request);

        // Assert
        Assert.NotNull(response);

        VerifyPostJson<AddBase64SubjectExampleResponse, Url>();
        ServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task AddBase64SubjectExampleAsync_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupPostJson<AddBase64SubjectExampleResponse, Url>();

        // Act
        var func = async () => await _service.AddBase64SubjectExampleAsync(null!);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(func);
    }

    [Fact]
    public async Task DeletMultipleExamplesAsync_TakesRequestModel_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new DeleteMultipleExampleRequest();

        SetupPostJson<List<Face>, Url>();

        // Act
        var response = await _service.DeletMultipleExamplesAsync(request);

        // Assert
        Assert.IsType<DeleteMultipleExamplesResponse>(response);
        VerifyPostJson<List<Face>, Url>();
        ServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task DeletMultipleExamplesAsync_TakesRequestModel_ReturnsNotNull()
    {
        // Arrange
        var request = new DeleteMultipleExampleRequest();

        SetupPostJson<List<Face>, Url>();

        // Act
        var response = await _service.DeletMultipleExamplesAsync(request);

        // Assert
        Assert.NotNull(response);
        VerifyPostJson<List<Face>, Url>();
        ServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task DeletMultipleExamplesAsync_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupPostJson<List<Face>, Url>();

        // Act
        var func = async () => await _service.DeletMultipleExamplesAsync(null!);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(func);
    }

    [Fact]
    public async Task DownloadImageByIdAsync_TakesRequestModel_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new DownloadImageByIdRequest();

        SetupGetBytesFromRemote();

        // Act
        var response = await _service.DownloadImageByIdAsync(request);

        // Assert
        Assert.IsType<byte[]>(response);
        VerifyGetBytesFromRemote();
        ServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task DownloadImageByIdAsync_TakesRequestModel_ReturnsNotNull()
    {
        // Arrange
        var request = new DownloadImageByIdRequest();

        SetupGetBytesFromRemote();

        // Act
        var response = await _service.DownloadImageByIdAsync(request);

        // Assert
        Assert.NotNull(response);
        VerifyGetBytesFromRemote();
        ServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task DownloadImageByIdAsync_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupGetBytesFromRemote();

        // Act
        var func = async () => await _service.DownloadImageByIdAsync(null!);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(func);
    }

    [Fact]
    public async Task DownloadImageBySubjectIdAsync_TakesRequestModel_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new DownloadImageBySubjectIdRequest();

        SetupGetBytesFromRemote();

        // Act
        var response = await _service.DownloadImageBySubjectIdAsync(request);

        // Assert
        Assert.IsType<byte[]>(response);
        VerifyGetBytesFromRemote();
        ServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task DownloadImageBySubjectIdAsync_TakesRequestModel_ReturnsNotNull()
    {
        // Arrange
        var request = new DownloadImageBySubjectIdRequest();

        SetupGetBytesFromRemote();

        // Act
        var response = await _service.DownloadImageBySubjectIdAsync(request);

        // Assert
        Assert.NotNull(response);
        VerifyGetBytesFromRemote();
        ServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task DownloadImageBySubjectIdAsync_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupGetBytesFromRemote();

        // Act
        var func = async () => await _service.DownloadImageBySubjectIdAsync(null!);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(func);
    }

    [Fact]
    public async Task GetAllSubjectExamplesAsync_TakesRequestModel_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new ListAllSubjectExamplesRequest();

        SetupGetJson<ListAllSubjectExamplesResponse, Url>();

        // Act
        var response = await _service.GetAllSubjectExamplesAsync(request);

        // Assert
        Assert.IsType<ListAllSubjectExamplesResponse>(response);

        VerifyGetJson<ListAllSubjectExamplesResponse, Url>();
        ServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task GetAllSubjectExamplesAsync_TakesRequestModel_ReturnsNotNull()
    {
        // Arrange
        var request = new ListAllSubjectExamplesRequest();

        SetupGetJson<ListAllSubjectExamplesResponse, Url>();

        // Act
        var response = await _service.GetAllSubjectExamplesAsync(request);

        // Assert
        Assert.NotNull(response);
        VerifyGetJson<ListAllSubjectExamplesResponse, Url>();
        ServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task GetAllSubjectExamplesAsync_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupGetJson<ListAllSubjectExamplesResponse>();

        // Act
        var func = async () => await _service.GetAllSubjectExamplesAsync(null!);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(func);
    }

    [Fact]
    public async Task ClearSubjectAsync_TakesRequestModel_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new DeleteAllExamplesRequest();

        SetupDeleteJson<DeleteAllExamplesResponse, Url>();

        // Act
        var response = await _service.ClearSubjectAsync(request);

        // Assert
        Assert.IsType<DeleteAllExamplesResponse>(response);

        VerifyDeleteJson<DeleteAllExamplesResponse, Url>();
        ServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task ClearSubjectAsync_TakesRequestModel_ReturnsNotNull()
    {
        // Arrange
        var request = new DeleteAllExamplesRequest();

        SetupDeleteJson<DeleteAllExamplesResponse, Url>();

        // Act
        var response = await _service.ClearSubjectAsync(request);

        // Assert
        Assert.NotNull(response);
        VerifyDeleteJson<DeleteAllExamplesResponse, Url>();
        ServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task ClearSubjectAsync_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupDeleteJson<DeleteAllExamplesResponse, Url>();

        // Act
        var func = async () => await _service.ClearSubjectAsync(null!);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(func);
    }

    [Fact]
    public async Task DeleteImageByIdAsync_TakesRequestModel_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new DeleteImageByIdRequest();

        SetupDeleteJson<DeleteImageByIdResponse, Url>();

        // Act
        var response = await _service.DeleteImageByIdAsync(request);

        // Assert
        Assert.IsType<DeleteImageByIdResponse>(response);

        VerifyDeleteJson<DeleteImageByIdResponse, Url>();
        ServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task DeleteImageByIdAsync_TakesRequestModel_ReturnsNotNull()
    {
        // Arrange
        var request = new DeleteImageByIdRequest();

        SetupDeleteJson<DeleteImageByIdResponse, Url>();

        // Act
        var response = await _service.DeleteImageByIdAsync(request);

        // Assert
        Assert.NotNull(response);
        VerifyDeleteJson<DeleteImageByIdResponse, Url>();
        ServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task DeleteImageByIdAsync_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupDeleteJson<DeleteImageByIdResponse, Url>();

        // Act
        var func = async () => await _service.DeleteImageByIdAsync(null!);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(func);
    }
}