using Exadel.Compreface.DTOs.HelperDTOs.BaseDTOs;

namespace Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetection
{
    public class FaceDetectionRequest : BaseFaceRequest
    {
        public string FilePath { get; set; }
    }
}
