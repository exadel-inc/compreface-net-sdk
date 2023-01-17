using Exadel.Compreface.Clients.Interfaces;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetection;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetectionBase64;
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

        public async Task<FaceDetectionResponse> FaceDetectionAsync(FaceDetectionRequest faceDetectionRequest)
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
                _apiClient.PostMultipartAsync<FaceDetectionResponse>(
                    requestUrl: requestUrlWithQueryParameters,
                    buildContent: mp =>
                        mp.AddFile("file", fileName: faceDetectionRequest.FileName, path: faceDetectionRequest.FilePath));

            return response;
        }

        public async Task<FaceDetectionBase64Response> FaceDetectionBase64Async(FaceDetectionBase64Request faceDetectionRequest)
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
                _apiClient.PostJsonAsync<FaceDetectionBase64Response>(
                    requestUrl: requestUrlWithQueryParameters, 
                    body: new { file = faceDetectionRequest.File });

            return response;
        }
    }
}
