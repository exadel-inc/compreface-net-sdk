using Exadel.Compreface.Services.Interfaces;

namespace Exadel.Compreface.Builder
{
    public interface ICompreFaceBuilder
    {
        IFaceDetectionService BuildFaceDetection();
        IFaceVerificationService BuildVerification();
        List<IRecognitionService> BuildRecognition();
    }
}