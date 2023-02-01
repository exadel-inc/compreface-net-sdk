﻿using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddExampleSubject;
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
using Exadel.Compreface.Clients.Config;

namespace Exadel.Compreface.Services;

public class SubjectExampleService : IService
{
    private readonly IService _iService;

    public IComprefaceConfiguration Configuration { get; }

    public SubjectExampleService(IComprefaceConfiguration configuration)
    {
        _iService = this;

        Configuration = configuration;

        ConfigInitializer.InitializeSnakeCaseJsonConfigs();
    }

    public async Task<AddSubjectExampleResponse> AddSubjectExampleAsync(AddSubjectExampleRequest request, bool isFileInTheRemoteServer = false)
    {
        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/recognition/faces";
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

            response = await _iService.PostJsonAsync<AddSubjectExampleResponse>(requestUrlWithQueryParameters, body: addBase64SubjectExampleRequest);
            return response;
        }

        response = await _iService.PostMultipartAsync<AddSubjectExampleResponse>(
            requestUrl: requestUrlWithQueryParameters,
            buildContent: mp =>
                mp.AddFile("file", fileName: FileHelpers.GenerateFileName(request.File), path: request.File));

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

        var response = await _iService.PostJsonAsync<AddBase64SubjectExampleResponse>(requestUrlWithQueryParameters, new { file = request.File });

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

        var response = await _iService.GetJsonAsync<ListAllSubjectExamplesResponse>(requestUrlWithQueryParameters);

        return response;
    }

    public async Task<DeleteAllExamplesResponse> ClearSubjectAsync(DeleteAllExamplesRequest request)
    {
        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/recognition/faces";
        var requestUrlWithQueryParameters = requestUrl
            .SetQueryParam("subject", request.Subject);

        var response = 
            await _iService.DeleteJsonAsync<DeleteAllExamplesResponse>(requestUrlWithQueryParameters);

        return response;
    }

    public async Task<DeleteImageByIdResponse> DeleteImageByIdAsync(DeleteImageByIdRequest request)
    {
        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/recognition/faces";
        var requestUrlWithQueryParameters = requestUrl
            .AppendPathSegment(request.ImageId.ToString());

        var response = await 
            _iService.DeleteJsonAsync<DeleteImageByIdResponse>(requestUrlWithQueryParameters);

        return response;
    }

    public async Task<DeleteMultipleExamplesResponse> DeletMultipleExamplesAsync(DeleteMultipleExampleRequest deleteMultipleExamplesRequest)
    {
        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/recognition/faces";
        var requestUrlWithQueryParameters = requestUrl
            .AppendPathSegment("delete");

        var response = await _iService.PostJsonAsync<List<Face>>(requestUrlWithQueryParameters, deleteMultipleExamplesRequest.ImageIdList);

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

        var response = await _iService.GetBytesFromRemoteAsync(requestUrlWithQueryParameters);

        return response;
    }

    public async Task<byte[]> DownloadImageBySubjectIdAsync(DownloadImageBySubjectIdRequest downloadImageBySubjectIdRequest)
    {
        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/recognition/faces";
        var requestUrlWithQueryParameters = requestUrl
            .AppendPathSegments(downloadImageBySubjectIdRequest.ImageId.ToString(), "/img");

        var response = await _iService.GetBytesFromRemoteAsync(requestUrlWithQueryParameters);

        return response;
    }
}