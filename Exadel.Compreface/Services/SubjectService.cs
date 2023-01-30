using Exadel.Compreface.Clients.Interfaces;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.SubjectDTOs.AddSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteAllSubjects;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.GetSubjectList;
using Exadel.Compreface.DTOs.SubjectDTOs.RenameSubject;

namespace Exadel.Compreface.Services;

public class SubjectService
{
    private readonly ComprefaceConfiguration _configuration;
    private readonly IApiClient _apiClient;

    public SubjectService(ComprefaceConfiguration configuration, IApiClient apiClient)
    {
        _configuration = configuration;
        _apiClient = apiClient;
    }

    public async Task<GetAllSubjectResponse> GetAllSubject()
    {
        var requestUrl = $"{_configuration.Domain}:{_configuration.Port}/api/v1/recognition/subjects/";

        var response = await _apiClient.GetJsonAsync<GetAllSubjectResponse>(requestUrl);

        return response;
    }

    public async Task<AddSubjectResponse> AddSubject(AddSubjectRequest request)
    {
        var requestUrl = $"{_configuration.Domain}:{_configuration.Port}/api/v1/recognition/subjects";

        var response = await _apiClient.PostJsonAsync<AddSubjectResponse>(requestUrl, request);

        return response;
    }

    public async Task<RenameSubjectResponse> RenameSubject(RenameSubjectRequest request)
    {
        var requestUrl = $"{_configuration.Domain}:{_configuration.Port}/api/v1/recognition/subjects/{request.CurrentSubject}";

        var response = await _apiClient
            .PutJsonAsync<RenameSubjectResponse>(requestUrl, body: request.Subject);
        
        return response;
    }

    public async Task<DeleteSubjectResponse> DeleteSubject(DeleteSubjectRequest request)
    {
        var requestUrl = $"{_configuration.Domain}:{_configuration.Port}/api/v1/recognition/subjects/{request.ActualSubject}";

        var response = await _apiClient.DeleteJsonAsync<DeleteSubjectResponse>(requestUrl);
        
        return response;
    }

    public async Task<DeleteAllSubjectsResponse> DeleteAllSubjects()
    {
        var requestUrl = $"{_configuration.Domain}:{_configuration.Port}/api/v1/recognition/subjects";

        var response = await _apiClient.DeleteJsonAsync<DeleteAllSubjectsResponse>(requestUrl);

        return response;
    }
}