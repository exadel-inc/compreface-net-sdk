using Avalonia.Interactivity;
using Exadel.Compreface.Clients.CompreFaceClient;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.AddSubjectExample;
using Exadel.Compreface.DTOs.SubjectDTOs.AddSubject;
using Exadel.Compreface.Services.RecognitionService;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFaceFromImage;
using System.IO;
using System.Collections.Generic;
using Avalonia.Controls;
using System;
using Avalonia.Platform;
using Avalonia;
using Avalonia.Media.Imaging;
using System.Threading.Tasks;
using System.Net.Http;

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

        private async void OnCreateClick(object sender, RoutedEventArgs e)
        {
            ConfigureRecognitionService();

            foreach (var imagePath in imagePathList)
            {
                var imageName = Path.GetFileName(imagePath);
                var subject = await recognitionService.Subject.AddAsync(new AddSubjectRequest() { Subject = imageName });
                await recognitionService.FaceCollection.AddAsync(new AddSubjectExampleRequestByFilePath() { FilePath = imagePath, Subject = subject.Subject });
            }
        }

        private async void OnClearClick(object sender, RoutedEventArgs e)
        {
            ConfigureRecognitionService();
            await recognitionService.Subject.DeleteAllAsync();
        }

        private async void OnChooseClick(object sender, RoutedEventArgs e)
        {
            var dialogWindow = new OpenFileDialog();
            var inputFile = await dialogWindow.ShowAsync(new Window());
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
                    uploadedImage.Source = Bitmap.DecodeToHeight(imageStream, 500);
                }
            }
        }

        private async void OnStartClick(object sender, RoutedEventArgs e)
        {
            var recognizeRequest = new RecognizeFaceFromImageRequestByFilePath()
            {
                FilePath = recognizeImagePath,
                DetProbThreshold = 0.81m,
                Limit = 1,
                Status = false,
                FacePlugins = new List<string>()
                            {
                                "landmarks",
                                "gender",
                                "age",
                                "detector",
                                "calculator"
                            }
            };

            var recognitionResponse = await recognitionService.RecognizeFaceFromImage.RecognizeAsync(recognizeRequest);

            string resultText = "Images from folder, which contains provided image: ";

            foreach (var result in recognitionResponse.Result)
            {
                foreach (var subjectName in result.Subjects)
                    resultText += subjectName.Subject + ", ";
            }

            recognitionResult.Text = resultText;
        }

        private void ConfigureRecognitionService()
        {
            domain = domainTextBox.Text;
            port = portTextBox.Text;
            apiKey = apiKeyTextBox.Text;

            compreFaceClient = new CompreFaceClient(domain, port);
            recognitionService = compreFaceClient.GetCompreFaceService<RecognitionService>(apiKey);
        }
    }
}