﻿using System.Collections.Generic;
using Exadel.Compreface.DTOs.HelperDTOs;
using Exadel.Compreface.DTOs.HelperDTOs.BaseDTOs;

namespace Exadel.Compreface.DTOs.RecognitionDTOs.VerifyFacesFromImage
{

    public class VerifyFacesFromImageResponse
    {
        public IList<Result> Result { get; set; }

        public PluginVersions PluginsVersions { get; set; }
    }

    public class Result : BaseResult
    {
        public string Subject { get; set; }

        public decimal Similarity { get; set; }
    }
}