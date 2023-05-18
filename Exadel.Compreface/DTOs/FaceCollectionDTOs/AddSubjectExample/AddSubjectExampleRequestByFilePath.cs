using Exadel.Compreface.DTOs.HelperDTOs.BaseDTOs;

namespace Exadel.Compreface.DTOs.FaceCollectionDTOs.AddSubjectExample
{
    /// <summary>
    /// DTO helps to create an example of the subject by saving images.
    /// </summary>
    public class AddSubjectExampleRequestByFilePath : BaseExampleRequest
    {
        /// <summary>
        /// Full file path.
        /// </summary>
        public string FilePath { get; set; }
    }
}