using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.ExampleSubject.AddExampleSubject;
using Exadel.Compreface.DTOs.ExampleSubject.ListAllExampleSubject;
using Flurl;
using Flurl.Http;

namespace Exadel.Compreface.Services;

public class ExampleSubjectService
{
    private readonly ComprefaceConfiguration _configuration;
    
    public ExampleSubjectService(ComprefaceConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public async Task<AddExampleSubjectResponse> AddExampleSubject(AddExampleSubjectRequest request)
    {
        var requestUrl = $"{_configuration.BaseUrl}recognition/faces";

        var response = await requestUrl
            .SetQueryParams(new
            {
                subject = request.Subject,
                det_prob_threshold = request.DetProbThreShold,
            })
            .PostMultipartAsync(mp =>
                mp.AddFile("file", fileName: request.FileName, path: request.FilePath))
            .ReceiveJson<AddExampleSubjectResponse>();

        return response;
    }
    public async Task<ListAllExampleSubjectResponse> GetAllExampleSubjects(ListAllExampleSubjectRequest request)
    {
        var requestUrl = $"{_configuration.BaseUrl}recognition/faces";

        var response = await requestUrl
            .SetQueryParams(new
            {
                page = request.Page,
                size = request.Size,
                subject = request.Subject,
            })
            .GetJsonAsync<ListAllExampleSubjectResponse>();

        return response;
    }
}