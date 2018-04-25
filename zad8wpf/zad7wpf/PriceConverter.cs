using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace zad7wpf
{
    [ValueConversion(typeof(decimal), typeof(string))]
    public class PriceConverter : IValueConverter
    {
        decimal tax = (decimal)1.23;
        public object Convert(object value, Type targetType,
        object parameter, CultureInfo culture)
        {
            decimal price = (decimal)value;
            
            price = decimal.Divide(price, tax);
            return price.ToString("C", culture);
        }
        public object ConvertBack(object value, Type targetType,
        object parameter, CultureInfo culture)
        {
            string price = value.ToString();
            decimal result;
            if (decimal.TryParse(price, NumberStyles.Any,
            culture, out result))
            {
                result = decimal.Multiply(result, tax);
                return result;
            }
            return value;
        }
    }
}
