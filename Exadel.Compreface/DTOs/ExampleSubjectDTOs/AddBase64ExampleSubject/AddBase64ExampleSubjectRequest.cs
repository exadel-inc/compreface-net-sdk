using Exadel.Compreface.DTOs.HelperDTOs;

namespace Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddBase64ExampleSubject
{
    public class AddBase64ExampleSubjectRequest
    {
        public string Subject { get; set; }

        public decimal? DetProbThreShold { get; set; }

        public string File { get; set; }
    }
}
