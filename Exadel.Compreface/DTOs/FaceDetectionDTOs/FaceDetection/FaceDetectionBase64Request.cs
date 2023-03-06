using Exadel.Compreface.DTOs.HelperDTOs.BaseDTOs;

namespace Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetection
{
    public class FaceDetectionBase64Request : BaseFaceRequest
    {
        public string File { get; set; }
    }
}