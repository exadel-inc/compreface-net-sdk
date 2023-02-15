using Exadel.Compreface.DTOs.HelperDTOs;

namespace Exadel.Compreface.DTOs.ExampleSubjectDTOs.ListAllExampleSubject;

public class ListAllSubjectExamplesResponse
{
    public IList<Face> Faces { get; set; }

    public int PageNumber { get; set; }

    public int PageSize { get; set; }
    
    public int TotalPages { get; set; }
    
    public int TotalElements { get; set; }
}