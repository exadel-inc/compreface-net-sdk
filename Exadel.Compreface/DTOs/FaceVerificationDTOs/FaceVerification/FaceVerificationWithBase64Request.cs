using Exadel.Compreface.DTOs.HelperDTOs.BaseDTOs;

namespace Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerification
{

    public class FaceVerificationWithBase64Request : BaseFaceRequest
    {
        public string SourceImageWithBase64 { get; set; }

        public string TargetImageWithBase64 { get; set; }
    }
}