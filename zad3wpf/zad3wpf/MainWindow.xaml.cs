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

namespace zad3wpf
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MarginSlider.Value = 5;
            PaddingSlider.Value = 5;
            RedBackSlider.Value = GreenBackSlider.Value = BlueBackSlider.Value = 255;
            RedForeTextBox.Text = GreenForeTextBox.Text = BlueForeTextBox.Text = "0";
            BrushComboBox.Text = "black";
            BorderTickSlider.Value = 1;
            FontTextBox.Text = mainLabel.FontFamily.ToString();
            getContent.Text = "Ala ma kota";
            FontSizeTB.Text = "12";

            //System.Windows.MessageBox.Show(MarginSlider.ToString());
        }
        // ------------------CONTENT

        private void getContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            mainLabel.Content = getContent.Text;
        }


        //------------------ ALIGNMENT
        private void HorizontAlignment_Click(object sender, RoutedEventArgs e)
        {
            RadioButton rdbtn = sender as RadioButton;
            HorizontalAlignment a;
            if (Enum.TryParse(rdbtn.Content.ToString(), out a))
                mainLabel.HorizontalAlignment = a;
        }
        

        private void VerticalAlignment_Click(object sender, RoutedEventArgs e)
        {
            RadioButton rdbtn = sender as RadioButton;
            VerticalAlignment a;
            if (Enum.TryParse(rdbtn.Content.ToString(), out a))
                mainLabel.VerticalAlignment = a;
        }

        //---------------CONTENT ALIGNMENT

        private void VerticalContent_Click(object sender, RoutedEventArgs e)
        {
            RadioButton rdbtn = sender as RadioButton;
            VerticalAlignment a;
            if (Enum.TryParse(rdbtn.Content.ToString(), out a))
                mainLabel.VerticalContentAlignment = a;
        }

        private void HorizontContent_Click(object sender, RoutedEventArgs e)
        {
            RadioButton rdbtn = sender as RadioButton;
            HorizontalAlignment a;
            if (Enum.TryParse(rdbtn.Content.ToString(), out a))
                mainLabel.HorizontalContentAlignment = a;
        }



        // ------------------------- FONT

        private void Font_TextChanged(object sender, TextChangedEventArgs e)
        {
            mainLabel.FontFamily = new FontFamily(FontTextBox.Text);
        }

        private void FontSizeTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            double size;
            if (double.TryParse(FontSizeTB.Text, out size))
            {
                if(size <= 999 && size >0)
                    mainLabel.FontSize = size;
            }
                
        }

        private void Bold_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            mainLabel.FontWeight = FontWeights.Bold;
        }

        private void Bold_CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            mainLabel.FontWeight = FontWeights.Normal;
        }

        private void Italic_Checkbox_Checked(object sender, RoutedEventArgs e)
        {
            mainLabel.FontStyle = FontStyles.Italic;
        }

        private void Italic_Checkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            mainLabel.FontStyle = FontStyles.Normal;
        }

        // -------- margin, padding

        private void MarginSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mainLabel.Margin = new Thickness(MarginSlider.Value);
        }

        private void PaddingSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mainLabel.Padding = new Thickness(PaddingSlider.Value);
        }

        //-----------colors
        private void BackSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            byte r, g, b;

            r = (byte)RedBackSlider.Value;
            g = (byte)GreenBackSlider.Value;
            b = (byte)BlueBackSlider.Value;

            mainLabel.Background = new SolidColorBrush(Color.FromRgb(r, g, b));
        }

        private void ForeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            byte r, g, b;

            if( byte.TryParse(RedForeTextBox.Text,out r)
                && byte.TryParse(GreenForeTextBox.Text,out g)
                && byte.TryParse(BlueForeTextBox.Text, out b))
            {
                mainLabel.Foreground = new SolidColorBrush(Color.FromRgb(r, g, b));
            }
        }

        // -------------- BORDER
        private void BrushComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                mainLabel.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(BrushComboBox.Text));
            }
            catch { }
        }


        private void BorderTickSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mainLabel.BorderThickness = new Thickness(BorderTickSlider.Value);
        }
    }
}
