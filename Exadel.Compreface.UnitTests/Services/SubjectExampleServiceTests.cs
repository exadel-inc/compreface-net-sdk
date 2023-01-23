using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddBase64ExampleSubject;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddExampleSubject;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFaceFromImage;
using Exadel.Compreface.DTOs.SubjectDTOs.GetSubjectList;
using Exadel.Compreface.Services;
using Flurl;

namespace Exadel.Compreface.UnitTests.Services;

public class SubjectExampleServiceTests : AbstractBaseServiceTests
{
    private readonly SubjectExampleService _exampleSubjectService;

    public SubjectExampleServiceTests()
    {
        _exampleSubjectService = new SubjectExampleService(Configuration, ApiClientMock.Object);
    }

    [Fact]
    public async Task AddSubjectExampleAsync_TakesRequestModel_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new AddSubjectExampleRequest();

        SetupPostMultipart<AddSubjectExampleResponse>();
        
        // Act
        var response = await _exampleSubjectService.AddSubjectExampleAsync(request);
        
        // Assert
        Assert.IsType<AddSubjectExampleResponse>(response);

        VerifyPostMultipart<AddSubjectExampleResponse>();
        ApiClientMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task AddSubjectExampleAsync_TakesRequestModel_ReturnsNotNull()
    {
        // Arrange
        var request = new AddSubjectExampleRequest();

        SetupPostMultipart<AddSubjectExampleResponse>();

        // Act
        var response = await _exampleSubjectService.AddSubjectExampleAsync(request);

        // Assert
        Assert.NotNull(response);

        VerifyPostMultipart<AddSubjectExampleResponse>();
        ApiClientMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task AddSubjectExampleAsync_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupPostMultipart<AddSubjectExampleResponse>();

        // Act
        var func = async () => await _exampleSubjectService.AddSubjectExampleAsync(null!);

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
        var response = await _exampleSubjectService.AddBase64SubjectExampleAsync(request);
        
        // Assert
        Assert.IsType<AddBase64SubjectExampleResponse>(response);

        VerifyPostJson<AddBase64SubjectExampleResponse, Url>();
        ApiClientMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task AddBase64SubjectExampleAsync_TakesRequestModel_ReturnsNotNull()
    {
        // Arrange
        var request = new AddBase64SubjectExampleRequest();

        SetupPostJson<AddBase64SubjectExampleResponse, Url>();

        // Act
        var response = await _exampleSubjectService.AddBase64SubjectExampleAsync(request);

        // Assert
        Assert.NotNull(response);

        VerifyPostJson<AddBase64SubjectExampleResponse, Url>();
        ApiClientMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task AddBase64SubjectExampleAsync_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupPostJson<AddBase64SubjectExampleResponse, Url>();

        // Act
        var func = async () => await _exampleSubjectService.AddBase64SubjectExampleAsync(null!);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(func);
    }
}