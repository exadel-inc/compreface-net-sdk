using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddExampleSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.GetSubjectList;
using Exadel.Compreface.Exceptions;
using Flurl.Http;
using Moq;
using static Exadel.Compreface.UnitTests.Helpers.GetRandomStringHelper;


namespace Exadel.Compreface.UnitTests.ApiClientTest;

public partial class ApiClientTests
{
    [Fact]
    public async Task GetJsonAsync_ShouldHandleFlurlHttpExceptionAndThrowServiceException()
    {
        _httpTest.RespondWith(ExceptionMessage, BadResponseStatusCode);
        
        var httpException = It.IsAny<FlurlHttpException>();
        _httpTest.SimulateException(httpException);
        
        var responseCall = _apiClient.GetJsonAsync<GetAllSubjectResponse>(requestUrl: RequestUrl);
        
        await Assert.ThrowsAsync<ServiceException>(async () => await responseCall);
    }
    
    [Fact]
    public async Task PostJsonAsync_ShouldHandleFlurlHttpExceptionAndThrowServiceException()
    {
        var httpException = It.IsAny<FlurlHttpException>();
        
        _httpTest.RespondWith(ExceptionMessage, BadResponseStatusCode);
        _httpTest.SimulateException(httpException);
        
        var responseCall = _apiClient.PostJsonAsync<AddSubjectExampleResponse>(
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
        
        var responseCall = _apiClient.PutJsonAsync<AddSubjectExampleResponse>(
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
        
        var responseCall = _apiClient.DeleteJsonAsync<AddSubjectExampleResponse>(requestUrl: RequestUrl);

        await Assert.ThrowsAsync<ServiceException>(async () => await responseCall);
    }

    [Fact]
    public async Task PostMultipartAsync_ShouldHandleFlurlHttpExceptionAndThrowServiceException()
    {
        var httpException = It.IsAny<FlurlHttpException>();
        
        _httpTest.RespondWith(ExceptionMessage, BadResponseStatusCode);
        _httpTest.SimulateException(httpException);
        
        var randomstring = GetRandomString();
        
        var responseCall = _apiClient.PostMultipartAsync<AddSubjectExampleResponse>(
            requestUrl: RequestUrl,
            mp => mp.AddFile(randomstring, fileName: randomstring, path: randomstring));
        
        await Assert.ThrowsAsync<ServiceException>(async () => await responseCall);
    }
    
    [Fact]
    public async Task GetBytesFromRemoteAsync_ShouldHandleFlurlHttpExceptionAndThrowServiceException()
    {
        var httpException = It.IsAny<FlurlHttpException>();
        
        _httpTest.RespondWith(ExceptionMessage, BadResponseStatusCode);
        _httpTest.SimulateException(httpException);
        
        var responseCall = _apiClient.GetBytesFromRemoteAsync(requestUrl: RequestUrl);

        await Assert.ThrowsAsync<ServiceException>(async () => await responseCall);
    }
}