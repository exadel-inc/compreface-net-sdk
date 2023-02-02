using Exadel.Compreface.DTOs.HelperDTOs.BaseDTOs;

namespace Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetectionBase64
{
    public class FaceDetectionBase64Request : BaseFaceRequest
    {
        public string? File { get; set; }
    }
}
