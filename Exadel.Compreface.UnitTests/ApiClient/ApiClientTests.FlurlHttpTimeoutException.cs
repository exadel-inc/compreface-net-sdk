using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddExampleSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.GetSubjectList;
using Exadel.Compreface.Exceptions;
using Flurl.Http;
using Moq;

namespace Exadel.Compreface.UnitTests.ApiClient;

public partial class ApiClientTests
{
    [Fact]
    public async Task GetJsonAsync_ShouldHandleFlurlHttpTimeoutExceptionAndThrowServiceException()
    {
        var httpException = It.IsAny<FlurlHttpTimeoutException>();
        
        _httpTest
            .SimulateTimeout()
            .SimulateException(httpException);
        
        var responseCall = _service.GetJsonAsync<GetAllSubjectResponse>(requestUrl: RequestUrl);
        
        await Assert.ThrowsAsync<ServiceTimeoutException>(async () => await responseCall);
    }
    
    [Fact]
    public async Task PostJsonAsync_ShouldHandleFlurlHttpTimeoutExceptionAndThrowServiceException()
    {
        var httpException = It.IsAny<FlurlHttpException>();
        
        _httpTest
            .SimulateTimeout()
            .SimulateException(httpException);
        
        var responseCall = _service.PostJsonAsync<AddSubjectExampleResponse>(requestUrl: RequestUrl, body: It.IsAny<object>());
        
        await Assert.ThrowsAsync<ServiceTimeoutException>(async () => await responseCall);
    }
    
    [Fact]
    public async Task PutJsonAsync_ShouldHandleFlurlHttpTimeoutExceptionAndThrowServiceException()
    {
        var httpException = It.IsAny<FlurlHttpException>();
        
        _httpTest
            .SimulateTimeout()
            .SimulateException(httpException);
        
        var responseCall = _service.PutJsonAsync<AddSubjectExampleResponse>(
            requestUrl: RequestUrl,
            body: It.IsAny<object>());

        await Assert.ThrowsAsync<ServiceTimeoutException>(async () => await responseCall);
    }
    
    [Fact]
    public async Task DeleteJsonAsync_ShouldHandleFlurlHttpTimeoutExceptionAndThrowServiceException()
    {
        var httpException = It.IsAny<FlurlHttpException>();
        
        _httpTest
            .SimulateTimeout()
            .SimulateException(httpException);
        
        var responseCall = _service.DeleteJsonAsync<AddSubjectExampleResponse>(requestUrl: RequestUrl);

        await Assert.ThrowsAsync<ServiceTimeoutException>(async () => await responseCall);
    }

    [Fact]
    public async Task PostMultipartAsync_ShouldHandleFlurlHttpTimeoutExceptionAndThrowServiceException()
    {
        var httpException = It.IsAny<FlurlHttpException>();
        
        _httpTest
            .SimulateTimeout()
            .SimulateException(httpException);
        
        var randomstring = GetRandomString();
        
        var responseCall = _service.PostMultipartAsync<AddSubjectExampleResponse>(
            requestUrl: RequestUrl,
            mp => mp.AddFile(randomstring, fileName: randomstring, path: randomstring));
        
        await Assert.ThrowsAsync<ServiceTimeoutException>(async () => await responseCall);
    }
    
    [Fact]
    public async Task GetBytesFromRemoteAsync_ShouldHandleFlurlHttpTimeoutExceptionAndThrowServiceException()
    {
        var httpException = It.IsAny<FlurlHttpException>();
        
        _httpTest
            .SimulateTimeout()
            .SimulateException(httpException);
        
        var responseCall = _service.GetBytesFromRemoteAsync(requestUrl: RequestUrl);

        await Assert.ThrowsAsync<ServiceTimeoutException>(async () => await responseCall);
    }
}