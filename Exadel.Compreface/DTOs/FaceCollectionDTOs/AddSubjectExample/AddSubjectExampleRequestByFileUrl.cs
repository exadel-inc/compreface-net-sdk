using Exadel.Compreface.DTOs.HelperDTOs.BaseDTOs;

namespace Exadel.Compreface.DTOs.FaceCollectionDTOs.AddSubjectExample
{
    /// <summary>
    /// DTO helps to create an example of the subject by saving images.
    /// </summary>
    public class AddSubjectExampleRequestByFileUrl : BaseExampleRequest
    {
        /// <summary>
        /// Url of image.
        /// </summary>
        public string FileUrl { get; set; }
    }
}