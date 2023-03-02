using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddBase64ExampleSubject;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddExampleSubject;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteAllSubjectExamples;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteImageById;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteMultipleExamples;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DownloadImageById;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DownloadImageBySubjectId;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.ListAllExampleSubject;
using Exadel.Compreface.DTOs.HelperDTOs;
using static Exadel.Compreface.UnitTests.Helpers.GetRandomStringHelper;
using Exadel.Compreface.Services.RecognitionService;
using Exadel.Compreface.UnitTests.Helpers;
using Flurl;
using Exadel.Compreface.DTOs.SubjectExampleDTOs.AddSubjectExample;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.AddSubjectExample;

namespace Exadel.Compreface.UnitTests.Services;

public class FaceCollectionTests : SetupAndVerifyTests
{
    private readonly IComprefaceConfiguration _comprefaceConfiguration;

    private readonly FaceCollection _faceCollection;

    public FaceCollectionTests()
    {
        var apiKey = GetRandomString();
        var domain = GetRandomString();
        var port = GetRandomString();

        _comprefaceConfiguration = new ComprefaceConfiguration(apiKey, domain, port);

        _faceCollection = new FaceCollection(_comprefaceConfiguration, ApiClientMock.Object);
    }

    [Fact]
    public async Task AddAsync_TakesRequestModel_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new AddSubjectExampleRequestByFilePath();

        SetupPostMultipart<AddSubjectExampleResponse>();

        // Act
        var response = await _faceCollection.AddAsync(request);

        // Assert
        Assert.IsType<AddSubjectExampleResponse>(response);
        Assert.NotNull(response);

        VerifyPostMultipart<AddSubjectExampleResponse>();
        ApiClientMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task AddAsync_TakesRequestModelUsingUrl_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new AddSubjectExampleRequestByFileUrl();

        SetupPostJson<AddSubjectExampleResponse>();
        SetupGetBytes();

        // Act
        var response = await _faceCollection.AddAsync(request);

        // Assert
        Assert.IsType<AddSubjectExampleResponse>(response);
        Assert.NotNull(response);

        VerifyPostJson<AddSubjectExampleResponse>();
        VerifySetupGetBytes();
        ApiClientMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task AddAsync_TakesRequestModelUsingImageInBytes_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new AddSubjectExampleRequestByBytes()
        { 
            ImageInBytes= new byte[] {},
        };

        SetupPostJson<AddSubjectExampleResponse>();

        // Act
        var response = await _faceCollection.AddAsync(request);

        // Assert
        Assert.IsType<AddSubjectExampleResponse>(response);
        Assert.NotNull(response);

        VerifyPostJson<AddSubjectExampleResponse>();
        ApiClientMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task AddAsync_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupPostMultipart<AddSubjectExampleResponse>();

