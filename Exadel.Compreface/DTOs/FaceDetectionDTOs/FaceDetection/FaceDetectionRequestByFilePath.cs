using Exadel.Compreface.DTOs.HelperDTOs.BaseDTOs;

namespace Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetection
{
    public class FaceDetectionRequestByFilePath : BaseFaceRequest
    {
        public string FilePath { get; set; }
    }
}
