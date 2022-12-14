# Compreface .NET SDK client

**This library can be used to simplify access to Compreface from .NET**

**Subject**


*Get All subjects*

```
    
    var getAllSubjectResponse = await subjectService.GetAllSubject();
    
    foreach (var subject in getAllSubjectResponse.Subjects)
    {
    
        Console.WriteLine(subject);
    
    }

```

*Delete all subjects*

````
        var deleteAllSubjectsResponse = await subjectService.DeleteAllSubjects();
        
        Console.WriteLine(deleteAllSubjectsResponse.Deleted);

````

*Delete subject*

```
        var deleteSubjectRequest = new DeleteSubjectRequest()
        {
            ActualSubject = "Asadbek Sindarov"
        };
        
        var deleteSubjectResponse = await subjectService.DeleteSubject(deleteSubjectRequest);
        
        Console.WriteLine(deleteSubjectResponse.Subject);

```

*Add new Subject*

```
        var addSubjectRequest = new AddSubjectRequest()
        {
            Subject = "Some guy's name"
        };
        
        var addSubjectResponse = await subjectService.AddSubject(addSubjectRequest);
        
        Console.WriteLine(addSubjectResponse.Subject);

```

*Rename Subject*

```
    var renameSubjectRequest = new RenameSubjectRequest()
        {
            CurrentSubject = "Asadbek",
            Subject = "Asadbek Sindarov"
        };
        
        var renameSubjectResponse = await subjectService.RenameSubject(renameSubjectRequest);
        
        Console.WriteLine(renameSubjectResponse.Updated);


```

**Subject Example**

*Get All Example Subject*

```
        var listAllExampleSubjectRequest = new ListAllExampleSubjectRequest()
        {
            Page = 1,
            Size = 1,
            Subject = "Asadbek Sindarov",
        };
        
        var listAllExampleSubjectResponse = await exampleSubjectService.GetAllExampleSubjects(listAllExampleSubjectRequest);
        
        foreach (var exampleSubject in listAllExampleSubjectResponse.Faces)
        {
            Console.WriteLine(exampleSubject.Subject);
            Console.WriteLine(exampleSubject.ImageId);
        }
        
        Console.WriteLine(listAllExampleSubjectResponse.PageNumber);
        Console.WriteLine(listAllExampleSubjectResponse.PageSize);
        Console.WriteLine(listAllExampleSubjectResponse.TotalElements);
        Console.WriteLine(listAllExampleSubjectResponse.TotalPages);

```

*Add Example Subject*

```
        var addExampleSubjectRequest = new AddExampleSubjectRequest()
        {
            DetProbThreShold = 0.81m,
            FilePath = @"image path here",
            Subject = "Asadbek Sindarov",
            FileName = "file name" // Guid.NewGuid().ToString(),
        };
    
        var addExampleSubjectResponse = await exampleSubjectService.AddExampleSubject(addExampleSubjectRequest);
    
        Console.WriteLine(addExampleSubjectResponse.Subject);
        Console.WriteLine(addExampleSubjectResponse.ImageId);
```
*Delete All Examples of the Subject by Name*
```
   await exampleSubjectService.ClearSubjectAsync(new DTOs.ExampleSubject.DeleteAllSubjectExamples.DeleteAllExamplesRequest()
        {
            Subject = "Stars"
        });
```

*Delete an Example of the Subject by ID*
```
    await exampleSubjectService.DeleteImageByIdAsync(new DTOs.ExampleSubject.DeleteImageById.DeleteImageByIdRequest
        {
            ImageId = Guid.Parse("c3dd56c2-1a51-450f-800f-b9fe230a9a7a")
        }
            );
```

*Delete multiple examples*
```
 await exampleSubjectService.DeletMultipleExamplesAsync(
            new DTOs.ExampleSubjectDTOs.DeleteMultipleExamples.DeleteMultipleExampleRequest()
            {
                ImageIdList = new List<Guid>
                {
                    Guid.Parse("39bbf8c8-e7de-4b0c-9035-bbbe3621ab89"),
                    Guid.Parse("208a3002-75cd-4b95-93aa-89c727e454da")
                }
            });
```

*Direct Download an Image example of the Subject by ID*
```
      await exampleSubjectService.DownloadImageByIdAsync(
            new DTOs.ExampleSubject.DownloadImageById.DownloadImageByIdRequest()
            {
                ApiKey = Guid.Parse("e468da55-b884-4865-8c83-f1ad5775f00d"),
                ImageId = Guid.Parse("e0053da2-e0a1-4b6e-b647-5d7108e42aea")
            });
```

*Download an Image example of the Subject by ID*
```
        await exampleSubjectService.DownloadImageBySubjectIdAsync(
            new DTOs.ExampleSubject.DownloadImageBySubjectId.DownloadImageBySubjectIdRequest()
            {
                ImageId = Guid.Parse("e0053da2-e0a1-4b6e-b647-5d7108e42aea")
            });
```


*POST Base64, Add an Example of a Subject*
```
        await exampleSubjectService.AddBase64ExampleSubjectAsync(
     new DTOs.ExampleSubject.AddBase64ExampleSubject.AddBase64ExampleSubjectRequest()
     {
         DetProbThreShold = 0.81m,
         Subject = "Stars",
         File = "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"
     });
```

