using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddBase64ExampleSubject;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddExampleSubject;
using Exadel.Compreface.Services;
using Flurl.Http.Content;
using Moq;

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
    public async Task AddBase64SubjectExampleAsync_TakesRequestModel_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new AddBase64SubjectExampleRequest();

        SetupPostJson<AddBase64SubjectExampleResponse>();
        
        //Act
        var response = await _exampleSubjectService.AddBase64SubjectExampleAsync(request);
        
        // Assert
        Assert.IsType<AddBase64SubjectExampleResponse>(response);

        VerifyPostJson<AddBase64SubjectExampleResponse>();
        ApiClientMock.VerifyNoOtherCalls();
    }
}