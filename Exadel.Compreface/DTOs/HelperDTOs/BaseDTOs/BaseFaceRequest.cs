namespace Exadel.Compreface.DTOs.HelperDTOs.BaseFaceRequest;

public class BaseFaceRequest
{
    public int? Limit { get; set; }

    public decimal DetProbThreshold { get; set; }

    public IList<string> FacePlugins { get; set; }

    public bool Status { get; set; }
}