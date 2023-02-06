using Exadel.Compreface.Clients;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddExampleSubject;
using Exadel.Compreface.Services;

// the rest of the other services will be configured like this
var client = new CompreFaceClient(
    domain: "http://localhost",
    port: "8000");

await client.GetService<SubjectExampleService>("771b42b2-eaf3-47d4-a768-aa35e316c76f").AddAsync(
    new AddSubjectExampleRequest()
     { Subject = "Name",
         File = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSEDRhEeRY31Tf4S7NU-S2lFH_SitKGWOGSDg&usqp=CAU",
         DetProbThreShold = 0.81m
     },
    true
    );

//foreach (var subject in subjects.Subjects)
//{
//    Console.WriteLine(subject);
//}
