using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace laba_2_060925
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click_close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItem_Click_white_bg(object sender, RoutedEventArgs e)
        {
            SolidColorBrush customBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            Background = customBrush;
        }

        private void MenuItem_Click_red_bg(object sender, RoutedEventArgs e)
        {
            SolidColorBrush customBrush = new SolidColorBrush(Color.FromArgb(200, 255, 0, 0));
            Background = customBrush;
        }

        private void MenuItem_Click_green_bg(object sender, RoutedEventArgs e)
        {
            SolidColorBrush customBrush = new SolidColorBrush(Color.FromArgb(200, 0, 255, 0));
            Background = customBrush;
        }

        private void MenuItem_Click_developers(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разботчик - Light");
        }
    }
}