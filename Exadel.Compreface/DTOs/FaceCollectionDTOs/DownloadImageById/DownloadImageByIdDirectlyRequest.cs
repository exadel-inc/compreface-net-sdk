namespace Exadel.Compreface.DTOs.FaceCollectionDTOs.DownloadImageById
{
    public class DownloadImageByIdDirectlyRequest
    {
        public Guid ImageId { get; set; }

        public Guid RecognitionApiKey { get; set; }
    }
}