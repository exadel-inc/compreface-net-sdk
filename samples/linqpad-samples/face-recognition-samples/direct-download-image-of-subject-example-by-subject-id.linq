<Query Kind="Statements">
  <Reference Relative="..\..\..\Exadel.Compreface\bin\Debug\net7.0\Exadel.Compreface.dll">C:\Users\asindarov\source\repos\exadel\compreface-net-sdk\Exadel.Compreface\bin\Debug\net7.0\Exadel.Compreface.dll</Reference>
  <Namespace>Exadel.Compreface.Clients</Namespace>
  <Namespace>Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteAllSubjectExamples</Namespace>
  <Namespace>Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteImageById</Namespace>
  <Namespace>Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteMultipleExamples</Namespace>
  <Namespace>Exadel.Compreface.DTOs.ExampleSubjectDTOs.DownloadImageById</Namespace>
  <Namespace>Exadel.Compreface.DTOs.ExampleSubjectDTOs.DownloadImageBySubjectId</Namespace>
  <Namespace>Exadel.Compreface.DTOs.ExampleSubjectDTOs.ListAllExampleSubject</Namespace>
  <Namespace>Exadel.Compreface.DTOs.SubjectDTOs.AddSubject</Namespace>
  <Namespace>Exadel.Compreface.DTOs.SubjectDTOs.DeleteSubject</Namespace>
  <Namespace>Exadel.Compreface.DTOs.SubjectDTOs.RenameSubject</Namespace>
</Query>

var faceRecognitionClient = new FaceRecognitionClient("PASTE YOUR API KEY", "http://localhost", "8000");

var downloadImageBySubjectIdRequest = new DownloadImageBySubjectIdRequest()
{
    ImageId = Guid.Parse("Image Id here")
};
	
await faceRecognitionClient.SubjectExampleService.DownloadImageBySubjectIdAsync(downloadImageBySubjectIdRequest);