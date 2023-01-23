using Exadel.Compreface.Clients;

// the rest of the other services will be configured like this
var faceRecognitionClient = new FaceRecognitionClient(
    apiKey: "746f45a6-b35e-4087-a79a-a686b3c47fb7",
    domain: "http://localhost",
    port: "8000");

var subjects = await faceRecognitionClient.SubjectService.GetAllSubject();

foreach (var subject in subjects.Subjects)
{
    Console.WriteLine(subject);
}    
