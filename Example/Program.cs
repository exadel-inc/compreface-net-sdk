using Exadel.Compreface.Clients.CompreFaceClient;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.Services;
using Exadel.Compreface.Services.RecognitionService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
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
        var configFaceDetection = configuration.GetSection("FaceDetectionApiKey").Value;
        var configFaceRecognition = configuration.GetSection("FaceRecognitionApiKey").Value;
        var configFaceVerification = configuration.GetSection("FaceVerificationApiKey").Value;

        var client = new CompreFaceClient(configuration?.GetValue<string>("Domain"), configuration?.GetValue<string>("Port"));
        var recognitionService = client.GetCompreFaceService<RecognitionService>(configFaceRecognition);
        var detectionService = client.GetCompreFaceService<FaceDetectionService>(configFaceDetection);
        var verificationService = client.GetCompreFaceService<FaceVerificationService>(configFaceVerification);

        // use client methods here.....
    }
}