using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddBase64ExampleSubject;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddExampleSubject;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteAllSubjectExamples;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteImageById;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteMultipleExamples;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DownloadImageById;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DownloadImageBySubjectId;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.ListAllExampleSubject;

namespace Exadel.Compreface.Services.Interfaces
{
    public interface IFaceRecognitionService
    {
        Task<AddSubjectExampleResponse> AddSubjectExampleAsync(AddSubjectExampleRequest request, bool isFileInTheRemoteServer = false);
        Task<AddBase64SubjectExampleResponse> AddBase64SubjectExampleAsync(AddBase64SubjectExampleRequest request);
        Task<ListAllSubjectExamplesResponse> GetAllSubjectExamplesAsync(ListAllSubjectExamplesRequest request);
        Task<DeleteAllExamplesResponse> ClearSubjectAsync(DeleteAllExamplesRequest request);

        Task<DeleteImageByIdResponse> DeleteImageByIdAsync(DeleteImageByIdRequest request);
        Task<DeleteMultipleExamplesResponse> DeletMultipleExamplesAsync(DeleteMultipleExampleRequest deleteMultipleExamplesRequest);
        Task<byte[]> DownloadImageByIdAsync(DownloadImageByIdRequest downloadImageByIdRequest);
        Task<byte[]> DownloadImageBySubjectIdAsync(DownloadImageBySubjectIdRequest downloadImageBySubjectIdRequest);
    }
}