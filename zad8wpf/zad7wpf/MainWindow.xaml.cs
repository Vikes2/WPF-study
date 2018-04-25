using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace zad7wpf
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Person> Persons = new ObservableCollection<Person>(); 

        public MainWindow()
        {
            InitializeComponent();

            ListPersons.ItemsSource = Persons;
            RegionCB.ItemsSource = Enum.GetValues(typeof(CitiesEnum));
            GenderCB.ItemsSource = Enum.GetValues(typeof(GenderEnum));

            View.GroupDescriptions.Add(new PropertyGroupDescription("Gender"));
        }

        private ListCollectionView View
        {
            get
            {
                return (ListCollectionView)CollectionViewSource.GetDefaultView(Persons);
            }
        }

        private void Filter(object sender, RoutedEventArgs e)
        {
            decimal minimumPrice;
            if (Decimal.TryParse(txtMinPrice.Text, out minimumPrice))
            {
                View.Filter = delegate (object item)
                {
                    Person pers = item as Person;
                    if (pers != null)
                    {
                        return (pers.Price > minimumPrice);
                    }
                    return false;
                };
            }
        }

        private void FilterNone(object sender, RoutedEventArgs e)
        {
            View.Filter = null;
        }



        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Persons.Add(new Person());
            ListPersons.SelectedIndex = Persons.Count - 1;
            
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Persons.Remove((Person)ListPersons.SelectedItem);
            ListPersons.SelectedIndex = Persons.Count - 1;
        }

        private void GenderCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            View.Refresh();
        }
    }
}
