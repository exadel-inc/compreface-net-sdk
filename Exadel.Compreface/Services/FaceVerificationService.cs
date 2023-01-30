using Exadel.Compreface.Clients.Interfaces;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.FaceVerificationDTOs;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerification;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerificationWithBase64;
using Exadel.Compreface.Helpers;
using Flurl;
using Flurl.Http;

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

    public async Task<FaceVerificationResponse> VerifyAsync(FaceVerificationRequest request)
    {
        var requestUrl = $"{_comprefaceConfiguration.Domain}:{_comprefaceConfiguration.Port}/api/v1/verification/verify";
        var requestUrlWithQueryParameters = requestUrl
            .SetQueryParams(new
            {
                limit = request.Limit,
                det_prob_threshold = request.DetProbThreshold,
                face_plugins = string.Join(",", request.FacePlugins),
                status = request.Status,
            });

        FaceVerificationResponse? response = null;

        if (isFileInTheRemoteServer)
        {
            var fileSourceImageStream = await request.SourceImageFilePath.GetBytesAsync();
            var fileSourceImagInBase64String = Convert.ToBase64String(fileSourceImageStream);

            var fileTargetImageStream = await request.TargetImageFilePath.GetBytesAsync();
            var fileTargetImagegInBase64Strin = Convert.ToBase64String(fileTargetImageStream);
           
            response = await _apiClient.PostJsonAsync<FaceVerificationResponse>(requestUrlWithQueryParameters, body: new
            {
                source_image = fileSourceImagInBase64String,
                target_image = fileTargetImagegInBase64Strin
            });

            return response;
        }

        response = await
            _apiClient.PostMultipartAsync<FaceVerificationResponse>(
                requestUrl: requestUrlWithQueryParameters,
                buildContent: mp =>
                {
                    mp.AddFile(name: "source_image", fileName: FileHelpers.GenerateFileName(request.SourceImageFilePath),
                        path: request.SourceImageFilePath);
                    mp.AddFile(name: "target_image", fileName: FileHelpers.GenerateFileName(request.TargetImageFilePath),
                        path: request.TargetImageFilePath);
                }
            );

        return response;
    }
    
    public async Task<FaceVerificationResponse> VerifyAsync(FaceVerificationWithBase64Request request)
    {
        var requestUrl = $"{_comprefaceConfiguration.Domain}:{_comprefaceConfiguration.Port}/api/v1/verification/verify";
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