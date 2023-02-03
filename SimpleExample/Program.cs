using Exadel.Compreface.Clients;
using Exadel.Compreface.Clients.Config;
using Exadel.Compreface.Clients.Interfaces;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddExampleSubject;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetection;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerification;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFaceFromImage;
using Exadel.Compreface.Services;
using Exadel.Compreface.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;



var host = Host.CreateDefaultBuilder()
           .ConfigureServices((context, collection) =>
           {
               collection.Configure<ComprefaceConfiguration>(context.Configuration.GetSection("ComprefaceConfiguration"));

               collection.AddScoped<IApiClient>((serviceProvider) =>
               {
                   var configuration = serviceProvider.GetRequiredService<IOptionsMonitor<ComprefaceConfiguration>>();
                   return configuration.CurrentValue.FlagForClient switch
                   {
                       FlagForClient.VerificationClient => new ApiClient(configuration.CurrentValue.FaceVerificationApiKey),
                       FlagForClient.DetectionClient => new ApiClient(configuration.CurrentValue.FaceDetectionApiKey),
                       FlagForClient.RecognitionClient => new ApiClient(configuration.CurrentValue.FaceRecognitionApiKey),
                       _ => throw new ArgumentOutOfRangeException()
                   };
               });
               collection.AddScoped<IFaceDetectionService>((serviceProvider) =>
               {
                   var configuration = serviceProvider.GetRequiredService<IOptionsMonitor<ComprefaceConfiguration>>();
                   var _apiClirnt = serviceProvider.GetRequiredService<IApiClient>();
                   return new FaceDetectionService(configuration, _apiClirnt);
               });
               collection.AddScoped<IFaceVerificationService>((serviceProvider) =>
               {
                   var configuration = serviceProvider.GetRequiredService<IOptionsMonitor<ComprefaceConfiguration>>();
                   var _apiClirnt = serviceProvider.GetRequiredService<IApiClient>();
                   return new FaceVerificationService(configuration, _apiClirnt);
               });
               collection.AddScoped<IFaceRecognitionService>((serviceProvider) =>
               {
                   var configuration = serviceProvider.GetRequiredService<IOptionsMonitor<ComprefaceConfiguration>>();
                   var _apiClirnt = serviceProvider.GetRequiredService<IApiClient>();
                   return new SubjectExampleService(configuration, _apiClirnt);
               });
           }).Build();

var serviceProvider = host.Services;

var configuration = serviceProvider.GetRequiredService<IOptionsMonitor<ComprefaceConfiguration>>();


var faceVerificationService = serviceProvider.GetRequiredService<IFaceVerificationService>();
var faceDetectionService = serviceProvider.GetRequiredService<IFaceDetectionService>(); 
var faceRecognitionService = serviceProvider.GetRequiredService<IFaceRecognitionService>();

ConfigInitializer.InitializeSnakeCaseJsonConfigs();

var faceVerificationExampleRequest = new FaceVerificationRequest()
{
    DetProbThreshold = 0.85m,
    FacePlugins = new List<string>()
    {
        "age",
        "gender",
        "mask",
        "calculator",
    },
    Status = true,
    //SourceImageFilePath = @"C:\Users\alis\Downloads\Elon_Musk_Royal_Society.jpg",
    //TargetImageFilePath = @"C:\Users\alis\Downloads\Elon_Musk_Royal_Society.jpg"
    
    SourceImageFilePath = "http://t1.gstatic.com/licensed-image?q=tbn:ANd9GcS6j6jazxVpBpf4ZdKMgUeN61C_s4EJPqI7NijX0PDep3SGXQ_bT9ap12h2MWoIolUIpngs3pApkIH-Kzw",
    TargetImageFilePath = "http://t1.gstatic.com/licensed-image?q=tbn:ANd9GcS6j6jazxVpBpf4ZdKMgUeN61C_s4EJPqI7NijX0PDep3SGXQ_bT9ap12h2MWoIolUIpngs3pApkIH-Kzw",

};

var faceVerificationresult = await faceVerificationService.VerifyImageAsync(faceVerificationExampleRequest, true);

var recognizeFaceFromImageRequest = new RecognizeFaceFromImageRequest()
{
    FilePath = "https://raw.githubusercontent.com/exadel-inc/compreface-net-sdk/main/Exadel.Compreface.AcceptenceTests/Resources/Images/brad-pitt_24.jpg",
    DetProbThreshold = 0.85m,
    FacePlugins = new List<string>()
            {
                "age",
                "gender",
                "mask",
                "calculator",
            },
    Status = true,
};
var faceDetectionRequest = new FaceDetectionRequest()
{
    FilePath = "http://t1.gstatic.com/licensed-image?q=tbn:ANd9GcS6j6jazxVpBpf4ZdKMgUeN61C_s4EJPqI7NijX0PDep3SGXQ_bT9ap12h2MWoIolUIpngs3pApkIH-Kzw",
    DetProbThreshold = 0.85m,
    FacePlugins = new List<string>()
            {
                "age",
                "gender",
                "mask",
                "calculator",
            },
    Status = true,
};

var faceDetectionresult = await faceDetectionService.FaceDetectionAsync(faceDetectionRequest, isFileInTheRemoteServer: true);


var addSubjectExampleRequest = new AddSubjectExampleRequest()
{
    Subject = "API",
    File = "http://t1.gstatic.com/licensed-image?q=tbn:ANd9GcS6j6jazxVpBpf4ZdKMgUeN61C_s4EJPqI7NijX0PDep3SGXQ_bT9ap12h2MWoIolUIpngs3pApkIH-Kzw",
    //FilePath = "https://raw.githubusercontent.com/exadel-inc/compreface-net-sdk/main/Exadel.Compreface.AcceptenceTests/Resources/Images/brad-pitt_24.jpg",
};

var faceRecognitionresult = await faceRecognitionService.AddSubjectExampleAsync(addSubjectExampleRequest, isFileInTheRemoteServer: true);



host.Run();