<Query Kind="Statements">
  <Reference Relative="..\..\..\Exadel.Compreface\bin\Debug\net7.0\Exadel.Compreface.dll">C:\Users\asindarov\source\repos\exadel\compreface-net-sdk\Exadel.Compreface\bin\Debug\net7.0\Exadel.Compreface.dll</Reference>
  <Namespace>Exadel.Compreface.Clients</Namespace>
  <Namespace>Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteAllSubjectExamples</Namespace>
  <Namespace>Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteImageById</Namespace>
  <Namespace>Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteMultipleExamples</Namespace>
  <Namespace>Exadel.Compreface.DTOs.ExampleSubjectDTOs.DownloadImageById</Namespace>
  <Namespace>Exadel.Compreface.DTOs.ExampleSubjectDTOs.ListAllExampleSubject</Namespace>
  <Namespace>Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFaceFromImage</Namespace>
  <Namespace>Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFacesFromImageWithBase64</Namespace>
  <Namespace>Exadel.Compreface.DTOs.SubjectDTOs.AddSubject</Namespace>
  <Namespace>Exadel.Compreface.DTOs.SubjectDTOs.DeleteSubject</Namespace>
  <Namespace>Exadel.Compreface.DTOs.SubjectDTOs.RenameSubject</Namespace>
</Query>

var faceRecognitionClient = new FaceRecognitionClient("PASTE YOUR API KEY", "http://localhost", "8000");


var imageBytes = await File.ReadAllBytesAsync("file path");

var base64ImageValue = Convert.ToBase64String(imageBytes);

var recognizeFacesFromImageWithBase64Request = new RecognizeFacesFromImageWithBase64Request()
{
    FileBase64Value = base64ImageValue,
    DetProbThreshold = 0.85m,
    FacePlugins = new List<string>()
    {
        "landmarks",
        "gender",
        "age",
    },
    Status = true,
};

var recognizeFaceFromImageResponse =
    await faceRecognitionClient.RecognitionService.RecognizeFaceFromBase64File(recognizeFacesFromImageWithBase64Request);

foreach (var result in recognizeFaceFromImageResponse.Result)
{
    // observe result object
}