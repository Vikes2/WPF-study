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
using System.Windows.Shapes;

namespace zad5wpf.Properties
{
    /// <summary>
    /// Logika interakcji dla klasy UserDlg.xaml
    /// </summary>
    public partial class UserDlg : Window
    {
        public UserDlg()
        {
            InitializeComponent();
        }

        public string MyName { get; set; }
        public string MySurname { get; set; }
        public string MyMail { get; set; }

        public void Dlg_loaded(object sender, RoutedEventArgs e)
        {
            nameBox.Text = MyName;
            surnameBox.Text = MySurname;
            mailBox.Text = MyMail;
        }

        private void onOk(object sender, RoutedEventArgs e)
        {
            MyName = nameBox.Text;
            MySurname = surnameBox.Text;
            MyMail = mailBox.Text;
            DialogResult = true;
            Close();
        }
    }
}
