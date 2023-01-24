# CompreFace .NET SDK

This library can be used to simplify access to Compreface from .NET

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
    - [Methods](#methods)
  - [Options structure](#options-structure)
  - [Face Recognition Service](#face-recognition-service)
    - [Recognize Faces from a Given Image](#recognize-faces-from-a-given-image)
    - [Get Face Collection](#get-face-collection)
      - [Add an Example of a Subject](#add-an-example-of-a-subject)
      - [List of All Saved Examples of the Subject](#list-of-all-saved-examples-of-the-subject)
      - [Delete All Examples of the Subject by Name](#delete-all-examples-of-the-subject-by-name)
      - [Delete an Example of the Subject by ID](#delete-an-example-of-the-subject-by-id)
      - [Verify Faces from a Given Image](#verify-faces-from-a-given-image)
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

| CompreFace .NET SDK version | CompreFace 1.1.0 |
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

To start using  Compreface .NET SDK you need to import ??? `CompreFace` ??? object from 'compreface-sdk' dependency.

Then you need to create ??? `ComprefaceClient`??? object and initialize it with ??? `url` and `api key`???. By default, if you run CompreFace on your local machine, it's address `http://localhost:8000`, ??? `url` in this case will be `http://localhost:8000/api/v1`???
???You can pass optional `options` object when call method to set default parameters, see reference for [more information](#options-structure).???

???You can use `RecognitionService` service in `ComprefaceClient` object to recognize faces.???

However, before recognizing you need first to add faces into the face collection. To do this, get the face collection object with the help of `SubjectService`.

```
???? usings

const string BASE_URL = "http://localhost:8000/api/v1/";
const string API_KEY = "your api key";

var comprefaceApiClient = new ComprefaceClient(new ComprefaceConfiguration(API_KEY,BASE_URL));

var getAllSubjectResponse = await comprefaceApiClient.SubjectService.GetAllSubject();

```

## Adding faces into a face collection

Here is example that shows how to add an image to your face collection from your file system:

```
```

```
```

## Recognition

This code snippet shows how to recognize unknown face.
_Recognize faces from a given image_
```python
```

```
```

# Reference

## CompreFace Global Object

Global CompreFace Object is used for initializing connection to CompreFace and setting default values for options.
Default values will be used in every service method if applicable.

**???Constructor:???**

```ComprefaceClient(domain, port)```

| Argument | Type   | Required | Notes                                     | 
| ---------| ------ | -------- | ----------------------------------------- | 
| url      | string | required | URL with protocol where CompreFace is located. E.g. `http://localhost` |
| port     | string | required | CompreFace port. E.g. `8000` |


### Methods

1. ``````

Inits face recognition service object.

| Argument | Type   | Required | Notes                                     |
| ---------| ------ | -------- | ----------------------------------------- |
| api_key  | string | required | Face Recognition Api Key in UUID format    |

Example:

```
```

2. ``````

Inits face detection service object.

| Argument | Type   | Required | Notes                                     |
| ---------| ------ | -------- | ----------------------------------------- |
| api_key  | string | required | Face Detection Api Key in UUID format    |

Example:

```
```

3. ``````

Inits face verification service object.

| Argument | Type   | Required | Notes                                     |
| ---------| ------ | -------- | ----------------------------------------- |
| api_key  | string | required | Face Verification Api Key in UUID format    |

Example:

```
```

## Face Recognition Service

Face recognition service is used for face identification.
This means that you first need to upload known faces to face collection and then recognize unknown faces among them.
When you upload an unknown face, the service returns the most similar faces to it.
Also, face recognition service supports verify endpoint to check if this person from face collection is the correct one.
For more information, see [CompreFace page](https://github.com/exadel-inc/CompreFace).

### Recognize Faces from a Given Image

*[Example](examples/)*

Recognizes all faces from the image.
The first argument is the image location, it can be an url, local path or bytes.

```
```

| Argument           | Type    | Required | Notes                                                                                                                                          |
| ------------------ | ------- | -------- | ---------------------------------------------------------------------------------------------------------------------------------------------- |


Response:

```
```



### Get Face Collection

```
```

Returns Face collection object

Face collection could be used to manage known faces, e.g. add, list, or delete them.

Face recognition is performed for the saved known faces in face collection, so before using the `recognize` method you need to save at least one face into the face collection.

More information about face collection and managing examples [here](https://github.com/exadel-inc/CompreFace/blob/master/docs/Rest-API-description.md#managing-subject-examples)

**Methods:**

#### Add an Example of a Subject

*[Example](examples/add_example_of_a_subject.py)*

This creates an example of the subject by saving images. You can add as many images as you want to train the system. Image should
contain only one face.

```

```

| Argument           | Type   | Required | Notes                                                                                                |
| ------------------ | ------ | -------- | ---------------------------------------------------------------------------------------------------- |


Response:

```json

```

| Element  | Type   | Description                |
| -------- | ------ | -------------------------- |


#### List of All Saved Examples of the Subject

To retrieve a list of subjects saved in a Face Collection:

```

```

Response:

```

```

| Element  | Type   | Description                                                       |
| -------- | ------ | ----------------------------------------------------------------- |


#### Delete All Examples of the Subject by Name

*[Example](examples/)*

To delete all image examples of the <subject>:

```
```

| Argument  | Type   | Required | Notes                                                                                                                                |
| --------- | ------ | -------- | ------------------------------------------------------------------------------------------------------------------------------------ |
| subject   | string | optional | is the name you assign to the image you save. If this parameter is absent, all faces in Face Collection will be removed |

Response:

```

```

| Element  | Type    | Description              |
| -------- | ------- | ------------------------ |


#### Delete an Example of the Subject by ID

*[Example](examples/delete_example_by_id.py)*

To delete an image by ID:

```

```
| Argument  | Type   | Required | Notes                                                        |
| --------- | ------ | -------- | ------------------------------------------------------------ 


Response:

```

```

| Element  | Type   | Description                                                       |
| -------- | ------ | ----------------------------------------------------------------- |


#### Verify Faces from a Given Image

*[Example](examples/)*

```
```

Compares similarities of given image with image from your face collection.


| Argument           | Type    | Required | Notes                                                                                                                                                 |
| ------------------ | ------- | -------- | ----------------------------------------------------------------------------------------------------------------------------------------------------- |


Response:

```
```

| Element                        | Type    | Description                                                  |
| ------------------------------ | ------- | ------------------------------------------------------------ |
                   |

### Get Subjects

```
```



**Methods:**

#### Add a Subject

*[Example](examples/)*

Create a new subject in Face Collection.
```
```

| Argument           | Type   | Required | Notes                                                                   |
| ------------------ | ------ | -------- | ------------------------------------------------------------------------|


Response:

```
```

| Element  | Type   | Description                |
| -------- | ------ | -------------------------- |


#### List Subjects

*[Example](examples/)*

Returns all subject related to Face Collection.
```
```

Response:

```
```

| Element  | Type   | Description                |
| -------- | ------ | -------------------------- |
| subjects | array  | the list of subjects in Face Collection |

#### Rename a Subject

*[Example](examples/update_existing_subject.py)*

Rename existing subject. If a new subject name already exists, subjects are merged - all faces from the old subject name are reassigned to the subject with the new name, old subject removed.

```
```

| Argument            | Type   | Required | Notes                                                                   |
| ------------------  | ------ | -------- | ------------------------------------------------------------------------|
              |

Response:

```json

```

| Element  | Type    | Description                |
| -------- | ------  | -------------------------- |
| updated  | boolean | failed or success          |

#### Delete a Subject

*[Example](examples/delete_subject_by_name.py)*

Delete existing subject and all saved faces.
```python

```

| Argument           | Type   | Required | Notes                                                                   |
| ------------------ | ------ | -------- | ------------------------------------------------------------------------|
| subject            | string | required | is the name of the subject.                                             |

Response:

```json

```

| Element  | Type   | Description                |
| -------- | ------ | -------------------------- |
| subject  | string | is the name of the subject |

#### Delete All Subjects

*[Example](examples/delete_all_subjects.py)*

Delete all existing subjects and all saved faces.
```python

```

Response:

```json

```

| Element  | Type    | Description                |
| -------- | ------  | -------------------------- |



## Face Detection Service

Face detection service is used for detecting faces in the image.

**Methods:**

### Detect

*[Example](examples/detect_face_from_image.py)*

```python

```

Finds all faces on the image.

| Argument          | Type    | Required | Notes                                                                                                                                          |
| ----------------- | ------- | -------- | ---------------------------------------------------------------------------------------------------------------------------------------------- |
| image_path        | image   | required | image where to detect faces. Image can pass from url, local path or bytes. Max size is 5Mb                            |


Response:

```json

```

| Element                        | Type    | Description                                                  |
| ------------------------------ | ------- | ------------------------------------------------------------ |



## Face Verification Service

*[Example](examples/verify_face_from_image.py)*

Face verification service is used for comparing two images.
A source image should contain only one face which will be compared to all faces on the target image.

**Methods:**

### Verify

```python

```

Compares two images provided in arguments. Source image should contain only one face, it will be compared to all faces in the target image.

| Argument            | Type    | Required | Notes                                                                                                                                                 |
| ------------------  | ------- | -------- | ----------------------------------------------------------------------------------------------------------------------------------------------------- |


Response:

```json

```

| Element                        | Type    | Description                                                  |
| ------------------------------ | ------- | ------------------------------------------------------------ |


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
