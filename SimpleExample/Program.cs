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
using Exadel.Compreface.Services.RecognitionService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;



var host = Host.CreateDefaultBuilder()
           .ConfigureServices((context, collection) =>
           {
               collection.Configure<ComprefaceConfiguration>(context.Configuration.GetSection("ComprefaceConfiguration"));
               
               var factory = ActivatorUtilities.CreateFactory(typeof(ApiClient), new Type[] { typeof(string) });
               collection.AddTransient<IApiClient>(sp => (IApiClient) factory(sp, new object[] { sp.GetService<IOptionsMonitor<ComprefaceConfiguration>>().CurrentValue.FaceVerificationApiKey }));
               collection.AddTransient<IApiClient>(sp => (IApiClient)factory(sp, new object[] { sp.GetService<IOptionsMonitor<ComprefaceConfiguration>>().CurrentValue.FaceDetectionApiKey }));
               collection.AddTransient<IApiClient>(sp => (IApiClient)factory(sp, new object[] { sp.GetService<IOptionsMonitor<ComprefaceConfiguration>>().CurrentValue.FaceRecognitionApiKey }));
               collection.AddTransient<Client>();
               collection.AddScoped<IFaceDetectionService>((serviceProvider) =>
               {
                   var configuration = serviceProvider.GetRequiredService<IOptionsMonitor<ComprefaceConfiguration>>();
                   var client = serviceProvider.GetRequiredService<Client>();
                   var apiClient = client.GetBarByKey(configuration.CurrentValue.FaceDetectionApiKey);
                   return new FaceDetectionService(configuration, apiClient);
               });
               collection.AddScoped<IFaceVerificationService>((serviceProvider) =>
               {
                   var configuration = serviceProvider.GetRequiredService<IOptionsMonitor<ComprefaceConfiguration>>();
                   var client = serviceProvider.GetRequiredService<Client>();
                   var apiClient = client.GetBarByKey(configuration.CurrentValue.FaceVerificationApiKey);
                   return new FaceVerificationService(configuration, apiClient);
               });
               collection.AddScoped<IRecognitionService>((serviceProvider) =>
               {
                   var configuration = serviceProvider.GetRequiredService<IOptionsMonitor<ComprefaceConfiguration>>();
                   var client = serviceProvider.GetRequiredService<Client>();
                   var apiClient = client.GetBarByKey(configuration.CurrentValue.FaceRecognitionApiKey);
                   return new RecognitionService(configuration, apiClient);
               });
           }).Build();

var serviceProvider = host.Services;

var configuration = serviceProvider.GetRequiredService<IOptionsMonitor<ComprefaceConfiguration>>();

var faceVerificationService = serviceProvider.GetRequiredService<IFaceVerificationService>();
var faceDetectionService = serviceProvider.GetRequiredService<IFaceDetectionService>();
var faceRecognitionService = serviceProvider.GetRequiredService<IRecognitionService>();

//var client = serviceProvider.GetRequiredService<Client>();
//var verificationClient = client.GetBarByKey("2283c5cf-4a8b-49d9-9bd7-0a75f49c816b");
//var detectionClient = client.GetBarByKey("59e2df37-0781-439d-802a-63329bb7e60a");
//var recognitionClient = client.GetBarByKey("3b4d6aaa-252f-41fd-aa6a-052cc6cc1474");

//var faceVerificationService = new FaceVerificationService(configuration, verificationClient);
//var faceDetectionService = new FaceDetectionService(configuration, detectionClient);
//var faceRecognitionService = new RecognitionClient(configuration, recognitionClient);


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

var faceVerificationresult = await faceVerificationService.VerifyAsync(faceVerificationExampleRequest, true);

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

var faceDetectionresult = await faceDetectionService.DetectAsync(faceDetectionRequest, isFileInTheRemoteServer: true);


var addSubjectExampleRequest = new AddSubjectExampleRequest()
{
    Subject = "API",
    File = "http://t1.gstatic.com/licensed-image?q=tbn:ANd9GcS6j6jazxVpBpf4ZdKMgUeN61C_s4EJPqI7NijX0PDep3SGXQ_bT9ap12h2MWoIolUIpngs3pApkIH-Kzw",
    //FilePath = "https://raw.githubusercontent.com/exadel-inc/compreface-net-sdk/main/Exadel.Compreface.AcceptenceTests/Resources/Images/brad-pitt_24.jpg",
};

//var faceRecognitionresult = await faceRecognitionService.AddSubjectExampleAsync(addSubjectExampleRequest, isFileInTheRemoteServer: true);



host.Run();