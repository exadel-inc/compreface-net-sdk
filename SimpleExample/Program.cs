using Exadel.Compreface.Clients;
using Exadel.Compreface.Services;
using Exadel.Compreface.Services.RecognitionService;

// the rest of the other services will be configured like this
var client = new CompreFaceClient(
    domain: "http://localhost",
    port: "8000");

var subjects = client.GetService<RecognitionService>("00000000-0000-0000-0000-000000000002");
var x = subjects.RecognizeFaceFromImage;
var y = subjects.FaceCollection;
var b = subjects.Subject;

//foreach (var subject in subjects.Subjects)
//{
//    Console.WriteLine(subject);
//}
