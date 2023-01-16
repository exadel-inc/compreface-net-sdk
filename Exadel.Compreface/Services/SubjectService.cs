using Exadel.Compreface.Clients.Interfaces;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.SubjectDTOs.AddSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteAllSubjects;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.GetSubjectList;
using Exadel.Compreface.DTOs.SubjectDTOs.RenameSubject;
using Flurl;

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
        var requestUrl = $"{_configuration.Domain}/api/v1/recognition/subjects/";
        var url = new Url(requestUrl);
        url.Port = Convert.ToInt32(_configuration.Port);

        var response = await _apiClient.GetJsonAsync<GetAllSubjectResponse>(url);

        return response;
    }

    public async Task<AddSubjectResponse> AddSubject(AddSubjectRequest request)
    {
        var requestUrl = $"{_configuration.Domain}/api/v1/recognition/subjects";

        var url = new Url(requestUrl);
        url.Port = Convert.ToInt32(_configuration.Port);

        var response = await _apiClient.PostJsonAsync<AddSubjectResponse>(url, request);

        return response;
    }

    public async Task<RenameSubjectResponse> RenameSubject(RenameSubjectRequest request)
    {
        var requestUrl = $"{_configuration.Domain}/api/v1/recognition/subjects/{request.CurrentSubject}";

        var url = new Url(requestUrl);
        url.Port = Convert.ToInt32(_configuration.Port);

        var response = await _apiClient
            .PutJsonAsync<RenameSubjectResponse>(url, body: request.Subject);
        
        return response;
    }

    public async Task<DeleteSubjectResponse> DeleteSubject(DeleteSubjectRequest request)
    {
        var requestUrl = $"{_configuration.Domain}/api/v1/recognition/subjects/{request.ActualSubject}";

        var url = new Url(requestUrl);
        url.Port = Convert.ToInt32(_configuration.Port);

        var response = await _apiClient.DeleteJsonAsync<DeleteSubjectResponse>(url);
        
        return response;
    }

    public async Task<DeleteAllSubjectsResponse> DeleteAllSubjects()
    {
        var requestUrl = $"{_configuration.Domain}/api/v1/recognition/subjects";

        var url = new Url(requestUrl);
        url.Port = Convert.ToInt32(_configuration.Port);

        var response = await _apiClient.DeleteJsonAsync<DeleteAllSubjectsResponse>(url);

        return response;
    }
}