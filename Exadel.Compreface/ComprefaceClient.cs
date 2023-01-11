using System.Text.Json;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.Helpers;
using Exadel.Compreface.Services;
using Flurl.Http;
using Microsoft.Extensions.Configuration;

namespace Exadel.Compreface;

public class ComprefaceClient
{
    public SubjectExampleService ExampleSubjectService { get; private set; }

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
        
        InitializeComprefaceClientConfigs(configuration.ApiKey);
        
        FaceDetectionService = new FaceDetectionService(apiClient: apiClient, configuration: configuration);
        ExampleSubjectService = new SubjectExampleService(apiClient: apiClient, configuration: configuration);
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

    /// <summary>
    /// Creates the instance of <see cref="SystemJsonSerializer"/> instance and binds it to Flurl's built-in JsonSerializer 
    /// </summary>
    private static void InitializeSnakeCaseJsonConfigs()
    {
        var jsonOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = SnakeCaseToCamelCaseNamingPolicy.Policy,
            PropertyNameCaseInsensitive = true,
        };

        FlurlHttp.GlobalSettings.JsonSerializer = new SystemJsonSerializer(jsonOptions);
    }
}