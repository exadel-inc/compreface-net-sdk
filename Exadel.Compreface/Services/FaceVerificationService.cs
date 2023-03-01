using Exadel.Compreface.Clients.ApiClient;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.FaceVerificationDTOs;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerification;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerificationWithBase64;
using Exadel.Compreface.DTOs.HelperDTOs.BaseDTOs;
using Exadel.Compreface.Helpers;
using Exadel.Compreface.Services.Attributes;
using Exadel.Compreface.Services.Interfaces;
using Flurl;
using Flurl.Http;

namespace Exadel.Compreface.Services;

[CompreFaceService]
public class FaceVerificationService : IFaceVerificationService
{
    private readonly IComprefaceConfiguration _configuration;
    private readonly IApiClient _apiClient;

    public FaceVerificationService(IComprefaceConfiguration configuration, IApiClient apiClient)
    {
        _configuration = configuration;
        _apiClient = apiClient;
    }

    public async Task<FaceVerificationResponse> VerifyAsync(FaceVerificationRequestByFilePath request)
    {
        var requestUrlWithQueryParameters = GetRequestUrl(request);

        var response = await
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

    public async Task<FaceVerificationResponse> VerifyAsync(FaceVerificationRequestByFileUrl request)
    {
        var requestUrlWithQueryParameters = GetRequestUrl(request);

        var fileSourceImagInBase64String = await ConvertUrlToBase64StringHelpers.ConvertUrlAsync(_apiClient, request.SourceImageFileUrl);
        var fileTargetImagegInBase64Strin = await ConvertUrlToBase64StringHelpers.ConvertUrlAsync(_apiClient, request.TargetImageFileUrl);

        var response = await _apiClient.PostJsonAsync<FaceVerificationResponse>(requestUrlWithQueryParameters,
            body: new
            {
                source_image = fileSourceImagInBase64String,
                target_image = fileTargetImagegInBase64Strin
            });

        return response;
    }

    public async Task<FaceVerificationResponse> VerifyAsync(FaceVerificationRequestByBytes request)
    {
        var requestUrlWithQueryParameters = GetRequestUrl(request);

        var fileSourceImagInBase64String = Convert.ToBase64String(request.SourceImageInBytes);
        var fileTargetImagegInBase64Strin = Convert.ToBase64String(request.TargetImageInBytes);

        var response = await _apiClient.PostJsonAsync<FaceVerificationResponse>(requestUrlWithQueryParameters,
            body: new
            {
                source_image = fileSourceImagInBase64String,
                target_image = fileTargetImagegInBase64Strin
            });

        return response;
    }

    public async Task<FaceVerificationResponse> VerifyAsync(FaceVerificationWithBase64Request request)
    {
        var requestUrlWithQueryParameters = GetRequestUrl(request);

        var response = await _apiClient.PostJsonAsync<FaceVerificationResponse>(requestUrl: requestUrlWithQueryParameters,
                body: new
                {
                    source_image = request.SourceImageWithBase64,
                    target_image = request.TargetImageWithBase64,
                });

        return response;
    }

    private Url GetRequestUrl(BaseFaceRequest baseFaceRequest)
    {
        var requestUrl = $"{_configuration.Domain}:{_configuration.Port}/api/v1/verification/verify";

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