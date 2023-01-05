using Exadel.Compreface.DTOs.HelperDTOs.BaseDTOs;

namespace Exadel.Compreface.DTOs.RecognitionDTOs.BaseRequests;

public class BaseRecognizeFaceFromImageRequest : BaseFaceRequest
{
    public int? PredictionCount { get; set; }
}
