using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddExampleSubject;
using Exadel.Compreface.Services;
using Flurl.Http.Content;
using Moq;
using Tynamix.ObjectFiller;

namespace Exadel.Compreface.UnitTests;

public class ExampleSubjectServiceTests
{
    private readonly Mock<ApiClient> _apiClientMock;
    private readonly ExampleSubjectService _exampleSubjectService;

    public ExampleSubjectServiceTests()
    {
        _apiClientMock = new Mock<ApiClient>();
        var randomString = GetRandomString();
        var apiKey = randomString;
        var baseUrl = randomString;
        var configuration = new ComprefaceConfiguration(apiKey, baseUrl);
        
        _exampleSubjectService = new ExampleSubjectService(configuration, _apiClientMock.Object);
    }

    private string GetRandomString()
    {
        return new Filler<string>().Create();
    }
    
    [Fact]
    public async Task AddExampleSubjectAsync_TakesRequestModel_ReturnsProperResponseModel()
    {
        var request = new AddExampleSubjectRequest()
        {
            Subject = "some",
            FileName = "somefile",
            FilePath = "some path",
        };

        var requestUrl = new Flurl.Url("some url");
        Action<CapturedMultipartContent> buildContent = (mp) =>
        {
            mp.AddFile("adaf", "fasfaf", "asfasff");
        };
        
        _apiClientMock.Setup(apiClient =>
            apiClient.PostMultipartAsync<AddExampleSubjectResponse>(
                requestUrl,
                buildContent,
                HttpCompletionOption.ResponseContentRead,
                default))
            .ReturnsAsync(new AddExampleSubjectResponse()
            {
                ImageId = Guid.NewGuid(),
                Subject = "some",
            });
        
        var response = await _exampleSubjectService.AddExampleSubjectAsync(request);
        
        Assert.IsNotType<AddExampleSubjectResponse>(response);

        _apiClientMock.Verify(client => 
            client.PostMultipartAsync<AddExampleSubjectResponse>(
                requestUrl, 
                buildContent, 
                HttpCompletionOption.ResponseContentRead, 
                default), Times.Once);
    }
}