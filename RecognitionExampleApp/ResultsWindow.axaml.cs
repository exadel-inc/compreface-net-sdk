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
                decimal count = (decimal)subjects.Count / 5m;
                for (int i = 0; i < Math.Ceiling(count); i++)
                {
                    ImagesGrid.RowDefinitions.Add(new RowDefinition());
                    for (int k = 0; i < 5; i++)
                    {
                        Image image = new Image()
                        {
                            VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center,
                            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                            [Grid.ColumnProperty] = k,
                            [Grid.RowProperty] = i,
                            Height = 300,
                            Width = 300,
                            Margin = Thickness.Parse("10, 10, 10, 10")
                        };

                        FileStream file = null;

                        var filePath = imagePathList.FirstOrDefault(x => x.Contains(subjects[k].Subject));

                        if (File.Exists(filePath))
                        {
                            file = File.OpenRead(filePath);
                        }

                        using (var imageStream = file)
                        {
                            image.Source = Bitmap.DecodeToHeight(imageStream, 500);
                        }
                        ImagesGrid.Children.Add(image);
                    }
                }
            }
        }
    }
}
