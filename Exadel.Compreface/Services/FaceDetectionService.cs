using Exadel.Compreface.Clients.ApiClient;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddBase64ExampleSubject;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetection;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetectionBase64;
using Exadel.Compreface.DTOs.HelperDTOs.BaseDTOs;
using Exadel.Compreface.Helpers;
using Exadel.Compreface.Services.Attributes;
using Flurl;
using Flurl.Http;

namespace Exadel.Compreface.Services
{
    [CompreFaceService]
    public class FaceDetectionService 
    {
        private readonly IComprefaceConfiguration _configuration;
        private readonly IApiClient _apiClient;

        public FaceDetectionService(IComprefaceConfiguration configuration)
        {
            _configuration = configuration;
            _apiClient = new ApiClient(configuration);
        }

        public async Task<FaceDetectionResponse> DetectAsync(FaceDetectionRequestByFileRath faceDetectionRequest)
        {
            var requestUrlWithQueryParameters = GetRequestUrl(faceDetectionRequest);
            var response = await
                _apiClient.PostMultipartAsync<FaceDetectionResponse>(
                    requestUrl: requestUrlWithQueryParameters,
                    buildContent: mp =>
                        mp.AddFile("file", fileName: FileHelpers.GenerateFileName(faceDetectionRequest.FilePath), path: faceDetectionRequest.FilePath));

            return response;
        }
        public async Task<FaceDetectionResponse> DetectAsync(FaceDetectionRequestByFileUrl faceDetectionRequest)
        {
            var requestUrlWithQueryParameters = GetRequestUrl(faceDetectionRequest);

            var fileStream = await faceDetectionRequest.FileUrl.GetBytesAsync();
            var fileInBase64String = Convert.ToBase64String(fileStream);

            var addBase64SubjectExampleRequest = new AddBase64SubjectExampleRequest()
            {
                DetProbThreShold = faceDetectionRequest.DetProbThreshold,
                File = fileInBase64String,
            };

            var response = await _apiClient.PostJsonAsync<FaceDetectionResponse>(requestUrlWithQueryParameters, body: addBase64SubjectExampleRequest);

            return response;
        }

        public async Task<FaceDetectionResponse> DetectAsync(FaceDetectionBase64Request faceDetectionRequest)
        {
            var requestUrlWithQueryParameters = GetRequestUrl(faceDetectionRequest);
           
            var response = await
                _apiClient.PostJsonAsync<FaceDetectionResponse>(
                    requestUrl: requestUrlWithQueryParameters, 
                    body: new { file = faceDetectionRequest.File });

            return response;
        }

        private Url GetRequestUrl(BaseFaceRequest baseFaceRequest)
        {
            var requestUrl = $"{_configuration.Domain}:{_configuration.Port}/api/v1/detection/detect";
            return requestUrl
                .SetQueryParams(new
                {
                    limit = baseFaceRequest.Limit,
                    det_prob_threshold = baseFaceRequest.DetProbThreshold,
                    face_plugins = string.Join(",", baseFaceRequest.FacePlugins),
                    status = baseFaceRequest.Status,
                });
        }
    }
}