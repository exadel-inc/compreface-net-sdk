using Exadel.Compreface.Clients.ApiClient;
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

    public RecognitionService(IComprefaceConfiguration configuration, IApiClient apiClient)
	{
		FaceCollection = new FaceCollection(configuration, apiClient);
        Subject = new Subject(configuration, apiClient);
        RecognizeFaceFromImage = new RecognizeFaceFromImage(configuration, apiClient);
    }
}