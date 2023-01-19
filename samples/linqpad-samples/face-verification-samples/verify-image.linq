<Query Kind="Statements">
  <Reference Relative="..\..\..\Exadel.Compreface\bin\Debug\net7.0\Exadel.Compreface.dll">C:\Users\asindarov\source\repos\exadel\compreface-net-sdk\Exadel.Compreface\bin\Debug\net7.0\Exadel.Compreface.dll</Reference>
  <Namespace>Exadel.Compreface.Clients</Namespace>
  <Namespace>Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteAllSubjectExamples</Namespace>
  <Namespace>Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteImageById</Namespace>
  <Namespace>Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteMultipleExamples</Namespace>
  <Namespace>Exadel.Compreface.DTOs.ExampleSubjectDTOs.DownloadImageById</Namespace>
  <Namespace>Exadel.Compreface.DTOs.ExampleSubjectDTOs.DownloadImageBySubjectId</Namespace>
  <Namespace>Exadel.Compreface.DTOs.ExampleSubjectDTOs.ListAllExampleSubject</Namespace>
  <Namespace>Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetection</Namespace>
  <Namespace>Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetectionBase64</Namespace>
  <Namespace>Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerification</Namespace>
  <Namespace>Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImage</Namespace>
  <Namespace>Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImageWithBase64</Namespace>
  <Namespace>Exadel.Compreface.DTOs.SubjectDTOs.AddSubject</Namespace>
  <Namespace>Exadel.Compreface.DTOs.SubjectDTOs.DeleteSubject</Namespace>
  <Namespace>Exadel.Compreface.DTOs.SubjectDTOs.RenameSubject</Namespace>
</Query>

var faceVerificationClient = new FaceVerificationClient("PASTE YOUR API KEY", "http://localhost", "8000");

var faceVerificationRequest = new FaceVerificationRequest()
{
    DetProbThreshold = 0.88m,
    FacePlugins = new List<string>()
    {
        "age",
        "mask",
        "calculator",
        "gender",
    },
    SourceImageFileName = "", // file name for source image,
    SourceImageFilePath = "", // file path for source image,
    TargetImageFileName = "", // file name for target image,
    TargetImageFilePath = "", // file path for target image,
    Status = true,
};

var faceVerificationResponse = await faceVerificationClient.FaceVerificationService.VerifyImageAsync(faceVerificationRequest);