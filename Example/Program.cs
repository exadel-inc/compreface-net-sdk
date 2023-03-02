using Exadel.Compreface.Clients.CompreFaceClient;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.AddBase64SubjectExample;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.AddSubjectExample;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.DeleteAllSubjectExamples;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.DeleteImageById;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.DeleteMultipleExamples;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.DownloadImageById;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.DownloadImageByIdFromSubject;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.ListAllExampleSubject;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetection;
using Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetectionBase64;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerification;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerificationWithBase64;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFaceFromImage;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFacesFromImageWithBase64;
using Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImage;
using Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImageWithBase64;
using Exadel.Compreface.DTOs.RecognizeFaceFromImageDTOs.RecognizeFaceFromImage;
using Exadel.Compreface.DTOs.RecognizeFaceFromImageDTOs.VerifyFacesFromImage;
using Exadel.Compreface.DTOs.RecognizeFaceFromImageDTOs.VerifyFacesFromImageWithBytesRequest;
using Exadel.Compreface.DTOs.SubjectDTOs.AddSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.RenameSubject;
using Exadel.Compreface.Services;
using Exadel.Compreface.Services.RecognitionService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static Exadel.Compreface.AcceptenceTests.ExampleConst;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, collection) =>
    {
        collection.AddScoped<IComprefaceConfiguration, ComprefaceConfiguration>();
    })
    .Build();

var serviceProvider = host.Services;
var configuration = serviceProvider.GetService<IConfiguration>();

var client = new CompreFaceClient(
domain: "http://localhost",
port: "8000");

var faceDetectionService = client.GetCompreFaceService<DetectionService>(configuration!, "FaceDetectionApiKey");
var faceVerificationService = client.GetCompreFaceService<VerificationService>("00000000-0000-0000-0000-000000000004");
var faceRecognitionService = client.GetCompreFaceService<RecognitionService>("00000000-0000-0000-0000-000000000002");

//Detection

#region Detection Service, by File Path
//var faceDetectionRequestByFilePath = new FaceDetectionRequestByFilePath()
//{
//    FilePath = "Paste here full file path",
//    DetProbThreshold = 0.81m,
//    Limit = 1,
//    Status = false,
//    FacePlugins = new List<string>()
//            {
//                "landmarks",
//                "gender",
//                "age",
//                "detector",
//                "calculator"
//            }
//};

//var faceDetectionByFilePathResponse = await faceDetectionService.DetectAsync(faceDetectionRequestByFilePath);
#endregion

#region Detection Service, by File Url
//var faceDetectionRequestByFileUrl = new FaceDetectionRequestByFileUrl()
//{
//    FileUrl = FILE_URL,
//    DetProbThreshold = 0.81m,
//    Limit = 1,
//    Status = false,
//    FacePlugins = new List<string>()
//            {
//                "landmarks",
//                "gender",
//                "age",
//                "detector",
//                "calculator"
//            }
//};

//var faceDetectionByUrlResponse = await faceDetectionService.DetectAsync(faceDetectionRequestByFileUrl);
#endregion

#region Detection Service, Base64
//var faceDetectionBase64Request = new FaceDetectionBase64Request()
//{
//    File = IMAGE_BASE64_STRING,
//    DetProbThreshold = 0.81m,
//    Limit = 1,
//    Status = false,
//    FacePlugins = new List<string>()
//            {
//                "landmarks",
//                "gender",
//                "age",
//                "detector",
//                "calculator"
//            }
//};

//var faceDetectionBase64Response = await faceDetectionService.DetectAsync(faceDetectionBase64Request);
#endregion

#region Detection Service, Bytes array
//var faceDetectionRequestByBytes = new FaceDetectionRequestByBytes()
//{
//    ImageInBytes = "Here should be byte array."
//    DetProbThreshold = 0.81m,
//    Limit = 1,
//    Status = false,
//    FacePlugins = new List<string>()
//            {
//                "landmarks",
//                "gender",
//                "age",
//                "detector",
//                "calculator"
//            }
//};

//var faceDetectionByBytesResponse = await faceDetectionService.DetectAsync(faceDetectionRequestByBytes);
#endregion

//Verification

#region Verification Service, by File Path
//var faceVerificationRequestByFilePath = new FaceVerificationRequestByFilePath()
//{
//    SourceImageFilePath = "Paste here full file path",
//    TargetImageFilePath = "Paste here full file path",
//    DetProbThreshold = 0.81m,
//    Limit = 1,
//    Status = false,
//    FacePlugins = new List<string>()
//            {
//                "landmarks",
//                "gender",
//                "age",
//                "detector",
//                "calculator"
//            }
//};

