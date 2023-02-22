using Exadel.Compreface.Clients.CompreFaceClient;
using Exadel.Compreface.Services;
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


var configFaceDetection = configuration.GetSection("FaceDetectionApiKey").Value;
var detectService = client.GetCompreFaceService<FaceDetectionService>(configFaceDetection);

var configFaceRecognition = configuration.GetSection("FaceRecognitionApiKey").Value;
var recognitionService = client.GetCompreFaceService<RecognitionService>(configFaceRecognition);

var conf = serviceProvider.GetService<IConfiguration>();
var subject = client.GetCompreFaceService<RecognitionService>(conf, "FaceRecognitionApiKey");
await subject.FaceCollection.ListAsync(new Exadel.Compreface.DTOs.ExampleSubjectDTOs.ListAllExampleSubject.ListAllSubjectExamplesRequest() { Subject = "Subject name" });