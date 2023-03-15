//using Exadel.Compreface.Clients.CompreFaceClient;
//using Exadel.Compreface.DTOs.FaceCollectionDTOs.DeleteAllSubjectExamples;
//using Exadel.Compreface.DTOs.SubjectDTOs.AddSubject;
//using Exadel.Compreface.DTOs.SubjectDTOs.DeleteSubject;
//using Exadel.Compreface.Services.RecognitionService;
//using System.Reflection;
//using Xunit.Sdk;
//using static Exadel.Compreface.AcceptenceTests.UrlConstConfig;

//namespace Exadel.Compreface.AcceptenceTests.Services.RecognitionServiceTests
//{
//    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
//    public class FaceCollectionTestBeforeAfter : BeforeAfterTestAttribute
//    {
//        private readonly ICompreFaceClient _client;
//        private readonly RecognitionService _recognitionService;

//        public FaceCollectionTestBeforeAfter()
//        {
//            _client = new CompreFaceClient(DOMAIN, PORT);
//            _recognitionService = _client.GetCompreFaceService<RecognitionService>(API_KEY_RECOGNITION_SERVICE);
//        }

//        public async override void Before(MethodInfo methodUnderTest)
//        {
//            await _recognitionService.FaceCollection.DeleteAllAsync(new DeleteAllExamplesRequest() { Subject = TEST_SUBJECT_EXAMPLE_NAME });

//            await _recognitionService.Subject.AddAsync(
//                 new AddSubjectRequest() { Subject = TEST_SUBJECT_EXAMPLE_NAME });
//        }

//        public async override void After(MethodInfo methodUnderTest)
//        {
//            await _recognitionService.Subject.DeleteAsync(new DeleteSubjectRequest() { ActualSubject = TEST_SUBJECT_EXAMPLE_NAME });
//        }
//    }
//}
