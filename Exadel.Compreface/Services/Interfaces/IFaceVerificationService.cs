using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerification;
using Exadel.Compreface.DTOs.FaceVerificationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerificationWithBase64;

namespace Exadel.Compreface.Services.Interfaces
{
    public interface IFaceVerificationService
    {
        Task<FaceVerificationResponse> VerifyImageAsync(FaceVerificationRequest request, bool isFileInTheRemoteServer = false);
        Task<FaceVerificationResponse> VerifyBase64ImageAsync(FaceVerificationWithBase64Request request);
    }
}
