using Flurl.Http.Testing;
using Tynamix.ObjectFiller;

namespace Exadel.Compreface.UnitTests.ApiClient;

public partial class ApiClientTests : IDisposable
{
    private readonly HttpTest _httpTest;

    public ApiClientTests()
    {
        _httpTest = new HttpTest();
    }

    private const string RequestUrl = "http://site.com";
    private const string ExceptionMessage = "{\"message\":\"Something bad happened!!!\",\"code\":20}";
    private const string SuccessMessage = "{\"message\":\"Everything is good so far!!!\"}";
    public const int BadRequestStatusCode = 400;
    
    private static string GetRandomString()
    {
        return new Filler<string>().Create();
    }

    public void Dispose()
    {
        _httpTest.Dispose();
    }
}