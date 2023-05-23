# Recognition demo.
This cross-platform desktop app is a simple example how to use CompreFace SDK for .NET. App is cross-platform and can be used with Linux, Mac and Windows. 
Before using our SDK make sure you have installed CompreFace, .NET and AvaloniaUI framework on your machine.

# Description
Application provide an ability to recognize face from a list of photos in a folder.

# How demo app works.
1. Expand CompreFace on your local machine.
2. Create an application in your CompreFace account.
3. Create recognition service in this new application and copy its apikey.
4. Start the RecognitionExampleApp project from your IDE.
5. Fill the Domain, Port(by default: http://localhost:8000) and ApiKey(which was copied) fields in main window of application.
6. Then choose the folder with photos and click "Create subject" button.
7. Move to the "Step 2" and choose the photo with one person for recognition. Choose similarity threshold and click "Process" button.

App will crop the faces from photos in a chosen folder and will save them as a subjects with names of a photo in your created service in CompreFace account. And then the window with results will be shown. Raise the similarity threshhold if you need more accurate result.

## Optional step.
"Clear service" button clear your recognition service from previous created subjects by provided apikey. Please, to avoid exception use this button if you try to create subjects repeatedly from the same folder with photos.
