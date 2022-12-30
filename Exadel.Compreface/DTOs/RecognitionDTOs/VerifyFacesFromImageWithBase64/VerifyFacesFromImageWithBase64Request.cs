using Exadel.Compreface.DTOs.RecognitionDTOs.BaseRequests;

namespace Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImageWithBase64;

public class VerifyFacesFromImageWithBase64Request : BaseVerifyFacesFromImageRequest
{
    public string FileBase64Value { get; set; }
}
