using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace laba_2_060925
{
    public partial class Window_paint : Window
    {
        public DrawingAttributes DrawingAttributes { get; set; }
        private Stroke selectedStroke;
        private Point lastPoint;

        public Window_paint()
        {
            InitializeComponent();
            InitializeDrawingAttributes();
            InitializeColorComboBox();
            SetupCanvas();
        }

        private void InitializeDrawingAttributes()
        {
            DrawingAttributes = new DrawingAttributes
            {
                Color = Colors.Black,
                Width = 5,
                Height = 5
            };
        }

        private void InitializeColorComboBox()
        {
            var colorDictionary = new Dictionary<string, Color>
            {
                {"Черный", Colors.Black},
                {"Красный", Colors.Red},
                {"Синий", Colors.Blue},
                {"Зеленый", Colors.Green},
                {"Желтый", Colors.Yellow},
                {"Фиолетовый", Colors.Purple},
                {"Оранжевый", Colors.Orange},
                {"Белый", Colors.White},
                {"Серый", Colors.Gray},
                {"Коричневый", Colors.Brown}
            };

            colorComboBox.ItemsSource = colorDictionary;
            colorComboBox.DisplayMemberPath = "Key";
            colorComboBox.SelectedIndex = 0;
        }

        private void SetupCanvas()
        {
            drawingCanvas.DefaultDrawingAttributes = DrawingAttributes;
            drawingCanvas.MouseMove += DrawingCanvas_MouseMove;
            drawingCanvas.MouseLeftButtonDown += DrawingCanvas_MouseLeftButtonDown;
            drawingCanvas.MouseLeftButtonUp += DrawingCanvas_MouseLeftButtonUp;
        }

        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (colorComboBox.SelectedItem is KeyValuePair<string, Color> selectedColor)
            {
                DrawingAttributes.Color = selectedColor.Value;
                drawingCanvas.DefaultDrawingAttributes = DrawingAttributes;
            }
        }

        private void BrushSizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (DrawingAttributes != null && drawingCanvas != null)
            {
                DrawingAttributes.Width = brushSizeSlider.Value;
                DrawingAttributes.Height = brushSizeSlider.Value;
                drawingCanvas.DefaultDrawingAttributes = DrawingAttributes;
            }
        }

        private void ModeRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (!IsInitialized || drawingCanvas == null)
                return;

            try
            {
                if (drawRadioButton.IsChecked == true)
                {
                    SetDrawingMode();
                }
                else if (editRadioButton.IsChecked == true)
                {
                    SetEditingMode();
                }
                else if (deleteRadioButton.IsChecked == true)
                {
                    SetDeletionMode();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка смены режима: {ex.Message}");
            }
        }

        private void SetDrawingMode()
        {
            if (drawingCanvas != null)
            {
                drawingCanvas.EditingMode = InkCanvasEditingMode.Ink;
                drawingCanvas.Cursor = Cursors.Pen;
            }
        }

        private void SetDeletionMode()
        {
            if (drawingCanvas != null)
            {
                drawingCanvas.Strokes.Clear();
            }
            drawingCanvas.Cursor = Cursors.Arrow;
        }

        private void SetEditingMode()
        {
            if (drawingCanvas != null)
            {
                drawingCanvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
                drawingCanvas.Cursor = Cursors.Cross;
            }
        }

        private void DrawingCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (editRadioButton.IsChecked == true)
            {
                var point = e.GetPosition(drawingCanvas);
                selectedStroke = FindStrokeAtPoint(point);

                if (selectedStroke != null)
                {
                    lastPoint = point;
                    drawingCanvas.CaptureMouse();
                }
            }
        }

        private void DrawingCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (editRadioButton.IsChecked == true && selectedStroke != null && e.LeftButton == MouseButtonState.Pressed)
            {
                var currentPoint = e.GetPosition(drawingCanvas);
                var offset = currentPoint - lastPoint;

                // штрих
                var transform = new Matrix();
                transform.Translate(offset.X, offset.Y);
                selectedStroke.Transform(transform, false);

                lastPoint = currentPoint;
            }
        }

        private void DrawingCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (editRadioButton.IsChecked == true)
            {
                selectedStroke = null;
                drawingCanvas.ReleaseMouseCapture();
            }
        }

        private Stroke FindStrokeAtPoint(Point point)
        {
            foreach (Stroke stroke in drawingCanvas.Strokes)
            {
                if (stroke.HitTest(point, 5))
                {
                    return stroke;
                }
            }
            return null;
        }

        private void Button_Click_close(object sender, RoutedEventArgs e)
        {
            var MmainWindow = new MainWindow();
            MmainWindow.Show();
            this.Close();
        }
    }
}