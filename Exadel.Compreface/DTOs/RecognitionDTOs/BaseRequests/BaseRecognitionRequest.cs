namespace Exadel.Compreface.DTOs.RecognitionDTOs.BaseRequests;

public class BaseRecognitionRequest
{
    public int? Limit { get; set; }

    public decimal DetProbThreshold { get; set; }

    public IList<string> FacePlugins { get; set; }

    public bool Status { get; set; }
}