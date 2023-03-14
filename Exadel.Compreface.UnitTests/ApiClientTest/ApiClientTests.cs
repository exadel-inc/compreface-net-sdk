//using Exadel.Compreface.Clients.ApiClient;
//using Exadel.Compreface.Configuration;
//using Flurl.Http.Testing;
//using static Exadel.Compreface.UnitTests.Helpers.GetRandomStringHelper;

//namespace Exadel.Compreface.UnitTests.ApiClientTest;

//public partial class ApiClientTests : IDisposable
//{
//    private readonly HttpTest _httpTest;
//    private readonly IApiClient _apiClient;

//    public ApiClientTests()
//    {
//        var apiKey = GetRandomString();
//        var domain = GetRandomString();
//        var port = GetRandomString();

//        _httpTest = new HttpTest();
//        _apiClient = new ApiClient(new ComprefaceConfiguration(apiKey, domain, port));

//    }

//    private const string RequestUrl = "http://site.com";
//    private const string ExceptionMessage = "{\"message\":\"Something bad happened!!!\",\"code\":20}";
//    private const string SuccessMessage = "{\"message\":\"Everything is good so far!!!\"}";
//    public const int BadResponseStatusCode = 400;
//    public const int SuccessResponseStatusCode = 200;
   
//    public void Dispose()
//    {
//        _httpTest.Dispose();
//    }
//}