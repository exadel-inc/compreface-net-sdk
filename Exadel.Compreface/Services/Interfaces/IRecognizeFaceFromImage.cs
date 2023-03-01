using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFaceFromImage;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFacesFromImageWithBase64;
using Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImage;
using Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImageWithBase64;
using Exadel.Compreface.DTOs.RecognizeFaceFromImageDTOs.VerifyFacesFromImage;

namespace Exadel.Compreface.Services.Interfaces
{
    public interface IRecognizeFaceFromImage
    {
        Task<RecognizeFaceFromImageResponse> RecognizeAsync(RecognizeFaceFromImageRequestByFilePath request);

        Task<RecognizeFaceFromImageResponse> RecognizeAsync(RecognizeFaceFromImageRequestByFileUrl request);

        Task<RecognizeFaceFromImageResponse> RecognizeAsync(RecognizeFaceFromImageRequestByBytes request);

        Task<RecognizeFaceFromImageResponse> RecognizeAsync(RecognizeFacesFromImageWithBase64Request request);

        Task<VerifyFacesFromImageResponse> VerifyAsync(VerifyFacesFromImageByFilePathRequest request);

        Task<VerifyFacesFromImageResponse> VerifyAsync(VerifyFacesFromImageByFileUrlRequest request);

        Task<VerifyFacesFromImageResponse> VerifyAsync(VerifyFacesFromImageWithBase64Request request);

        Task<VerifyFacesFromImageResponse> VerifyAsync(VerifyFacesFromImageWithBytesRequest request);
    }
}