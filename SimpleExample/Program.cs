using Exadel.Compreface.Clients;

// the rest of the other services will be configured like this
var faceRecognitionClient = new FaceRecognitionClient(
    apiKey: "recognition api key here...",
    domain: "http://localhost",
    port: "8000");

var subjects = await faceRecognitionClient.SubjectService.GetAllSubject();

foreach (var subject in subjects.Subjects)
{
    Console.WriteLine(subject);
}