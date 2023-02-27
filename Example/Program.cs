using Exadel.Compreface.Clients.CompreFaceClient;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddBase64ExampleSubject;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddExampleSubject;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteAllSubjectExamples;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteImageById;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteMultipleExamples;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DownloadImageById;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DownloadImageBySubjectId;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.ListAllExampleSubject;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetection;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetectionBase64;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerification;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerificationWithBase64;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFaceFromImage;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFacesFromImageWithBase64;
using Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImage;
using Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImageWithBase64;
using Exadel.Compreface.DTOs.SubjectDTOs.AddSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.RenameSubject;
using Exadel.Compreface.DTOs.SubjectExampleDTOs.AddSubjectExample;
using Exadel.Compreface.Services;
using Exadel.Compreface.Services.RecognitionService;
using static Exadel.Compreface.AcceptenceTests.UrlConstConfig;

var client = new CompreFaceClient(
domain: "http://localhost",
port: "8000");

var faceDetectionService = client.GetCompreFaceService<FaceDetectionService>("00000000-0000-0000-0000-000000000003");
var faceVerificationService = client.GetCompreFaceService<FaceVerificationService>("00000000-0000-0000-0000-000000000004");
var faceRecognitionService = client.GetCompreFaceService<RecognitionService>("00000000-0000-0000-0000-000000000002");

//FaceDetection

#region Face Detection Service, by File Path
var faceDetectionRequestByFilePath = new FaceDetectionRequestByFilePath()
{
    FilePath = "C:\\Users\\ukalenik\\source\\repos\\compreface-net-sdk\\Exadel.Compreface.AcceptenceTests\\Resources\\Images\\pexels-jonathan-yakubu.jpg",
    DetProbThreshold = 0.81m,
    Limit = 1,
    Status = false,
    FacePlugins = new List<string>()
            {
                "landmarks",
                "gender",
                "age",
                "detector",
                "calculator"
            }
};

var faceDetectionByFilePathResponse = await faceDetectionService.DetectAsync(faceDetectionRequestByFilePath);
#endregion

#region Face Detection Service, by File Url
var faceDetectionRequestByFileUrl = new FaceDetectionRequestByFileUrl()
{
    FileUrl = FILE_URL,
    DetProbThreshold = 0.81m,
    Limit = 1,
    Status = false,
    FacePlugins = new List<string>()
            {
                "landmarks",
                "gender",
                "age",
                "detector",
                "calculator"
            }
};

var faceDetectionByUrlResponse = await faceDetectionService.DetectAsync(faceDetectionRequestByFileUrl);
#endregion

#region Face Detection Service, Base64
var faceDetectionBase64Request = new FaceDetectionBase64Request()
{
    File = IMAGE_BASE64_STRING,
    DetProbThreshold = 0.81m,
    Limit = 1,
    Status = false,
    FacePlugins = new List<string>()
            {
                "landmarks",
                "gender",
                "age",
                "detector",
                "calculator"
            }
};

var faceDetectionBase64Response = await faceDetectionService.DetectAsync(faceDetectionBase64Request);
#endregion

//FaceVerification

#region Face Verification Service, by File Path
var faceVerificationRequestByFilePath = new FaceVerificationRequestByFilePath()
{
    SourceImageFilePath = "C:\\Users\\ukalenik\\source\\repos\\compreface-net-sdk\\Exadel.Compreface.AcceptenceTests\\Resources\\Images\\pexels-jonathan-yakubu.jpg",
    TargetImageFilePath = "C:\\Users\\ukalenik\\source\\repos\\compreface-net-sdk\\Exadel.Compreface.AcceptenceTests\\Resources\\Images\\pexels-jonathan-yakubu.jpg",
    DetProbThreshold = 0.81m,
    Limit = 1,
    Status = false,
    FacePlugins = new List<string>()
            {
                "landmarks",
                "gender",
                "age",
                "detector",
                "calculator"
            }
};

var faceVerificationByFilePathResponse = await faceVerificationService.VerifyAsync(faceVerificationRequestByFilePath);
#endregion

#region Face Verification Service, by File Url
var faceVerificationRequestByFileUrl = new FaceVerificationRequestByFileUrl()
{
    SourceImageFileUrl = FILE_URL,
    TargetImageFileUrl = FILE_URL,
    DetProbThreshold = 0.81m,
    Limit = 1,
    Status = false,
    FacePlugins = new List<string>()
            {
                "landmarks",
                "gender",
                "age",
                "detector",
                "calculator"
            }
};

var faceVerificationByUrlResponse = await faceVerificationService.VerifyAsync(faceVerificationRequestByFileUrl);
#endregion

