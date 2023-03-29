using Avalonia.Interactivity;
using Exadel.Compreface.Clients.CompreFaceClient;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.AddSubjectExample;
using Exadel.Compreface.DTOs.SubjectDTOs.AddSubject;
using Exadel.Compreface.Services.RecognitionService;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFaceFromImage;
using System.IO;
using Avalonia.Controls;
using Avalonia.Media.Imaging;

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
                Limit = 1,
                PredictionCount = 100,
                Status = false,
            };

            var recognitionResponse = await recognitionService.RecognizeFaceFromImage.RecognizeAsync(recognizeRequest);

            var similarityValue = (decimal)similarity.Value;

            var resultsWindow = new ResultsWindow(recognitionResponse, similarityValue, imagePathList);

            resultsWindow.Show();
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