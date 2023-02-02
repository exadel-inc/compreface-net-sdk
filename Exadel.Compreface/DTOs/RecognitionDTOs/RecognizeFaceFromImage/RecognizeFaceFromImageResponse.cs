using Exadel.Compreface.DTOs.HelperDTOs;
using Exadel.Compreface.DTOs.HelperDTOs.BaseDTOs;

namespace Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFaceFromImage;

public class RecognizeFaceFromImageResponse
{
    public IList<Result>? Result { get; set; }

    public PluginVersions? PluginsVersions { get; set; }
}

public class Result : BaseResult
{
    public IList<SimilarSubject>? Subjects { get; set; }
}
