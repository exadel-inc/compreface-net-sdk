﻿using Exadel.Compreface.Clients.CompreFaceClient;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetection;
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

var faceDetectionRequest = new FaceDetectionRequestByFileUrl()
{
    FileUrl = "http://t1.gstatic.com/licensed-image?q=tbn:ANd9GcS6j6jazxVpBpf4ZdKMgUeN61C_s4EJPqI7NijX0PDep3SGXQ_bT9ap12h2MWoIolUIpngs3pApkIH-Kzw",
    DetProbThreshold = 0.85m,
    FacePlugins = new List<string>()
            {
                "age",
                "gender",
                "mask",
                "calculator",
            },
    Status = true,
};
var configdetect = configuration.GetSection("FaceDetectionApiKey").Value;
var detectService = client.GetCompreFaceService<FaceDetectionService>(configdetect);
await detectService.DetectAsync(faceDetectionRequest);

var config = configuration.GetSection("FaceRecognitionApiKey").Value;
var subjects = client.GetCompreFaceService<RecognitionService>(config);
await subjects.FaceCollection.ListAsync(new Exadel.Compreface.DTOs.ExampleSubjectDTOs.ListAllExampleSubject.ListAllSubjectExamplesRequest() { Subject = "Subject name" });

var conf = serviceProvider.GetService<IConfiguration>();
var subject = client.GetCompreFaceService<RecognitionService>(conf, "FaceRecognitionApiKey");
await subject.FaceCollection.ListAsync(new Exadel.Compreface.DTOs.ExampleSubjectDTOs.ListAllExampleSubject.ListAllSubjectExamplesRequest() { Subject = "Subject name" });

var subj = client.GetCompreFaceService<RecognitionService>("00000000-0000-0000-0000-000000000002");
await subj.FaceCollection.ListAsync(new Exadel.Compreface.DTOs.ExampleSubjectDTOs.ListAllExampleSubject.ListAllSubjectExamplesRequest() { Subject = "Subject name" });

