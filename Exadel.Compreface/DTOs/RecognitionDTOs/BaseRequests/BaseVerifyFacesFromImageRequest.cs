using Exadel.Compreface.DTOs.HelperDTOs.BaseFaceRequest;

namespace Exadel.Compreface.DTOs.RecognitionDTOs.BaseRequests;

public class BaseVerifyFacesFromImageRequest : BaseFaceRequest
{
    public Guid ImageId { get; set; }
}
