namespace Exadel.Compreface.DTOs.RecognitionDTOs.BaseRequests;

public class BaseRecognizeFaceFromImageRequest : BaseRecognitionRequest
{
    public int? PredictionCount { get; set; }
}
