using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddBase64ExampleSubject;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetection;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetectionBase64;
using Exadel.Compreface.Helpers;
using Flurl;
using Flurl.Http;

namespace Exadel.Compreface.Services
{
    public class FaceDetectionService : AbstractBaseService
    {
        public FaceDetectionService(IComprefaceConfiguration configuration)
            : base(configuration) { }

        public async Task<FaceDetectionResponse> DetectAsync(FaceDetectionRequest faceDetectionRequest, bool isFileInTheRemoteServer = false)
        {
            if (faceDetectionRequest.FacePlugins == null) throw new NullReferenceException();
            if (string.IsNullOrEmpty(faceDetectionRequest.FilePath)) throw new NullReferenceException();

            var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/detection/detect";
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

                response = await PostJsonAsync<FaceDetectionResponse>(requestUrlWithQueryParameters, body: addBase64SubjectExampleRequest);

                return response;
            }

            response = await
                PostMultipartAsync<FaceDetectionResponse>(
                    requestUrl: requestUrlWithQueryParameters,
                    buildContent: mp =>
                        mp.AddFile("file", fileName: FileHelpers.GenerateFileName(faceDetectionRequest.FilePath), path: faceDetectionRequest.FilePath));

            return response;
        }

        public async Task<FaceDetectionResponse> DetectAsync(FaceDetectionBase64Request faceDetectionRequest)
        {
            if (faceDetectionRequest.FacePlugins == null) throw new NullReferenceException();

            var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/detection/detect";
            var requestUrlWithQueryParameters = requestUrl
                .SetQueryParams(new
                {
                    limit = faceDetectionRequest.Limit,
                    det_prob_threshold = faceDetectionRequest.DetProbThreshold,
                    face_plugins = string.Join(",", faceDetectionRequest.FacePlugins),
                    status = faceDetectionRequest.Status,
                });

            var response = await 
                PostJsonAsync<FaceDetectionResponse>(
                    requestUrl: requestUrlWithQueryParameters, 
                    body: new { file = faceDetectionRequest.File });

            return response;
        }
    }
}