using Exadel.Compreface.Clients.Config;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.SubjectDTOs.AddSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteAllSubjects;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.GetSubjectList;
using Exadel.Compreface.DTOs.SubjectDTOs.RenameSubject;

namespace Exadel.Compreface.Services;

public class SubjectService : IService
{
    private readonly IService _iService;

    public IComprefaceConfiguration Configuration { get; }

    public SubjectService(IComprefaceConfiguration configuration)
    {
        _iService = this;

        Configuration = configuration;

        ConfigInitializer.InitializeSnakeCaseJsonConfigs();
    }

    public async Task<GetAllSubjectResponse> GetAllSubject()
    {
        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/recognition/subjects/";

        var response = await _iService.GetJsonAsync<GetAllSubjectResponse>(requestUrl);

        return response;
    }

    public async Task<AddSubjectResponse> AddSubject(AddSubjectRequest request)
    {
        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/recognition/subjects";

        var response = await _iService.PostJsonAsync<AddSubjectResponse>(requestUrl, request);

        return response;
    }

    public async Task<RenameSubjectResponse> RenameSubject(RenameSubjectRequest request)
    {
        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/recognition/subjects/{request.CurrentSubject}";

        var response = await _iService.PutJsonAsync<RenameSubjectResponse>(requestUrl, body: request.Subject);
        
        return response;
    }

    public async Task<DeleteSubjectResponse> DeleteSubject(DeleteSubjectRequest request)
    {
        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/recognition/subjects/{request.ActualSubject}";

        var response = await _iService.DeleteJsonAsync<DeleteSubjectResponse>(requestUrl);
        
        return response;
    }

    public async Task<DeleteAllSubjectsResponse> DeleteAllSubjects()
    {
        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/recognition/subjects";

        var response = await _iService.DeleteJsonAsync<DeleteAllSubjectsResponse>(requestUrl);

        return response;
    }
}