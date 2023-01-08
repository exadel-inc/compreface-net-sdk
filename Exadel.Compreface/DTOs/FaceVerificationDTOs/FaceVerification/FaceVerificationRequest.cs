using Exadel.Compreface.DTOs.HelperDTOs.BaseDTOs;

namespace Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerification;

public class FaceVerificationRequest : BaseFaceRequest
{
    public string SourceImageFilePath { get; set; }

    public string SourceImageFileName { get; set; }
    
    public string TargetImageFilePath { get; set; }
    
    public string TargetImageFileName { get; set; }
}
