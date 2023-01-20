<Query Kind="Statements">
  <Reference Relative="..\..\..\Exadel.Compreface\bin\Debug\net7.0\Exadel.Compreface.dll">C:\Users\asindarov\source\repos\exadel\compreface-net-sdk\Exadel.Compreface\bin\Debug\net7.0\Exadel.Compreface.dll</Reference>
  <Namespace>Exadel.Compreface.Clients</Namespace>
  <Namespace>Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteAllSubjectExamples</Namespace>
  <Namespace>Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteImageById</Namespace>
  <Namespace>Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteMultipleExamples</Namespace>
  <Namespace>Exadel.Compreface.DTOs.ExampleSubjectDTOs.DownloadImageById</Namespace>
  <Namespace>Exadel.Compreface.DTOs.ExampleSubjectDTOs.DownloadImageBySubjectId</Namespace>
  <Namespace>Exadel.Compreface.DTOs.ExampleSubjectDTOs.ListAllExampleSubject</Namespace>
  <Namespace>Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerification</Namespace>
  <Namespace>Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImage</Namespace>
  <Namespace>Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImageWithBase64</Namespace>
  <Namespace>Exadel.Compreface.DTOs.SubjectDTOs.AddSubject</Namespace>
  <Namespace>Exadel.Compreface.DTOs.SubjectDTOs.DeleteSubject</Namespace>
  <Namespace>Exadel.Compreface.DTOs.SubjectDTOs.RenameSubject</Namespace>
</Query>

var faceRecognitionClient = new FaceRecognitionClient("PASTE YOUR API KEY", "http://localhost", "8000");

var imageBytes = File.ReadAllBytes("file path here");

var base64ImageValue = Convert.ToBase64String(imageBytes);
var verifyFacesFromImageWithBase64Request = new VerifyFacesFromImageWithBase64Request()
{
    DetProbThreshold = 0.85m,
    FacePlugins = new List<string>()
    {
        "age",
        "mask",
        "gender",
        "detector",
        "calculator",
    },
    FileBase64Value = base64ImageValue,
    ImageId = Guid.Parse(""), // image_id here,
};

var verifyFacesFromImageResponse =
    await faceRecognitionClient.RecognitionService.VerifyFacesFromBase64File(verifyFacesFromImageWithBase64Request);

foreach (var result in verifyFacesFromImageResponse.Result)
{
    
}

