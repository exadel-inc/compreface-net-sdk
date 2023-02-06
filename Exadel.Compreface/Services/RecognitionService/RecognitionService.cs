using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddBase64ExampleSubject;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFaceFromImage;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFacesFromImageWithBase64;
using Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImage;
using Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImageWithBase64;
using Exadel.Compreface.Helpers;
using Exadel.Compreface.Services.Interfaces;
using Flurl;
using Flurl.Http;

namespace Exadel.Compreface.Services.RecognitionService;

public class RecognitionService : IBaseService
{
	//private readonly FaceCollection _faceCollection;
 //   private readonly Subject _subject;
	//private readonly RecognizeFaceFromImage _recognizeFaceFromImage;
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