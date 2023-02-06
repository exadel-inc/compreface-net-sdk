using Exadel.Compreface.Configuration;
using Exadel.Compreface.Services.Attributes;

namespace Exadel.Compreface.Services.RecognitionService;

[CompreFaceService]
public class RecognitionService
{
    public RecognitionService(IComprefaceConfiguration configuration)
	{
		FaceCollection = new FaceCollection(configuration);
        Subject = new Subject(configuration);
        RecognizeFaceFromImage = new RecognizeFaceFromImage(configuration);
    }

	public FaceCollection FaceCollection { get; set; }

    public Subject Subject { get; set; }

    public RecognizeFaceFromImage RecognizeFaceFromImage { get; set; }
}