using Exadel.Compreface.DTOs.RecognitionDTOs.BaseRequests;

namespace Exadel.Compreface.DTOs.RecognizeFaceFromImageDTOs.VerifyFacesFromImage
{
    public class VerifyFacesFromImageByFileUrlRequest : BaseVerifyFacesFromImageRequest
    {
        public string FileUrl { get; set; }
    }
}
