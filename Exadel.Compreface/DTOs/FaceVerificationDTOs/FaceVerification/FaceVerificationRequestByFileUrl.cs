using Exadel.Compreface.DTOs.HelperDTOs.BaseDTOs;

namespace Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerification
{
    public class FaceVerificationRequestByFileUrl : BaseFaceRequest
    {
        public string SourceImageFileUrl { get; set; }

        public string TargetImageFileUrl { get; set; }
    }
}