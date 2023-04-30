using Avalonia.Interactivity;
using Exadel.Compreface.Clients.CompreFaceClient;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.AddSubjectExample;
using Exadel.Compreface.DTOs.SubjectDTOs.AddSubject;
using Exadel.Compreface.Services.RecognitionService;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFaceFromImage;
using System.IO;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using OpenCvSharp;
using System.Drawing.Imaging;
using System.Drawing;
using System;
using System.Threading.Tasks;

namespace RecognitionExampleApp
{
    public partial class MainWindow : Avalonia.Controls.Window
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
            var inputFolder = await dialogWindow.ShowAsync(new Avalonia.Controls.Window());
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
            ConfigureRecognitionService();
            await recognitionService.Subject.DeleteAllAsync();
            new DoneWindow().Show();
        }

        private void OnCleareSubjectsHelpClick(object sender, RoutedEventArgs e)
        {
            new ClearSubjectsHelpWindow().Show();
        }

        private async void OnChooseClick(object sender, RoutedEventArgs e)
        {
            var dialogWindow = new OpenFileDialog();
            var inputFile = await dialogWindow.ShowAsync(new Avalonia.Controls.Window());
            if (inputFile != null)
            {
                imagePath.Text = inputFile[0];
                recognizeImagePath = inputFile[0];

                FileStream file = null;

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

        private async void OnProcessingClick(object sender, RoutedEventArgs e)
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
            ConfigureRecognitionService();

            foreach (var imagePath in imagePathList)
            {
               await SaveCropedImageToSubject(imagePath);
            }
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

            using var img = Cv2.ImRead(imagePath);
            using Mat dst = new Mat();
            Cv2.CvtColor(img, dst, ColorConversionCodes.RGB2BGR, 0);

            var face_quality_plugin_path = GetFacePluginPath();
            var face_cascade = new CascadeClassifier(face_quality_plugin_path);
            var faces = face_cascade.DetectMultiScale(dst);

            foreach (var face in faces)
            {
                //Cv2.Rectangle(img, face, Scalar.Red, 3);
                System.Drawing.Bitmap source = new System.Drawing.Bitmap(imagePath);
                Rectangle section = new Rectangle(new System.Drawing.Point(face.X-20, face.Y-100), new System.Drawing.Size(face.Width + 70, face.Height + 210));

                CropImage(source, section, face);

                System.Drawing.Bitmap CroppedImage = CropImage(source, section, face);

                using MemoryStream stream = new MemoryStream();
                CroppedImage.Save(stream, ImageFormat.Jpeg);
                byte[] byteImage = stream.ToArray();
                var imageBase64= Convert.ToBase64String(byteImage);

                await recognitionService.FaceCollection.AddAsync(new AddBase64SubjectExampleRequest() { File = imageBase64, Subject = subject.Subject });
            }
        }

        private System.Drawing.Bitmap CropImage(System.Drawing.Bitmap source, Rectangle section, Rect face)
        {
            var bitmap = new System.Drawing.Bitmap(face.Width + 70, face.Height + 210);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);
                return bitmap;
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