using Exadel.Compreface.DTOs.HelperDTOs;

namespace Exadel.Compreface.DTOs.RecognitionDTOs.BaseRequests;

public class BaseResult
{
    public Age Age { get; set; }

    public Gender Gender { get; set; }

    public Mask Mask { get; set; }
    
    public Box Box { get; set; }

    public IList<List<int>> Landmarks { get; set; }
    
    public ExecutionTime ExecutionTime { get; set; }
    
    public IList<decimal> Embedding { get; set; }
}
