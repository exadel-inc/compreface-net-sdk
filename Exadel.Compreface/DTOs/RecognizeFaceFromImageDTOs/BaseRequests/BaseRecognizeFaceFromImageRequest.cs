using Exadel.Compreface.DTOs.HelperDTOs.BaseDTOs;

namespace Exadel.Compreface.DTOs.RecognitionDTOs.BaseRequests
{

    /// <summary>
    /// Base class with several common properties.
    /// </summary>
    public class BaseRecognizeFaceFromImageRequest : BaseFaceRequest
    {
        /// <summary>
        /// Optional property: maximum number of subject predictions per face. It returns the most similar subjects. Default value: 1
        /// </summary>
        public int? PredictionCount { get; set; }
    }
}