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
using zad5wpf.Properties;

namespace zad5wpf
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

        public UserInfo selectedUser;

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedUser = (UserInfo)list.SelectedItem;
            if(list.SelectedItem != null)
            {
                deleteElementBtn.IsEnabled = true;
                editElementBtn.IsEnabled = true;
                previewElementBtn.IsEnabled = true;
                ((App)Application.Current).UpdateAll(selectedUser.Name, selectedUser.Surname, selectedUser.Mail);
            }
            else
            {
                deleteElementBtn.IsEnabled = false;
                editElementBtn.IsEnabled = false;
                previewElementBtn.IsEnabled = false;
                ((App)Application.Current).DeleteAll();
            }
        }

        private void addElementBtn_Click(object sender, RoutedEventArgs e)
        {
            UserDlg window = new UserDlg();
            if (window.ShowDialog() == true)
            {
                UserInfo user = new UserInfo() {
                    Name = window.MyName,
                    Surname = window.MySurname,
                    Mail = window.MyMail
                };
                list.Items.Add( user );
            }
        }

        private void editElementBtn_Click(object sender, RoutedEventArgs e)
        {
            UserDlg window = new UserDlg();
            window.MyName = selectedUser.Name;
            window.MySurname = selectedUser.Surname;
            window.MyMail = selectedUser.Mail;
            if (window.ShowDialog() == true)
            {
                
                selectedUser.Name = window.MyName;
                selectedUser.Surname = window.MySurname;
                selectedUser.Mail = window.MyMail;
                list.Items.Refresh();
                ((App)Application.Current).UpdateAll(selectedUser.Name, selectedUser.Surname, selectedUser.Mail);
            }
        }

        private void deleteElementBtn_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Czy napewno chcesz usunąć?", "Usuwanie elementu", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                list.Items.Remove(selectedUser);
                list.Items.Refresh();
                ((App)Application.Current).DeleteAll();
            }
        }

        private void previewElementBtn_Click(object sender, RoutedEventArgs e)
        {
            UserDlgNonm window = new UserDlgNonm();
            window.MyName = selectedUser.Name;
            window.MySurname = selectedUser.Surname;
            window.MyMail = selectedUser.Mail;
            window.Show();
        }

        public void updateAll(string name, string surname, string mail)
        {
            selectedUser.Name = name;
            selectedUser.Surname = surname;
            selectedUser.Mail = mail;
            list.Items.Refresh();
            ((App)Application.Current).UpdateAll(selectedUser.Name, selectedUser.Surname, selectedUser.Mail);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
