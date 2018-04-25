using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace zad7wpf
{
    public class GenderToBackgroundConverter : IValueConverter
    {
        public GenderEnum GenderToHighlight { get; set; }
        public Brush HighlightBrush { get; set; }
        public Brush DefaultBrush { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Enum gender = (Enum)value;
            if (gender.CompareTo(GenderEnum.Kobieta) == 0)
                return HighlightBrush;
            else
                return DefaultBrush;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
