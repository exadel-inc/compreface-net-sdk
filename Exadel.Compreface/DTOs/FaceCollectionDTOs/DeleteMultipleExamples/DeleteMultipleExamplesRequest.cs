using System;
using System.Collections.Generic;

namespace Exadel.Compreface.DTOs.FaceCollectionDTOs.DeleteMultipleExamples
{
    public class DeleteMultipleExampleRequest
    {
        public IList<Guid> ImageIdList { get; set; }
    }
}