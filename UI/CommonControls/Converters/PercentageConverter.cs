using System;
using Windows.UI.Xaml.Data;

namespace UI.CommonControls.Converters
{
    public class PercentageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return "No info";
            }
            else if (value is decimal decimalValue)
            {
                return string.Format("{0:P2}", decimalValue * 0.01m); // *0.01 to correctly format the percentage value
            }
            else
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
