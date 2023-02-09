using Exadel.Compreface.Services;
using Exadel.Compreface.Services.RecognitionService;

namespace Exadel.Compreface.Builder
{
    public interface ICompreFaceBuilder
    {
        List<FaceDetectionService> BuildFaceDetection();
        List<FaceVerificationService> BuildVerification();
        List<RecognitionService> BuildRecognition();
    }
}