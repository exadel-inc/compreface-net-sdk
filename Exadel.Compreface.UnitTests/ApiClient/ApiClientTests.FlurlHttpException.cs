using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddExampleSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.GetSubjectList;
using Exadel.Compreface.Exceptions;
using Flurl.Http;
using Moq;

namespace Exadel.Compreface.UnitTests.ApiClient;

public partial class ApiClientTests
{
    [Fact]
    public async Task GetJsonAsync_ShouldHandleFlurlHttpExceptionAndThrowServiceException()
    {
        _httpTest.RespondWith(ExceptionMessage, BadResponseStatusCode);
        
        var httpException = It.IsAny<FlurlHttpException>();
        _httpTest.SimulateException(httpException);

        var randomstring = GetRandomString();

        var apiClient = new Clients.ApiClient();
        
        var responseCall = apiClient.GetJsonAsync<GetAllSubjectResponse>(
            apiKey: randomstring,
            requestUrl: RequestUrl);
        
        await Assert.ThrowsAsync<ServiceException>(async () => await responseCall);
    }
    
    [Fact]
    public async Task PostJsonAsync_ShouldHandleFlurlHttpExceptionAndThrowServiceException()
    {
        var httpException = It.IsAny<FlurlHttpException>();
        
        _httpTest.RespondWith(ExceptionMessage, BadResponseStatusCode);
        _httpTest.SimulateException(httpException);

        var randomstring = GetRandomString();
        
        var apiClient = new Clients.ApiClient();
        
        var responseCall = apiClient.PostJsonAsync<AddSubjectExampleResponse>(
            apiKey: randomstring,
            requestUrl: RequestUrl,
            body: It.IsAny<object>());
        
        await Assert.ThrowsAsync<ServiceException>(async () => await responseCall);
    }
    
    [Fact]
    public async Task PutJsonAsync_ShouldHandleFlurlHttpExceptionAndThrowServiceException()
    {
        var httpException = It.IsAny<FlurlHttpException>();
        
        _httpTest.RespondWith(ExceptionMessage, BadResponseStatusCode);
        _httpTest.SimulateException(httpException);
        
        var randomstring = GetRandomString();

        var apiClient = new Clients.ApiClient();
        
        var responseCall = apiClient.PutJsonAsync<AddSubjectExampleResponse>(
            apiKey: randomstring,
            requestUrl: RequestUrl,
            body: It.IsAny<object>());

        await Assert.ThrowsAsync<ServiceException>(async () => await responseCall);
    }
    
    [Fact]
    public async Task DeleteJsonAsync_ShouldHandleFlurlHttpExceptionAndThrowServiceException()
    {
        var httpException = It.IsAny<FlurlHttpException>();
        
        _httpTest.RespondWith(ExceptionMessage, BadResponseStatusCode);
        _httpTest.SimulateException(httpException);

        var randomstring = GetRandomString();

        var apiClient = new Clients.ApiClient();
        
        var responseCall = apiClient.DeleteJsonAsync<AddSubjectExampleResponse>(
            apiKey: randomstring,
            requestUrl: RequestUrl);

        await Assert.ThrowsAsync<ServiceException>(async () => await responseCall);
    }

    [Fact]
    public async Task PostMultipartAsync_ShouldHandleFlurlHttpExceptionAndThrowServiceException()
    {
        var httpException = It.IsAny<FlurlHttpException>();
        
        _httpTest.RespondWith(ExceptionMessage, BadResponseStatusCode);
        _httpTest.SimulateException(httpException);
        
        var randomstring = GetRandomString();
        
        var apiClient = new Clients.ApiClient();
        
        var responseCall = apiClient.PostMultipartAsync<AddSubjectExampleResponse>(
            apiKey: randomstring,
            requestUrl: RequestUrl,
            mp =>
                mp.AddFile(randomstring, fileName: randomstring, path: randomstring));
        
        await Assert.ThrowsAsync<ServiceException>(async () => await responseCall);
    }
    
    [Fact]
    public async Task GetBytesFromRemoteAsync_ShouldHandleFlurlHttpExceptionAndThrowServiceException()
    {
        var httpException = It.IsAny<FlurlHttpException>();
        
        _httpTest.RespondWith(ExceptionMessage, BadResponseStatusCode);
        _httpTest.SimulateException(httpException);
        
        var randomstring = GetRandomString();

        var apiClient = new Clients.ApiClient();
        
        var responseCall = apiClient.GetBytesFromRemoteAsync(
            apiKey: randomstring,
            requestUrl: RequestUrl);

        await Assert.ThrowsAsync<ServiceException>(async () => await responseCall);
    }
}