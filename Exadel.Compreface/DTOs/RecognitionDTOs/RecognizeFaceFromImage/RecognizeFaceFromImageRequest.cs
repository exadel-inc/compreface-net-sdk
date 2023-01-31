using Exadel.Compreface.DTOs.RecognitionDTOs.BaseRequests;

namespace Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFaceFromImage;

public class RecognizeFaceFromImageRequest : BaseRecognizeFaceFromImageRequest
{
    public string? FilePath { get; set; }
}
