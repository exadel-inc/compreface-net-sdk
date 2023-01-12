using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddBase64ExampleSubject;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddExampleSubject;
using Exadel.Compreface.Services;
using Flurl.Http.Content;
using Moq;
using Tynamix.ObjectFiller;

namespace Exadel.Compreface.UnitTests.Services;

public class SubjectExampleServiceTests
{
    private readonly Mock<IApiClient> _apiClientMock;
    private readonly SubjectExampleService _exampleSubjectService;

    public SubjectExampleServiceTests()
    {
        _apiClientMock = new Mock<IApiClient>();
        var randomString = GetRandomString();
        var apiKey = randomString;
        var baseUrl = randomString;
        var configuration = new ComprefaceConfiguration(apiKey, baseUrl);
        
        _exampleSubjectService = new SubjectExampleService(configuration, _apiClientMock.Object);
    }

    private string GetRandomString()
    {
        return new Filler<string>().Create();
    }

    [Fact]
    public async Task AddExampleSubjectAsync_TakesRequestModel_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new AddSubjectExampleRequest();

        _apiClientMock.Setup(apiClient =>
            apiClient.PostMultipartAsync<AddSubjectExampleResponse>(
                It.IsAny<Flurl.Url>(),
                It.IsAny<Action<CapturedMultipartContent>>(),
                It.IsAny<HttpCompletionOption>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AddSubjectExampleResponse());
        
        // Act
        var response = await _exampleSubjectService.AddSubjectExampleAsync(request);
        
        // Assert
        Assert.IsType<AddSubjectExampleResponse>(response);

        _apiClientMock.Verify(client => 
            client.PostMultipartAsync<AddSubjectExampleResponse>(
                It.IsAny<Flurl.Url>(), 
                It.IsAny<Action<CapturedMultipartContent>>(), 
                It.IsAny<HttpCompletionOption>(), 
                It.IsAny<CancellationToken>()), Times.Once);

        _apiClientMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task AddBase64ExampleSubjectAsync_TakesRequestModel_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new AddBase64SubjectExampleRequest();

        _apiClientMock.Setup(apiClient =>
                apiClient.PostJsonAsync<AddBase64SubjectExampleResponse>(
                    It.IsAny<Flurl.Url>(),
                    It.IsAny<Action<CapturedMultipartContent>>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AddBase64SubjectExampleResponse());
        
        
        //Act
        var response = await _exampleSubjectService.AddBase64SubjectExampleAsync(request);
        
        // Assert
        Assert.IsType<AddBase64SubjectExampleResponse>(response);
        
        _apiClientMock.Verify(client => 
            client.PostJsonAsync<AddBase64SubjectExampleResponse>(
                It.IsAny<Flurl.Url>(), 
                It.IsAny<Action<CapturedMultipartContent>>(), 
                It.IsAny<HttpCompletionOption>(), 
                It.IsAny<CancellationToken>()), Times.Once);

        _apiClientMock.VerifyNoOtherCalls();
    }
}