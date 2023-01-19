<Query Kind="Statements">
  <Reference Relative="..\..\..\Exadel.Compreface\bin\Debug\net7.0\Exadel.Compreface.dll">C:\Users\asindarov\source\repos\exadel\compreface-net-sdk\Exadel.Compreface\bin\Debug\net7.0\Exadel.Compreface.dll</Reference>
  <Namespace>Exadel.Compreface.Clients</Namespace>
</Query>

var faceRecognitionClient = new FaceRecognitionClient("PASTE YOUR API KEY", "http://localhost", "8000");
	
var subjects = await faceRecognitionClient.SubjectService.GetAllSubject();

foreach(var subject in subjects.Subjects)
{
	Console.WriteLine(subject);
}
