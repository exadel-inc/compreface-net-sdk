using Avalonia.Controls;
using Avalonia.Interactivity;

namespace RecognitionExampleApp
{
    public partial class DoneWindow : Window
    {
        public DoneWindow()
        {
            InitializeComponent();
        }

        private void OnCloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
