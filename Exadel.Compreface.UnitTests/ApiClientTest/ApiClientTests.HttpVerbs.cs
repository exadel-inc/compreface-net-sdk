//using Exadel.Compreface.DTOs.FaceCollectionDTOs.AddSubjectExample;
//using Exadel.Compreface.DTOs.SubjectDTOs.GetSubjectList;
//using Moq;
//using static Exadel.Compreface.UnitTests.Helpers.GetRandomStringHelper;


//namespace Exadel.Compreface.UnitTests.ApiClientTest;

//public partial class ApiClientTests
//{
//    [Fact]
//    public async Task GetJsonAsync_ShouldUseGETHttpMethod()
//    {
//        // simulating api calls here and constructing fake response
//        _httpTest.RespondWith(SuccessMessage, SuccessResponseStatusCode);

//        await _apiClient.GetJsonAsync<GetAllSubjectResponse>(RequestUrl);

//        _httpTest
//            .ShouldHaveCalled(RequestUrl)
//            .WithVerb(HttpMethod.Get);
//    }
    
//    [Fact]
//    public async Task PostJsonAsync_ShouldUsePOSTHttpMethod()
//    {
//        // simulating api calls here and constructing fake response
//        _httpTest.RespondWith(SuccessMessage, SuccessResponseStatusCode);
        
//        await _apiClient.PostJsonAsync<AddSubjectExampleResponse>(
//            requestUrl: RequestUrl,
//            body: It.IsAny<object>());

//        _httpTest
//            .ShouldHaveCalled(RequestUrl)
//            .WithVerb(HttpMethod.Post);
//    }
    
//    [Fact]
//    public async Task PutJsonAsync_ShouldUsePUTHttpMethod()
//    {
//        // simulating api calls here and constructing fake response
//        _httpTest.RespondWith(SuccessMessage, SuccessResponseStatusCode);
        
//        await _apiClient.PutJsonAsync<AddSubjectExampleResponse>(
//            requestUrl: RequestUrl,
//            body: It.IsAny<object>());

//        _httpTest
//            .ShouldHaveCalled(RequestUrl)
//            .WithVerb(HttpMethod.Put);
//    }
    
//    [Fact]
//    public async Task DeleteJsonAsync_ShoulUseDELETEHttpMethod()
//    {
//        // simulating api calls here and constructing fake response
//        _httpTest.RespondWith(SuccessMessage, SuccessResponseStatusCode);
        
//        await _apiClient.DeleteJsonAsync<AddSubjectExampleResponse>(requestUrl: RequestUrl);

//        _httpTest
//            .ShouldHaveCalled(RequestUrl)
//            .WithVerb(HttpMethod.Delete);
//    }
    
//    [Fact]
//    public async Task PostMultipartAsync_ShouldUsePOSTHttpMethod()
//    {
//        var randomstring = GetRandomString();
        
//        // simulating api calls here and constructing fake response
//        _httpTest.RespondWith(SuccessMessage, SuccessResponseStatusCode);
        
//        await _apiClient.PostMultipartAsync<AddSubjectExampleResponse>(requestUrl: RequestUrl, mp => mp.AddFile(randomstring, fileName: randomstring, path: randomstring));

//        _httpTest
//            .ShouldHaveCalled(RequestUrl)
//            .WithVerb(HttpMethod.Post)
//            .WithContentType("multipart/form-data");
//    }
    
//    [Fact]
//    public async Task GetBytesFromRemoteAsync_ShouldUseGETHttpMethod()
//    {
//        // simulating api calls here and constructing fake response
//        _httpTest.RespondWith(SuccessMessage, SuccessResponseStatusCode);
        
//        await _apiClient.GetBytesFromRemoteAsync(
//            requestUrl: RequestUrl);

//        _httpTest
//            .ShouldHaveCalled(RequestUrl)
//            .WithVerb(HttpMethod.Get);
//    }
//}