using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFaceFromImage;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFacesFromImageWithBase64;
using Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImage;
using Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImageWithBase64;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exadel.Compreface.Services.Interfaces
{
    public interface IRecognizeFaceFromImage
    {
        Task<RecognizeFaceFromImageResponse> RecognizeAsync(RecognizeFaceFromImageRequest request, bool isFileInTheRemoteServer = false);
        Task<RecognizeFaceFromImageResponse> RecognizeAsync(RecognizeFacesFromImageWithBase64Request request);
        Task<VerifyFacesFromImageResponse> VerifyAsync(VerifyFacesFromImageRequest request);
        Task<VerifyFacesFromImageResponse> VerifyAsync(VerifyFacesFromImageWithBase64Request request);

    }
}
