using Exadel.Compreface.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Exadel.Compreface.Clients;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.ListAllExampleSubject;

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

        var faceDetectionClient = new FaceDetectionClient(apiKey: "00000000-0000-0000-0000-000000000003", domain: "http://localhost", port: "8000");

        var faceRecognitionClient = new FaceRecognitionClient(apiKey: "00000000-0000-0000-0000-000000000002", domain: "http://localhost", port: "8000");

        var faceVerificationClient = new FaceVerificationClient(apiKey: "00000000-0000-0000-0000-000000000004", domain: "http://localhost", port: "8000");
    }
}