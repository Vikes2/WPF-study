using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad7wpf
{
    public enum CitiesEnum
    {
        Bialystok,
        Warszawa,
        Gdansk ,
        Poznan,
        Katowice,
        Sopot
    }

    public enum GenderEnum
    {
        Mezczyzna,
        Kobieta
    }

    public class Person : INotifyPropertyChanged
    {
        private string name;
        private string lastName;
        private string mail;
        private decimal price;
        public CitiesEnum City { get; set; }
        public int AccessLevel { get; set; }
        private bool description;
        public GenderEnum Gender { get; set; }

        public decimal Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                    throw new ArgumentException(
                    "Cena musi być większa od 0.");
                price = value;
            }
        }

        public bool Description
        { get { return description;}
          set { description = value; OnPropertyChanged("Description");}
        }

        public Person()
        {
            Price = 100;
            AccessLevel = 0;
            Description = true;
            City = 0 ;
        }

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("personView"); }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; OnPropertyChanged("personView"); }
        }

        public string Mail
        {
            get { return mail; }
            set { mail = value; OnPropertyChanged("personView"); }
        }

        public string PersonView
        {
            
            get {
                if(mail == null)
                {
                    return name + " " + lastName;
                }
                return name + " " + lastName + " (" + mail + ")"; }
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this,
                new PropertyChangedEventArgs(property));
        }

    }
}
