using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddExampleSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.GetSubjectList;
using Moq;

namespace Exadel.Compreface.UnitTests.ApiClient;

public partial class ApiClientTests
{
    [Fact]
    public async Task GetJsonAsync_ShouldUseGETHttpMethod()
    {
        // simulating api calls here and constructing fake response
        _httpTest.RespondWith(SuccessMessage, SuccessRequestStatusCode);
        
        var apiClient = new Compreface.ApiClient();
        
        await apiClient.GetJsonAsync<GetAllSubjectResponse>(
            requestUrl: RequestUrl);

        _httpTest
            .ShouldHaveCalled(RequestUrl)
            .WithVerb(HttpMethod.Get);

    }
    
    [Fact]
    public async Task PostJsonAsync_ShouldUsePOSTHttpMethod()
    {
        // simulating api calls here and constructing fake response
        _httpTest.RespondWith(SuccessMessage, SuccessRequestStatusCode);
        
        var apiClient = new Compreface.ApiClient();
        
        await apiClient.PostJsonAsync<AddExampleSubjectResponse>(
            requestUrl: RequestUrl,
            body: It.IsAny<object>());

        _httpTest
            .ShouldHaveCalled(RequestUrl)
            .WithVerb(HttpMethod.Post);
    }
    
    [Fact]
    public async Task PutJsonAsync_ShouldUsePUTHttpMethod()
    {
        // simulating api calls here and constructing fake response
        _httpTest.RespondWith(SuccessMessage, SuccessRequestStatusCode);
        
        var apiClient = new Compreface.ApiClient();
        
        await apiClient.PutJsonAsync<AddExampleSubjectResponse>(
            requestUrl: RequestUrl,
            body: It.IsAny<object>());

        _httpTest
            .ShouldHaveCalled(RequestUrl)
            .WithVerb(HttpMethod.Put);
    }
    
    [Fact]
    public async Task DeleteJsonAsync_ShoulUseDELETEHttpMethod()
    {
        // simulating api calls here and constructing fake response
        _httpTest.RespondWith(SuccessMessage, SuccessRequestStatusCode);
        
        var apiClient = new Compreface.ApiClient();
        
        await apiClient.DeleteJsonAsync<AddExampleSubjectResponse>(
            requestUrl: RequestUrl);

        _httpTest
            .ShouldHaveCalled(RequestUrl)
            .WithVerb(HttpMethod.Delete);
    }
    
    [Fact]
    public async Task PostMultipartAsync_ShouldUsePOSTHttpMethod()
    {
        var randomstring = GetRandomString();
        
        // simulating api calls here and constructing fake response
        _httpTest.RespondWith(SuccessMessage, SuccessRequestStatusCode);
        
        var apiClient = new Compreface.ApiClient();
        
        await apiClient.PostMultipartAsync<AddExampleSubjectResponse>(
            requestUrl: RequestUrl,
            mp =>
                mp.AddFile(randomstring, fileName: randomstring, path: randomstring));

        _httpTest
            .ShouldHaveCalled(RequestUrl)
            .WithVerb(HttpMethod.Post)
            .WithContentType("multipart/form-data");
    }
    
    [Fact]
    public async Task GetBytesFromRemoteAsync_ShouldUseGETHttpMethod()
    {
        // simulating api calls here and constructing fake response
        _httpTest.RespondWith(SuccessMessage, SuccessRequestStatusCode);
        
        var apiClient = new Compreface.ApiClient();
        
        await apiClient.GetBytesFromRemoteAsync(
            requestUrl: RequestUrl);

        _httpTest
            .ShouldHaveCalled(RequestUrl)
            .WithVerb(HttpMethod.Get);
    }
}