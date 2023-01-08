using Exadel.Compreface.DTOs.HelperDTOs;
using Exadel.Compreface.DTOs.HelperDTOs.BaseDTOs;

namespace Exadel.Compreface.DTOs.FaceVerificationDTOs;

public class FaceVerificationResponse 
{
    public IList<Result> Result { get; set; }
}

public class Result
{
    public SourceImageFace SourceImageFace { get; set; }
    
    public IList<FaceMatches> FaceMatches { get; set; }
    
    public PluginVersions PluginsVersions { get; set; }
}

public class SourceImageFace : BaseResult
{ }

public class FaceMatches : BaseResult
{
    public decimal Similarity { get; set; }
}
