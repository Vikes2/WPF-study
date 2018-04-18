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

namespace zad4wpf
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Rectangle rectangle;
        double initX, initY;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void canabis_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(myCanvas);
            rectangle = new Rectangle();
            myCanvas.Children.Add(rectangle);
            Point pt = e.GetPosition(myCanvas);
            rectangle.SetValue(Canvas.TopProperty, pt.Y);
            rectangle.SetValue(Canvas.LeftProperty, pt.X);
            rectangle.Fill = new SolidColorBrush(Colors.LightBlue);
            rectangle.Stroke = new SolidColorBrush(Colors.Blue);
            rectangle.StrokeThickness = 3;
            initX = pt.X;
            initY = pt.Y;
        }

        private void canabis_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(null);

        }

        private void canabis_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.LeftButton == MouseButtonState.Pressed)
            { 
                Point pt = e.GetPosition(myCanvas);
                double height, width;
                //height = pt.Y - (double)rectangle.GetValue(Canvas.TopProperty);
                //width = pt.X - (double)rectangle.GetValue(Canvas.LeftProperty);

                height = pt.Y - initY;
                width = pt.X - initX;


                if (width > 0 && height > 0)
                {
                    rectangle.Height = Math.Abs(height);
                    rectangle.Width = Math.Abs(width);
                } else if(width < 0 && height > 0)
                {
                    rectangle.SetValue(Canvas.LeftProperty, pt.X);
                    rectangle.Height = Math.Abs(height);
                    rectangle.Width = Math.Abs(width);
                } else if(width < 0 && height < 0)
                {
                    rectangle.SetValue(Canvas.LeftProperty, pt.X);
                    rectangle.SetValue(Canvas.TopProperty, pt.Y);
                    rectangle.Height = Math.Abs(height);
                    rectangle.Width = Math.Abs(width);
                }else if (width > 0 && height < 0)
                {
                    rectangle.SetValue(Canvas.TopProperty, pt.Y);
                    rectangle.Height = Math.Abs(height);
                    rectangle.Width = Math.Abs(width);
                }



            }
        }

        private void canabis_KeyDown(object sender, KeyEventArgs e)
        {
            if (rectangle == null)
                return;
            double top = (double)rectangle.GetValue(Canvas.TopProperty);
            double left = (double)rectangle.GetValue(Canvas.LeftProperty);


            if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
            {

                if (e.Key == Key.Up)
                {
                    if (rectangle.Height < 6)
                        rectangle.Height = 1;
                    else
                        rectangle.Height -= 5;

                }
                if (e.Key == Key.Down)
                {
                    rectangle.Height += 5;
                }
                if (e.Key == Key.Left)
                {
                    if (rectangle.Width < 6)
                        rectangle.Width = 1;
                    else
                        rectangle.Width -= 5;
                }
                if (e.Key == Key.Right)
                {
                    rectangle.Width += 5;
                }

            }
            else
            {
                if (e.Key == Key.Up)
                {
                    
                    rectangle.SetValue(Canvas.TopProperty, top - 5);

                }
                if (e.Key == Key.Down)
                {
                    rectangle.SetValue(Canvas.TopProperty, top + 5);
                }
                if (e.Key == Key.Left)
                {
                    rectangle.SetValue(Canvas.LeftProperty, left - 5);
                }
                if (e.Key == Key.Right)
                {
                    rectangle.SetValue(Canvas.LeftProperty, left + 5);
                }
            }

           

        }
    }
}
