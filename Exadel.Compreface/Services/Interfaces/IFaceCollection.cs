using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddBase64ExampleSubject;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddExampleSubject;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteAllSubjectExamples;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteImageById;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DeleteMultipleExamples;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DownloadImageById;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.DownloadImageBySubjectId;
using Exadel.Compreface.DTOs.ExampleSubjectDTOs.ListAllExampleSubject;
using Exadel.Compreface.DTOs.SubjectExampleDTOs.AddSubjectExample;

namespace Exadel.Compreface.Services.Interfaces
{
    public interface IFaceCollection
    {
        Task<AddSubjectExampleResponse> AddAsync(AddSubjectExampleRequestByFilePath request);

        Task<AddSubjectExampleResponse> AddAsync(AddSubjectExampleRequestByFileUrl request);

        Task<AddBase64SubjectExampleResponse> AddAsync(AddBase64SubjectExampleRequest request);

        Task<ListAllSubjectExamplesResponse> ListAsync(ListAllSubjectExamplesRequest request);

        Task<DeleteAllExamplesResponse> DeleteAllAsync(DeleteAllExamplesRequest request);

        Task<DeleteImageByIdResponse> DeleteAsync(DeleteImageByIdRequest request);

        Task<DeleteMultipleExamplesResponse> DeleteAsync(DeleteMultipleExampleRequest deleteMultipleExamplesRequest);

        Task<byte[]> DownloadAsync(DownloadImageByIdDirectlyRequest downloadImageByIdRequest);

        Task<byte[]> DownloadAsync(DownloadImageByIdFromSubjectRequest downloadImageBySubjectIdRequest);
    }
}