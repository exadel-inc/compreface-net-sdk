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
        _httpTest.RespondWith(ExceptionMessage, BadRequestStatusCode);
        
        var httpException = It.IsAny<FlurlHttpException>();
        _httpTest.SimulateException(httpException);

        var apiClient = new Compreface.ApiClient();
        
        var responseCall = apiClient.GetJsonAsync<GetAllSubjectResponse>(
            requestUrl: RequestUrl);
        
        await Assert.ThrowsAsync<ServiceException>(async () => await responseCall);
    }
    
    [Fact]
    public async Task PostJsonAsync_ShouldHandleFlurlHttpExceptionAndThrowServiceException()
    {
        var httpException = It.IsAny<FlurlHttpException>();
        
        _httpTest.RespondWith(ExceptionMessage, BadRequestStatusCode);
        _httpTest.SimulateException(httpException);
        
        var apiClient = new Compreface.ApiClient();
        
        var responseCall = apiClient.PostJsonAsync<AddExampleSubjectResponse>(
            requestUrl: RequestUrl,
            body: It.IsAny<object>());
        
        await Assert.ThrowsAsync<ServiceException>(async () => await responseCall);
    }
    
    [Fact]
    public async Task PutJsonAsync_ShouldHandleFlurlHttpExceptionAndThrowServiceException()
    {
        var httpException = It.IsAny<FlurlHttpException>();
        
        _httpTest.RespondWith(ExceptionMessage, BadRequestStatusCode);
        _httpTest.SimulateException(httpException);
        
        var apiClient = new Compreface.ApiClient();
        
        var responseCall = apiClient.PutJsonAsync<AddExampleSubjectResponse>(
            requestUrl: RequestUrl,
            body: It.IsAny<object>());

        await Assert.ThrowsAsync<ServiceException>(async () => await responseCall);
    }
    
    [Fact]
    public async Task DeleteJsonAsync_ShouldHandleFlurlHttpExceptionAndThrowServiceException()
    {
        var httpException = It.IsAny<FlurlHttpException>();
        
        _httpTest.RespondWith(ExceptionMessage, BadRequestStatusCode);
        _httpTest.SimulateException(httpException);
        
        var apiClient = new Compreface.ApiClient();
        
        var responseCall = apiClient.DeleteJsonAsync<AddExampleSubjectResponse>(
            requestUrl: RequestUrl);

        await Assert.ThrowsAsync<ServiceException>(async () => await responseCall);
    }

    [Fact]
    public async Task PostMultipartAsync_ShouldHandleFlurlHttpExceptionAndThrowServiceException()
    {
        var httpException = It.IsAny<FlurlHttpException>();
        
        _httpTest.RespondWith(ExceptionMessage, BadRequestStatusCode);
        _httpTest.SimulateException(httpException);
        
        var randomstring = GetRandomString();
        var apiClient = new Compreface.ApiClient();
        
        var responseCall = apiClient.PostMultipartAsync<AddExampleSubjectResponse>(
            requestUrl: RequestUrl,
            mp =>
                mp.AddFile(randomstring, fileName: randomstring, path: randomstring));
        
        await Assert.ThrowsAsync<ServiceException>(async () => await responseCall);
    }
    
    [Fact]
    public async Task GetBytesFromRemoteAsync_ShouldHandleFlurlHttpExceptionAndThrowServiceException()
    {
        var httpException = It.IsAny<FlurlHttpException>();
        
        _httpTest.RespondWith(ExceptionMessage, BadRequestStatusCode);
        _httpTest.SimulateException(httpException);
        
        var apiClient = new Compreface.ApiClient();
        
        var responseCall = apiClient.GetBytesFromRemoteAsync(
            requestUrl: RequestUrl);

        await Assert.ThrowsAsync<ServiceException>(async () => await responseCall);
    }
}