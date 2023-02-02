﻿using Exadel.Compreface.Clients;
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

    static void Main()
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices(s => 
            {
                // configure services here....
            })
            .Build();

        var serviceProvider = host.Services;

        var configuration = serviceProvider.GetService<IConfiguration>();
        
        var recognitionConfiguration = new ComprefaceConfiguration(
            configuration!, 
            $"{Compreface}:{RecognitionService}:{nameof(ComprefaceConfiguration.ApiKey)}",
            $"{Compreface}:{RecognitionService}:{nameof(ComprefaceConfiguration.Domain)}",
            $"{Compreface}:{RecognitionService}:{nameof(ComprefaceConfiguration.Port)}");

        var detectionConfiguration = new ComprefaceConfiguration(
            configuration!, 
            $"{Compreface}:{DetectionService}:{nameof(ComprefaceConfiguration.ApiKey)}",
            $"{Compreface}:{DetectionService}:{nameof(ComprefaceConfiguration.Domain)}",
            $"{Compreface}:{DetectionService}:{nameof(ComprefaceConfiguration.Port)}");

        var verificationConfiguration = new ComprefaceConfiguration(
            configuration!, 
            $"{Compreface}:{VerificationService}:{nameof(ComprefaceConfiguration.ApiKey)}",
            $"{Compreface}:{VerificationService}:{nameof(ComprefaceConfiguration.Domain)}",
            $"{Compreface}:{VerificationService}:{nameof(ComprefaceConfiguration.Port)}");

        var client = new CompreFaceClient("domain here...", "port here...");
        var recognitionService = client.GetService<RecognitionService>(recognitionConfiguration.ApiKey);
        var detectionService = client.GetService<FaceDetectionService>(detectionConfiguration.ApiKey);
        var verificationService = client.GetService<FaceVerificationService>(verificationConfiguration.ApiKey);

        // use client methods here.....
    }
}