**Recognition Service**

*Recognize faces from a given image*

```
var recognizeFaceFromImageRequest = new RecognizeFaceFromImageRequest()
        {
            FileName = Guid.NewGuid().ToString() + ".jpg", // file name here....
            FilePath = "", // file path
            DetProbThreshold = 0.85m,
            FacePlugins = new List<string>()
            {
                "landmarks",
                "gender",
                "age",
            },
            Status = true,
        };

        var recognizeFaceFromImageResponse =
            await recognitionService.RecognizeFaceFromImage(recognizeFaceFromImageRequest);

        foreach (var result in recognizeFaceFromImageResponse.Result)
        {
            foreach (var subject in result.Subjects)
            {
                Console.WriteLine($"Subject : {subject.Subject}");
                Console.WriteLine($"Similarity: {subject.Similarity}");
            }
        }
```

*Base64, Recognize Faces from a Given Image*

```
var imageBytes = await File.ReadAllBytesAsync("file path");

        var base64ImageValue = Convert.ToBase64String(imageBytes);

        var recognizeFacesFromImageWithBase64Request = new RecognizeFacesFromImageWithBase64Request()
        {
            FileBase64Value = base64ImageValue,
            DetProbThreshold = 0.85m,
            FacePlugins = new List<string>()
            {
                "landmarks",
                "gender",
                "age",
            },
            Status = true,
        };

        var recognizeFaceFromImageResponse =
            await recognitionService.RecognizeFaceFromBase64File(recognizeFacesFromImageWithBase64Request);

        foreach (var result in recognizeFaceFromImageResponse.Result)
        {
            
        }
```

*Verify Faces from a Given Image*

```
var verifyFacesFromImageRequest = new VerifyFacesFromImageRequest()
        {
            DetProbThreshold = 0.85m,
            FacePlugins = new List<string>()
            {
                "age",
                "gender",
                "mask",
                "calculator",
            },
            FilePath = file path here,
            FileName = Guid.NewGuid().ToString() + ".jpg",
            ImageId = image_id here
        };

        var verifyFacesFromImageResponse = await recognitionService.VerifyFacesFromImage(verifyFacesFromImageRequest);

        foreach (var result in verifyFacesFromImageResponse.Result)
        {
            
        }
```

```
var imageBytes = File.ReadAllBytes("file path here");

        var base64ImageValue = Convert.ToBase64String(imageBytes);
        var verifyFacesFromImageWithBase64Request = new VerifyFacesFromImageWithBase64Request()
        {
            DetProbThreshold = 0.85m,
            FacePlugins = new List<string>()
            {
                "age",
                "mask",
                "gender",
                "detector",
                "calculator",
            },
            FileBase64Value = base64ImageValue,
            ImageId = image_id here,
        };

        var verifyFacesFromImageResponse =
            await recognitionService.VerifyFacesFromBase64File(verifyFacesFromImageWithBase64Request);

        foreach (var result in verifyFacesFromImageResponse.Result)
        {
            
        }
```

**Face Setection Service**

*Face Detection Service*
```
        await comprefaceClientV2.FaceDetectionService.FaceDetectionAsync(
            new DTOs.FaceDetectionDTOs.FaceDetection.FaceDetectionRequest()
            {
                DetProbThreshold = 0.91m,
                FacePlugins = new List<string>()
            {
                "age",
                "gender",
                "mask",
                "calculator",
            },
                Status = true,
                FileName = file name with format
                FilePath = full path to the file,
                Limit = 0
            }
            );
```

*Face Detection Service, Base64*
```
         await comprefaceClientV2.FaceDetectionService.FaceDetectionBase64Async(
        new DTOs.FaceDetectionDTOs.FaceDetectionBase64.FaceDetectionBase64Request()
        {
            DetProbThreshold = 0.91m,
            FacePlugins = new List<string>()
            {
                    "age",
                    "gender",
                    "mask",
                    "calculator",
            },
            Status = true,
            Limit = 0,
            File = "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"
            
        }
    );
```


**Face Verification Service**

*Face Verification Service endpoint*

```
var faceVerificationRequest = new FaceVerificationWithBase64Request()
        {
            DetProbThreshold = 0.88m,
            FacePlugins = new List<string>()
            {
                "age",
                "mask",
                "calculator",
                "gender",
            },
            SourceImageFileName = file name for source image,
            SourceImageFilePath = file path for source image,
            TargetImageFileName = file name for target image,
            TargetImageFilePath = file path for target image,
            Status = true,
        };
        
        var faceVerificationResponse = await comprefaceClient.FaceVerificationService.VerifyImageAsync(faceVerificationRequest);
```

*Face Verification Service endpoint, Base64*

```
var faceVerificationWith64Request = new FaceVerificationWithBase64Request()
        {
            DetProbThreshold = 0.88m,
            FacePlugins = new List<string>()
            {
                "age",
                "mask",
                "calculator",
                "gender",
            },
            SourceImageWithBase64 = source image's base64 value,
            TargetImageWithBase64 = target image's base64 value,
            Status = true,
        };
        
        var faceVerificationResponse = await comprefaceClientV2.FaceVerificationService.VerifyBase64ImageAsync(faceVerificationRequest);
```