using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddBase64ExampleSubject;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddExampleSubject;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteAllSubjectExamples;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteImageById;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteMultipleExamples;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DownloadImageById;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DownloadImageBySubjectId;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.ListAllExampleSubject;
using Exadel.Compreface.Configuration;
using Flurl;
using Exadel.Compreface.DTOs.HelperDTOs;

namespace Exadel.Compreface.Services;

public class ExampleSubjectService
{
    private readonly IComprefaceConfiguration _configuration;

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
            .PostMultipartAsync<AddExampleSubjectResponse>(mp =>
                mp.AddFile("file", fileName: request.FileName, path: request.FilePath));

        return response;
    }

    public async Task<AddBase64ExampleSubjectResponse> AddBase64ExampleSubjectAsync(AddBase64ExampleSubjectRequest request)
    {
        var requestUrl = $"{_configuration.BaseUrl}recognition/faces";

        var response = await requestUrl
            .SetQueryParams(new
            {
                subject = request.Subject,
                det_prob_threshold = request.DetProbThreShold,
            })
            .PostJsonAsync<AddBase64ExampleSubjectResponse>(request.File);

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

    public async Task<DeleteAllExamplesResponse> ClearSubjectAsync(DeleteAllExamplesRequest request)
    {
        var requestUrl = $"{_configuration.BaseUrl}recognition/faces";

        var response = await requestUrl.
            SetQueryParam("subject", request.Subject)
            .DeleteJsonAsync<DeleteAllExamplesResponse>();

        return response;
    }

    public async Task<DeleteImageByIdResponse> DeleteImageByIdAsync(DeleteImageByIdRequest request)
    {
        var requestUrl = $"{_configuration.BaseUrl}recognition/faces";

        var response = await requestUrl
            .AppendPathSegment(request.ImageId.ToString())
            .DeleteJsonAsync<DeleteImageByIdResponse>();

        return response;
    }

    public async Task<DeleteMultipleExamplesResponse> DeletMultipleExamplesAsync(DeleteMultipleExampleRequest deleteMultipleExamplesRequest)
    {
        var requestUrl = $"{_configuration.BaseUrl}recognition/faces";

        var response = await requestUrl
            .AppendPathSegment("delete")
            .PostJsonAsync<List<Face>>(deleteMultipleExamplesRequest.ImageIdList);

        return new DeleteMultipleExamplesResponse() { Faces = response }; ;

    }

    public async Task<byte[]> DownloadImageByIdAsync(DownloadImageByIdRequest downloadImageByIdRequest)
    {
        var requestUrl = $"{_configuration.BaseUrl}recognition/faces";

        var response = await requestUrl
            .AppendPathSegments(downloadImageByIdRequest.RecognitionApiKey.ToString(), "/images/", downloadImageByIdRequest.ImageId.ToString())
            .GetBytesFromRemoteAsync();

        return response;
    }

    public async Task<byte[]> DownloadImageBySubjectIdAsync(DownloadImageBySubjectIdRequest downloadImageBySubjectIdRequest)
    {
        var requestUrl = $"{_configuration.BaseUrl}recognition/faces";

        var response = await requestUrl
            .AppendPathSegments(downloadImageBySubjectIdRequest.ImageId.ToString(), "/img")
            .GetBytesFromRemoteAsync();

        return response;
    }
}