using Exadel.Compreface.DTOs.HelperDTOs.BaseDTOs;

namespace Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerification
{
    public class FaceVerificationRequestByBytes : BaseFaceRequest
    {
        public byte[] SourceImageInBytes { get; set; }

        public byte[] TargetImageInBytes { get; set; }
    }
}