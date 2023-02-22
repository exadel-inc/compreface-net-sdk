namespace Exadel.Compreface.DTOs.ExampleSubjectDTOs.DownloadImageById
{
    public class DownloadImageByIdDirectlyRequest
    {
        public Guid ImageId { get; set; }

        public Guid RecognitionApiKey { get; set; }
    }
}