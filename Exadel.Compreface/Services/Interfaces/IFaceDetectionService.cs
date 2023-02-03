using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetection;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetectionBase64;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exadel.Compreface.Services.Interfaces
{
    public interface IFaceDetectionService
    {
        Task<FaceDetectionResponse> FaceDetectionAsync(FaceDetectionRequest faceDetectionRequest, bool isFileInTheRemoteServer = false);
        Task<FaceDetectionResponse> FaceDetectionBase64Async(FaceDetectionBase64Request faceDetectionRequest);

    }
}
