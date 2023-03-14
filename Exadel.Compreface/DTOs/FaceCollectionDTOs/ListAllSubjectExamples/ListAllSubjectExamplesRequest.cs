namespace Exadel.Compreface.DTOs.FaceCollectionDTOs.ListAllExampleSubject;

/// <summary>
/// DTO helps to retrieve a list of subjects saved in a Face Collection.
/// </summary>
public class ListAllSubjectExamplesRequest
{
    /// <summary>
    /// Page number of examples to return. Can be used for pagination. Default value is 0.
    /// </summary>
    public int? Page { get; set; }

    /// <summary>
    /// Faces on page (page size). Can be used for pagination. Default value is 20. 
    /// </summary>
    public int? Size { get; set; }

    /// <summary>
    /// What subject examples endpoint should return. If empty, return examples for all subjects.
    /// </summary>
    public string Subject { get; set; }
}