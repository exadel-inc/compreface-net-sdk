using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.SubjectDTOs.AddSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteAllSubjects;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.GetSubjectList;
using Exadel.Compreface.DTOs.SubjectDTOs.RenameSubject;

namespace Exadel.Compreface.Services.RecognitionService
{
    public class Subject
    {
        private readonly IComprefaceConfiguration _configuration;
        private readonly ApiClient _apiClient;

        public Subject(IComprefaceConfiguration configuration)
        {
            _configuration = configuration;
            _apiClient = new ApiClient(configuration);
        }

        public async Task<GetAllSubjectResponse> ListAsync()
        {
            var requestUrl = $"{_configuration.Domain}:{_configuration.Port}/api/v1/recognition/subjects/";

            var response = await _apiClient.GetJsonAsync<GetAllSubjectResponse>(requestUrl);

            return response;
        }

        public async Task<AddSubjectResponse> AddAsync(AddSubjectRequest request)
        {
            var requestUrl = $"{_configuration.Domain}:{_configuration.Port}/api/v1/recognition/subjects";

            var response = await _apiClient.PostJsonAsync<AddSubjectResponse>(requestUrl, request);

            return response;
        }

        public async Task<RenameSubjectResponse> RenameAsync(RenameSubjectRequest request)
        {
            var requestUrl = $"{_configuration.Domain}:{_configuration.Port}/api/v1/recognition/subjects/{request.CurrentSubject}";

            var response = await _apiClient.PutJsonAsync<RenameSubjectResponse>(requestUrl, body: request.Subject);

            return response;
        }

        public async Task<DeleteSubjectResponse> DeleteAsync(DeleteSubjectRequest request)
        {
            var requestUrl = $"{_configuration.Domain}:{_configuration.Port}/api/v1/recognition/subjects/{request.ActualSubject}";

            var response = await _apiClient.DeleteJsonAsync<DeleteSubjectResponse>(requestUrl);

            return response;
        }

        public async Task<DeleteAllSubjectsResponse> DeleteAllAsync()
        {
            var requestUrl = $"{_configuration.Domain}:{_configuration.Port}/api/v1/recognition/subjects";

            var response = await _apiClient.DeleteJsonAsync<DeleteAllSubjectsResponse>(requestUrl);

            return response;
        }
    }
}
