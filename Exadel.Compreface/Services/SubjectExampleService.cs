using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddExampleSubject;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddBase64ExampleSubject;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteAllSubjectExamples;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteImageById;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteMultipleExamples;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DownloadImageById;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DownloadImageBySubjectId;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.ListAllExampleSubject;
using Exadel.Compreface.DTOs.HelperDTOs;
using Flurl;

namespace Exadel.Compreface.Services;

public class SubjectExampleService : AbstractBaseService
{
    public SubjectExampleService(IComprefaceConfiguration configuration)
            : base(configuration) { }

    public async Task<AddSubjectExampleResponse> AddSubjectExampleAsync(AddSubjectExampleRequest request)
    {
        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/recognition/faces";
        var requestUrlWithQueryParameters = requestUrl
            .SetQueryParams(new
            {
                subject = request.Subject,
                det_prob_threshold = request.DetProbThreShold,
            });

        var response = await PostMultipartAsync<AddSubjectExampleResponse>(
            requestUrl: requestUrlWithQueryParameters,
            buildContent: mp =>
                mp.AddFile("file", fileName: request.FileName, path: request.FilePath)); 

        return response;
    }

    public async Task<AddBase64SubjectExampleResponse> AddBase64SubjectExampleAsync(AddBase64SubjectExampleRequest request)
    {
        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/recognition/faces";
        var requestUrlWithQueryParameters = requestUrl
            .SetQueryParams(new
            {
                subject = request.Subject,
                det_prob_threshold = request.DetProbThreShold,
            });

        var response = await PostJsonAsync<AddBase64SubjectExampleResponse>(requestUrlWithQueryParameters, new { file = request.File });

        return response;
    }

    public async Task<ListAllSubjectExamplesResponse> GetAllSubjectExamplesAsync(ListAllSubjectExamplesRequest request)
    {
        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/recognition/faces";
        var requestUrlWithQueryParameters = requestUrl
            .SetQueryParams(new
            {
                page = request.Page,
                size = request.Size,
                subject = request.Subject,
            });

        var response = await GetJsonAsync<ListAllSubjectExamplesResponse>(requestUrlWithQueryParameters);

        return response;
    }

    public async Task<DeleteAllExamplesResponse> ClearSubjectAsync(DeleteAllExamplesRequest request)
    {
        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/recognition/faces";
        var requestUrlWithQueryParameters = requestUrl
            .SetQueryParam("subject", request.Subject);

        var response = 
            await DeleteJsonAsync<DeleteAllExamplesResponse>(requestUrlWithQueryParameters);

        return response;
    }

    public async Task<DeleteImageByIdResponse> DeleteImageByIdAsync(DeleteImageByIdRequest request)
    {
        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/recognition/faces";
        var requestUrlWithQueryParameters = requestUrl
            .AppendPathSegment(request.ImageId.ToString());

        var response = await 
            DeleteJsonAsync<DeleteImageByIdResponse>(requestUrlWithQueryParameters);

        return response;
    }

    public async Task<DeleteMultipleExamplesResponse> DeletMultipleExamplesAsync(DeleteMultipleExampleRequest deleteMultipleExamplesRequest)
    {
        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/recognition/faces";
        var requestUrlWithQueryParameters = requestUrl
            .AppendPathSegment("delete");

        var response = await PostJsonAsync<List<Face>>(requestUrlWithQueryParameters, deleteMultipleExamplesRequest.ImageIdList);

        return new DeleteMultipleExamplesResponse() { Faces = response };
    }

    public async Task<byte[]> DownloadImageByIdAsync(DownloadImageByIdRequest downloadImageByIdRequest)
    {
        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/static";
        var requestUrlWithQueryParameters = requestUrl
            .AppendPathSegments(
                downloadImageByIdRequest.RecognitionApiKey.ToString(),
                "/images/",
                downloadImageByIdRequest.ImageId.ToString());

        var response = await GetBytesFromRemoteAsync(requestUrlWithQueryParameters);

        return response;
    }

    public async Task<byte[]> DownloadImageBySubjectIdAsync(DownloadImageBySubjectIdRequest downloadImageBySubjectIdRequest)
    {
        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/recognition/faces";
        var requestUrlWithQueryParameters = requestUrl
            .AppendPathSegments(downloadImageBySubjectIdRequest.ImageId.ToString(), "/img");

        var response = await GetBytesFromRemoteAsync(requestUrlWithQueryParameters);

        return response;
    }
}