using System.Collections.Generic;
using Exadel.Compreface.DTOs.HelperDTOs;
using Exadel.Compreface.DTOs.HelperDTOs.BaseDTOs;

namespace Exadel.Compreface.DTOs.FaceDetectionDTOs.FaceDetection
{
    public class FaceDetectionResponse
    {
        public IList<BaseResult> Result { get; set; }

        public PluginVersions PluginsVersions { get; set; }
    }
}