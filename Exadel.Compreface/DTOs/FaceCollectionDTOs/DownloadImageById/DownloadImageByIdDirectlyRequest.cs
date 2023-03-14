namespace Exadel.Compreface.DTOs.FaceCollectionDTOs.DownloadImageById
{
    /// <summary>
    /// DTO for direct example downloading from recognition service.
    /// </summary>
    public class DownloadImageByIdDirectlyRequest
    {
        public Guid ImageId { get; set; }

        public Guid RecognitionApiKey { get; set; }
    }
}