#region Face Verification Service, Base64
var faceVerificationWithBase64Request = new FaceVerificationWithBase64Request()
{
    SourceImageWithBase64 = IMAGE_BASE64_STRING,
    TargetImageWithBase64 = IMAGE_BASE64_STRING,
    DetProbThreshold = 0.81m,
    Limit = 1,
    Status = false,
    FacePlugins = new List<string>()
            {
                "landmarks",
                "gender",
                "age",
                "detector",
                "calculator"
            }
};

var faceVerificationBase64Response = await faceVerificationService.VerifyAsync(faceVerificationWithBase64Request);
#endregion

//Subjects

#region Add a Subject
var addSubjectRequest = new AddSubjectRequest()
{
    Subject = TEST_SUBJECT_NAME
};

var addSubjectResponse = await faceRecognitionService.Subject.AddAsync(addSubjectRequest);
#endregion

#region Rename a Subject
var renameSubjectRequest = new RenameSubjectRequest()
{
    CurrentSubject = TEST_SUBJECT_NAME,
    Subject = RENAMED_SUBJECT_NAME
};

var renameSubjectResponse = await faceRecognitionService.Subject.RenameAsync(renameSubjectRequest);
#endregion

#region List Subjects
var subjectList = await faceRecognitionService.Subject.ListAsync();
#endregion

#region Delete a Subject
var deleteSubjectRequest = new DeleteSubjectRequest()
{
    ActualSubject = RENAMED_SUBJECT_NAME
};

var deleteSubjectResponse = await faceRecognitionService.Subject.DeleteAsync(deleteSubjectRequest);
#endregion

#region Delete All Subjects
var deleteAllSubjectsResponse = await faceRecognitionService.Subject.DeleteAllAsync();
#endregion

//FaceCollection

#region Add an Example of a Subject, by File Path
var addSubjectExampleRequestByFilePath = new AddSubjectExampleRequestByFilePath()
{
    FilePath = "C:\\Users\\ukalenik\\source\\repos\\compreface-net-sdk\\Exadel.Compreface.AcceptenceTests\\Resources\\Images\\pexels-jonathan-yakubu.jpg",
    DetProbThreShold = 0.81m,
    Subject = TEST_SUBJECT_NAME,
};

var addSubjectExampleResponse = await faceRecognitionService.FaceCollection.AddAsync(addSubjectExampleRequestByFilePath);
#endregion

#region Add an Example of a Subject, by URL
var addSubjectExampleRequestByFileUrl = new AddSubjectExampleRequestByFileUrl()
{
    FileUrl = FILE_URL,
    DetProbThreShold = 0.9m,
    Subject = TEST_SUBJECT_NAME
};

var addSubjectExampleByUrlResponse = await faceRecognitionService.FaceCollection.AddAsync(addSubjectExampleRequestByFileUrl);
#endregion

#region Add an Example of a Subject, Base64
var addBase64SubjectExampleRequest = new AddBase64SubjectExampleRequest()
{
    File = IMAGE_BASE64_STRING,
    DetProbThreShold = 0.9m,
    Subject = TEST_SUBJECT_NAME
};

var addBase64SubjectExampleResponse = await faceRecognitionService.FaceCollection.AddAsync(addBase64SubjectExampleRequest);
#endregion

#region List of All Saved Examples of the Subject
var listAllSubjectExamplesRequest = new ListAllSubjectExamplesRequest()
{
    Page = 0,
    Size = 0,
    Subject = TEST_SUBJECT_NAME,
};

var listAllSubjectExamplesResponse = await faceRecognitionService.FaceCollection.ListAsync(listAllSubjectExamplesRequest);
#endregion

#region Delete All Examples of the Subject by Name
var deleteAllExamplesRequest = new DeleteAllExamplesRequest()
{
    Subject = TEST_SUBJECT_NAME
};

var deleteAllExamplesResponse = await faceRecognitionService.FaceCollection.DeleteAllAsync(deleteAllExamplesRequest);
#endregion

#region Delete Multiple Examples
var deleteMultipleExampleRequest = new DeleteMultipleExampleRequest()
{
    ImageIdList = new List<Guid>
    {
        Guid.NewGuid(),
        Guid.NewGuid(),
        Guid.NewGuid()
    }
};

var deleteMultipleExamplesResponse = await faceRecognitionService.FaceCollection.DeleteAsync(deleteMultipleExampleRequest);
#endregion

#region Delete an Example of the Subject by ID
var deleteImageByIdRequest = new DeleteImageByIdRequest()
{
    ImageId = Guid.NewGuid(),
};

