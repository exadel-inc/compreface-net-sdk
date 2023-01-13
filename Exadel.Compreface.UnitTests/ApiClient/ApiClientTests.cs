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
    
    public const string RequestUrl = "http://site.com";
    public const string ExceptionMessage = "{\"message\":\"Somethingbadhappened!!!\",\"code\":20}";

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