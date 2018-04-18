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

namespace zad5wpf
{
    /// <summary>
    /// Logika interakcji dla klasy UserDlgNonm.xaml
    /// </summary>
    public partial class UserDlgNonm : Window
    {
        public UserDlgNonm()
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).updateAll(nameBox.Text, surnameBox.Text, mailBox.Text);
        }

        public void update(string _name, string _surname, string _mail)
        {
            nameBox.Text = _name;
            surnameBox.Text = _surname;
            mailBox.Text = _mail;
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
