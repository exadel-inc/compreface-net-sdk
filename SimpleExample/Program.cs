using System.Threading.Channels;
using Exadel.Compreface.Clients;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddExampleSubject;

// the rest of the other services will be configured like this
var faceRecognitionClient = new FaceRecognitionClient(
    apiKey: "746f45a6-b35e-4087-a79a-a686b3c47fb7",
    domain: "http://localhost",
    port: "8000");

var addSubjectExampleRequest = new AddSubjectExampleRequest()
{
    Subject = "Vladimir",
    File = "https://www.pngall.com/wp-content/uploads/12/Girl-Face-Transparent.png",
};

var createdSubjectExample = await faceRecognitionClient.SubjectExampleService.AddSubjectExampleAsync(addSubjectExampleRequest, isFileInTheRemoteServer: true);

Console.WriteLine("");