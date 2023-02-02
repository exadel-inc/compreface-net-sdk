using Exadel.Compreface.Clients;
using Exadel.Compreface.Services;

// the rest of the other services will be configured like this
var client = new CompreFaceClient(
    domain: "http://localhost",
    port: "8000");

var response = await client.GetService<SubjectService>("recognition api key...").ListAsync();

if (response.Subjects == null) throw new NullReferenceException();

foreach (var subject in response.Subjects)
{
    Console.WriteLine(subject);
}