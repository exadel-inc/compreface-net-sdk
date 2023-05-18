using Exadel.Compreface.DTOs.RecognitionDTOs.BaseRequests;

namespace Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFaceFromImage
{

    public class RecognizeFaceFromImageRequestByFilePath : BaseRecognizeFaceFromImageRequest
    {
        public string FilePath { get; set; }
    }
}