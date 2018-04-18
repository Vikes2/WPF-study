using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace zad5wpf
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void UpdateAll(string name, string surname, string mail)
        {
            foreach (Window w in Windows)
            {
                if (w is UserDlgNonm)
                {
                    ((UserDlgNonm)w).update(name, surname, mail);
                }
            }
        }
        public void DeleteAll()
        {
            foreach (Window w in Windows)
            {
                if (w is UserDlgNonm)
                {
                    ((UserDlgNonm)w).Close();
                }
            }
        }

    }


}
