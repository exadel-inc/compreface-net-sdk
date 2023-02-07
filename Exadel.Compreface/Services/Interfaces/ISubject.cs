using Exadel.Compreface.DTOs.SubjectDTOs.AddSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteAllSubjects;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.GetSubjectList;
using Exadel.Compreface.DTOs.SubjectDTOs.RenameSubject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exadel.Compreface.Services.Interfaces
{
    public interface ISubject
    {
        Task<GetAllSubjectResponse> ListAsync();
        Task<AddSubjectResponse> AddAsync(AddSubjectRequest request);
        Task<RenameSubjectResponse> RenameAsync(RenameSubjectRequest request);
        Task<DeleteSubjectResponse> DeleteAsync(DeleteSubjectRequest request);
        Task<DeleteAllSubjectsResponse> DeleteAllAsync();

    }
}
