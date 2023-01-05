using System.Net.Http.Json;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.SubjectDTOs.AddSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteAllSubjects;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.GetSubjectList;
using Exadel.Compreface.DTOs.SubjectDTOs.RenameSubject;
using Flurl.Http;

namespace Exadel.Compreface.Services;

public class SubjectService
{
    private readonly ComprefaceConfiguration _configuration;
    
    public SubjectService(ComprefaceConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<GetAllSubjectResponse> GetAllSubject()
    {
        var requestUrl = $"{_configuration.BaseUrl}recognition/subjects/";
        var response = await requestUrl.GetJsonAsync<GetAllSubjectResponse>();

        return response;
    }

    public async Task<AddSubjectResponse> AddSubject(AddSubjectRequest request)
    {
        var requestUrl = $"{_configuration.BaseUrl}recognition/subjects";

        var response = await requestUrl.PostJsonAsync<AddSubjectResponse>(request);

        return response;
    }

    public async Task<RenameSubjectResponse> RenameSubject(RenameSubjectRequest request)
    {
        var requestUrl = $"{_configuration.BaseUrl}recognition/subjects/{request.CurrentSubject}";
        var response = await requestUrl
            .PutJsonAsync<RenameSubjectResponse>(body: request.Subject);
        
        return response;
    }

    public async Task<DeleteSubjectResponse> DeleteSubject(DeleteSubjectRequest request)
    {
        var requestUrl = $"{_configuration.BaseUrl}recognition/subjects/{request.ActualSubject}";

        var response = await requestUrl.DeleteJsonAsync<DeleteSubjectResponse>();
        
        return response;
    }

    public async Task<DeleteAllSubjectsResponse> DeleteAllSubjects()
    {
        var requestUrl = $"{_configuration.BaseUrl}recognition/subjects";

        var response = await requestUrl.DeleteJsonAsync<DeleteAllSubjectsResponse>();

        return response;
    }
}