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
    private readonly ApiClient _apiClient;

    public ExampleSubjectService(ComprefaceConfiguration configuration, ApiClient apiClient)
    {
        _configuration = configuration;
        _apiClient = apiClient;
    }

    public async Task<AddExampleSubjectResponse> AddExampleSubjectAsync(AddExampleSubjectRequest request)
    {
        var requestUrl = $"{_configuration.BaseUrl}recognition/faces";
        var requestUrlWithQueryParameters = requestUrl
            .SetQueryParams(new
            {
                subject = request.Subject,
                det_prob_threshold = request.DetProbThreShold,
            });
        
        var response = await _apiClient.PostMultipartAsync<AddExampleSubjectResponse>(
            requestUrl: requestUrlWithQueryParameters,
            buildContent: mp =>
                mp.AddFile("file", fileName: request.FileName, path: request.FilePath)); 

        return response;
    }

    public async Task<AddBase64ExampleSubjectResponse> AddBase64ExampleSubjectAsync(AddBase64ExampleSubjectRequest request)
    {
        var requestUrl = $"{_configuration.BaseUrl}recognition/faces";
        var requestUrlWithQueryParameters = requestUrl
            .SetQueryParams(new
            {
                subject = request.Subject,
                det_prob_threshold = request.DetProbThreShold,
            });
        
        var response = await _apiClient
            .PostJsonAsync<AddBase64ExampleSubjectResponse>(requestUrlWithQueryParameters, request.File);

        return response;
    }

    public async Task<ListAllExampleSubjectResponse> GetAllExampleSubjectsAsync(ListAllExampleSubjectRequest request)
    {
        var requestUrl = $"{_configuration.BaseUrl}recognition/faces";
        var requestUrlWithQueryParameters = requestUrl
            .SetQueryParams(new
            {
                page = request.Page,
                size = request.Size,
                subject = request.Subject,
            });
            
        var response = await _apiClient.GetJsonAsync<ListAllExampleSubjectResponse>(requestUrlWithQueryParameters);

        return response;
    }

    public async Task<DeleteAllExamplesResponse> ClearSubjectAsync(DeleteAllExamplesRequest request)
    {
        var requestUrl = $"{_configuration.BaseUrl}recognition/faces";
        var requestUrlWithQueryParameters = requestUrl
            .SetQueryParam("subject", request.Subject);
        
        var response = 
            await _apiClient.DeleteJsonAsync<DeleteAllExamplesResponse>(requestUrlWithQueryParameters);

        return response;
    }

    public async Task<DeleteImageByIdResponse> DeleteImageByIdAsync(DeleteImageByIdRequest request)
    {
        var requestUrl = $"{_configuration.BaseUrl}recognition/faces";
        var requestUrlWithQueryParameters = requestUrl
            .AppendPathSegment(request.ImageId.ToString());
        
        var response = await 
            _apiClient.DeleteJsonAsync<DeleteImageByIdResponse>(requestUrlWithQueryParameters);

        return response;
    }

    public async Task<DeleteMultipleExamplesResponse> DeletMultipleExamplesAsync(DeleteMultipleExampleRequest deleteMultipleExamplesRequest)
    {
        var requestUrl = $"{_configuration.BaseUrl}recognition/faces";
        var requestUrlWithQueryParameters = requestUrl
            .AppendPathSegment("delete");
        
        var response = await 
            _apiClient.PostJsonAsync<List<Face>>(requestUrlWithQueryParameters, deleteMultipleExamplesRequest.ImageIdList);

        return new DeleteMultipleExamplesResponse() { Faces = response }; ;

    }

    public async Task<byte[]> DownloadImageByIdAsync(DownloadImageByIdRequest downloadImageByIdRequest)
    {
        var requestUrl = $"{_configuration.BaseUrl}recognition/faces";
        var requestUrlWithQueryParameters = requestUrl
            .AppendPathSegments(
                downloadImageByIdRequest.RecognitionApiKey.ToString(),
                "/images/",
                downloadImageByIdRequest.ImageId.ToString());
        
        var response = await 
            _apiClient.GetBytesFromRemoteAsync(requestUrlWithQueryParameters);

        return response;
    }

    public async Task<byte[]> DownloadImageBySubjectIdAsync(DownloadImageBySubjectIdRequest downloadImageBySubjectIdRequest)
    {
        var requestUrl = $"{_configuration.BaseUrl}recognition/faces";
        var requestUrlWithQueryParameters = requestUrl
            .AppendPathSegments(downloadImageBySubjectIdRequest.ImageId.ToString(), "/img");

        var response = await 
            _apiClient.GetBytesFromRemoteAsync(requestUrlWithQueryParameters);

        return response;
    }
}