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
using Exadel.Compreface.Helpers;
using Flurl.Http;
using Exadel.Compreface.Services.Interfaces;

namespace Exadel.Compreface.Services;

public class SubjectExampleService : IBaseService
{
    private readonly IComprefaceConfiguration _configuration;
    private readonly ApiClient _apiClient;

    public SubjectExampleService(IComprefaceConfiguration configuration)
    {
        _configuration = configuration;
        _apiClient = new ApiClient(configuration);
    }

    public async Task<AddSubjectExampleResponse> AddAsync(AddSubjectExampleRequest request, bool isFileInTheRemoteServer = false)
    {
        var requestUrl = $"{_configuration.Domain}:{_configuration.Port}/api/v1/recognition/faces";
        var requestUrlWithQueryParameters = requestUrl
            .SetQueryParams(new
            {
                subject = request.Subject,
                det_prob_threshold = request.DetProbThreShold,
            });
        AddSubjectExampleResponse? response = null;

        if (isFileInTheRemoteServer)
        {
            var fileStream = await request.File.GetBytesAsync();
            var fileInBase64String = Convert.ToBase64String(fileStream);

            var addBase64SubjectExampleRequest = new AddBase64SubjectExampleRequest()
            {
                DetProbThreShold = request.DetProbThreShold,
                File = fileInBase64String,
                Subject = request.Subject,
            };

            response = await _apiClient.PostJsonAsync<AddSubjectExampleResponse>(requestUrlWithQueryParameters, body: addBase64SubjectExampleRequest);
            return response;
        }

        response = await _apiClient.PostMultipartAsync<AddSubjectExampleResponse>(
            requestUrl: requestUrlWithQueryParameters,
            buildContent: mp =>
                mp.AddFile("file", fileName: FileHelpers.GenerateFileName(request.File), path: request.File));

        return response;
    }

    public async Task<AddBase64SubjectExampleResponse> AddAsync(AddBase64SubjectExampleRequest request)
    {
        var requestUrl = $"{_configuration.Domain}:{_configuration.Port}/api/v1/recognition/faces";
        var requestUrlWithQueryParameters = requestUrl
            .SetQueryParams(new
            {
                subject = request.Subject,
                det_prob_threshold = request.DetProbThreShold,
            });

        var response = await _apiClient.PostJsonAsync<AddBase64SubjectExampleResponse>(requestUrlWithQueryParameters, new { file = request.File });

        return response;
    }

    public async Task<ListAllSubjectExamplesResponse> ListAsync(ListAllSubjectExamplesRequest request)
    {
        var requestUrl = $"{_configuration.Domain}:{_configuration.Port}/api/v1/recognition/faces";
        var requestUrlWithQueryParameters = requestUrl
            .SetQueryParams(new
            {
                page = request.Page,
                size = request.Size,
                subject = request.Subject,
            });

        var response = await _apiClient.GetJsonAsync<ListAllSubjectExamplesResponse>(requestUrlWithQueryParameters);

        return response;
    }

    public async Task<DeleteAllExamplesResponse> DeleteAllAsync(DeleteAllExamplesRequest request)
    {
        var requestUrl = $"{_configuration.Domain}:{_configuration.Port}/api/v1/recognition/faces";
        var requestUrlWithQueryParameters = requestUrl
            .SetQueryParam("subject", request.Subject);

        var response = 
            await _apiClient.DeleteJsonAsync<DeleteAllExamplesResponse>(requestUrlWithQueryParameters);

        return response;
    }

    public async Task<DeleteImageByIdResponse> DeleteAsync(DeleteImageByIdRequest request)
    {
        var requestUrl = $"{_configuration.Domain}:{_configuration.Port}/api/v1/recognition/faces";
        var requestUrlWithQueryParameters = requestUrl
            .AppendPathSegment(request.ImageId.ToString());

        var response = await 
            _apiClient.DeleteJsonAsync<DeleteImageByIdResponse>(requestUrlWithQueryParameters);

        return response;
    }

    public async Task<DeleteMultipleExamplesResponse> DeleteAsync(DeleteMultipleExampleRequest deleteMultipleExamplesRequest)
    {
        var requestUrl = $"{_configuration.Domain}:{_configuration.Port}/api/v1/recognition/faces";
        var requestUrlWithQueryParameters = requestUrl
            .AppendPathSegment("delete");

        var response = await _apiClient.PostJsonAsync<List<Face>>(requestUrlWithQueryParameters, deleteMultipleExamplesRequest.ImageIdList);

        return new DeleteMultipleExamplesResponse() { Faces = response };
    }

    public async Task<byte[]> DownloadAsync(DownloadImageByIdRequest downloadImageByIdRequest)
    {
        var requestUrl = $"{_configuration.Domain}:{_configuration.Port}/api/v1/static";
        var requestUrlWithQueryParameters = requestUrl
            .AppendPathSegments(
                downloadImageByIdRequest.RecognitionApiKey.ToString(),
                "/images/",
                downloadImageByIdRequest.ImageId.ToString());

        var response = await _apiClient.GetBytesFromRemoteAsync(requestUrlWithQueryParameters);

        return response;
    }

    public async Task<byte[]> DownloadAsync(DownloadImageBySubjectIdRequest downloadImageBySubjectIdRequest)
    {
        var requestUrl = $"{_configuration.Domain}:{_configuration.Port}/api/v1/recognition/faces";
        var requestUrlWithQueryParameters = requestUrl
            .AppendPathSegments(downloadImageBySubjectIdRequest.ImageId.ToString(), "/img");

        var response = await _apiClient.GetBytesFromRemoteAsync(requestUrlWithQueryParameters);

        return response;
    }
}