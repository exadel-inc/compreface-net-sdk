using Exadel.Compreface.DTOs.RecognitionDTOs.BaseRequests;

namespace Exadel.Compreface.DTOs.RecognizeFaceFromImageDTOs.VerifyFacesFromImage
{
    public class VerifyFacesFromImageWithBytesRequest : BaseVerifyFacesFromImageRequest
    {
        public byte[] ImageInBytes { get; set; }
    }
}