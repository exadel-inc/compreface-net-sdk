using Exadel.Compreface.Clients.Interfaces;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddBase64ExampleSubject;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetection;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetectionBase64;
using Exadel.Compreface.Helpers;
using Flurl;
using Flurl.Http;

namespace Exadel.Compreface.Services
{
    public class FaceDetectionService
    {
        private readonly IComprefaceConfiguration _configuration;
        private readonly IApiClient _apiClient;

        public FaceDetectionService(ComprefaceConfiguration configuration, IApiClient apiClient)
        {
            _configuration= configuration;
            _apiClient = apiClient;
        }
        public async Task<FaceDetectionResponse> FaceDetectionAsync(FaceDetectionRequest faceDetectionRequest, bool isFileInTheRemoteServer = false)
        {
            var requestUrl = $"{_configuration.Domain}:{_configuration.Port}/api/v1/detection/detect";
            var requestUrlWithQueryParameters = requestUrl
                .SetQueryParams(new
                {
                    limit = faceDetectionRequest.Limit,
                    det_prob_threshold = faceDetectionRequest.DetProbThreshold,
                    face_plugins = string.Join(",", faceDetectionRequest.FacePlugins),
                    status = faceDetectionRequest.Status,
                });
            FaceDetectionResponse? response = null;

            if (isFileInTheRemoteServer)
            {
                var fileStream = await faceDetectionRequest.FilePath.GetBytesAsync();
                var fileInBase64String = Convert.ToBase64String(fileStream);

                var addBase64SubjectExampleRequest = new AddBase64SubjectExampleRequest()
                {
                    DetProbThreShold = faceDetectionRequest.DetProbThreshold,
                    File = fileInBase64String,
                };

                response = await _apiClient.PostJsonAsync<FaceDetectionResponse>(requestUrlWithQueryParameters, body: addBase64SubjectExampleRequest);

                return response;
            }

            response = await
                _apiClient.PostMultipartAsync<FaceDetectionResponse>(
                    requestUrl: requestUrlWithQueryParameters,
                    buildContent: mp =>
                        mp.AddFile("file", fileName: FileHelpers.GenerateFileName(faceDetectionRequest.FilePath), path: faceDetectionRequest.FilePath));

            return response;
        }

        public async Task<FaceDetectionResponse> FaceDetectionBase64Async(FaceDetectionBase64Request faceDetectionRequest)
        {
            var requestUrl = $"{_configuration.Domain}:{_configuration.Port}/api/v1/detection/detect";
            var requestUrlWithQueryParameters = requestUrl
                .SetQueryParams(new
                {
                    limit = faceDetectionRequest.Limit,
                    det_prob_threshold = faceDetectionRequest.DetProbThreshold,
                    face_plugins = string.Join(",", faceDetectionRequest.FacePlugins),
                    status = faceDetectionRequest.Status,
                });

            var response = await 
                _apiClient.PostJsonAsync<FaceDetectionResponse>(
                    requestUrl: requestUrlWithQueryParameters, 
                    body: new { file = faceDetectionRequest.File });

            return response;
        }
    }
}