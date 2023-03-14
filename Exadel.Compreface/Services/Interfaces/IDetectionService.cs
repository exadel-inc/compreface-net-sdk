﻿using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetection;

namespace Exadel.Compreface.Services.Interfaces
{
    public interface IDetectionService
    {
        Task<FaceDetectionResponse> DetectAsync(FaceDetectionRequestByFilePath faceDetectionRequest);

        Task<FaceDetectionResponse> DetectAsync(FaceDetectionRequestByFileUrl faceDetectionRequest);

        Task<FaceDetectionResponse> DetectAsync(FaceDetectionBase64Request faceDetectionRequest);

        Task<FaceDetectionResponse> DetectAsync(FaceDetectionRequestByBytes faceDetectionRequest);
    }
}