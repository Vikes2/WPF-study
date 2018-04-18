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

namespace zad6wpf
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Dictionary<object, bool> isAvaible = new Dictionary<object, bool>();

        private void PopDisk_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ListBoxItem item = ((ListBox)e.Parameter).Items[0] as ListBoxItem;
            mainTB.Text = item.Content.ToString();
            (((ListBox)e.Parameter).Items).RemoveAt(0);
        }

        private void PopDisk_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if(e.Parameter as ListBox != null)
            {
                if (((ListBox)e.Parameter).Items.Count == 0 || mainTB.Text != "")
                {
                    e.CanExecute = false;
                }
                else
                {
                    e.CanExecute = true;

                }
            }

        }

        private void PushDisk_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ListBoxItem item = new ListBoxItem();
            item.Content = mainTB.Text;
            ((ListBox)e.Parameter).Items.Insert(0, item);
            mainTB.Text = "";
        }

        private void PushDisk_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (e.Parameter as ListBox != null && mainTB.Text != "")
            {
                if(((ListBox)e.Parameter).HasItems)
                {
                    int a, b;

                    Int32.TryParse(((ListBoxItem)((ListBox)e.Parameter).Items[0]).Content.ToString(), out a);
                    Int32.TryParse(mainTB.Text, out b);
                    if (a > b)
                    {
                        e.CanExecute = true;
                    }
                    else
                    {
                        e.CanExecute = false;

                    }
                }
                else
                {
                    e.CanExecute = true;
                }
                
            }

        }

        private void mainTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
