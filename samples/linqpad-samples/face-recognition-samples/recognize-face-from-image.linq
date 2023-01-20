<Query Kind="Statements">
  <Reference Relative="..\..\..\Exadel.Compreface\bin\Debug\net7.0\Exadel.Compreface.dll">C:\Users\asindarov\source\repos\exadel\compreface-net-sdk\Exadel.Compreface\bin\Debug\net7.0\Exadel.Compreface.dll</Reference>
  <Namespace>Exadel.Compreface.Clients</Namespace>
  <Namespace>Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteAllSubjectExamples</Namespace>
  <Namespace>Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteImageById</Namespace>
  <Namespace>Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteMultipleExamples</Namespace>
  <Namespace>Exadel.Compreface.DTOs.ExampleSubjectDTOs.DownloadImageById</Namespace>
  <Namespace>Exadel.Compreface.DTOs.ExampleSubjectDTOs.ListAllExampleSubject</Namespace>
  <Namespace>Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFaceFromImage</Namespace>
  <Namespace>Exadel.Compreface.DTOs.SubjectDTOs.AddSubject</Namespace>
  <Namespace>Exadel.Compreface.DTOs.SubjectDTOs.DeleteSubject</Namespace>
  <Namespace>Exadel.Compreface.DTOs.SubjectDTOs.RenameSubject</Namespace>
</Query>

var faceRecognitionClient = new FaceRecognitionClient("PASTE YOUR API KEY", "http://localhost", "8000");


var recognizeFaceFromImageRequest = new RecognizeFaceFromImageRequest()
{
    FileName = "", // file name here....
    FilePath = "", // file path
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
    await faceRecognitionClient.RecognitionService.RecognizeFaceFromImage(recognizeFaceFromImageRequest);

foreach (var result in recognizeFaceFromImageResponse.Result)
{
    foreach (var subject in result.Subjects)
    {
        Console.WriteLine($"Subject : {subject.Subject}");
        Console.WriteLine($"Similarity: {subject.Similarity}");
    }
}
