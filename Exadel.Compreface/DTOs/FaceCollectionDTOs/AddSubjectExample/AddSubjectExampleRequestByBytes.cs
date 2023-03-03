using Exadel.Compreface.DTOs.HelperDTOs.BaseDTOs;

namespace Exadel.Compreface.DTOs.FaceCollectionDTOs.AddSubjectExample
{
    /// <summary>
    /// DTO helps to create an example of the subject by saving images.
    /// </summary>
    public class AddSubjectExampleRequestByBytes : BaseExampleRequest
    {
        /// <summary>
        /// Image as byte array.
        /// </summary>
        public byte[] ImageInBytes { get; set; }
    }
}