using Exadel.Compreface.Clients;
using Exadel.Compreface.Services;
using Exadel.Compreface.Services.RecognitionService;

// the rest of the other services will be configured like this
var client = new CompreFaceClient(
    domain: "http://localhost",
    port: "8000");

var subjects = await client.GetService<RecognitionService>("00000000-0000-0000-0000-000000000002").Subject.ListAsync();
var subjects1 = await client.GetService<RecognitionService>("771b42b2-eaf3-47d4-a768-aa35e316c76f").Subject.ListAsync();

foreach (var subject in subjects.Subjects)
{
    Console.WriteLine(subject);
}
