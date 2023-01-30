using System.Threading.Channels;
using Exadel.Compreface.Clients;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddExampleSubject;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetection;
using Exadel.Compreface.DTOs.FaceVerificationDTOs;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerification;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerificationWithBase64;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFaceFromImage;

// the rest of the other services will be configured like this
var faceRecognitionClient = new FaceRecognitionClient(
    apiKey: "3b4d6aaa-252f-41fd-aa6a-052cc6cc1474",
    domain: "http://localhost",
    port: "8000");

var faceVerificationClient = new FaceVerificationClient(
    apiKey: "2283c5cf-4a8b-49d9-9bd7-0a75f49c816b",
    domain: "http://localhost",
    port: "8000");

//var faceDetectionClient = new FaceDetectionClient(
//    apiKey: "59e2df37-0781-439d-802a-63329bb7e60a",
//    domain: "http://localhost",
//    port: "8000");

var addSubjectExampleRequest = new AddSubjectExampleRequest()
{
    Subject = "Steve",
    File = "http://t1.gstatic.com/licensed-image?q=tbn:ANd9GcS6j6jazxVpBpf4ZdKMgUeN61C_s4EJPqI7NijX0PDep3SGXQ_bT9ap12h2MWoIolUIpngs3pApkIH-Kzw",
    //FilePath = "https://raw.githubusercontent.com/exadel-inc/compreface-net-sdk/main/Exadel.Compreface.AcceptenceTests/Resources/Images/brad-pitt_24.jpg",
};
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

var FaceVerificationExampleRequest = new FaceVerificationRequest()
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
var faceDetectionRequest = new FaceDetectionRequest()
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

//var createdSubjectExample = await faceRecognitionClient.RecognitionService.RecognizeFaceFromImage(recognizeFaceFromImageRequest, isFileInTheRemoteServer: true);
//var createdSubjectExample = await faceRecognitionClient.SubjectExampleService.AddSubjectExampleAsync(addSubjectExampleRequest, isFileInTheRemoteServer: true);
//var createdSubjectExample = await faceVerificationClient.FaceVerificationService.VerifyBase64ImageAsync(faceVerificationWithBase64Request);
var createdSubjectExample = await faceVerificationClient.FaceVerificationService.VerifyImageAsync(FaceVerificationExampleRequest);
//var createdSubjectExample = await faceDetectionClient.FaceDetectionService.FaceDetectionAsync(faceDetectionRequest, isFileInTheRemoteServer: true);

