using Exadel.Compreface.Clients.ApiClient;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddBase64ExampleSubject;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFaceFromImage;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFacesFromImageWithBase64;
using Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImage;
using Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImageWithBase64;
using Exadel.Compreface.DTOs.RecognizeFaceFromImageDTOs.VerifyFacesFromImage;
using Exadel.Compreface.Helpers;
using Exadel.Compreface.Services.Interfaces;
using Flurl;
using Flurl.Http;

namespace Exadel.Compreface.Services.RecognitionService
{
    public class RecognizeFaceFromImage : IRecognizeFaceFromImage
    {
        private readonly IComprefaceConfiguration _configuration;
        private readonly IApiClient _apiClient;

        public RecognizeFaceFromImage(IComprefaceConfiguration configuration, IApiClient apiClient)
        {
            _configuration = configuration;
            _apiClient = apiClient;
        }

        public async Task<RecognizeFaceFromImageResponse> RecognizeAsync(RecognizeFaceFromImageRequestByFilePath request)
        {
            var requestUrl = $"{_configuration.Domain}:{_configuration.Port}/api/v1/recognition/recognize";
            var requestUrlWithQueryParameters = requestUrl
                .SetQueryParams(new
                {
                    limit = request.Limit,
                    prediction_count = request.PredictionCount,
                    det_prob_threshold = request.DetProbThreshold,
                    face_plugins = string.Join(",", request.FacePlugins),
                    status = request.Status,
                });

            var response = await
                _apiClient.PostMultipartAsync<RecognizeFaceFromImageResponse>(
                    requestUrl: requestUrlWithQueryParameters,
                    buildContent: mp =>
                    mp.AddFile("file", fileName: FileHelpers.GenerateFileName(request.FilePath), path: request.FilePath));

            return response;
        }

        public async Task<RecognizeFaceFromImageResponse> RecognizeAsync(RecognizeFaceFromImageRequestByFileUrl request)
        {
            var requestUrl = $"{_configuration.Domain}:{_configuration.Port}/api/v1/recognition/recognize";
            var requestUrlWithQueryParameters = requestUrl
                .SetQueryParams(new
                {
                    limit = request.Limit,
                    prediction_count = request.PredictionCount,
                    det_prob_threshold = request.DetProbThreshold,
                    face_plugins = string.Join(",", request.FacePlugins),
                    status = request.Status,
                });

            var fileInBase64String = ConvertUrlToBase64StringHelpers.ConvertUrlAsync(_apiClient, request.FileUrl).Result;

            var addBase64SubjectExampleRequest = new AddBase64SubjectExampleRequest()
            {
               DetProbThreShold = request.DetProbThreshold,
               File = fileInBase64String,
            };

            var response = await _apiClient.PostJsonAsync<RecognizeFaceFromImageResponse>(requestUrlWithQueryParameters, body: addBase64SubjectExampleRequest );

            return response;
        }

        public async Task<RecognizeFaceFromImageResponse> RecognizeAsync(RecognizeFacesFromImageWithBase64Request request)
        {
            var requestUrl = $"{_configuration.Domain}:{_configuration.Port}/api/v1/recognition/recognize";
            var requestUrlWithQueryParameters = requestUrl
                .SetQueryParams(new
                {
                    limit = request.Limit,
                    prediction_count = request.PredictionCount,
                    det_prob_threshold = request.DetProbThreshold,
                    face_plugins = string.Join(",", request.FacePlugins),
                    status = request.Status,
                });

            var response = await
                _apiClient.PostJsonAsync<RecognizeFaceFromImageResponse>(
                    requestUrl: requestUrlWithQueryParameters,
                    body: new { file = request.FileBase64Value });

            return response;
        }

        public async Task<VerifyFacesFromImageResponse> VerifyAsync(VerifyFacesFromImageByFilePathRequest request)
        {
            var requestUrl = $"{_configuration.Domain}:{_configuration.Port}/api/v1/recognition/faces/{request.ImageId}/verify";
            var requestUrlWithQueryParameters = requestUrl
                .SetQueryParams(new
                {
                    limit = request.Limit,
                    det_prob_threshold = request.DetProbThreshold,
                    face_plugins = string.Join(",", request.FacePlugins),
                    status = request.Status,
                });

            var response = await
                _apiClient.PostMultipartAsync<VerifyFacesFromImageResponse>(
                    requestUrl: requestUrlWithQueryParameters,
                    buildContent: mp =>
                    mp.AddFile("file", fileName: FileHelpers.GenerateFileName(request.FilePath), path: request.FilePath));

            return response;
        }

        public async Task<VerifyFacesFromImageResponse> VerifyAsync(VerifyFacesFromImageWithBase64Request request)
        {
            var requestUrl = $"{_configuration.Domain}:{_configuration.Port}/api/v1/recognition/faces/{request.ImageId}/verify";
            var requestUrlWithQueryParameters = requestUrl
                .SetQueryParams(new
                {
                    limit = request.Limit,
                    det_prob_threshold = request.DetProbThreshold,
                    face_plugins = string.Join(",", request.FacePlugins),
                    status = request.Status,
                });

            var response = await
                _apiClient.PostJsonAsync<VerifyFacesFromImageResponse>(
                    requestUrl: requestUrlWithQueryParameters,
                    body: new { file = request.FileBase64Value });

            return response;
        }

        public async Task<VerifyFacesFromImageResponse> VerifyAsync(VerifyFacesFromImageByFileUrlRequest request)
        {
            var requestUrl = $"{_configuration.Domain}:{_configuration.Port}/api/v1/recognition/faces/{request.ImageId}/verify";
            var requestUrlWithQueryParameters = requestUrl
                .SetQueryParams(new
                {
                    limit = request.Limit,
                    det_prob_threshold = request.DetProbThreshold,
                    face_plugins = string.Join(",", request.FacePlugins),
                    status = request.Status,
                });

            var fileInBase64String = await ConvertUrlToBase64StringHelpers.ConvertUrlAsync(_apiClient, request.FileUrl);

            var response = await
                _apiClient.PostJsonAsync<VerifyFacesFromImageResponse>(
                    requestUrl: requestUrlWithQueryParameters,
                    body: new { file = fileInBase64String });

            return response;
        }
    }
}