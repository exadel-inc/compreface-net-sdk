# CompreFace .NET SDK

CompreFace NET SDK makes face recognition into your application even easier.

# Table of content
- [Requirements](#requirements)
- [Installation](#installation)
- [Usage](#usage)
  - [Initialization](#initialization)
  - [Adding faces into a face collection](#adding-faces-into-a-face-collection)
  - [Recognition](#recognition)
  - [Webcam demo](#webcam-demo)
- [Reference](#reference)
  - [CompreFace Global Object](#compreFace-global-object)
    - [Services](#Services)
  - [Optional properties](#optional-properties)
  - [Face Recognition Service](#face-recognition-service)
	- [Face Recognition](#face-recognition)
	  - [Recognize Faces from a Given Image](#recognize-faces-from-a-given-image)
	  - [Verify Faces from a Given Image](#verify-faces-from-a-given-image)
    - [Get Face Collection](#get-face-collection)
      - [Add an Example of a Subject](#add-an-example-of-a-subject)
      - [List of All Saved Examples of the Subject](#list-of-all-saved-examples-of-the-subject)
      - [Delete All Examples of the Subject by Name](#delete-all-examples-of-the-subject-by-name)
      - [Delete an Example of the Subject by ID](#delete-an-example-of-the-subject-by-id)
	  - [Direct Download an Image example of the Subject by ID](#direct-download-an-image-by-ID)
	  - [Download an Image example of the Subject by ID](#download-an-image-by-ID)
    - [Get Subjects](#get-subjects)
      - [Add a Subject](#add-a-subject)
      - [List Subjects](#list-subjects)
      - [Rename a Subject](#rename-a-subject)
      - [Delete a Subject](#delete-a-subject)
      - [Delete All Subjects](#delete-all-subjects)
    - [Face Detection Service](#face-detection-service)
      - [Detect](#detect)
    - [Face Verification Service](#face-verification-service)
      - [Verify](#verify)
- [Contributing](#contributing)
    - [Report Bugs](#report-bugs)
    - [Submit Feedback](#submit-feedback)
- [License info](#license-info)

# Requirements

Before using our SDK make sure you have installed CompreFace and .NET on your machine.

1. [CompreFace](https://github.com/exadel-inc/CompreFace#getting-started-with-compreface)
2. [.NET](https://dotnet.microsoft.com/en-us/download) (Version 7+)

## CompreFace compatibility matrix

| CompreFace .NET SDK version   | CompreFace 1.1.0 |
| ------------------------------| ---------------- |
| ?                             | ✔                |

Explanation:

* ✔  SDK supports all functionality from CompreFace. 
* :yellow_circle:  SDK works with this CompreFace version. 
In case if CompreFace version is newer - SDK won't support new features of CompreFace. In case if CompreFace version is older - new SDK features will fail.
* ✘ There are major backward compatibility issues. It is not recommended to use these versions together


# Installation

To use SDK install NuGet package
```
Install-Package ???
```

# Usage

All examples below you can find in repository inside [examples](/examples) folder.

## Initialization

To start using  Compreface .NET SDK you need to import `CompreFace` object from 'compreface-sdk' dependency.

Then you need to create `CompreFaceClient` object and initialize it with `DOMAIN` and `PORT`. By default, if you run CompreFace on your local machine, it's `DOMAIN` will be `http://localhost`, and `PORT` in this case will be `8000`.
You can pass optional `options` object when call method to set default parameters, see reference for [more information](#options-structure).

You should use `RecognitionService` service in `CompreFaceClient` object to recognize faces.

However, before recognizing you need first to add subject into the face collection. To do this, get the `Subject` object with the help of `RecognitionService`. `Subject` is included in `RecognitionService` class.

```
var client = new CompreFaceClient(
    domain: "http://localhost",
    port: "8000");

var recognitionService = client.GetCompreFaceService<RecognitionService>(recognition api key);

var subject = recognitionService.Subject;

var subjectRequest = new AddSubjectRequest()
{
    Subject = "Subject name"
};

var subjectResponse = await subject.AddAsync(subjectRequest);
```

## Adding faces into a face collection

Here is example that shows how to add an image to your face collection from your file system:

```
var faceCollection = recognitionService.FaceCollection;

var request = new AddSubjectExampleRequestByFilePath()
{
    DetProbThreShold = 0.81m,
    Subject = "Subject name",
    FilePath = "Full file path"
};

var response = await faceCollection.AddAsync(request);
```

## Recognition

This code snippet shows how to recognize unknown face.
_Recognize faces from a given image_

```
var recognizeRequest = new RecognizeFaceFromImageRequestByFilePath()
{
    FilePath = "Full file path",
    DetProbThreshold = 0.81m,
    FacePlugins = new List<string>()
    {
        "landmarks",
        "gender",
        "age",
        "detector",
        "calculator"
    },
    Limit = 0,
    PredictionCount = 1,
    Status = true
};

var recognizeResponse = await recognitionService.RecognizeFaceFromImage.RecognizeAsync(recognizeRequest);
```

# Reference

## CompreFace Global Object

Global CompreFace Object is used for initializing connection to CompreFace and setting default values for options.
Default values will be used in every service method if applicable.

**Constructor:**
```CompreFaceClient(domain, port)```

| Argument | Type   | Required | Notes                                     | 
| ---------| ------ | -------- | ----------------------------------------- | 
| domain   | string | required | Domain with protocol where CompreFace is located. E.g. `http://localhost` |
| port     | string | required | CompreFace port. E.g. `8000` |

Example:

```
var client = new CompreFaceClient(
    domain: "http://localhost",
    port: "8000");

```

### Services

1. ```client.GetCompreFaceService<RecognitionService>(apiKey)```

Inits face recognition service object.

| Argument | Type   | Required | Notes                                     |
| ---------| ------ | -------- | ----------------------------------------- |
| apiKey   | string | required | Face Recognition Api Key in UUID format   |

Example:

```
var apiKey = "00000000-0000-0000-0000-000000000002";

var recognitionService = client.GetCompreFaceService<RecognitionService>(apiKey);
```

2. ```client.GetCompreFaceService<FaceDetectionService>(apiKey)```

Inits face detection service object.

| Argument | Type   | Required | Notes                                     |
| ---------| ------ | -------- | ----------------------------------------- |
| apiKey   | string | required | Face Detection Api Key in UUID format     |

Example:

```
var apiKey = "00000000-0000-0000-0000-000000000003";

var faceDetectionService = client.GetCompreFaceService<FaceDetectionService>(api_key);
```

3. ```client.GetCompreFaceService<FaceVerificationService>(apiKey)```

Inits face verification service object.

| Argument | Type   | Required | Notes                                     |
| ---------| ------ | -------- | ----------------------------------------- |
| apiKey   | string | required | Face Verification Api Key in UUID format  |

Example:

```
var apiKey = "00000000-0000-0000-0000-000000000004";

var faceVerificationService = client.GetCompreFaceService<FaceVerificationService>(api_key);
```

## Optional properties
All optional properties are located in the `BaseFaceRequest` class.

```
public class BaseFaceRequest
{
    public int? Limit { get; set; }

    public decimal DetProbThreshold { get; set; }

    public IList<string> FacePlugins { get; set; }

    public bool Status { get; set; }
}
```

`BaseFaceRequest` class is inherited by several DTO classes which are serialized to request format.

Here is description how it looks like in request body.
| Option              | Type    | Notes                                     |
| --------------------| ------  | ----------------------------------------- |
| det_prob_threshold  | float   | minimum required confidence that a recognized face is actually a face. Value is between 0.0 and 1.0 |
| limit               | integer | maximum number of faces on the image to be recognized. It recognizes the biggest faces first. Value of 0 represents no limit. Default value: 0       |
| prediction_count    | integer | maximum number of subject predictions per face. It returns the most similar subjects. Default value: 1    |
| face_plugins        | string  | comma-separated slugs of face plugins. If empty, no additional information is returned. [Learn more](https://github.com/exadel-inc/CompreFace/tree/master/docs/Face-services-and-plugins.md)    |
| status              | boolean | if true includes system information like execution_time and plugin_version fields. Default value is false    |

Example of face recognition with object:
```
var recognizeRequest = new RecognizeFaceFromImageRequestByFilePath()
{
    FilePath = "Full file path",
    DetProbThreshold = 0.81m,
    FacePlugins = new List<string>()
    {
        "landmarks",
        "gender",
        "age",
        "detector",
        "calculator"
    },
    Limit = 0,
    PredictionCount = 1,
    Status = true
};

var recognizeResponse = await recognitionService.RecognizeFaceFromImage.RecognizeAsync(recognizeRequest);
```

## Face Recognition Service

Face recognition service is used for face identification.
This means that you first need to upload known faces to face collection and then recognize unknown faces among them.
When you upload an unknown face, the service returns the most similar faces to it.
Also, face recognition service supports verify endpoint to check if this person from face collection is the correct one.
For more information, see [CompreFace page](https://github.com/exadel-inc/CompreFace).

###Face Recognition

**Methods:**

#### Recognize Faces from a Given Image

Recognizes all faces from the image.
The first argument is the image location, it can be an url, local path or bytes.

```
await recognitionService.RecognizeFaceFromImage.RecognizeAsync(recognizeRequest)
```

| Argument           | Type    						           | Required | Notes                                                                                                                                          |
| ------------------ | --------------------------------------- | -------- | ---------------------------------------------------------------------------------------------------------------------------------------------- |
| recognizeRequest	 |	RecognizeFaceFromImageRequestByFilePath| required | 

`RecognizeFaceFromImageRequestByFilePath` this is data transfer object which is serialized to JSON. 

```
public class RecognizeFaceFromImageRequestByFilePath : BaseRecognizeFaceFromImageRequest
{
    public string FilePath { get; set; }
}
```
`BaseRecognizeFaceFromImageRequest` class:

```
public class BaseRecognizeFaceFromImageRequest : BaseFaceRequest
{
    public int? PredictionCount { get; set; }
}
```

`BaseFaceRequest` class contains **optional** properties:

```
public class BaseFaceRequest
{
    public int? Limit { get; set; }

    public decimal DetProbThreshold { get; set; }

    public IList<string> FacePlugins { get; set; } = new List<string>()

    public bool Status { get; set; }
}
```
| Option              | Type    | Notes                                     |
| --------------------| ------  | ----------------------------------------- |
| det_prob_threshold  | float   | minimum required confidence that a recognized face is actually a face. Value is between 0.0 and 1.0 |
| limit               | integer | maximum number of faces on the image to be recognized. It recognizes the biggest faces first. Value of 0 represents no limit. Default value: 0       |
| prediction_count    | integer | maximum number of subject predictions per face. It returns the most similar subjects. Default value: 1    |
| face_plugins        | string  | comma-separated slugs of face plugins. If empty, no additional information is returned. [Learn more](https://github.com/exadel-inc/CompreFace/tree/master/docs/Face-services-and-plugins.md)    |
| status              | boolean | if true includes system information like execution_time and plugin_version fields. Default value is false    |

Response from ComreFace API:

```
{
  "result" : [ {
    "age" : {
      "probability": 0.9308982491493225,
      "high": 32,
      "low": 25
    },
    "gender" : {
      "probability": 0.9898611307144165,
      "value": "female"
    },
    "mask" : {
      "probability": 0.9999470710754395,
      "value": "without_mask"
    },
    "embedding" : [ 9.424854069948196E-4, "...", -0.011415496468544006 ],
    "box" : {
      "probability" : 1.0,
      "x_max" : 1420,
      "y_max" : 1368,
      "x_min" : 548,
      "y_min" : 295
    },
    "landmarks" : [ [ 814, 713 ], [ 1104, 829 ], [ 832, 937 ], [ 704, 1030 ], [ 1017, 1133 ] ],
    "subjects" : [ {
      "similarity" : 0.97858,
      "subject" : "subject1"
    } ],
    "execution_time" : {
      "age" : 28.0,
      "gender" : 26.0,
      "detector" : 117.0,
      "calculator" : 45.0,
      "mask": 36.0
    }
  } ],
  "plugins_versions" : {
    "age" : "agegender.AgeDetector",
    "gender" : "agegender.GenderDetector",
    "detector" : "facenet.FaceDetector",
    "calculator" : "facenet.Calculator",
    "mask": "facemask.MaskDetector"
  }
}
```

| Element                    | Type    | Description                                                                                                                                                 |
| -------------------------- | ------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------- |
| age                        | object  | detected age range. Return only if [age plugin](https://github.com/exadel-inc/CompreFace/blob/master/docs/Face-services-and-plugins.md) is enabled                                                       |
| gender                     | object  | detected gender. Return only if [gender plugin](https://github.com/exadel-inc/CompreFace/blob/master/docs/Face-services-and-plugins.md) is enabled                                                       |
| mask                       | object  | detected mask. Return only if [face mask plugin](https://github.com/exadel-inc/CompreFace/blob/master/docs/Face-services-and-plugins.md) is enabled.          |
| embedding                  | array   | face embeddings. Return only if [calculator plugin](https://github.com/exadel-inc/CompreFace/blob/master/docs/Face-services-and-plugins.md) is enabled                                                   |
| box                        | object  | list of parameters of the bounding box for this face                                                                                                        |
| probability                | float   | probability that a found face is actually a face                                                                                                            |
| x_max, y_max, x_min, y_min | integer | coordinates of the frame containing the face                                                                                                                |
| landmarks                  | array   | list of the coordinates of the frame containing the face-landmarks.|
| subjects                   | list    | list of similar subjects with size of <prediction_count> order by similarity                                                                                |
| similarity                 | float   | similarity that on that image predicted person                                                                                                              |
| subject                    | string  | name of the subject in Face Collection                                                                                                                      |
| execution_time             | object  | execution time of all plugins                                                                                                                               |
| plugins_versions           | object  | contains information about plugin versions                                                                                                                  |

This JSON response is deserialized to `RecognizeFaceFromImageResponse` data transfer object(DTO).

```
public class RecognizeFaceFromImageResponse
{
    public IList<Result> Result { get; set; }

    public PluginVersions PluginsVersions { get; set; }
}

public class Result : BaseResult
{
    public IList<SimilarSubject> Subjects { get; set; }
} 
```

`BaseResult` class:
```
public class BaseResult
{
    public Age Age { get; set; }

    public Gender Gender { get; set; }

    public Mask Mask { get; set; }

    public Box Box { get; set; }

    public IList<List<int>> Landmarks { get; set; }

    public ExecutionTime ExecutionTime { get; set; }

    public IList<decimal> Embedding { get; set; }
}
```

#### Verify Faces from a Given Image

```
await recognitionService.RecognizeFaceFromImage.VerifyAsync(request);
```

Compares similarities of given image with image from your face collection.

| Argument| Type    			       | Required | Notes                                                                                                                                          |
| ------- | -------------------------- | -------- | ---------------------------------------------------------------------------------------------------------------------------------------------- |
| request |	VerifyFacesFromImageRequest| required | 

`VerifyFacesFromImageRequest` this is data transfer object which is serialized to JSON.

```
public class VerifyFacesFromImageRequest : BaseVerifyFacesFromImageRequest
{
    public string FilePath { get; set; }
}
```

`BaseVerifyFacesFromImageRequest` class:

```
public class BaseVerifyFacesFromImageRequest : BaseFaceRequest
{
    public Guid ImageId { get; set; }
}
```

`BaseFaceRequest` class contains **optional** properties:

```
public class BaseFaceRequest
{
    public int? Limit { get; set; }

    public decimal DetProbThreshold { get; set; }

    public IList<string> FacePlugins { get; set; }

    public bool Status { get; set; }
}
```
| Option              | Type    | Notes                                     |
| --------------------| ------  | ----------------------------------------- |
| det_prob_threshold  | float   | minimum required confidence that a recognized face is actually a face. Value is between 0.0 and 1.0 |
| limit               | integer | maximum number of faces on the image to be recognized. It recognizes the biggest faces first. Value of 0 represents no limit. Default value: 0       |
| prediction_count    | integer | maximum number of subject predictions per face. It returns the most similar subjects. Default value: 1    |
| face_plugins        | string  | comma-separated slugs of face plugins. If empty, no additional information is returned. [Learn more](https://github.com/exadel-inc/CompreFace/tree/master/docs/Face-services-and-plugins.md)    |
| status              | boolean | if true includes system information like execution_time and plugin_version fields. Default value is false    |

Response:
```json
{
  "result" : [ {
    "age" : {
      "probability": 0.9308982491493225,
      "high": 32,
      "low": 25
    },
    "gender" : {
      "probability": 0.9898611307144165,
      "value": "female"
    },
    "mask" : {
      "probability": 0.9999470710754395,
      "value": "without_mask"
    },
    "embedding" : [ 9.424854069948196E-4, "...", -0.011415496468544006 ],
    "box" : {
      "probability" : 1.0,
      "x_max" : 1420,
      "y_max" : 1368,
      "x_min" : 548,
      "y_min" : 295
    },
    "landmarks" : [ [ 814, 713 ], [ 1104, 829 ], [ 832, 937 ], [ 704, 1030 ], [ 1017, 1133 ] ],
    "subjects" : [ {
      "similarity" : 0.97858,
      "subject" : "subject1"
    } ],
    "execution_time" : {
      "age" : 28.0,
      "gender" : 26.0,
      "detector" : 117.0,
      "calculator" : 45.0,
      "mask": 36.0
    }
  } ],
  "plugins_versions" : {
    "age" : "agegender.AgeDetector",
    "gender" : "agegender.GenderDetector",
    "detector" : "facenet.FaceDetector",
    "calculator" : "facenet.Calculator",
    "mask": "facemask.MaskDetector"
  }
}
```

| Element                        | Type    | Description                                                  |
| ------------------------------ | ------- | ------------------------------------------------------------ |
| age                            | object  | detected age range. Return only if [age plugin](https://github.com/exadel-inc/CompreFace/tree/master/docs/Face-services-and-plugins.md#face-plugins) is enabled         |
| gender                         | object  | detected gender. Return only if [gender plugin](https://github.com/exadel-inc/CompreFace/tree/master/docs/Face-services-and-plugins.md#face-plugins) is enabled         |
| mask                           | object  | detected mask. Return only if [face mask plugin](https://github.com/exadel-inc/CompreFace/blob/master/docs/Face-services-and-plugins.md) is enabled.          |
| embedding                      | array   | face embeddings. Return only if [calculator plugin](https://github.com/exadel-inc/CompreFace/tree/master/docs/Face-services-and-plugins.md#face-plugins) is enabled      |
| box                            | object  | list of parameters of the bounding box for this face         |
| probability                    | float   | probability that a found face is actually a face             |
| x_max, y_max, x_min, y_min     | integer | coordinates of the frame containing the face                 |
| landmarks                      | array   | list of the coordinates of the frame containing the face-landmarks. Return only if [landmarks plugin](https://github.com/exadel-inc/CompreFace/tree/master/docs/Face-services-and-plugins.md#face-plugins) is enabled      |
| similarity                     | float   | similarity that on that image predicted person               |
| execution_time                 | object  | execution time of all plugins                       |
| plugins_versions               | object  | contains information about plugin versions                       |

This JSON response is deserialized to `VerifyFacesFromImageResponse` data transfer object(DTO).

```
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
```

`BaseResult` class:

```
public class BaseResult
{
    public Age Age { get; set; }

    public Gender Gender { get; set; }

    public Mask Mask { get; set; }

    public Box Box { get; set; }

    public IList<List<int>> Landmarks { get; set; }

    public ExecutionTime ExecutionTime { get; set; }

    public IList<decimal> Embedding { get; set; }
}
```

`ExecutionTime` class:

```
public class ExecutionTime
{
    public decimal Age { get; set; }

    public decimal Gender { get; set; }

    public decimal Detector { get; set; }

    public decimal Calculator { get; set; }

    public decimal Mask { get; set; }
}
```

### Get Face Collection

```
recognitionService.FaceCollection
```

Returns Face collection object

Face collection could be used to manage known faces, e.g. add, list, or delete them.

Face recognition is performed for the saved known faces in face collection, so before using the `recognize` method you need to save at least one face into the face collection.

More information about face collection and managing examples [here](https://github.com/exadel-inc/CompreFace/blob/master/docs/Rest-API-description.md#managing-subject-examples)

**Methods:**

#### Add an Example of a Subject

This creates an example of the subject by saving images. You can add as many images as you want to train the system. Image should
contain only one face.

```
await recognitionService.FaceCollection.AddAsync(request);
```

| Argument| Type    						       | Required | Notes                                                                                                                                          |
| ------- | -------------------------------------- | -------- | ---------------------------------------------------------------------------------------------------------------------------------------------- |
| request |	AddSubjectExampleRequestByFilePath     | required | 

`AddSubjectExampleRequestByFilePath` this is data transfer object which is serialized to JSON.

```
public class AddSubjectExampleRequestByFilePath : BaseExampleRequest
{
    public string FilePath { get; set; }
}
``` 

`BaseExampleRequest` class:

```
namespace Exadel.Compreface.DTOs.HelperDTOs.BaseDTOs
{
    public class BaseExampleRequest
    {
        public string Subject { get; set; }

        public decimal? DetProbThreShold { get; set; }
    }
}
```
| Option              | Type    | Notes                                     |
| --------------------| ------  | ----------------------------------------- |
| det_prob_threshold  | float   | minimum required confidence that a recognized face is actually a face. Value is between 0.0 and 1.0 |

`DetProbThreShold` is optional property.

Response:

```
{
  "image_id": "6b135f5b-a365-4522-b1f1-4c9ac2dd0728",
  "subject": "SubjectName"
}
```

| Element  | Type   | Description                |
| -------- | ------ | -------------------------- |
| image_id | UUID   | UUID of uploaded image     |
| subject  | string | Subject of the saved image |

This JSON response is deserialized to `AddSubjectExampleResponse` data transfer object(DTO).

```
public class AddSubjectExampleResponse
{
    public Guid ImageId { get; set; }

    public string Subject { get; set; }
}
```

#### List of All Saved Examples of the Subject

To retrieve a list of subjects saved in a Face Collection:

```
await recognitionService.FaceCollection.ListAsync(request);
```

| Argument| Type    					 | Required | Notes                                                                                                                                          |
| ------- | ---------------------------- | -------- | ---------------------------------------------------------------------------------------------------------------------------------------------- |
| request |	ListAllSubjectExamplesRequest| required | 

`ListAllSubjectExamplesRequest` this is data transfer object which is serialized to JSON.

```

public class ListAllSubjectExamplesRequest
{
    public int? Page { get; set; }
    
    public int? Size { get; set; }
    
    public string Subject { get; set; }
}
```

| Argument| Type| Required | Notes                                                                                                                                          |
| ------- | --- | -------- | ---------------------------------------------------------------------------------------------------------------------------------------------- |
| Page    |	int | optional | Page number of examples to return. Can be used for pagination. Default value is 0. Since 0.6 version.
| Size    |	int | optional | Faces on page (page size). Can be used for pagination. Default value is 20. Since 0.6 version.
| Subject |	int | optional | What subject examples endpoint should return. If empty, return examples for all subjects. Since 1.0 version

Response:
```
{
  "faces": [
    {
      "image_id": <image_id>,
      "subject": <subject>
    },
    ...
  ]
}
```

| Element  | Type   | Description                                                       |
| -------- | ------ | ----------------------------------------------------------------- |
| image_id | UUID   | UUID of the face                                                  |
| subject  | string | <subject> of the person, whose picture was saved for this api key |

This JSON response is deserialized to `ListAllSubjectExamplesResponse` data transfer object(DTO).

```
public class ListAllSubjectExamplesResponse
{
    public IList<Face> Faces { get; set; }

    public int PageNumber { get; set; }

    public int PageSize { get; set; }
    
    public int TotalPages { get; set; }
    
    public int TotalElements { get; set; }
}
```

`Face` class:

```
public class Face
{
    public Guid ImageId { get; set; }
    
    public string Subject{ get; set; }
}
```


#### Delete All Examples of the Subject by Name

To delete all image examples of the <subject>:

```
recognitionService.FaceCollection.DeleteAllAsync(request);
```

| Argument| Type    				| Required | Notes                                                                                                                                          |
| ------- | ----------------------- | -------- | ---------------------------------------------------------------------------------------------------------------------------------------------- |
| request |	DeleteAllExamplesRequest| required | 

`DeleteAllExamplesRequest` this is data transfer object which is serialized to JSON.

```
public class DeleteMultipleExampleRequest
{
	public IList<Guid> ImageIdList { get; set; }
}
```

Response:
```
{
    "deleted": <count>
}
```
| Element  | Type    | Description              |
| -------- | ------- | ------------------------ |
| deleted  | integer | Number of deleted faces  |

This JSON response is deserialized to `DeleteMultipleExamplesResponse` data transfer object(DTO).

```
public class DeleteMultipleExamplesResponse
{
	public IList<Face> Faces { get; set; }
}
```


#### Delete an Example of the Subject by ID

To delete an image by ID:

```
await recognitionService.FaceCollection.DeleteAsync(request);
```
| Argument| Type    			  | Required | Notes                                                                                                                                          |
| ------- | --------------------- | -------- | ---------------------------------------------------------------------------------------------------------------------------------------------- |
| request |	DeleteImageByIdRequest| required | 

`DeleteImageByIdRequest` this is data transfer object which is serialized to JSON.

```
public class DeleteImageByIdRequest
{
	public Guid ImageId { get; set; }
}
```

Response:
```
{
  "image_id": <image_id>,
  "subject": <subject>
}
```

| Element  | Type   | Description                                                       |
| -------- | ------ | ----------------------------------------------------------------- |
| image_id | UUID   | UUID of the removed face                                          |
| subject  | string | <subject> of the person, whose picture was saved for this api key |

This JSON response is deserialized to `DeleteImageByIdResponse` data transfer object(DTO).

```
public class DeleteImageByIdResponse
{
	public Guid ImageId { get; set; }

	public string Subject { get; set; }
}
```

#### Direct Download an Image example of the Subject by ID

To download an image by ID:

```
await recognitionService.FaceCollection.DownloadAsync(downloadImageByIdRequest);
```
| Argument| Type    			            | Required | Notes                                                                                                                                          |
| ------- | ------------------------------- | -------- | ---------------------------------------------------------------------------------------------------------------------------------------------- |
| request |	DownloadImageByIdDirectlyRequest| required | 

`DownloadImageByIdDirectlyRequest` this is data transfer object which is serialized to JSON.

```
public class DownloadImageByIdDirectlyRequest
{
	public Guid ImageId { get; set; }

    public Guid RecognitionApiKey { get; set; }
}
```

**Response body** is binary image. Empty bytes if image not found.

#### Download an Image example of the Subject by ID
`since 0.6 version`

To download an image example of the Subject by ID:

```
await recognitionService.FaceCollection.DownloadAsync(downloadImageBySubjectIdRequest);
```
| Argument| Type    			               | Required | Notes                                                                                                                                          |
| ------- | ---------------------------------- | -------- | ---------------------------------------------------------------------------------------------------------------------------------------------- |
| request |	DownloadImageByIdFromSubjectRequest| required | 

`DownloadImageByIdFromSubjectRequest` this is data transfer object which is serialized to JSON.

```
public class DownloadImageByIdFromSubjectRequest
{
	public Guid ImageId { get; set; }
}
```

**Response body** is binary image. Empty bytes if image not found.

		
### Get Subjects

```
recognitionService.Subject
```

Returns subjects object
Subjects object allows working with subjects directly (not via subject examples).
More information about subjects [here](https://github.com/exadel-inc/CompreFace/blob/master/docs/Rest-API-description.md#managing-subjects)


**Methods:**

#### Add a Subject

Create a new subject in Face Collection.
```
await recognitionService.Subject.AddAsync(request);
```

| Argument| Type    		 | Required | Notes                                                                                                                                          |
| ------- | ---------------- | -------- | ---------------------------------------------------------------------------------------------------------------------------------------------- |
| request |	AddSubjectRequest| required | 

`AddSubjectRequest` this is data transfer object which is serialized to JSON.

```
public class AddSubjectRequest
{
    public string Subject { get; set; }
}
```

Response:
```json
{
  "subject": "subject1"
}
```

| Element  | Type   | Description                |
| -------- | ------ | -------------------------- |
| subject  | string | is the name of the subject |

This JSON response is deserialized to `AddSubjectResponse` data transfer object(DTO).

```
public class AddSubjectResponse
{
    public string Subject { get; set; }
}
```


#### List Subjects

Returns all subject related to Face Collection.
```
await recognitionService.Subject.ListAsync();
```

Response:

```json
{
  "subjects": [
    "<subject_name1>",
    "<subject_name2>"
  ]
}
```

| Element  | Type   | Description                |
| -------- | ------ | -------------------------- |
| subjects | array  | the list of subjects in Face Collection |

This JSON response is deserialized to `GetAllSubjectResponse` data transfer object(DTO).

```
public class GetAllSubjectResponse
{
    public IList<string> Subjects { get; set; }
}
```

#### Rename a Subject

Rename existing subject. If a new subject name already exists, subjects are merged - all faces from the old subject name are reassigned to the subject with the new name, old subject removed.

```
await recognitionService.Subject.RenameAsync(request);
```

| Argument| Type    		    | Required | Notes                                                                                                                                          |
| ------- | ------------------- | -------- | ---------------------------------------------------------------------------------------------------------------------------------------------- |
| request |	RenameSubjectRequest| required | 

`RenameSubjectRequest` this is data transfer object which is serialized to JSON.

```
public class RenameSubjectRequest
{
    public string CurrentSubject { get; set; }

    public string Subject { get; set; }
}
```

Response:

```json
{
  "updated": "true|false"
}
```

| Element  | Type    | Description                |
| -------- | ------  | -------------------------- |
| updated  | boolean | failed or success          |

This JSON response is deserialized to `RenameSubjectResponse` data transfer object(DTO).

```
public class RenameSubjectResponse
{
    public bool Updated { get; set; }
}
```


#### Delete a Subject

Delete existing subject and all saved faces.
```
await recognitionService.Subject.DeleteAsync(request);
```

| Argument| Type    		    | Required | Notes                                                                                                                                          |
| ------- | ------------------- | -------- | ---------------------------------------------------------------------------------------------------------------------------------------------- |
| request |	DeleteSubjectRequest| required |       

`DeleteSubjectRequest` this is data transfer object which is serialized to JSON.

```
public class RenameSubjectRequest
{
    public string CurrentSubject { get; set; }

    public string Subject { get; set; }
}
```                                     

Response:
```json
{
  "subject": "subject1"
}
```

| Element  | Type   | Description                |
| -------- | ------ | -------------------------- |
| subject  | string | is the name of the subject |

This JSON response is deserialized to `DeleteSubjectResponse` data transfer object(DTO).

```
public class DeleteSubjectResponse
{
    public string Subject { get; set; }
}
```


#### Delete All Subjects

Delete all existing subjects and all saved faces.
```
await recognitionService.Subject.DeleteAllAsync();
```

Response:
```json
{
  "deleted": "<count>"
}
```

| Element  | Type    | Description                |
| -------- | ------- | -------------------------- |
| deleted  | integer | number of deleted subjects |

This JSON response is deserialized to `DeleteAllSubjectsResponse` data transfer object(DTO).

```
public class DeleteAllSubjectsResponse
{
    public int Deleted { get; set; }
}
```


## Face Detection Service

Face detection service is used for detecting faces in the image.

**Methods:**

### Detect

```
await faceDetectionService.DetectAsync(request);
```

Finds all faces on the image.

| Argument| Type    		              | Required | Notes                                                                                                                                          |
| ------- | ----------------------------- | -------- | ---------------------------------------------------------------------------------------------------------------------------------------------- |
| request |	FaceDetectionRequestByFilePath| required | 

`FaceDetectionRequestByFilePath` this is data transfer object which is serialized to JSON.

```
public class FaceDetectionRequestByFilePath : BaseFaceRequest
{
	public string FilePath { get; set; }
}
```

`BaseFaceRequest` class contains **optional** properties:

```
public class BaseFaceRequest
{
    public int? Limit { get; set; }

    public decimal DetProbThreshold { get; set; }

    public IList<string> FacePlugins { get; set; }

    public bool Status { get; set; }
}
```
| Option              | Type    | Notes                                     |
| --------------------| ------  | ----------------------------------------- |
| det_prob_threshold  | float   | minimum required confidence that a recognized face is actually a face. Value is between 0.0 and 1.0 |
| limit               | integer | maximum number of faces on the image to be recognized. It recognizes the biggest faces first. Value of 0 represents no limit. Default value: 0       |
| prediction_count    | integer | maximum number of subject predictions per face. It returns the most similar subjects. Default value: 1    |
| face_plugins        | string  | comma-separated slugs of face plugins. If empty, no additional information is returned. [Learn more](https://github.com/exadel-inc/CompreFace/tree/master/docs/Face-services-and-plugins.md)    |
| status              | boolean | if true includes system information like execution_time and plugin_version fields. Default value is false    |

Response:

```json
{
  "result" : [ {
    "age" : {
      "probability": 0.9308982491493225,
      "high": 32,
      "low": 25
    },
    "gender" : {
      "probability": 0.9898611307144165,
      "value": "female"
    },
    "mask" : {
      "probability": 0.9999470710754395,
      "value": "without_mask"
    },
    "embedding" : [ -0.03027934394776821, "...", -0.05117142200469971 ],
    "box" : {
      "probability" : 0.9987509250640869,
      "x_max" : 376,
      "y_max" : 479,
      "x_min" : 68,
      "y_min" : 77
    },
    "landmarks" : [ [ 156, 245 ], [ 277, 253 ], [ 202, 311 ], [ 148, 358 ], [ 274, 365 ] ],
    "execution_time" : {
      "age" : 30.0,
      "gender" : 26.0,
      "detector" : 130.0,
      "calculator" : 49.0,
      "mask": 36.0
    }
  } ],
  "plugins_versions" : {
    "age" : "agegender.AgeDetector",
    "gender" : "agegender.GenderDetector",
    "detector" : "facenet.FaceDetector",
    "calculator" : "facenet.Calculator",
    "mask": "facemask.MaskDetector"
  }
}
```

| Element                        | Type    | Description                                                  |
| ------------------------------ | ------- | ------------------------------------------------------------ |
| age                            | object  | detected age range. Return only if [age plugin](https://github.com/exadel-inc/CompreFace/tree/master/docs/Face-services-and-plugins.md#face-plugins) is enabled         |
| gender                         | object  | detected gender. Return only if [gender plugin](https://github.com/exadel-inc/CompreFace/tree/master/docs/Face-services-and-plugins.md#face-plugins) is enabled         |
| mask                           | object  | detected mask. Return only if [face mask plugin](https://github.com/exadel-inc/CompreFace/blob/master/docs/Face-services-and-plugins.md) is enabled.          |
| embedding                      | array   | face embeddings. Return only if [calculator plugin](https://github.com/exadel-inc/CompreFace/tree/master/docs/Face-services-and-plugins.md#face-plugins) is enabled      |
| box                            | object  | list of parameters of the bounding box for this face (on processedImage) |
| probability                    | float   | probability that a found face is actually a face (on processedImage)     |
| x_max, y_max, x_min, y_min     | integer | coordinates of the frame containing the face (on processedImage)         |
| landmarks                      | array   | list of the coordinates of the frame containing the face-landmarks. Return only if [landmarks plugin](https://github.com/exadel-inc/CompreFace/tree/master/docs/Face-services-and-plugins.md#face-plugins) is enabled      |
| execution_time                 | object  | execution time of all plugins                       |
| plugins_versions               | object  | contains information about plugin versions                       |

This JSON response is deserialized to `FaceDetectionResponse` data transfer object(DTO).

```
public class FaceDetectionResponse
{
	public IList<BaseResult> Result { get; set; }

	public PluginVersions PluginsVersions { get; set; }
}
```

`BaseResult` class:

```
public class BaseResult
{
    public Age Age { get; set; }

    public Gender Gender { get; set; }

    public Mask Mask { get; set; }

    public Box Box { get; set; }

    public IList<List<int>> Landmarks { get; set; }

    public ExecutionTime ExecutionTime { get; set; }

    public IList<decimal> Embedding { get; set; }
}
```


## Face Verification Service


Face verification service is used for comparing two images.
A source image should contain only one face which will be compared to all faces on the target image.

**Methods:**

### Verify

```
await faceVerificationService.VerifyAsync(request);
```

Compares two images provided in arguments. Source image should contain only one face, it will be compared to all faces in the target image.

| Argument| Type    		                 | Required | Notes                                                                                                                                          |
| ------- | -------------------------------- | -------- | ---------------------------------------------------------------------------------------------------------------------------------------------- |
| request |	FaceVerificationRequestByFilePath| required | 

`FaceVerificationRequestByFilePath` this is data transfer object which is serialized to JSON.

```
public class FaceVerificationRequestByFilePath : BaseFaceRequest
{
    public string SourceImageFilePath { get; set; }

    public string TargetImageFilePath { get; set; }
}
```

`BaseFaceRequest` class contains **optional** properties:

```
public class BaseFaceRequest
{
    public int? Limit { get; set; }

    public decimal DetProbThreshold { get; set; }

    public IList<string> FacePlugins { get; set; }

    public bool Status { get; set; }
}
```
| Option              | Type    | Notes                                     |
| --------------------| ------  | ----------------------------------------- |
| det_prob_threshold  | float   | minimum required confidence that a recognized face is actually a face. Value is between 0.0 and 1.0 |
| limit               | integer | maximum number of faces on the image to be recognized. It recognizes the biggest faces first. Value of 0 represents no limit. Default value: 0       |
| prediction_count    | integer | maximum number of subject predictions per face. It returns the most similar subjects. Default value: 1    |
| face_plugins        | string  | comma-separated slugs of face plugins. If empty, no additional information is returned. [Learn more](https://github.com/exadel-inc/CompreFace/tree/master/docs/Face-services-and-plugins.md)    |
| status              | boolean | if true includes system information like execution_time and plugin_version fields. Default value is false    |

Response:

```json
{
  "result" : [{
    "source_image_face" : {
      "age" : {
        "probability": 0.9308982491493225,
        "high": 32,
        "low": 25
      },
      "gender" : {
        "probability": 0.9898611307144165,
        "value": "female"
      },
      "mask" : {
        "probability": 0.9999470710754395,
        "value": "without_mask"
      },
      "embedding" : [ -0.0010271212086081505, "...", -0.008746841922402382 ],
      "box" : {
        "probability" : 0.9997453093528748,
        "x_max" : 205,
        "y_max" : 167,
        "x_min" : 48,
        "y_min" : 0
      },
      "landmarks" : [ [ 92, 44 ], [ 130, 68 ], [ 71, 76 ], [ 60, 104 ], [ 95, 125 ] ],
      "execution_time" : {
        "age" : 85.0,
        "gender" : 51.0,
        "detector" : 67.0,
        "calculator" : 116.0,
        "mask": 36.0
      }
    },
    "face_matches": [
      {
        "age" : {
          "probability": 0.9308982491493225,
          "high": 32,
          "low": 25
        },
        "gender" : {
          "probability": 0.9898611307144165,
          "value": "female"
        },
        "mask" : {
          "probability": 0.9999470710754395,
          "value": "without_mask"
        },
        "embedding" : [ -0.049007344990968704, "...", -0.01753818802535534 ],
        "box" : {
          "probability" : 0.99975,
          "x_max" : 308,
          "y_max" : 180,
          "x_min" : 235,
          "y_min" : 98
        },
        "landmarks" : [ [ 260, 129 ], [ 273, 127 ], [ 258, 136 ], [ 257, 150 ], [ 269, 148 ] ],
        "similarity" : 0.97858,
        "execution_time" : {
          "age" : 59.0,
          "gender" : 30.0,
          "detector" : 177.0,
          "calculator" : 70.0,
          "mask": 36.0
        }
      }],
    "plugins_versions" : {
      "age" : "agegender.AgeDetector",
      "gender" : "agegender.GenderDetector",
      "detector" : "facenet.FaceDetector",
      "calculator" : "facenet.Calculator",
      "mask": "facemask.MaskDetector"
    }
  }]
}
```
| Element                        | Type    | Description                                                  |
| ------------------------------ | ------- | ------------------------------------------------------------ |
| source_image_face              | object  | additional info about source image face |
| face_matches                   | array   | result of face verification |
| age                            | object  | detected age range. Return only if [age plugin](https://github.com/exadel-inc/CompreFace/tree/master/docs/Face-services-and-plugins.md#face-plugins) is enabled         |
| gender                         | object  | detected gender. Return only if [gender plugin](https://github.com/exadel-inc/CompreFace/tree/master/docs/Face-services-and-plugins.md#face-plugins) is enabled         |
| mask                           | object  | detected mask. Return only if [face mask plugin](https://github.com/exadel-inc/CompreFace/blob/master/docs/Face-services-and-plugins.md) is enabled.          |
| embedding                      | array   | face embeddings. Return only if [calculator plugin](https://github.com/exadel-inc/CompreFace/tree/master/docs/Face-services-and-plugins.md#face-plugins) is enabled      |
| box                            | object  | list of parameters of the bounding box for this face         |
| probability                    | float   | probability that a found face is actually a face             |
| x_max, y_max, x_min, y_min     | integer | coordinates of the frame containing the face                 |
| landmarks                      | array   | list of the coordinates of the frame containing the face-landmarks. Return only if [landmarks plugin](https://github.com/exadel-inc/CompreFace/tree/master/docs/Face-services-and-plugins.md#face-plugins) is enabled      |
| similarity                     | float   | similarity between this face and the face on the source image               |
| execution_time                 | object  | execution time of all plugins                       |
| plugins_versions               | object  | contains information about plugin versions                       |

This JSON response is deserialized to `FaceVerificationResponse` data transfer object(DTO).

```
public class FaceVerificationResponse 
{
    public IList<Result> Result { get; set; }
}

public class Result
{
    public SourceImageFace SourceImageFace { get; set; }
    
    public IList<FaceMatches> FaceMatches { get; set; }
    
    public PluginVersions PluginsVersions { get; set; }
}

public class SourceImageFace : BaseResult
{ }

public class FaceMatches : BaseResult
{
    public decimal Similarity { get; set; }
}
```

`BaseResult` class:

```
public class BaseResult
{
    public Age Age { get; set; }

    public Gender Gender { get; set; }

    public Mask Mask { get; set; }

    public Box Box { get; set; }

    public IList<List<int>> Landmarks { get; set; }

    public ExecutionTime ExecutionTime { get; set; }

    public IList<decimal> Embedding { get; set; }
}
```


# Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are greatly appreciated.

1.  Fork the Project
2.  Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3.  Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4.  Push to the Branch (`git push origin feature/AmazingFeature`)
5.  Open a Pull Request

After creating your first contributing pull request, you will receive a request to sign our Contributor License Agreement by commenting your pull request with a special message.

## Report Bugs

Please report any bugs  [here](https://github.com/exadel-inc/compreface-net-sdk/issues).

If you are reporting a bug, please specify:

-   Your operating system name and version
-   Any details about your local setup that might be helpful in troubleshooting
-   Detailed steps to reproduce the bug

## Submit Feedback


The best way to send us feedback is to file an issue at  [https://github.com/exadel-inc/compreface-net-sdk/issues](https://github.com/exadel-inc/compreface-net-sdk/issues).

If you are proposing a feature, please:

-   Explain in detail how it should work.
-   Keep the scope as narrow as possible to make it easier to implement.

# License info

CompreFace .NET SDK is open-source facial recognition SDK released under the [Apache 2.0 license](https://www.apache.org/licenses/LICENSE-2.0.html).
