using Exadel.Compreface.Configuration;
using Exadel.Compreface.Services;
using Flurl.Http;
using Microsoft.Extensions.Configuration;

namespace Exadel.Compreface;

public class ComprefaceClient
{
    public ExampleSubjectService ExampleSubjectService { get; private set; }

    public SubjectService SubjectService { get; private set; }

    public RecognitionService RecognitionService { get; private set; }

    public ComprefaceClient(string apiKey, string host) : this(new ComprefaceConfiguration(apiKey, host))
    { }

    public ComprefaceClient(IConfiguration configuration, string sectionForApiKey, string sectionForBaseUrl) : this(new ComprefaceConfiguration(configuration, sectionForApiKey, sectionForBaseUrl))
    { }

    public ComprefaceClient(ComprefaceConfiguration configuration)
    {
        InitializeApiKeyInRequestHeader(configuration.ApiKey);
        ExampleSubjectService = new ExampleSubjectService(configuration);
        SubjectService = new SubjectService(configuration);
        RecognitionService = new RecognitionService(configuration);
    }
    
    /// <summary>
    /// Adds Api Key to request header before sending http request to a given endpoint 
    /// </summary>
    /// <param name="apiKey">Valid api key for compreface api</param>
    private static void InitializeApiKeyInRequestHeader(string apiKey)
    {
        FlurlHttp.GlobalSettings.BeforeCall += apiCall =>
        {
            apiCall.Request.Headers.Add("x-api-key", apiKey);
        };
    }
}