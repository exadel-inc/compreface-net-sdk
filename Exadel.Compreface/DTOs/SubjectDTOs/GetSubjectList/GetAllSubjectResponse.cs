using System.Text.Json.Serialization;

namespace Exadel.Compreface.DTOs.SubjectDTOs.GetSubjectList;

public class GetAllSubjectResponse
{
    public IList<string> Subjects { get; set; }
}