<Query Kind="Statements">
  <Reference Relative="..\..\..\Exadel.Compreface\bin\Debug\net7.0\Exadel.Compreface.dll">C:\Users\asindarov\source\repos\exadel\compreface-net-sdk\Exadel.Compreface\bin\Debug\net7.0\Exadel.Compreface.dll</Reference>
  <Namespace>Exadel.Compreface.Clients</Namespace>
  <Namespace>Exadel.Compreface.DTOs.SubjectDTOs.DeleteSubject</Namespace>
</Query>

var faceRecognitionClient = new FaceRecognitionClient("PASTE YOUR API KEY", "http://localhost", "8000");

var deleteSubjectRequest = new DeleteSubjectRequest()
{
    ActualSubject = "Actual Subject name"
};
        
var deleteSubjectResponse = await faceRecognitionClient.SubjectService.DeleteSubject(deleteSubjectRequest);

Console.WriteLine(deleteSubjectResponse.Subject);