//var faceVerificationByFilePathResponse = await faceVerificationService.VerifyAsync(faceVerificationRequestByFilePath);
#endregion

#region Verification Service, by File Url
//var faceVerificationRequestByFileUrl = new FaceVerificationRequestByFileUrl()
//{
//    SourceImageFileUrl = FILE_URL,
//    TargetImageFileUrl = FILE_URL,
//    DetProbThreshold = 0.81m,
//    Limit = 1,
//    Status = false,
//    FacePlugins = new List<string>()
//            {
//                "landmarks",
//                "gender",
//                "age",
//                "detector",
//                "calculator"
//            }
//};

//var faceVerificationByUrlResponse = await faceVerificationService.VerifyAsync(faceVerificationRequestByFileUrl);
#endregion

#region Verification Service, Base64
//var faceVerificationWithBase64Request = new FaceVerificationWithBase64Request()
//{
//    SourceImageWithBase64 = IMAGE_BASE64_STRING,
//    TargetImageWithBase64 = IMAGE_BASE64_STRING,
//    DetProbThreshold = 0.81m,
//    Limit = 1,
//    Status = false,
//    FacePlugins = new List<string>()
//            {
//                "landmarks",
//                "gender",
//                "age",
//                "detector",
//                "calculator"
//            }
//};

//var faceVerificationBase64Response = await faceVerificationService.VerifyAsync(faceVerificationWithBase64Request);
#endregion

#region Verification Service, Bytes array
//var faceVerificationRequestByBytes = new FaceVerificationRequestByBytes()
//{
//    SourceImageInBytes = "Here should be byte array.",
//    TargetImageInBytes = "Here should be byte array.",
//    DetProbThreshold = 0.81m,
//    Limit = 1,
//    Status = false,
//    FacePlugins = new List<string>()
//            {
//                "landmarks",
//                "gender",
//                "age",
//                "detector",
//                "calculator"
//            }
//};

//var faceVerificationByBytesResponse = await faceVerificationService.VerifyAsync(faceVerificationRequestByBytes);
#endregion

//Subjects

#region Add a Subject
//var addSubjectRequest = new AddSubjectRequest()
//{
//    Subject = TEST_SUBJECT_NAME
//};

//var addSubjectResponse = await faceRecognitionService.Subject.AddAsync(addSubjectRequest);
#endregion

#region Rename a Subject
//var renameSubjectRequest = new RenameSubjectRequest()
//{
//    CurrentSubject = TEST_SUBJECT_NAME,
//    Subject = RENAMED_SUBJECT_NAME
//};

//var renameSubjectResponse = await faceRecognitionService.Subject.RenameAsync(renameSubjectRequest);
#endregion

#region List Subjects
//var subjectList = await faceRecognitionService.Subject.ListAsync();
#endregion

#region Delete a Subject
//var deleteSubjectRequest = new DeleteSubjectRequest()
//{
//    ActualSubject = RENAMED_SUBJECT_NAME
//};

//var deleteSubjectResponse = await faceRecognitionService.Subject.DeleteAsync(deleteSubjectRequest);
#endregion

#region Delete All Subjects
//var deleteAllSubjectsResponse = await faceRecognitionService.Subject.DeleteAllAsync();
#endregion

//FaceCollection

#region Add an Example of a Subject, by File Path
//var addSubjectExampleRequestByFilePath = new AddSubjectExampleRequestByFilePath()
//{
//    FilePath = "Paste here full file path",
//    DetProbThreShold = 0.81m,
//    Subject = TEST_SUBJECT_NAME,
//};

//var addSubjectExampleResponse = await faceRecognitionService.FaceCollection.AddAsync(addSubjectExampleRequestByFilePath);
#endregion

#region Add an Example of a Subject, by URL
//var addSubjectExampleRequestByFileUrl = new AddSubjectExampleRequestByFileUrl()
//{
//    FileUrl = FILE_URL,
//    DetProbThreShold = 0.9m,
//    Subject = TEST_SUBJECT_NAME
//};

//var addSubjectExampleByUrlResponse = await faceRecognitionService.FaceCollection.AddAsync(addSubjectExampleRequestByFileUrl);
#endregion

