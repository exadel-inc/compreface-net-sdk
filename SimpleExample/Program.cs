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
                   return new ApiClient(configuration.CurrentValue.ApiKey);
               });
               //collection.AddScoped<IFaceDetectionService>((serviceProvider) =>
               //{
               //    var configuration = serviceProvider.GetRequiredService<IOptionsMonitor<ComprefaceConfiguration>>();
               //    var _apiClirnt = serviceProvider.GetRequiredService<IApiClient>();
               //    return new FaceDetectionService(configuration, _apiClirnt);
               //});
               collection.AddScoped<IFaceVerificationService>((serviceProvider) =>
               {
                   var configuration = serviceProvider.GetRequiredService<IOptionsMonitor<ComprefaceConfiguration>>();
                   var _apiClirnt = serviceProvider.GetRequiredService<IApiClient>();
                   return new FaceVerificationService(configuration, _apiClirnt);
               });
               //collection.AddScoped<IFaceRecognitionService>((serviceProvider) =>
               //{
               //    var configuration = serviceProvider.GetRequiredService<IOptionsMonitor<ComprefaceConfiguration>>();
               //    var _apiClirnt = serviceProvider.GetRequiredService<IApiClient>();
               //    return new SubjectExampleService(configuration, _apiClirnt);
               //});
           }).Build();


var serviceProvider = host.Services;

var configuration = serviceProvider.GetRequiredService<IOptionsMonitor<ComprefaceConfiguration>>();
//var _apiClirnt = serviceProvider.GetRequiredService<IApiClient>();

var faceVerificationService = serviceProvider.GetRequiredService<IFaceVerificationService>();
//var faceDetectionService = serviceProvider.GetRequiredService<IFaceDetectionService>(); 
//var faceRecognitionService = serviceProvider.GetRequiredService<IFaceRecognitionService>();

//var client = new CompreFaceClient(configuration);
//client.GetClient();
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
    //SourceImageFilePath = @"..\..\..\britney-spears-during-the-2000-mtv-video-music-awards-at-news-photo-1636756684.jpg",
    //TargetImageFilePath = @"..\..\..\britney-spears-during-the-2000-mtv-video-music-awards-at-news-photo-1636756684.jpg",

    SourceImageFilePath = "http://t1.gstatic.com/licensed-image?q=tbn:ANd9GcS6j6jazxVpBpf4ZdKMgUeN61C_s4EJPqI7NijX0PDep3SGXQ_bT9ap12h2MWoIolUIpngs3pApkIH-Kzw",
    TargetImageFilePath = "http://t1.gstatic.com/licensed-image?q=tbn:ANd9GcS6j6jazxVpBpf4ZdKMgUeN61C_s4EJPqI7NijX0PDep3SGXQ_bT9ap12h2MWoIolUIpngs3pApkIH-Kzw",

};
ConfigInitializer.InitializeSnakeCaseJsonConfigs();
var result3 = faceVerificationService.VerifyImageAsync(faceVerificationExampleRequest, true);

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
//var result = await client.FaceDetectionService.FaceDetectionAsync(faceDetectionRequest, isFileInTheRemoteServer: true);
//var result = await faceDetectionService.FaceDetectionAsync(faceDetectionRequest);
var addSubjectExampleRequest = new AddSubjectExampleRequest()
{
    Subject = "API",
    File = "http://t1.gstatic.com/licensed-image?q=tbn:ANd9GcS6j6jazxVpBpf4ZdKMgUeN61C_s4EJPqI7NijX0PDep3SGXQ_bT9ap12h2MWoIolUIpngs3pApkIH-Kzw",
    //FilePath = "https://raw.githubusercontent.com/exadel-inc/compreface-net-sdk/main/Exadel.Compreface.AcceptenceTests/Resources/Images/brad-pitt_24.jpg",
};


host.Run();