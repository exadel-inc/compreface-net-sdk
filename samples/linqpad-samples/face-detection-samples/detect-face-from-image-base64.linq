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

var faceDetectionClient = new FaceDetectionClient("PASTE YOUR API KEY", "http://localhost", "8000");

var faceDetectionBase64Request = new FaceDetectionBase64Request()
{
    DetProbThreshold = 0.91m,
    FacePlugins = new List<string>()
    {
            "age",
            "gender",
            "mask",
            "calculator",
    },
    Status = true,
    Limit = 0,
    File = "", // paste file's base64 value
    
};

var response = await faceDetectionClient.FaceDetectionService.FaceDetectionBase64Async(faceDetectionBase64Request);

foreach(var result in response.Result)
{
	// observe result object 
}