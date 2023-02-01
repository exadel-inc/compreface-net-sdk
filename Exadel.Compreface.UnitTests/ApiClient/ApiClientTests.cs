using Exadel.Compreface.Configuration;
using Exadel.Compreface.Services;
using Flurl.Http.Testing;
using Tynamix.ObjectFiller;

namespace Exadel.Compreface.UnitTests.ApiClient;

public partial class ApiClientTests : IDisposable
{
    private readonly HttpTest _httpTest;
    private readonly IService _service;

    public ApiClientTests()
    {
        _httpTest = new HttpTest();
        _service = new RecognitionService(new ComprefaceConfiguration
        {
            ApiKey = GetRandomString(),
            Domain = GetRandomString(),
            Port = GetRandomString(),
        });
    }

    private const string RequestUrl = "http://site.com";
    private const string ExceptionMessage = "{\"message\":\"Something bad happened!!!\",\"code\":20}";
    private const string SuccessMessage = "{\"message\":\"Everything is good so far!!!\"}";
    public const int BadResponseStatusCode = 400;
    public const int SuccessResponseStatusCode = 200;
    
    private static string GetRandomString()
    {
        return new Filler<string>().Create();
    }

    public void Dispose()
    {
        _httpTest.Dispose();
    }
}