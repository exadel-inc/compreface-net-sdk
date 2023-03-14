using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerification;

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