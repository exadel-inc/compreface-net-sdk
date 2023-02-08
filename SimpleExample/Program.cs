using Exadel.Compreface.Clients.CompreFaceClient;
using Exadel.Compreface.Services.RecognitionService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// the rest of the other services will be configured like this
var client = new CompreFaceClient(
    domain: "http://localhost",
    port: "8000");

var host = Host.CreateDefaultBuilder()
    .Build();

var serviceProvider = host.Services;

var configuration = serviceProvider.GetService<IConfiguration>();
var config = configuration.GetSection("FaceRecognitionApiKey").Value;
var subjects = client.GetCompreFaceService<RecognitionService>(config);
await subjects.FaceCollection.ListAsync(new Exadel.Compreface.DTOs.ExampleSubjectDTOs.ListAllExampleSubject.ListAllSubjectExamplesRequest() { Subject = "dssdgsd" });

var conf = serviceProvider.GetService<IConfiguration>();
var subject = client.GetCompreFaceService<RecognitionService>(conf, "FaceRecognitionApiKey");
await subject.FaceCollection.ListAsync(new Exadel.Compreface.DTOs.ExampleSubjectDTOs.ListAllExampleSubject.ListAllSubjectExamplesRequest() { Subject = "dssdgsd" });

var subj = client.GetCompreFaceService<RecognitionService>("00000000-0000-0000-0000-000000000002");
await subj.FaceCollection.ListAsync(new Exadel.Compreface.DTOs.ExampleSubjectDTOs.ListAllExampleSubject.ListAllSubjectExamplesRequest() { Subject = "dssdgsd" });


//var subjects1 = client.GetCompreFaceService<RecognitionService>("");
//var subjects2 = client.GetCompreFaceService<RecognitionService>("00000000-0000-0000-0000-000000000002");
//var subjects3 = client.GetCompreFaceService<RecognitionService>("00000000-0000-0000-0000-000000000002");
//var subjects4 = client.GetCompreFaceService<RecognitionService>("00000000-0000-0000-0000-000000000002");
//var subjects5 = client.GetCompreFaceService<RecognitionService>("00000000-0000-0000-0000-000000000002");
//var subjects6 = client.GetCompreFaceService<RecognitionService>("00000000-0000-0000-0000-000000000002");


//foreach (var subject in subjects.Subjects)
//{
//    Console.WriteLine(subject);
//}
