using Exadel.Compreface.Clients;
using Exadel.Compreface.Services;

// the rest of the other services will be configured like this
var client = new CompreFaceClient(
    domain: "http://localhost",
    port: "8000");

var subjects = await faceRecognitionClient.SubjectService.GetAllSubject();

foreach (var subject in subjects.Subjects)
{
    Console.WriteLine(subject);
}
