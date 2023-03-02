using Exadel.Compreface.DTOs.FaceCollectionDTOs.AddBase64SubjectExample;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.AddSubjectExample;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.DeleteAllSubjectExamples;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.DeleteImageById;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.DeleteMultipleExamples;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.DownloadImageById;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.DownloadImageByIdFromSubject;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.ListAllExampleSubject;

namespace Exadel.Compreface.Services.Interfaces
{
    public interface IFaceCollection
    {
        Task<AddSubjectExampleResponse> AddAsync(AddSubjectExampleRequestByFilePath request);

        Task<AddSubjectExampleResponse> AddAsync(AddSubjectExampleRequestByFileUrl request);

        Task<AddSubjectExampleResponse> AddAsync(AddSubjectExampleRequestByBytes request);

        Task<AddBase64SubjectExampleResponse> AddAsync(AddBase64SubjectExampleRequest request);

        Task<ListAllSubjectExamplesResponse> ListAsync(ListAllSubjectExamplesRequest request);

        Task<DeleteAllExamplesResponse> DeleteAllAsync(DeleteAllExamplesRequest request);

        Task<DeleteImageByIdResponse> DeleteAsync(DeleteImageByIdRequest request);

        Task<DeleteMultipleExamplesResponse> DeleteAsync(DeleteMultipleExampleRequest deleteMultipleExamplesRequest);

        Task<byte[]> DownloadAsync(DownloadImageByIdDirectlyRequest downloadImageByIdRequest);

        Task<byte[]> DownloadAsync(DownloadImageByIdFromSubjectRequest downloadImageBySubjectIdRequest);
    }
}