using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace zad6wpf
{
    public class HanoiCommands
    {
        private static RoutedUICommand pop;
        private static RoutedUICommand push;

        static HanoiCommands()
        {
            pop = new RoutedUICommand("Pop disk from list", "Pop", typeof(HanoiCommands));
            push = new RoutedUICommand("Push disk to list", "Push", typeof(HanoiCommands));
            pop.InputGestures.Add(new KeyGesture(Key.P, ModifierKeys.Control));
        }

        public static RoutedUICommand Pop
        {
            get { return pop; }
        }

        public static RoutedUICommand Push
        {
            get { return push; }
        }

    }
}
