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
  <Namespace>Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerificationWithBase64</Namespace>
  <Namespace>Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImage</Namespace>
  <Namespace>Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImageWithBase64</Namespace>
  <Namespace>Exadel.Compreface.DTOs.SubjectDTOs.AddSubject</Namespace>
  <Namespace>Exadel.Compreface.DTOs.SubjectDTOs.DeleteSubject</Namespace>
  <Namespace>Exadel.Compreface.DTOs.SubjectDTOs.RenameSubject</Namespace>
</Query>

var faceVerificationClient = new FaceVerificationClient("PASTE YOUR API KEY", "http://localhost", "8000");

var faceVerificationWith64Request = new FaceVerificationWithBase64Request()
{
    DetProbThreshold = 0.88m,
    FacePlugins = new List<string>()
    {
        "age",
        "mask",
        "calculator",
        "gender",
    },
    SourceImageWithBase64 = "", // source image's base64 value,
    TargetImageWithBase64 = "", // target image's base64 value,
    Status = true,
};

var faceVerificationResponse = await faceVerificationClient.FaceVerificationService.VerifyBase64ImageAsync(faceVerificationWith64Request);

foreach(var result in faceVerificationResponse.Result)
{
	// observe result object 
}