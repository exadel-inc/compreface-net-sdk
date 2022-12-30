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