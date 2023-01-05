using Exadel.Compreface.DTOs.HelperDTOs.BaseDTOs;

namespace Exadel.Compreface.DTOs.RecognitionDTOs.BaseRequests;

public class BaseVerifyFacesFromImageRequest : BaseFaceRequest
{
    public Guid ImageId { get; set; }
}
