﻿using Exadel.Compreface.DTOs.RecognitionDTOs.BaseRequests;

namespace Exadel.Compreface.DTOs.RecognizeFaceFromImageDTOs.RecognizeFaceFromImage
{
    public class RecognizeFaceFromImageRequestByBytes : BaseRecognizeFaceFromImageRequest
    {
        public byte[] ImageInBytes { get; set; }
    }
}