using Exadel.Compreface.DTOs.HelperDTOs.BaseDTOs;

namespace Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerification
{
    public class FaceVerificationRequestByBytes : BaseFaceRequest
    {
        public byte[] SourceImageBytes { get; set; }

        public byte[] TargetImageBytes { get; set; }
    }
}