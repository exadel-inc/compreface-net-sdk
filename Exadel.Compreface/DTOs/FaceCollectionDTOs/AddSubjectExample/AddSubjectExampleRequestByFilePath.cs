using Exadel.Compreface.DTOs.HelperDTOs.BaseDTOs;

namespace Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddExampleSubject;

public class AddSubjectExampleRequestByFilePath : BaseExampleRequest
{
    public string FilePath { get; set; }
}