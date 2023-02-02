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
    public async Task AddAsync_TakesRequestModel_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new AddSubjectExampleRequest()
        {
            File = GetRandomString()
        };

        SetupPostMultipart<AddSubjectExampleResponse>();
        
        // Act
        var response = await _service.AddAsync(request);
        
        // Assert
        Assert.IsType<AddSubjectExampleResponse>(response);

        VerifyPostMultipart<AddSubjectExampleResponse>();
        ServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task AddAsync_TakesRequestModel_ReturnsNotNull()
    {
        // Arrange
        var request = new AddSubjectExampleRequest()
        {
            File = GetRandomString()
        };

        SetupPostMultipart<AddSubjectExampleResponse>();

        // Act
        var response = await _service.AddAsync(request);

        // Assert
        Assert.NotNull(response);

        VerifyPostMultipart<AddSubjectExampleResponse>();
        ServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task AddAsync_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupPostMultipart<AddSubjectExampleResponse>();

        // Act
        var func = async () => await _service.AddAsync(null!);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(func);
    }

    [Fact]
    public async Task AddBase64Async_TakesRequestModel_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new AddBase64SubjectExampleRequest();

        SetupPostJson<AddBase64SubjectExampleResponse, Url>();
        
        //Act
        var response = await _service.AddAsync(request);
        
        // Assert
        Assert.IsType<AddBase64SubjectExampleResponse>(response);

        VerifyPostJson<AddBase64SubjectExampleResponse, Url>();
        ServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task AddBase64Async_TakesRequestModel_ReturnsNotNull()
    {
        // Arrange
        var request = new AddBase64SubjectExampleRequest();

        SetupPostJson<AddBase64SubjectExampleResponse, Url>();

        // Act
        var response = await _service.AddAsync(request);

        // Assert
        Assert.NotNull(response);

        VerifyPostJson<AddBase64SubjectExampleResponse, Url>();
        ServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task AddBase64Async_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupPostJson<AddBase64SubjectExampleResponse, Url>();

        // Act
        var func = async () => await _service.AddAsync(null!);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(func);
    }

    [Fact]
    public async Task DeleteMultipleAsync_TakesRequestModel_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new DeleteMultipleExampleRequest()
        {
            ImageIdList = new List<Guid>()
        };

        SetupPostJson<List<Face>, Url>();

        // Act
        var response = await _service.DeleteAsync(request);

        // Assert
        Assert.IsType<DeleteMultipleExamplesResponse>(response);
        VerifyPostJson<List<Face>, Url>();
        ServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task DeleteMultipleAsync_TakesRequestModel_ReturnsNotNull()
    {
        // Arrange
        var request = new DeleteMultipleExampleRequest()
        {
            ImageIdList = new List<Guid>()
        };

        SetupPostJson<List<Face>, Url>();

        // Act
        var response = await _service.DeleteAsync(request);

        // Assert
        Assert.NotNull(response);
        VerifyPostJson<List<Face>, Url>();
        ServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task DeleteMultipleAsync_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupDeleteJson<DeleteImageByIdResponse, Url>();

        // Act
        var func = async () => await _service.DeleteAsync((DeleteMultipleExampleRequest)null!);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(func);
    }

    [Fact]
    public async Task DownloadAsync_TakesRequestModel_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new DownloadImageByIdRequest();

        SetupGetBytesFromRemote();

        // Act
        var response = await _service.DownloadAsync(request);

        // Assert
        Assert.IsType<byte[]>(response);
        VerifyGetBytesFromRemote();
        ServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task DownloadAsync_TakesRequestModel_ReturnsNotNull()
    {
        // Arrange
        var request = new DownloadImageByIdRequest();

        SetupGetBytesFromRemote();

        // Act
        var response = await _service.DownloadAsync(request);

        // Assert
        Assert.NotNull(response);
        VerifyGetBytesFromRemote();
        ServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task DownloadAsync_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupGetBytesFromRemote();

        // Act
        var func = async () => await _service.DownloadAsync((DownloadImageByIdRequest)null!);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(func);
    }

    [Fact]
    public async Task DownloadImageBySubjectAsync_TakesRequestModel_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new DownloadImageBySubjectIdRequest();

        SetupGetBytesFromRemote();

        // Act
        var response = await _service.DownloadAsync(request);

        // Assert
        Assert.IsType<byte[]>(response);
        VerifyGetBytesFromRemote();
        ServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task DownloadImageBySubjectAsync_TakesRequestModel_ReturnsNotNull()
    {
        // Arrange
        var request = new DownloadImageBySubjectIdRequest();

        SetupGetBytesFromRemote();

        // Act
        var response = await _service.DownloadAsync(request);

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
        var func = async () => await _service.DownloadAsync((DownloadImageBySubjectIdRequest)null!);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(func);
    }

    [Fact]
    public async Task GetAllAsync_TakesRequestModel_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new ListAllSubjectExamplesRequest();

        SetupGetJson<ListAllSubjectExamplesResponse, Url>();

        // Act
        var response = await _service.ListAsync(request);

        // Assert
        Assert.IsType<ListAllSubjectExamplesResponse>(response);

        VerifyGetJson<ListAllSubjectExamplesResponse, Url>();
        ServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task GetAllAsync_TakesRequestModel_ReturnsNotNull()
    {
        // Arrange
        var request = new ListAllSubjectExamplesRequest();

        SetupGetJson<ListAllSubjectExamplesResponse, Url>();

        // Act
        var response = await _service.ListAsync(request);

        // Assert
        Assert.NotNull(response);
        VerifyGetJson<ListAllSubjectExamplesResponse, Url>();
        ServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task GetAllAsync_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupGetJson<ListAllSubjectExamplesResponse>();

        // Act
        var func = async () => await _service.ListAsync(null!);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(func);
    }

    [Fact]
    public async Task DeleteAllAsync_TakesRequestModel_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new DeleteAllExamplesRequest();

        SetupDeleteJson<DeleteAllExamplesResponse, Url>();

        // Act
        var response = await _service.DeleteAllAsync(request);

        // Assert
        Assert.IsType<DeleteAllExamplesResponse>(response);

        VerifyDeleteJson<DeleteAllExamplesResponse, Url>();
        ServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task DeleteAllAsync_TakesRequestModel_ReturnsNotNull()
    {
        // Arrange
        var request = new DeleteAllExamplesRequest();

        SetupDeleteJson<DeleteAllExamplesResponse, Url>();

        // Act
        var response = await _service.DeleteAllAsync(request);

        // Assert
        Assert.NotNull(response);
        VerifyDeleteJson<DeleteAllExamplesResponse, Url>();
        ServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task DeleteAllAsync_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupDeleteJson<DeleteAllExamplesResponse, Url>();

        // Act
        var func = async () => await _service.DeleteAllAsync(null!);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(func);
    }

    [Fact]
    public async Task DeleteAsync_TakesRequestModel_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new DeleteImageByIdRequest();

        SetupDeleteJson<DeleteImageByIdResponse, Url>();

        // Act
        var response = await _service.DeleteAsync(request);

        // Assert
        Assert.IsType<DeleteImageByIdResponse>(response);

        VerifyDeleteJson<DeleteImageByIdResponse, Url>();
        ServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task DeleteAsync_TakesRequestModel_ReturnsNotNull()
    {
        // Arrange
        var request = new DeleteImageByIdRequest();

        SetupDeleteJson<DeleteImageByIdResponse, Url>();

        // Act
        var response = await _service.DeleteAsync(request);

        // Assert
        Assert.NotNull(response);
        VerifyDeleteJson<DeleteImageByIdResponse, Url>();
        ServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task DeleteAsync_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupDeleteJson<DeleteImageByIdResponse, Url>();

        // Act
        var func = async () => await _service.DeleteAsync((DeleteImageByIdRequest)null!);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(func);
    }
}