using Exadel.Compreface.Clients;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.Services;
using Exadel.Compreface.Services.RecognitionService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
    private static string Compreface => nameof(Compreface);
    
    private static string RecognitionService => nameof(RecognitionService);
    
    private static string DetectionService => nameof(DetectionService);
    
    private static string VerificationService => nameof(VerificationService);

    static async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, collection) =>
            {
                collection.AddScoped<IComprefaceConfiguration, ComprefaceConfiguration>();
            })
            .Build();

        var serviceProvider = host.Services;

        var configuration = serviceProvider.GetService<IConfiguration>();

        var apiKeyRecognition = new ComprefaceConfiguration(configuration?.GetValue<string>("FaceRecognitionApiKey"));
        var apiKeyDetection = new ComprefaceConfiguration(configuration?.GetValue<string>("FaceDetectionApiKey"));
        var apiKeyVerification = new ComprefaceConfiguration(configuration?.GetValue<string>("FaceVerificationApiKey"));

        var client = new CompreFaceClient(configuration?.GetValue<string>("Domain"), configuration?.GetValue<string>("Port"));
        var recognitionService = client.GetService<RecognitionService>(apiKeyRecognition.ApiKey);
        var detectionService = client.GetService<FaceDetectionService>(apiKeyDetection.ApiKey);
        var verificationService = client.GetService<FaceVerificationService>(apiKeyVerification.ApiKey);

        // use client methods here.....
    }
}