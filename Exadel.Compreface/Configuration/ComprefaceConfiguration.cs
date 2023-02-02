using Microsoft.Extensions.Configuration;

namespace Exadel.Compreface.Configuration;

public class ComprefaceConfiguration 
{
    public string Domain { get; set; } = null;
    public string Port { get; set; } = null;
    public string FaceDetectionApiKey { get; set; } = null;
    public string FaceVerificationApiKey { get; set; } = null;
    public string FaceRecognitionApiKey { get; set; } = null;
}