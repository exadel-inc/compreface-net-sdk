using Exadel.Compreface.DTOs.FaceVerificationDTOs;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerification;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerificationWithBase64;

namespace Exadel.Compreface.Services.Interfaces
{
    public interface IFaceVerificationService
    {
        Task<FaceVerificationResponse> VerifyAsync(FaceVerificationRequest request, bool isFileInTheRemoteServer = false);
        Task<FaceVerificationResponse> VerifyAsync(FaceVerificationWithBase64Request request);
    }
}