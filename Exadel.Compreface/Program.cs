using System.Text.Json;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerification;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerificationWithBase64;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFaceFromImage;
using Exadel.Compreface.Helpers;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Exadel.Compreface;

public class Program
{
    private static string Compreface => nameof(Compreface);

    static async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices(s => { s.AddOptions<ComprefaceConfiguration>().BindConfiguration(Compreface); })
            .Build();

        var serviceProvider = host.Services;

        var comprefaceConfiguration = serviceProvider.GetRequiredService<IOptions<ComprefaceConfiguration>>().Value;
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();

        var jsonOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = SnakeCaseToCamelCaseNamingPolicy.Policy,
            PropertyNameCaseInsensitive = true,
        };

        FlurlHttp.GlobalSettings.JsonSerializer = new SystemJsonSerializer(jsonOptions);
        var apiClient = new ApiClient();
        // var comprefaceClientV1 = new ComprefaceClient(
        //     configuration: configuration,
        //     sectionForApiKey: "Compreface:ApiKey (optional naming)",
        //     sectionForBaseUrl: "Compreface:BaseUrl (optional naming)");
        //
        var comprefaceClientV2 = new ComprefaceClient(
            apiKey: "746f45a6-b35e-4087-a79a-a686b3c47fb7", 
            host: "http://localhost:8000/api/v1/");
        
        // var comprefaceClientV3 = new ComprefaceClient(comprefaceConfiguration);

        var subjects = await comprefaceClientV2.SubjectService.GetAllSubject();

        Console.WriteLine("");
    }
}