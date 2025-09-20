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

        private SolidColorBrush[] _colorList =
        {
            Brushes.Red,
            Brushes.Green,
            Brushes.White
        };

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Background = _colorList[currentColorIndex];

            currentColorIndex = (currentColorIndex + 1) % _colorList.Length;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разботчик - Light");
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItem_MouseEnter_white_bg(object sender, MouseEventArgs e)
        {
            StatusText.Text = "Белый цвет";
        }

        private void MenuItem_MouseEnter_red_bg(object sender, MouseEventArgs e)
        {
            StatusText.Text = "Красный цвет";
        }

        private void MenuItem_MouseEnter_green_bg(object sender, MouseEventArgs e)
        {
            StatusText.Text = "Зеленый цвет";
        }

        private void MenuItem_MouseEnter_developers(object sender, MouseEventArgs e)
        {
            StatusText.Text = "Информация о разработчике";
        }

        private void MenuItem_MouseEnter_close(object sender, MouseEventArgs e)
        {
            StatusText.Text = "Закрыть программу";
        }

        private void Button_MouseEnter_1(object sender, MouseEventArgs e)
        {
            StatusText.Text = "Поменять цвет фона";
        }

        private void Button_MouseEnter_2(object sender, MouseEventArgs e)
        {
            StatusText.Text = "Информация о разработчике";
        }

        private void Button_MouseEnter_3(object sender, MouseEventArgs e)
        {
            StatusText.Text = "Закрыть программу";
        }

        private void MenuItem_MouseLeave_white_bg(object sender, MouseEventArgs e)
        {
            StatusText.Text = "";
        }

        private void MenuItem_MouseLeave_red_bg(object sender, MouseEventArgs e)
        {
            StatusText.Text = "";
        }

        private void MenuItem_MouseLeave_green_bg(object sender, MouseEventArgs e)
        {
            StatusText.Text = "";
        }

        private void MenuItem_MouseLeave_developers(object sender, MouseEventArgs e)
        {
            StatusText.Text = "";
        }

        private void MenuItem_MouseLeave_close(object sender, MouseEventArgs e)
        {
            StatusText.Text = "";
        }

        private void Button_MouseLeave_1(object sender, MouseEventArgs e)
        {
            StatusText.Text = "";
        }

        private void Button_MouseLeave_2(object sender, MouseEventArgs e)
        {
            StatusText.Text = "";
        }

        private void Button_MouseLeave_3(object sender, MouseEventArgs e)
        {
            StatusText.Text = "";
        }

        private void MenuItem_Click_openW(object sender, RoutedEventArgs e)
        {
            var Window_Ppaint = new Window_paint();
            Window_Ppaint.Show();
            this.Close();
        }
    }
}