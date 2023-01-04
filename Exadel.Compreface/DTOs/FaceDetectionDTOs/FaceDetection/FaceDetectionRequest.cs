using Exadel.Compreface.DTOs.HelperDTOs.BaseFaceRequest;

namespace Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetection
{
    public class FaceDetectionRequest : BaseFaceRequest
    {
        public string FilePath { get; set; }

        public string FileName { get; set; }
    }
}
