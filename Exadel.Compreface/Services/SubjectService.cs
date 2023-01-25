using Exadel.Compreface.Clients.Interfaces;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.SubjectDTOs.AddSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteAllSubjects;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.GetSubjectList;
using Exadel.Compreface.DTOs.SubjectDTOs.RenameSubject;
using Flurl;

namespace Exadel.Compreface.Services;

public class SubjectService : BaseService
{
    public SubjectService(IComprefaceConfiguration configuration, IApiClient apiClient)
            : base(configuration, apiClient) { }

    public async Task<GetAllSubjectResponse> GetAllSubject()
    {
        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/recognition/subjects/";

        var response = await ApiClient.GetJsonAsync<GetAllSubjectResponse>(requestUrl);

        return response;
    }

    public async Task<AddSubjectResponse> AddSubject(AddSubjectRequest request)
    {
        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/recognition/subjects";

        var response = await ApiClient.PostJsonAsync<AddSubjectResponse>(requestUrl, request);

        return response;
    }

    public async Task<RenameSubjectResponse> RenameSubject(RenameSubjectRequest request)
    {
        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/recognition/subjects/{request.CurrentSubject}";

        var response = await ApiClient
            .PutJsonAsync<RenameSubjectResponse>(requestUrl, body: request.Subject);
        
        return response;
    }

    public async Task<DeleteSubjectResponse> DeleteSubject(DeleteSubjectRequest request)
    {
        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/recognition/subjects/{request.ActualSubject}";

        var response = await ApiClient.DeleteJsonAsync<DeleteSubjectResponse>(requestUrl);
        
        return response;
    }

    public async Task<DeleteAllSubjectsResponse> DeleteAllSubjects()
    {
        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/recognition/subjects";

        var response = await ApiClient.DeleteJsonAsync<DeleteAllSubjectsResponse>(requestUrl);

        return response;
    }
}