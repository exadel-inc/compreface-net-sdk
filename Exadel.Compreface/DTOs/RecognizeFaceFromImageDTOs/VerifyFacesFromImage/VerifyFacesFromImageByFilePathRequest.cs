using Exadel.Compreface.DTOs.RecognitionDTOs.BaseRequests;

namespace Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImage;

public class VerifyFacesFromImageByFilePathRequest : BaseVerifyFacesFromImageRequest
{
    public string FilePath { get; set; }
}