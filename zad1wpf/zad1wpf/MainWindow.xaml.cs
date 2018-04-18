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

namespace zad1wpf
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Stos stack;

        public MainWindow()
        {
            InitializeComponent();
            stack = new Stos();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            stack.Push(tekst.Text);
            tekst.Text = "";
            lab.Content = stack.Top();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            stack.Pop();
            if (stack.Empty())
                lab.Content = "brak";
            else lab.Content = stack.Top();
        }
    }
}
