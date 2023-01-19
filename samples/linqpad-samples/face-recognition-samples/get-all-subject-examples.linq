<Query Kind="Statements">
  <Reference Relative="..\..\..\Exadel.Compreface\bin\Debug\net7.0\Exadel.Compreface.dll">C:\Users\asindarov\source\repos\exadel\compreface-net-sdk\Exadel.Compreface\bin\Debug\net7.0\Exadel.Compreface.dll</Reference>
  <Namespace>Exadel.Compreface.Clients</Namespace>
  <Namespace>Exadel.Compreface.DTOs.ExampleSubjectDTOs.ListAllExampleSubject</Namespace>
  <Namespace>Exadel.Compreface.DTOs.SubjectDTOs.AddSubject</Namespace>
  <Namespace>Exadel.Compreface.DTOs.SubjectDTOs.DeleteSubject</Namespace>
  <Namespace>Exadel.Compreface.DTOs.SubjectDTOs.RenameSubject</Namespace>
</Query>

var faceRecognitionClient = new FaceRecognitionClient("PASTE YOUR API KEY", "http://localhost", "8000");

var listAllExampleSubjectRequest = new ListAllSubjectExamplesRequest()
{
    Page = 0,
    Size = 1,
    Subject = "Subject name",
};

var listAllExampleSubjectResponse = await faceRecognitionClient.SubjectExampleService.GetAllSubjectExamplesAsync(listAllExampleSubjectRequest);

foreach (var exampleSubject in listAllExampleSubjectResponse.Faces)
{
    Console.WriteLine(exampleSubject.Subject);
    Console.WriteLine(exampleSubject.ImageId);
}

Console.WriteLine(listAllExampleSubjectResponse.PageNumber);
Console.WriteLine(listAllExampleSubjectResponse.PageSize);
Console.WriteLine(listAllExampleSubjectResponse.TotalElements);
Console.WriteLine(listAllExampleSubjectResponse.TotalPages);
