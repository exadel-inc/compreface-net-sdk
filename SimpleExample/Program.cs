using Exadel.Compreface.Clients;
using Exadel.Compreface.Services;

// the rest of the other services will be configured like this
var client = new CompreFaceClient(
    domain: "http://localhost",
    port: "8000");

var subjects = await client.GetService<SubjectService>("recognition api key here...").GetAllSubject();

foreach (var subject in subjects.Subjects)
{
    Console.WriteLine(subject);
}
