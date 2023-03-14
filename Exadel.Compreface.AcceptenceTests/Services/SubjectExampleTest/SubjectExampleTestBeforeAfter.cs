//using Exadel.Compreface.Clients;
//using Exadel.Compreface.Configuration;
//using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteAllSubjectExamples;
//using Exadel.Compreface.DTOs.SubjectDTOs.AddSubject;
//using Exadel.Compreface.DTOs.SubjectDTOs.DeleteSubject;
//using System.Reflection;
//using Xunit.Sdk;
//using static Exadel.Compreface.AcceptenceTests.UrlConstConfig;

//namespace Exadel.Compreface.AcceptenceTests.Services
//{
//    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
//    public class SubjectExampleTestBeforeAfter : BeforeAfterTestAttribute
//    {
//        private readonly FaceRecognitionClient faceRecognitionClient;

//        public SubjectExampleTestBeforeAfter()
//        {
//            faceRecognitionClient = new FaceRecognitionClient(new ComprefaceConfiguration(API_KEY_RECOGNITION_SERVICE, DOMAIN, PORT));
//        }

//        public async override void Before(MethodInfo methodUnderTest)
//        {
//            await faceRecognitionClient.SubjectExampleService.ClearSubjectAsync(new DeleteAllExamplesRequest() { Subject = TEST_SUBJECT_EXAMPLE_NAME });

//            await faceRecognitionClient.SubjectService.AddSubject(
//                 new AddSubjectRequest() { Subject = TEST_SUBJECT_EXAMPLE_NAME });
//        }

//        public async override void After(MethodInfo methodUnderTest)
//        {
//            await faceRecognitionClient.SubjectService.DeleteSubject(new DeleteSubjectRequest() { ActualSubject = TEST_SUBJECT_EXAMPLE_NAME });
//        }
//    }
//}
