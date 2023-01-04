using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddExampleSubject;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetection;
using Flurl;
using Flurl.Http;

namespace Exadel.Compreface.Services
{
    public class FaceDetectionService
    {
        private readonly IComprefaceConfiguration _configuration;

        public FaceDetectionService(ComprefaceConfiguration configuration)
        {
            _configuration= configuration;
        }

        public async Task<FaceDetectionResponse> FaceDetectionAsync(FaceDetectionRequest faceDetectionRequest)
        {
            var requestUrl = $"{_configuration.BaseUrl}detection/detect";

            var response = await requestUrl
                .SetQueryParams(new
                {
                    limit = faceDetectionRequest.Limit,
                    det_prob_threshold = faceDetectionRequest.DetProbThreshold,
                    face_plugins = string.Join(",", faceDetectionRequest.FacePlugins),
                    status = faceDetectionRequest.Status,
                })
                .PostMultipartAsync(mp =>
                    mp.AddFile("file", fileName: faceDetectionRequest.FileName, path: faceDetectionRequest.FilePath))
                .ReceiveJson<FaceDetectionResponse>();

            return response;
        }
    }
}
