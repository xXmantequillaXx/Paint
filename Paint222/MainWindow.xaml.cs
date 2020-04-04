using ColorPickerWPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Paint222
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WriteableBitmap Paint = BitmapFactory.New(640, 412);
        WriteableBitmap Save;
        bool isDrawable = false;
        Point point;
        Color color = Colors.Black;
        int num = 1;
        int thickness = 1;
        public MainWindow()
        {
            InitializeComponent();
            image.Source = Paint;
            Paint.Clear(Colors.White);
        }
        private void imageMove(object sender, MouseEventArgs e)
        {
            if (isDrawable)
            {
                Point P = e.GetPosition(image);
                Paint = Save.Clone();
                image.Source = Paint;
                switch (num)
                {
                    case 1:

                        Paint.DrawLine((int)point.X, (int)point.Y, (int)P.X, (int)P.Y, color);
                        point = e.GetPosition(image);
                        Save = Paint.Clone();
                        break;
                    case 2:
                        Paint.DrawLineAa((int)point.X, (int)point.Y, (int)P.X, (int)P.Y, color, thickness);
                        break;


                }
            }
        }

        private void imageUp(object sender, MouseButtonEventArgs e)
        {
            isDrawable = false;
        }

        private void imageDown(object sender, MouseButtonEventArgs e)
        {
            Save = Paint.Clone();
            point = e.GetPosition(image);
            isDrawable = true;
        }

        private void PencilClick(object sender, RoutedEventArgs e)
        {
            num = 1;
        }

        private void SlideChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            thickness = (int)(sender as Slider).Value;
        }

        private void ClearClick(object sender, RoutedEventArgs e)
        {
            Paint.Clear(Colors.White);
        }

        private void ColorPanelClick(object sender, RoutedEventArgs e)
        {
            
            ColorPickerWindow.ShowDialog(out color);

        }

        private void LineClick(object sender, RoutedEventArgs e)
        {
            num = 2;
        }

    }
}
