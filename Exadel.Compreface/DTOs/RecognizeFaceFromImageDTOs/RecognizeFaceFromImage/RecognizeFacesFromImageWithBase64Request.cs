using Exadel.Compreface.DTOs.RecognitionDTOs.BaseRequests;

namespace Exadel.Compreface.DTOs.RecognizeFaceFromImageDTOs.RecognizeFaceFromImage
{

    public class RecognizeFacesFromImageWithBase64Request : BaseRecognizeFaceFromImageRequest
    {
        public string FileBase64Value { get; set; }
    }
}