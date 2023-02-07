using Exadel.Compreface.Clients.CompreFaceClient;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteAllSubjectExamples;
using Exadel.Compreface.DTOs.SubjectDTOs.AddSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteSubject;
using Exadel.Compreface.Services;
using System.Reflection;
using Xunit.Sdk;
using static Exadel.Compreface.AcceptenceTests.UrlConstConfig;

namespace Exadel.Compreface.AcceptenceTests.Services
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class SubjectExampleTestBeforeAfter : BeforeAfterTestAttribute
    {
        private readonly CompreFaceClient _client;

        public SubjectExampleTestBeforeAfter()
        {
            _client = new CompreFaceClient(new ComprefaceConfiguration(API_KEY_RECOGNITION_SERVICE, DOMAIN, PORT));
        }

        public async override void Before(MethodInfo methodUnderTest)
        {
            await _client.GetService<SubjectExampleService>(API_KEY_RECOGNITION_SERVICE).DeleteAllAsync(new DeleteAllExamplesRequest() { Subject = TEST_SUBJECT_EXAMPLE_NAME });

            await _client.GetService<SubjectService>(API_KEY_RECOGNITION_SERVICE).AddAsync(
                 new AddSubjectRequest() { Subject = TEST_SUBJECT_EXAMPLE_NAME });
        }

        public async override void After(MethodInfo methodUnderTest)
        {
            await _client.GetService<SubjectService>(API_KEY_RECOGNITION_SERVICE).DeleteAsync(new DeleteSubjectRequest() { ActualSubject = TEST_SUBJECT_EXAMPLE_NAME });
        }
    }
}
