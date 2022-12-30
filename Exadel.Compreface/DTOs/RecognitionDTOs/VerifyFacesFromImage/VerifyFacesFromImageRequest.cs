using Exadel.Compreface.DTOs.RecognitionDTOs.BaseRequests;

namespace Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImage;

public class VerifyFacesFromImageRequest : BaseVerifyFacesFromImageRequest
{
    public string FilePath { get; set; }
    
    public string FileName { get; set; }
}
