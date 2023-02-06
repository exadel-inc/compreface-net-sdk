using Exadel.Compreface.Clients;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddExampleSubject;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetection;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerification;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFaceFromImage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

var host = Host.CreateDefaultBuilder()
           .ConfigureServices((context, collection) =>
           {
               collection.Configure<ComprefaceConfiguration>(context.Configuration.GetSection("ComprefaceConfiguration"));

           })
           .Build();

var serviceProvider = host.Services;
var configuration = serviceProvider.GetRequiredService<IOptionsMonitor<ComprefaceConfiguration>>();
var client = new CompreFaceClient(configuration);
client.GetClient();


var recognizeFaceFromImageRequest = new RecognizeFaceFromImageRequest()
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

var addSubjectExampleRequest = new AddSubjectExampleRequest()
{
    Subject = "API",
    File = "http://t1.gstatic.com/licensed-image?q=tbn:ANd9GcS6j6jazxVpBpf4ZdKMgUeN61C_s4EJPqI7NijX0PDep3SGXQ_bT9ap12h2MWoIolUIpngs3pApkIH-Kzw",
    //FilePath = "https://raw.githubusercontent.com/exadel-inc/compreface-net-sdk/main/Exadel.Compreface.AcceptenceTests/Resources/Images/brad-pitt_24.jpg",
};

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
    SourceImageFilePath = @"C:\Users\alis\Downloads\Elon_Musk_Royal_Society.jpg",
    TargetImageFilePath = @"C:\Users\alis\Downloads\Elon_Musk_Royal_Society.jpg"
    //SourceImageFilePath = @"..\..\..\britney-spears-during-the-2000-mtv-video-music-awards-at-news-photo-1636756684.jpg",
    //TargetImageFilePath = @"..\..\..\britney-spears-during-the-2000-mtv-video-music-awards-at-news-photo-1636756684.jpg",

    //SourceImageFilePath = "http://t1.gstatic.com/licensed-image?q=tbn:ANd9GcS6j6jazxVpBpf4ZdKMgUeN61C_s4EJPqI7NijX0PDep3SGXQ_bT9ap12h2MWoIolUIpngs3pApkIH-Kzw",
    //TargetImageFilePath = "https://raw.githubusercontent.com/exadel-inc/compreface-net-sdk/main/Exadel.Compreface.AcceptenceTests/Resources/Images/brad-pitt_24.jpg",

};


var resultFaceRecognition = await client.RecognitionService.RecognizeFaceFromImage(recognizeFaceFromImageRequest, isFileInTheRemoteServer: true);
var resultFaceRecognition2 = await client.SubjectExampleService.AddSubjectExampleAsync(addSubjectExampleRequest, isFileInTheRemoteServer: true);
var resultfaceVerification = await client.FaceVerificationService.VerifyImageAsync(faceVerificationExampleRequest);
var resultfaceDetection = await client.FaceDetectionService.FaceDetectionAsync(faceDetectionRequest, isFileInTheRemoteServer: true);


host.Run();
