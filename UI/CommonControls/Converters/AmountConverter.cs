using System;
using Windows.UI.Xaml.Data;

namespace UI.CommonControls.Converters
{
    public class AmountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return "No info";
            }
            else if (value is decimal decimalValue)
            {
                bool addDollarSign = parameter != null && parameter.ToString().ToLower() == "true";
                return FormatAmount(decimalValue, addDollarSign);
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

        private string FormatAmount(decimal value, bool addDollarSign)
        {
            string formattedValue;
            if (value >= 1_000_000_000_000)
                formattedValue = (value / 1_000_000_000_000M).ToString("0.##") + "t";
            else if (value >= 1_000_000_000)
                formattedValue = (value / 1_000_000_000M).ToString("0.##") + "b";
            else if (value >= 1_000_000)
                formattedValue = (value / 1_000_000M).ToString("0.##") + "m";
            else
                formattedValue = value.ToString("0.##");

            if (addDollarSign)
            {
                formattedValue = "$" + formattedValue;
            }            
            
            return formattedValue;
        }
    }
}