var deleteImageByIdResponse = await faceRecognitionService.FaceCollection.DeleteAsync(deleteImageByIdRequest);
#endregion

#region Direct Download an Image example of the Subject by ID
var downloadImageByIdDirectlyRequest = new DownloadImageByIdDirectlyRequest()
{
    ImageId = Guid.NewGuid(),
};

var directDownloadImage = await faceRecognitionService.FaceCollection.DownloadAsync(downloadImageByIdDirectlyRequest);
#endregion

#region Download an Image example of the Subject by ID
var downloadImageByIdFromSubjectRequest = new DownloadImageByIdFromSubjectRequest()
{
    ImageId = Guid.NewGuid(),
};

var image = await faceRecognitionService.FaceCollection.DownloadAsync(downloadImageByIdFromSubjectRequest);
#endregion

//RecognizeFaceFromImage

#region Recognize Faces from a Given Image, by File Path
var recognizeFaceFromImageRequestByFilePath = new RecognizeFaceFromImageRequestByFilePath()
{
    FilePath = "C:\\Users\\ukalenik\\source\\repos\\compreface-net-sdk\\Exadel.Compreface.AcceptenceTests\\Resources\\Images\\pexels-jonathan-yakubu.jpg",
    PredictionCount = 1,
    DetProbThreshold = 0.81m,
    Limit = 1,
    Status = false,
    FacePlugins = new List<string>()
            {
                "landmarks",
                "gender",
                "age",
                "detector",
                "calculator"
            }
};

var recognizeFaceFromImageByFilePathResponse = await faceRecognitionService.RecognizeFaceFromImage.RecognizeAsync(recognizeFaceFromImageRequestByFilePath);
#endregion

#region Recognize Faces from a Given Image, by URL
var RecognizeFaceFromImageRequestByFileUrl = new RecognizeFaceFromImageRequestByFileUrl()
{
    FileUrl = FILE_URL,
    PredictionCount = 1,
    DetProbThreshold = 0.81m,
    Limit = 1,
    Status = false,
    FacePlugins = new List<string>()
            {
                "landmarks",
                "gender",
                "age",
                "detector",
                "calculator"
            }
};

var recognizeFaceFromImageByUrlResponse = await faceRecognitionService.RecognizeFaceFromImage.RecognizeAsync(RecognizeFaceFromImageRequestByFileUrl);
#endregion

#region Recognize Faces from a Given Image, Base64
var recognizeFacesFromImageWithBase64Request = new RecognizeFacesFromImageWithBase64Request()
{
    FileBase64Value = IMAGE_BASE64_STRING,
    PredictionCount = 1,
    DetProbThreshold = 0.81m,
    Limit = 1,
    Status = false,
    FacePlugins = new List<string>()
            {
                "landmarks",
                "gender",
                "age",
                "detector",
                "calculator"
            }
};

var recognizeFaceFromImageBase64Response = await faceRecognitionService.RecognizeFaceFromImage.RecognizeAsync(recognizeFacesFromImageWithBase64Request);
#endregion

#region Verify Faces from a Given Image, by File Path
var verifyFacesFromImageByFilePathRequest = new VerifyFacesFromImageRequest()
{
    FilePath = "C:\\Users\\ukalenik\\source\\repos\\compreface-net-sdk\\Exadel.Compreface.AcceptenceTests\\Resources\\Images\\pexels-jonathan-yakubu.jpg",
    ImageId = Guid.NewGuid(),
    DetProbThreshold = 0.81m,
    Limit = 1,
    Status = false,
    FacePlugins = new List<string>()
            {
                "landmarks",
                "gender",
                "age",
                "detector",
                "calculator"
            }
};

var verifyFacesFromImageByFilePathResponse = await faceRecognitionService.RecognizeFaceFromImage.VerifyAsync(verifyFacesFromImageByFilePathRequest);
#endregion

#region Verify Faces from a Given Image, Base64
var verifyFacesFromImageWithBase64Request = new VerifyFacesFromImageWithBase64Request()
{
    FileBase64Value = IMAGE_BASE64_STRING,
    ImageId = Guid.NewGuid(),
    DetProbThreshold = 0.81m,
    Limit = 1,
    Status = false,
    FacePlugins = new List<string>()
            {
                "landmarks",
                "gender",
                "age",
                "detector",
                "calculator"
            }
};

var verifyFacesFromImageBase64Response = await faceRecognitionService.RecognizeFaceFromImage.VerifyAsync(verifyFacesFromImageWithBase64Request);
#endregion