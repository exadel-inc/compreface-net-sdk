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

        var response = await requestUrl.PostJsonAsync(request);
        var subjectDto = await response.ResponseMessage.Content.ReadFromJsonAsync<AddSubjectResponse>();

        return subjectDto;
    }

    public async Task<RenameSubjectResponse> RenameSubject(RenameSubjectRequest request)
    {
        var requestUrl = $"{_configuration.BaseUrl}recognition/subjects/{request.CurrentSubject}";
        var response = await requestUrl
            .PutJsonAsync(request.Subject);
        
        var subjectDto = await response.ResponseMessage.Content.ReadFromJsonAsync<RenameSubjectResponse>();

        return subjectDto;
    }

    public async Task<DeleteSubjectResponse> DeleteSubject(DeleteSubjectRequest request)
    {
        var requestUrl = $"{_configuration.BaseUrl}recognition/subjects/{request.ActualSubject}";

        var response = await requestUrl.DeleteAsync();
        
        var deleteSubjectResponse = await response.ResponseMessage.Content.ReadFromJsonAsync<DeleteSubjectResponse>();
        
        return deleteSubjectResponse;
    }

    public async Task<DeleteAllSubjectsResponse> DeleteAllSubjects()
    {
        var requestUrl = $"{_configuration.BaseUrl}recognition/subjects";

        var response = await requestUrl.DeleteAsync();

        var deleteAllSubjectsResponse = await response.ResponseMessage.Content.ReadFromJsonAsync<DeleteAllSubjectsResponse>();
        
        return deleteAllSubjectsResponse;
    }
}