using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.FaceVerificationDTOs;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerification;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerificationWithBase64;
using Flurl;

namespace Exadel.Compreface.Services;

public class FaceVerificationService
{
    private readonly IComprefaceConfiguration _comprefaceConfiguration;
    private readonly IApiClient _apiClient;

    public FaceVerificationService(IComprefaceConfiguration configuration, IApiClient apiClient)
    {
        _comprefaceConfiguration = configuration;
        _apiClient = apiClient;
    }

    public async Task<FaceVerificationResponse> VerifyImageAsync(FaceVerificationRequest request)
    {
        var requestUrl = $"{_comprefaceConfiguration.BaseUrl}verification/verify";
        var requestUrlWithQueryParameters = requestUrl
            .SetQueryParams(new
            {
                limit = request.Limit,
                det_prob_threshold = request.DetProbThreshold,
                face_plugins = string.Join(",", request.FacePlugins),
                status = request.Status,
            });
        
        var response = await 
            _apiClient.PostMultipartAsync<FaceVerificationResponse>(
                requestUrl: requestUrlWithQueryParameters,
                buildContent: mp =>
                {
                    mp.AddFile(name: "source_image", fileName: request.SourceImageFileName,
                        path: request.SourceImageFilePath);
                    mp.AddFile(name: "target_image", fileName: request.TargetImageFileName,
                        path: request.TargetImageFilePath);
                }
            );

        return response;
    }
    
    public async Task<FaceVerificationResponse> VerifyBase64ImageAsync(FaceVerificationWithBase64Request request)
    {
        var requestUrl = $"{_comprefaceConfiguration.BaseUrl}verification/verify";
        var requestUrlWithQueryParameters = requestUrl
            .SetQueryParams(new
            {
                limit = request.Limit,
                det_prob_threshold = request.DetProbThreshold,
                face_plugins = string.Join(",", request.FacePlugins),
                status = request.Status,
            });
        
        var response = await 
            _apiClient.PostJsonAsync<FaceVerificationResponse>(
                requestUrl: requestUrlWithQueryParameters,
                body: new
                {
                    source_image = request.SourceImageWithBase64,
                    target_image = request.TargetImageWithBase64,
                });

        return response;
    }
}