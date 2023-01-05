namespace Exadel.Compreface.DTOs.HelperDTOs.BaseDTOs;

public class BaseFaceRequest
{
    public int? Limit { get; set; }

    public decimal DetProbThreshold { get; set; }

    public IList<string> FacePlugins { get; set; }

    public bool Status { get; set; }
}