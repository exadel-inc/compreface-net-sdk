using Exadel.Compreface.DTOs.HelperDTOs.BaseDTOs;

namespace Exadel.Compreface.DTOs.FaceCollectionDTOs.AddSubjectExample
{
    /// <summary>
    /// DTO helps to create an example of the subject by saving images.
    /// </summary>
    public class AddBase64SubjectExampleRequest : BaseExampleRequest
    {
        /// <summary>
        /// Image as base64 string.
        /// </summary>
        public string File { get; set; }
    }
}