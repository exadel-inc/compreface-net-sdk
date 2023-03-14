namespace Exadel.Compreface.DTOs.HelperDTOs.BaseDTOs
{
    /// <summary>
    /// Base class with several common properties.
    /// </summary>
    public class BaseExampleRequest
    {
        /// <summary>
        /// Name of the subject.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Optional property: Minimum required confidence that a recognized face is actually a face. Value is between 0.0 and 1.0.
        /// </summary>
        public decimal? DetProbThreShold { get; set; }
    }
}