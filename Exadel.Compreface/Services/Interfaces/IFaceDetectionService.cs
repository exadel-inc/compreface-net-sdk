using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetection;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetectionBase64;

namespace Exadel.Compreface.Services.Interfaces
{
    public interface IFaceDetectionService
    {
        Task<FaceDetectionResponse> DetectAsync(FaceDetectionRequest faceDetectionRequest, bool isFileInTheRemoteServer = false);
        Task<FaceDetectionResponse> DetectAsync(FaceDetectionBase64Request faceDetectionRequest);

    }
}