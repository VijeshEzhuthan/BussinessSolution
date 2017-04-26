using System;
using System.Windows;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;

namespace BussinessSolution
{
    public class ErrorsToMessageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
          System.Globalization.CultureInfo culture)
        {
            ReadOnlyCollection<ValidationError> collection = value as ReadOnlyCollection<ValidationError>;
            if (collection != null && collection.Count > 0)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new object();
        }
    }
}
