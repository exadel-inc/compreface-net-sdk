using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddBase64ExampleSubject;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetection;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFaceFromImage;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFacesFromImageWithBase64;
using Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImage;
using Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImageWithBase64;
using Exadel.Compreface.Helpers;
using Flurl;
using Flurl.Http;

namespace Exadel.Compreface.Services;

public class RecognitionService : AbstractBaseService
{
    public RecognitionService(IComprefaceConfiguration configuration)
            : base(configuration) { }

    public async Task<RecognizeFaceFromImageResponse> RecognizeAsync(RecognizeFaceFromImageRequest request, bool isFileInTheRemoteServer = false)
    {
        if (request.FacePlugins == null) throw new NullReferenceException();
        if (string.IsNullOrEmpty(request.FilePath)) throw new NullReferenceException();

        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/recognition/recognize";
        var requestUrlWithQueryParameters = requestUrl
            .SetQueryParams(new
            {
                limit = request.Limit,
                prediction_count = request.PredictionCount,
                det_prob_threshold = request.DetProbThreshold,
                face_plugins = string.Join(",", request.FacePlugins),
                status = request.Status,
            });

        RecognizeFaceFromImageResponse? response = null;

        if (isFileInTheRemoteServer)
        {
            var fileStream = await request.FilePath.GetBytesAsync();
            var fileInBase64String = Convert.ToBase64String(fileStream);

            var addBase64SubjectExampleRequest = new AddBase64SubjectExampleRequest()
            {
                DetProbThreShold = request.DetProbThreshold,
                File = fileInBase64String,
            };

            response = await PostJsonAsync<RecognizeFaceFromImageResponse>(requestUrlWithQueryParameters, body: addBase64SubjectExampleRequest);

            return response;
        }

        response = await
            PostMultipartAsync<RecognizeFaceFromImageResponse>(
                requestUrl: requestUrlWithQueryParameters,
                buildContent: mp =>
                mp.AddFile("file", fileName: FileHelpers.GenerateFileName(request.FilePath), path: request.FilePath));

        return response;
    }

    public async Task<RecognizeFaceFromImageResponse> RecognizeAsync(
        RecognizeFacesFromImageWithBase64Request request)
    {
        if (request.FacePlugins == null) throw new NullReferenceException();

        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/recognition/recognize";
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
            PostJsonAsync<RecognizeFaceFromImageResponse>(
                requestUrl: requestUrlWithQueryParameters, 
                body: new { file = request.FileBase64Value });

        return response;
    }

    public async Task<VerifyFacesFromImageResponse> VerifyAsync(VerifyFacesFromImageRequest request)
    {
        if (request.FacePlugins == null) throw new NullReferenceException();

        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/recognition/faces/{request.ImageId}/verify";
        var requestUrlWithQueryParameters = requestUrl
            .SetQueryParams(new
            {
                limit = request.Limit,
                det_prob_threshold = request.DetProbThreshold,
                face_plugins = string.Join(",", request.FacePlugins),
                status = request.Status,
            });

        if (request.FilePath == null) throw new NullReferenceException();

        var response = await 
            PostMultipartAsync<VerifyFacesFromImageResponse>(
                requestUrl: requestUrlWithQueryParameters,
                buildContent: mp =>
                mp.AddFile("file", fileName: FileHelpers.GenerateFileName(request.FilePath), path: request.FilePath));

        return response;
    }
    
    public async Task<VerifyFacesFromImageResponse> VerifyAsync(VerifyFacesFromImageWithBase64Request request)
    {
        if (request.FacePlugins == null) throw new NullReferenceException();

        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/recognition/faces/{request.ImageId}/verify";
        var requestUrlWithQueryParameters = requestUrl
            .SetQueryParams(new
            {
                limit = request.Limit,
                det_prob_threshold = request.DetProbThreshold,
                face_plugins = string.Join(",", request.FacePlugins),
                status = request.Status,
            });

        var response = await 
            PostJsonAsync<VerifyFacesFromImageResponse>(
                requestUrl: requestUrlWithQueryParameters,
                body: new { file = request.FileBase64Value });

        return response;
    }
}