        // Act
        var func = async () => await _faceCollection.AddAsync((AddSubjectExampleRequestByFilePath)null!);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(func);
    }

    [Fact]
    public async Task AddAsync_TakesNullRequestModelUsingUrl_ThrowsNullReferenceException()
    {
        // Arrange
        SetupPostJson<AddSubjectExampleResponse>();
        SetupGetBytes();

        // Act
        var func = async () => await _faceCollection.AddAsync((AddSubjectExampleRequestByFileUrl)null!);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(func);
    }

    [Fact]
    public async Task AddAsync_TakesNullRequestModelUsingImageInBytes_ThrowsNullReferenceException()
    {
        // Arrange
        SetupPostJson<AddSubjectExampleResponse>();

        // Act
        var func = async () => await _faceCollection.AddAsync((AddSubjectExampleRequestByBytes)null!);

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
        var response = await _faceCollection.AddAsync(request);

        // Assert
        Assert.IsType<AddBase64SubjectExampleResponse>(response);
        Assert.NotNull(response);

        VerifyPostJson<AddBase64SubjectExampleResponse, Url>();
        ApiClientMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task AddBase64Async_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupPostJson<AddBase64SubjectExampleResponse, Url>();

        // Act
        var func = async () => await _faceCollection.AddAsync((AddBase64SubjectExampleRequest)null!);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(func);
    }

    [Fact]
    public async Task DeleteMultipleAsync_TakesRequestModel_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new DeleteMultipleExampleRequest();

        SetupPostJson<List<Face>, Url>();

        // Act
        var response = await _faceCollection.DeleteAsync(request);

        // Assert
        Assert.IsType<DeleteMultipleExamplesResponse>(response);
        Assert.NotNull(response);

        VerifyPostJson<List<Face>, Url>();
        ApiClientMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task DeleteMultipleAsync_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupDeleteJson<DeleteImageByIdResponse, Url>();

        // Act
        var func = async () => await _faceCollection.DeleteAsync((DeleteMultipleExampleRequest)null!);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(func);
    }

    [Fact]
    public async Task DownloadAsync_TakesRequestModel_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new DownloadImageByIdDirectlyRequest();

        SetupGetBytesFromRemote();

        // Act
        var response = await _faceCollection.DownloadAsync(request);

        // Assert
        Assert.IsType<byte[]>(response);
        Assert.NotNull(response);

        VerifyGetBytesFromRemote();
        ApiClientMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task DownloadAsync_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupGetBytesFromRemote();

        // Act
        var func = async () => await _faceCollection.DownloadAsync((DownloadImageByIdDirectlyRequest)null!);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(func);
    }

    [Fact]
    public async Task DownloadImageBySubjectAsync_TakesRequestModel_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new DownloadImageByIdFromSubjectRequest();

        SetupGetBytesFromRemote();

        // Act
        var response = await _faceCollection.DownloadAsync(request);

        // Assert
        Assert.IsType<byte[]>(response);
        Assert.NotNull(response);

        VerifyGetBytesFromRemote();
        ApiClientMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task DownloadImageBySubjectAsync_TakesRequestModel_ReturnsNotNull()
    {
        // Arrange
        var request = new DownloadImageByIdFromSubjectRequest();

        SetupGetBytesFromRemote();

        // Act
        var response = await _faceCollection.DownloadAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.NotNull(response);

        VerifyGetBytesFromRemote();
        ApiClientMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task DownloadImageBySubjectIdAsync_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupGetBytesFromRemote();

        // Act
        var func = async () => await _faceCollection.DownloadAsync((DownloadImageByIdFromSubjectRequest)null!);

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
        var response = await _faceCollection.ListAsync(request);

        // Assert
        Assert.IsType<ListAllSubjectExamplesResponse>(response);
        Assert.NotNull(response);

        VerifyGetJson<ListAllSubjectExamplesResponse, Url>();
        ApiClientMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task GetAllAsync_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupGetJson<ListAllSubjectExamplesResponse>();

        // Act
        var func = async () => await _faceCollection.ListAsync(null!);

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
        var response = await _faceCollection.DeleteAllAsync(request);

        // Assert
        Assert.IsType<DeleteAllExamplesResponse>(response);
        Assert.NotNull(response);

        VerifyDeleteJson<DeleteAllExamplesResponse, Url>();
        ApiClientMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task DeleteAllAsync_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupDeleteJson<DeleteAllExamplesResponse, Url>();

        // Act
        var func = async () => await _faceCollection.DeleteAllAsync(null!);

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
        var response = await _faceCollection.DeleteAsync(request);

        // Assert
        Assert.IsType<DeleteImageByIdResponse>(response);
        Assert.NotNull(response);

        VerifyDeleteJson<DeleteImageByIdResponse, Url>();
        ApiClientMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task DeleteAsync_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupDeleteJson<DeleteImageByIdResponse, Url>();

        // Act
        var func = async () => await _faceCollection.DeleteAsync((DeleteImageByIdRequest)null!);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(func);
    }
}