using Exadel.Compreface.Clients;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.Services;
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
            .ConfigureServices(s => 
            {
                // configure services here....
            })
            .Build();

        var serviceProvider = host.Services;

        var configuration = serviceProvider.GetService<IConfiguration>();
        var domain = configuration?.GetSection(nameof(ComprefaceConfiguration.Domain)).Value ?? throw new ArgumentNullException($"Cannot read section: {nameof(ComprefaceConfiguration.Domain)} from the given configuration appsettings.json file");
        var port = configuration?.GetSection(nameof(ComprefaceConfiguration.Port)).Value ?? throw new ArgumentNullException($"Cannot read section: {nameof(ComprefaceConfiguration.Port)} from the given configuration appsettings.json file");
        var recognitionApiKey = configuration?.GetSection(RecognitionService) ?? throw new ArgumentNullException($"Cannot read section: {RecognitionService} from the given configuration appsettings.json file");
        var detectionApiKey = configuration?.GetSection(DetectionService) ?? throw new ArgumentNullException($"Cannot read section: {DetectionService} from the given configuration appsettings.json file");
        var verificationApiKey = configuration?.GetSection(VerificationService) ?? throw new ArgumentNullException($"Cannot read section: {VerificationService} from the given configuration appsettings.json file");
        
        var recognitionConfiguration = new ComprefaceConfiguration(
            configuration!, 
            RecognitionService,
            $"{nameof(ComprefaceConfiguration.Domain)}",
            $"{nameof(ComprefaceConfiguration.Port)}");

        var detectionConfiguration = new ComprefaceConfiguration(
            configuration!, 
            DetectionService,
            $"{nameof(ComprefaceConfiguration.Domain)}",
            $"{nameof(ComprefaceConfiguration.Port)}");

        var verificationConfiguration = new ComprefaceConfiguration(
            configuration!, 
            VerificationService,
            $"{nameof(ComprefaceConfiguration.Domain)}",
            $"{nameof(ComprefaceConfiguration.Port)}");

        var client = new CompreFaceClient("domain here...", "port here...");
        var recognitionService = client.GetService<RecognitionService>(recognitionConfiguration.ApiKey);
        var detectionService = client.GetService<FaceDetectionService>(detectionConfiguration.ApiKey);
        var verificationService = client.GetService<FaceVerificationService>(verificationConfiguration.ApiKey);

        // use client methods here.....
    }
}