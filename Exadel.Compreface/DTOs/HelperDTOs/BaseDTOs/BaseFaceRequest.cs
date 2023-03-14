namespace Exadel.Compreface.DTOs.HelperDTOs.BaseDTOs;

/// <summary>
/// Base class with several common properties.
/// </summary>
public class BaseFaceRequest
{
    /// <summary>
    /// Optional property: maximum number of faces on the image to be recognized. It recognizes the biggest faces first. Value of 0 represents no limit. Default value: 0.
    /// </summary>
    public int? Limit { get; set; }

    /// <summary>
    /// Optional property: minimum required confidence that a recognized face is actually a face. Value is between 0.0 and 1.0.
    /// </summary>
    public decimal DetProbThreshold { get; set; }

    /// <summary>
    /// Optional property: comma-separated slugs of face plugins. If empty, no additional information is returned.
    /// </summary>
    public IList<string> FacePlugins { get; set; } = new List<string>();

    /// <summary>
    /// Optional property: if true includes system information like execution_time and plugin_version fields. Default value is false
    /// </summary>
    public bool Status { get; set; }
}