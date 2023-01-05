using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFaceFromImage;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFacesFromImageWithBase64;
using Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImage;
using Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImageWithBase64;
using Flurl;
using Flurl.Http;

namespace Exadel.Compreface.Services;

public class RecognitionService
{
    private readonly ComprefaceConfiguration _configuration;

    public RecognitionService(ComprefaceConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public async Task<RecognizeFaceFromImageResponse> RecognizeFaceFromImage(RecognizeFaceFromImageRequest request)
    {
        var requestUrl = $"{_configuration.BaseUrl}recognition/recognize";

        var response = await requestUrl
            .SetQueryParams(new
            {
                limit = request.Limit,
                prediction_count = request.PredictionCount,
                det_prob_threshold = request.DetProbThreshold,
                face_plugins = string.Join(",", request.FacePlugins),
                status = request.Status,
            })
            .PostMultipartAsync<RecognizeFaceFromImageResponse>(mp =>
                mp.AddFile("file", fileName: request.FileName, path: request.FilePath));

        return response;
    }

    public async Task<RecognizeFaceFromImageResponse> RecognizeFaceFromBase64File(
        RecognizeFacesFromImageWithBase64Request request)
    {
        var requestUrl = $"{_configuration.BaseUrl}recognition/recognize";

        var response = await requestUrl
            .SetQueryParams(new
            {
                limit = request.Limit,
                prediction_count = request.PredictionCount,
                det_prob_threshold = request.DetProbThreshold,
                face_plugins = string.Join(",", request.FacePlugins),
                status = request.Status,
            })
            .PostJsonAsync<RecognizeFaceFromImageResponse>(body: new { file = request.FileBase64Value });

        return response;
    }

    public async Task<VerifyFacesFromImageResponse> VerifyFacesFromImage(VerifyFacesFromImageRequest request)
    {
        var requestUrl = $"{_configuration.BaseUrl}recognition/faces/{request.ImageId}/verify";

        var response = await requestUrl
            .SetQueryParams(new
            {
                limit = request.Limit,
                det_prob_threshold = request.DetProbThreshold,
                face_plugins = string.Join(",", request.FacePlugins),
                status = request.Status,
            })
            .PostMultipartAsync<VerifyFacesFromImageResponse>(mp =>
                mp.AddFile("file", fileName: request.FileName, path: request.FilePath));

        return response;
    }
    
    public async Task<VerifyFacesFromImageResponse> VerifyFacesFromBase64File(VerifyFacesFromImageWithBase64Request request)
    {
        var requestUrl = $"{_configuration.BaseUrl}recognition/faces/{request.ImageId}/verify";

        var response = await requestUrl
            .SetQueryParams(new
            {
                limit = request.Limit,
                det_prob_threshold = request.DetProbThreshold,
                face_plugins = string.Join(",", request.FacePlugins),
                status = request.Status,
            })
            .PostJsonAsync<VerifyFacesFromImageResponse>(body: new { file = request.FileBase64Value });

        return response;
    }
}