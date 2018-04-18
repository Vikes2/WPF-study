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

    public class Person : INotifyPropertyChanged
    {
        private string name;
        private string lastName;
        private string mail;
        public decimal Price { get; set; }
        public CitiesEnum City { get; set; }
        public int AccessLevel { get; set; }
        private bool description;


        public bool Description
        { get { return description;}
          set { description = value; OnPropertyChanged("Description");}
        }

        public Person()
        {
            Price = 0;
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
