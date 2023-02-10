using Exadel.Compreface.DTOs.HelperDTOs.BaseDTOs;

namespace Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetection
{
    public class FaceDetectionRequestByFileUrl : BaseFaceRequest
    {
        public string FileUrl { get; set; }
    }
}