#region Add an Example of a Subject, Base64
//var addBase64SubjectExampleRequest = new AddBase64SubjectExampleRequest()
//{
//    File = IMAGE_BASE64_STRING,
//    DetProbThreShold = 0.9m,
//    Subject = TEST_SUBJECT_NAME
//};

//var addBase64SubjectExampleResponse = await faceRecognitionService.FaceCollection.AddAsync(addBase64SubjectExampleRequest);
#endregion

#region Add an Example of a Subject, Bytes array
//var addSubjectExampleRequestByBytes = new AddSubjectExampleRequestByBytes()
//{
//    ImageInBytes = "Here should be byte array.",
//    DetProbThreShold = 0.9m,
//    Subject = TEST_SUBJECT_NAME
//};

//var addSubjectExampleByBytesResponse = await faceRecognitionService.FaceCollection.AddAsync(addSubjectExampleRequestByBytes);
#endregion

#region List of All Saved Examples of the Subject
//var listAllSubjectExamplesRequest = new ListAllSubjectExamplesRequest()
//{
//    Page = 0,
//    Size = 0,
//    Subject = TEST_SUBJECT_NAME,
//};

//var listAllSubjectExamplesResponse = await faceRecognitionService.FaceCollection.ListAsync(listAllSubjectExamplesRequest);
#endregion

#region Delete All Examples of the Subject by Name
//var deleteAllExamplesRequest = new DeleteAllExamplesRequest()
//{
//    Subject = TEST_SUBJECT_NAME
//};

//var deleteAllExamplesResponse = await faceRecognitionService.FaceCollection.DeleteAllAsync(deleteAllExamplesRequest);
#endregion

#region Delete Multiple Examples
//var deleteMultipleExampleRequest = new DeleteMultipleExampleRequest()
//{
//    ImageIdList = new List<Guid>
//    {
//        Guid.NewGuid(),
//        Guid.NewGuid(),
//        Guid.NewGuid()
//    }
//};

//var deleteMultipleExamplesResponse = await faceRecognitionService.FaceCollection.DeleteAsync(deleteMultipleExampleRequest);
#endregion

#region Delete an Example of the Subject by ID
//var deleteImageByIdRequest = new DeleteImageByIdRequest()
//{
//    ImageId = Guid.NewGuid(),
//};

//var deleteImageByIdResponse = await faceRecognitionService.FaceCollection.DeleteAsync(deleteImageByIdRequest);
#endregion

#region Direct Download an Image example of the Subject by ID
//var downloadImageByIdDirectlyRequest = new DownloadImageByIdDirectlyRequest()
//{
//    ImageId = Guid.NewGuid(),
//};

//var directDownloadImage = await faceRecognitionService.FaceCollection.DownloadAsync(downloadImageByIdDirectlyRequest);
#endregion

#region Download an Image example of the Subject by ID
//var downloadImageByIdFromSubjectRequest = new DownloadImageByIdFromSubjectRequest()
//{
//    ImageId = Guid.NewGuid(),
//};

//var image = await faceRecognitionService.FaceCollection.DownloadAsync(downloadImageByIdFromSubjectRequest);
#endregion

//RecognizeFaceFromImage

#region Recognize Faces from a Given Image, by File Path
//var recognizeFaceFromImageRequestByFilePath = new RecognizeFaceFromImageRequestByFilePath()
//{
//    FilePath = "Paste here full file path",
//    PredictionCount = 1,
//    DetProbThreshold = 0.81m,
//    Limit = 1,
//    Status = false,
//    FacePlugins = new List<string>()
//            {
//                "landmarks",
//                "gender",
//                "age",
//                "detector",
//                "calculator"
//            }
//};

//var recognizeFaceFromImageByFilePathResponse = await faceRecognitionService.RecognizeFaceFromImage.RecognizeAsync(recognizeFaceFromImageRequestByFilePath);
#endregion

#region Recognize Faces from a Given Image, by URL
//var RecognizeFaceFromImageRequestByFileUrl = new RecognizeFaceFromImageRequestByFileUrl()
//{
//    FileUrl = FILE_URL,
//    PredictionCount = 1,
//    DetProbThreshold = 0.81m,
//    Limit = 1,
//    Status = false,
//    FacePlugins = new List<string>()
//            {
//                "landmarks",
//                "gender",
//                "age",
//                "detector",
//                "calculator"
//            }
//};

