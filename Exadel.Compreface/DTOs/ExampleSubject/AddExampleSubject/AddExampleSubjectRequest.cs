namespace Exadel.Compreface.DTOs.ExampleSubject.AddExampleSubject;

public class AddExampleSubjectRequest
{
    public string Subject { get; set; }
    
    public decimal? DetProbThreShold { get; set; }

    public string FilePath { get; set; }

    public string FileName { get; set; }
}