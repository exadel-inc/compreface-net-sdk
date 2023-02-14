﻿using Exadel.Compreface.DTOs.HelperDTOs.BaseDTOs;

namespace Exadel.Compreface.DTOs.ExampleSubjectDTOs.AddBase64ExampleSubject
{
    public class AddBase64SubjectExampleRequest : BaseExampleRequest
    {
        public string File { get; set; }

        public string SourceImageFilePath { get; set; }

        public string TargetImageFilePath { get; set; }
    }
}