//var recognizeFaceFromImageByUrlResponse = await faceRecognitionService.RecognizeFaceFromImage.RecognizeAsync(RecognizeFaceFromImageRequestByFileUrl);
#endregion

#region Recognize Faces from a Given Image, Base64
//var recognizeFacesFromImageWithBase64Request = new RecognizeFacesFromImageWithBase64Request()
//{
//    FileBase64Value = IMAGE_BASE64_STRING,
//    PredictionCount = 1,
//    DetProbThreshold = 0.81m,
//    Limit = 1,
//    Status = false,
//    FacePlugins = new List<string>()
//            {
//                "landmarks",
//                "gender",
//                "age",
//                "detector",
//                "calculator"
//            }
//};

//var recognizeFaceFromImageBase64Response = await faceRecognitionService.RecognizeFaceFromImage.RecognizeAsync(recognizeFacesFromImageWithBase64Request);
#endregion

#region Recognize Faces from a Given Image, Bytes array
//var recognizeFaceFromImageRequestByBytes = new RecognizeFaceFromImageRequestByBytes()
//{
//    ImageInBytes = "Here should be byte array.",
//    PredictionCount = 1,
//    DetProbThreshold = 0.81m,
//    Limit = 1,
//    Status = false,
//    FacePlugins = new List<string>()
//            {
//                "landmarks",
//                "gender",
//                "age",
//                "detector",
//                "calculator"
//            }
//};

//var recognizeFaceFromImageByBytesResponse = await faceRecognitionService.RecognizeFaceFromImage.RecognizeAsync(recognizeFaceFromImageRequestByBytes);
#endregion

#region Verify Faces from a Given Image, by File Path
//var verifyFacesFromImageByFilePathRequest = new VerifyFacesFromImageRequest()
//{
//    FilePath = "Paste here full file path",
//    ImageId = Guid.NewGuid(),
//    DetProbThreshold = 0.81m,
//    Limit = 1,
//    Status = false,
//    FacePlugins = new List<string>()
//            {
//                "landmarks",
//                "gender",
//                "age",
//                "detector",
//                "calculator"
//            }
//};

//var verifyFacesFromImageByFilePathResponse = await faceRecognitionService.RecognizeFaceFromImage.VerifyAsync(verifyFacesFromImageByFilePathRequest);
#endregion

#region Verify Faces from a Given Image, by File Url
//var verifyFacesFromImageByFileUrlRequest = new VerifyFacesFromImageByFileUrlRequest()
//{
//    FileUrl = FILE_URL,
//    ImageId = Guid.NewGuid(),
//    DetProbThreshold = 0.81m,
//    Limit = 1,
//    Status = false,
//    FacePlugins = new List<string>()
//            {
//                "landmarks",
//                "gender",
//                "age",
//                "detector",
//                "calculator"
//            }
//};

//var verifyFacesFromImageByFileUrlResponse = await faceRecognitionService.RecognizeFaceFromImage.VerifyAsync(verifyFacesFromImageByFileUrlRequest);
#endregion

#region Verify Faces from a Given Image, Base64
//var verifyFacesFromImageWithBase64Request = new VerifyFacesFromImageWithBase64Request()
//{
//    FileBase64Value = IMAGE_BASE64_STRING,
//    ImageId = Guid.NewGuid(),
//    DetProbThreshold = 0.81m,
//    Limit = 1,
//    Status = false,
//    FacePlugins = new List<string>()
//            {
//                "landmarks",
//                "gender",
//                "age",
//                "detector",
//                "calculator"
//            }
//};

//var verifyFacesFromImageBase64Response = await faceRecognitionService.RecognizeFaceFromImage.VerifyAsync(verifyFacesFromImageWithBase64Request);
#endregion

#region Verify Faces from a Given Image, Bytes array
//var verifyFacesFromImageWithBase64Request = new VerifyFacesFromImageWithBytesRequest()
//{
//    ImageInBytes = "Here should be byte array.",
//    ImageId = Guid.NewGuid(),
//    DetProbThreshold = 0.81m,
//    Limit = 1,
//    Status = false,
//    FacePlugins = new List<string>()
//            {
//                "landmarks",
//                "gender",
//                "age",
//                "detector",
//                "calculator"
//            }
//};

//var verifyFacesFromImageByBytesResponse = await faceRecognitionService.RecognizeFaceFromImage.VerifyAsync(verifyFacesFromImageWithBase64Request);
#endregion