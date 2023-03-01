using Exadel.Compreface.DTOs.HelperDTOs.BaseDTOs;

namespace Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetection
{
    public class FaceDetectionRequestByBytes : BaseFaceRequest
    {
        public byte[] ImageInBytes { get; set; }
    }
}