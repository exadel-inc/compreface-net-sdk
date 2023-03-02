using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerification;
using Exadel.Compreface.DTOs.FaceVerificationDTOs;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerificationWithBase64;

namespace Exadel.Compreface.Services.Interfaces
{
    public interface IVerificationService
    {
        Task<FaceVerificationResponse> VerifyAsync(FaceVerificationRequestByFilePath request);

        Task<FaceVerificationResponse> VerifyAsync(FaceVerificationRequestByFileUrl request);

        Task<FaceVerificationResponse> VerifyAsync(FaceVerificationRequestByBytes request);

        Task<FaceVerificationResponse> VerifyAsync(FaceVerificationWithBase64Request request);
    }
}