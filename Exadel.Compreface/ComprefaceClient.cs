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

    public FaceDetectionService FaceDetectionService { get; private set; }

    public FaceVerificationService FaceVerificationService { get; set; }

    public ComprefaceClient(string apiKey, string host) : this(new ComprefaceConfiguration(apiKey, host))
    { }

    public ComprefaceClient(IConfiguration configuration, string sectionForApiKey, string sectionForBaseUrl) : this(new ComprefaceConfiguration(configuration, sectionForApiKey, sectionForBaseUrl))
    { }

    public ComprefaceClient(ComprefaceConfiguration configuration)
    {
        var apiClient = new ApiClient(); 
        
        InitializeApiKeyInRequestHeader(configuration.ApiKey);
        
        FaceDetectionService = new FaceDetectionService(apiClient: apiClient, configuration: configuration);
        ExampleSubjectService = new ExampleSubjectService(apiClient: apiClient, configuration: configuration);
        SubjectService = new SubjectService(apiClient: apiClient, configuration: configuration);
        RecognitionService = new RecognitionService(apiClient: apiClient, configuration: configuration);
        FaceVerificationService = new FaceVerificationService(apiClient: apiClient, configuration: configuration);
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