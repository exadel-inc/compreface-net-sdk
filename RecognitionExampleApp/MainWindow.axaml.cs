using Avalonia.Interactivity;
using Exadel.Compreface.Clients.CompreFaceClient;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.AddSubjectExample;
using Exadel.Compreface.DTOs.SubjectDTOs.AddSubject;
using Exadel.Compreface.Services.RecognitionService;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFaceFromImage;
using System.IO;
using Avalonia.Controls;
using System;
using System.Threading.Tasks;
using Emgu.CV.Structure;
using Emgu.CV;

namespace RecognitionExampleApp
{
    public partial class MainWindow : Window
    {
        private ICompreFaceClient compreFaceClient;
        private RecognitionService recognitionService;
        private string[] imagePathList;

        private string recognizeImagePath;

        private string domain;
        private string port;
        private string apiKey;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void OnBrowseClick(object sender, RoutedEventArgs e)
        {
            var dialogWindow = new OpenFolderDialog();
            var inputFolder = await dialogWindow.ShowAsync(new Window());
            if (inputFolder != null)
            {
                folderPath.Text = inputFolder;
                imagePathList = Directory.GetFiles(inputFolder);
            }
        }

        private void OnCreateSubjectHelpClick(object sender, RoutedEventArgs e)
        {
            new CreateSubjectHelpWindow().Show();
        }

        private async void OnClearClick(object sender, RoutedEventArgs e)
        {
            var processingWindow = new ProcessingWindow();
            processingWindow.Show();

            ConfigureRecognitionService();
            await recognitionService.Subject.DeleteAllAsync();

            processingWindow.Close();
            new DoneWindow().Show();
        }

        private async void OnChooseClick(object sender, RoutedEventArgs e)
        {
            var dialogWindow = new OpenFileDialog();
            var inputFile = await dialogWindow.ShowAsync(new Avalonia.Controls.Window());
            if (inputFile != null)
            {
                imagePath.Text = inputFile[0];
                recognizeImagePath = inputFile[0];

                FileStream file = null!;

                if (File.Exists(recognizeImagePath))
                {
                    file = File.OpenRead(recognizeImagePath);
                }

                using (var imageStream = file)
                {
                    uploadedImage.Source = Avalonia.Media.Imaging.Bitmap.DecodeToHeight(imageStream, 500);
                }
            }
        }

        private async void OnProcessClick(object sender, RoutedEventArgs e)
        {
            var recognizeRequest = new RecognizeFaceFromImageRequestByFilePath()
            {
                FilePath = recognizeImagePath,
                Limit = 1,
                PredictionCount = 100,
                Status = false,
            };

            var recognitionResponse = await recognitionService.RecognizeFaceFromImage.RecognizeAsync(recognizeRequest);

            var similarityValue = (decimal)similarity.Value;

            var resultsWindow = new ResultsWindow(recognitionResponse, similarityValue, imagePathList);

            resultsWindow.Show();
        }

        private async void OnCreateClick(object sender, RoutedEventArgs e)
        {
            var processingWindow = new ProcessingWindow();
            processingWindow.Show();

            ConfigureRecognitionService();

            foreach (var imagePath in imagePathList)
            {
                await SaveCropedImageToSubject(imagePath);
            }

            processingWindow.Close();
            new DoneWindow().Show();
        }

        private void ConfigureRecognitionService()
        {
            domain = domainTextBox.Text;
            port = portTextBox.Text;
            apiKey = apiKeyTextBox.Text;

            compreFaceClient = new CompreFaceClient(domain, port);
            recognitionService = compreFaceClient.GetCompreFaceService<RecognitionService>(apiKey);
        }

        private async Task SaveCropedImageToSubject(string imagePath)
        {
            var imageName = Path.GetFileName(imagePath);
            var subject = await recognitionService.Subject.AddAsync(new AddSubjectRequest() { Subject = imageName });

            Image<Bgr, byte> image = new Image<Bgr, byte>(imagePath);

            // Load the face detection classifier
            var face_quality_plugin_path = GetFacePluginPath();
            CascadeClassifier faceDetector = new CascadeClassifier(face_quality_plugin_path);

            // Detect faces in the image
            var faces = faceDetector.DetectMultiScale(image, 1.05, 10);

            // Loop through each detected face
            foreach (var face in faces)
            {
                // Crop the face from the image
                var faceImage = image.Copy(face).ToJpegData();

                var imageBase64 = Convert.ToBase64String(faceImage);

                await recognitionService.FaceCollection.AddAsync(new AddBase64SubjectExampleRequest() { File = imageBase64, Subject = subject.Subject });
            }
        }

        private string GetFacePluginPath()
        {
            var rootPath = Directory.GetCurrentDirectory();
            var debugPath = Directory.GetParent(rootPath)?.ToString();
            var binPath = Directory.GetParent(debugPath!)?.ToString();
            var projectPath = Directory.GetParent(binPath!)?.ToString();

            return Path.Combine(projectPath!, "Assets", "haarcascade_frontalface_alt2.xml");
        }
    }
}