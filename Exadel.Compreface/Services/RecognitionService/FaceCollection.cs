﻿using Exadel.Compreface.Clients.ApiClient;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.AddSubjectExample;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.DeleteAllSubjectExamples;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.DeleteImageById;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.DeleteMultipleExamples;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.DownloadImageById;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.DownloadImageByIdFromSubject;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.ListAllExampleSubject;
using Exadel.Compreface.DTOs.HelperDTOs;
using Exadel.Compreface.DTOs.HelperDTOs.BaseDTOs;
using Exadel.Compreface.Helpers;
using Exadel.Compreface.Services.Interfaces;
using Flurl;
using Flurl.Http;

namespace Exadel.Compreface.Services.RecognitionService
{
    public class FaceCollection : IFaceCollection
    {
        private readonly IComprefaceConfiguration _configuration;
        private readonly IApiClient _apiClient;

        public FaceCollection(IComprefaceConfiguration configuration, IApiClient apiClient)
        {
            _configuration = configuration;
            _apiClient = apiClient;
        }

        public async Task<AddSubjectExampleResponse> AddAsync(AddSubjectExampleRequestByFilePath request)
        {
            var requestUrlWithQueryParameters = GetRequestUrl(request);

            var response = await _apiClient.PostMultipartAsync<AddSubjectExampleResponse>(
               requestUrl: requestUrlWithQueryParameters,
               buildContent: mp =>
                   mp.AddFile("file", fileName: FileHelpers.GenerateFileName(request.FilePath), path: request.FilePath));

            return response;
        }

        public async Task<AddSubjectExampleResponse> AddAsync(AddSubjectExampleRequestByFileUrl request)
        {
            var requestUrlWithQueryParameters = GetRequestUrl(request);

            var fileInBase64String = await ConvertUrlToBase64StringHelpers.ConvertUrlAsync(_apiClient, request.FileUrl);

            var response = await _apiClient.PostJsonAsync<AddSubjectExampleResponse>(requestUrlWithQueryParameters, body: new { file = fileInBase64String });
           
            return response;
        }

        public async Task<AddSubjectExampleResponse> AddAsync(AddSubjectExampleRequestByBytes request)
        {
            var requestUrlWithQueryParameters = GetRequestUrl(request);

            var fileInBase64String = Convert.ToBase64String(request.ImageInBytes);

            var response = await _apiClient.PostJsonAsync<AddSubjectExampleResponse>(requestUrlWithQueryParameters, body: new { file = fileInBase64String });

            return response;
        }

        public async Task<AddSubjectExampleResponse> AddAsync(AddBase64SubjectExampleRequest request)
        {
            var requestUrlWithQueryParameters = GetRequestUrl(request);

            var response = await _apiClient.PostJsonAsync<AddSubjectExampleResponse>(requestUrlWithQueryParameters, new { file = request.File });
            
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

        public async Task<byte[]> DownloadAsync(DownloadImageByIdDirectlyRequest downloadImageByIdRequest)
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

        public async Task<byte[]> DownloadAsync(DownloadImageByIdFromSubjectRequest downloadImageBySubjectIdRequest)
        {
            var requestUrl = $"{_configuration.Domain}:{_configuration.Port}/api/v1/recognition/faces";
            var requestUrlWithQueryParameters = requestUrl
                .AppendPathSegments(downloadImageBySubjectIdRequest.ImageId.ToString(), "/img");

            var response = await _apiClient.GetBytesFromRemoteAsync(requestUrlWithQueryParameters);
           
            return response;
        }

        private Url GetRequestUrl(BaseExampleRequest request)
        {
            var requestUrl = $"{_configuration.Domain}:{_configuration.Port}/api/v1/recognition/faces";

            return requestUrl
               .SetQueryParams(new
               {
                   subject = request.Subject,
                   det_prob_threshold = request.DetProbThreShold,
               });
        }
    }
}