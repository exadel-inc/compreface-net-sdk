using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetection;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetectionBase64;

namespace Exadel.Compreface.Services.Interfaces
{
    public interface IFaceDetectionService
    {
        Task<FaceDetectionResponse> DetectAsync(FaceDetectionRequestByFilePath faceDetectionRequest);

        Task<FaceDetectionResponse> DetectAsync(FaceDetectionRequestByFileUrl faceDetectionRequest);

        Task<FaceDetectionResponse> DetectAsync(FaceDetectionBase64Request faceDetectionRequest);

        Task<FaceDetectionResponse> DetectAsync(FaceDetectionRequestByBytes faceDetectionRequest);
    }
}