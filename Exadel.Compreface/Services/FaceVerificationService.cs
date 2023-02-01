using Exadel.Compreface.Clients.Config;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.FaceVerificationDTOs;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerification;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerificationWithBase64;
using Exadel.Compreface.Helpers;
using Flurl;
using Flurl.Http;

namespace Exadel.Compreface.Services;

public class FaceVerificationService : IService
{
    private readonly IService _iService;

    public IComprefaceConfiguration Configuration { get; }

    public FaceVerificationService(IComprefaceConfiguration configuration)
    {
        _iService = this;

        Configuration = configuration;

        ConfigInitializer.InitializeSnakeCaseJsonConfigs();
    }

    public async Task<FaceVerificationResponse> VerifyImageAsync(FaceVerificationRequest request, bool isFileInTheRemoteServer = false)
    {
        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/verification/verify";
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
           
            response = await _iService.PostJsonAsync<FaceVerificationResponse>(requestUrlWithQueryParameters, body: new
            {
                source_image = fileSourceImagInBase64String,
                target_image = fileTargetImagegInBase64Strin
            });

            return response;
        }

        response = await
            _iService.PostMultipartAsync<FaceVerificationResponse>(
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

    public async Task<FaceVerificationResponse> VerifyBase64ImageAsync(FaceVerificationWithBase64Request request)
    {
        var requestUrl = $"{Configuration.Domain}:{Configuration.Port}/api/v1/verification/verify";
        var requestUrlWithQueryParameters = requestUrl
            .SetQueryParams(new
            {
                limit = request.Limit,
                det_prob_threshold = request.DetProbThreshold,
                face_plugins = string.Join(",", request.FacePlugins),
                status = request.Status,
            });

        var response = await 
            _iService.PostJsonAsync<FaceVerificationResponse>(
                requestUrl: requestUrlWithQueryParameters,
                body: new
                {
                    source_image = request.SourceImageWithBase64,
                    target_image = request.TargetImageWithBase64,
                });

        return response;
    }
}