<Query Kind="Statements">
  <Reference Relative="..\..\..\Exadel.Compreface\bin\Debug\net7.0\Exadel.Compreface.dll">C:\Users\asindarov\source\repos\exadel\compreface-net-sdk\Exadel.Compreface\bin\Debug\net7.0\Exadel.Compreface.dll</Reference>
  <Namespace>Exadel.Compreface.Clients</Namespace>
  <Namespace>Exadel.Compreface.DTOs.SubjectDTOs.AddSubject</Namespace>
  <Namespace>Exadel.Compreface.DTOs.SubjectDTOs.DeleteSubject</Namespace>
</Query>

var faceRecognitionClient = new FaceRecognitionClient("PASTE YOUR API KEY", "http://localhost", "8000");

var addSubjectRequest = new AddSubjectRequest()
{
    Subject = "Newly created subject"
};

var addSubjectResponse = await faceRecognitionClient.SubjectService.AddSubject(addSubjectRequest);

Console.WriteLine(addSubjectResponse.Subject);
		
		