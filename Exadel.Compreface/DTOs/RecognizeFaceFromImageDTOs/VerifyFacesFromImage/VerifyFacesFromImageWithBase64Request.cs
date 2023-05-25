using Exadel.Compreface.DTOs.RecognitionDTOs.BaseRequests;

namespace Exadel.Compreface.DTOs.RecognizeFaceFromImageDTOs.VerifyFacesFromImage
{

    public class VerifyFacesFromImageWithBase64Request : BaseVerifyFacesFromImageRequest
    {
        public string FileBase64Value { get; set; }
    }
}