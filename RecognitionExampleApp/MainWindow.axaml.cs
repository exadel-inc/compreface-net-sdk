using Avalonia.Controls;
using Avalonia.Interactivity;
using Exadel.Compreface.Clients.CompreFaceClient;
using Exadel.Compreface.DTOs.FaceCollectionDTOs.AddSubjectExample;
using Exadel.Compreface.DTOs.SubjectDTOs.AddSubject;
using Exadel.Compreface.Services.RecognitionService;
using System.IO;

namespace RecognitionExampleApp
{
    public partial class MainWindow : Window
    {
        private readonly ICompreFaceClient compreFaceClient;
        private string[] imagePathList;

        public MainWindow()
        {
            InitializeComponent();

            compreFaceClient = new CompreFaceClient("http://localhost", "8000");
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

        private async void OnUploadClick(object sender, RoutedEventArgs e)
        {
            var recognitionService = compreFaceClient.GetCompreFaceService<RecognitionService>("439503b1-3788-4b8b-9c91-93a03dd4ffb5");
            foreach (var imagePath in imagePathList)
            {
                var imageName = Path.GetFileName(imagePath);
                var subject = await recognitionService.Subject.AddAsync(new AddSubjectRequest() { Subject = imageName });
                await recognitionService.FaceCollection.AddAsync(new AddSubjectExampleRequestByFilePath() { FilePath = imagePath, Subject = subject.Subject });
            }
        }

        private async void OnChooseClick(object sender, RoutedEventArgs e)
        {
            var dialogWindow = new OpenFileDialog();
            var inputFile = await dialogWindow.ShowAsync(new Window());
            if (inputFile != null)
                filePath2.Text = inputFile[0];
        }

        private async void OnBrowseClick3(object sender, RoutedEventArgs e)
        {
            var dialogWindow = new OpenFileDialog();
            var inputFile = await dialogWindow.ShowAsync(new Window());
            if (inputFile != null)
                filePath3.Text = inputFile[0];
        }
    }
}