﻿using Exadel.Compreface.DTOs.HelperDTOs.BaseDTOs;

namespace Exadel.Compreface.DTOs.FaceCollectionDTOs.AddSubjectExample
{
    public class AddSubjectExampleRequestByBytes : BaseExampleRequest
    {
        public byte[] Bytes { get; set; }
    }
}