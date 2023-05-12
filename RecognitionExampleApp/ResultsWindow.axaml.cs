using Avalonia;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Exadel.Compreface.DTOs.RecognitionDTOs.RecognizeFaceFromImage;
using System;
using System.IO;
using System.Linq;

namespace RecognitionExampleApp
{
    public partial class ResultsWindow : Window
    {
        //http://localhost
        public ResultsWindow()
        {
            InitializeComponent();
        }

        public ResultsWindow(RecognizeFaceFromImageResponse recognizeResponse, decimal similarityValue, string[] imagePathList) : this()
        {
            ShowImages(recognizeResponse, similarityValue, imagePathList);
        }

        private void ShowImages(RecognizeFaceFromImageResponse recognizeResponse, decimal similarityValue, string[] imagePathList)
        {
            foreach (var result in recognizeResponse.Result)
            {
                var subjects = result.Subjects.Where(x => x.Similarity >= similarityValue).ToList();
                var subjectCounter = subjects.Count();
                var counter = 0;
                decimal rowCount = Math.Ceiling((decimal)subjects.Count / 5m);
                for (int i = 0; i < rowCount; i++)
                {
                    ImagesGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(300)});

                    for (int k = 0; k < 5; k++)
                    {
                        if (subjectCounter == 0)
                            break;

                        Image image = new Image()
                        {
                            VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center,
                            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                            [Grid.ColumnProperty] = k,
                            [Grid.RowProperty] = i,
                            Height = 250,
                            Width = 250,
                            Margin = Thickness.Parse("0, 10, 0, 10")
                        };

                        Label label = new Label()
                        {
                            VerticalAlignment = Avalonia.Layout.VerticalAlignment.Bottom,
                            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                            [Grid.ColumnProperty] = k,
                            [Grid.RowProperty] = i,
                            Margin = Thickness.Parse("0, 5, 5, 5")
                        };

                        label.Content = subjects[counter].Subject;

                        var filePath = imagePathList.FirstOrDefault(x => Path.GetFileName(x) == subjects[counter].Subject);

                        AddImageToGrid(image, filePath);

                        ImagesGrid.Children.Add(image);
                        ImagesGrid.Children.Add(label);

                        counter++;
                        subjectCounter--;
                    }
                }
            }
        }

        private Image AddImageToGrid(Image image, string filePath)
        {
            FileStream file = null;
            if (File.Exists(filePath))
            {
                file = File.OpenRead(filePath);
            }

            using (var imageStream = file)
            {
                image.Source = Bitmap.DecodeToHeight(imageStream, 500);
            }

            return image;
        }
    }
}
