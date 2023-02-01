using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.SubjectDTOs.AddSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteAllSubjects;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.GetSubjectList;
using Exadel.Compreface.DTOs.SubjectDTOs.RenameSubject;

namespace Exadel.Compreface.Services;

public class SubjectService : AbstractBaseService
{
    public SubjectService(IComprefaceConfiguration configuration)
        : base(configuration) { }

    public async Task<GetAllSubjectResponse> ListAsync()
    {
        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/recognition/subjects/";

        var response = await GetJsonAsync<GetAllSubjectResponse>(requestUrl);

        return response;
    }

    public async Task<AddSubjectResponse> AddAsync(AddSubjectRequest request)
    {
        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/recognition/subjects";

        var response = await PostJsonAsync<AddSubjectResponse>(requestUrl, request);

        return response;
    }

    public async Task<RenameSubjectResponse> RenameAsync(RenameSubjectRequest request)
    {
        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/recognition/subjects/{request.CurrentSubject}";

        var response = await PutJsonAsync<RenameSubjectResponse>(requestUrl, body: request.Subject);
        
        return response;
    }

    public async Task<DeleteSubjectResponse> DeleteAsync(DeleteSubjectRequest request)
    {
        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/recognition/subjects/{request.ActualSubject}";

        var response = await DeleteJsonAsync<DeleteSubjectResponse>(requestUrl);
        
        return response;
    }

    public async Task<DeleteAllSubjectsResponse> DeleteAllAsync()
    {
        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/recognition/subjects";

        var response = await DeleteJsonAsync<DeleteAllSubjectsResponse>(requestUrl);

        return response;
    }
}