using Exadel.Compreface.Configuration;
using Exadel.Compreface.Services.Attributes;
using Exadel.Compreface.Services.Interfaces;

namespace Exadel.Compreface.Services.RecognitionService;

[CompreFaceService]
public class RecognitionService
{
    public IFaceCollection FaceCollection { get; set; }

    public ISubject Subject { get; set; }

    public IRecognizeFaceFromImage RecognizeFaceFromImage { get; set; }

    public RecognitionService(IComprefaceConfiguration configuration)
	{
		FaceCollection = new FaceCollection(configuration);
        Subject = new Subject(configuration);
        RecognizeFaceFromImage = new RecognizeFaceFromImage(configuration);
    }
}