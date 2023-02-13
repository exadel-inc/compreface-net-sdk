using Exadel.Compreface.DTOs.RecognitionDTOs.BaseRequests;

namespace Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFaceFromImage
{
    public class RecognizeFaceFromImageRequestByFileUrl : BaseRecognizeFaceFromImageRequest
    {
        public string FileUrl { get; set; }
    }
}