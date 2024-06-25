using System;

namespace UI.CommonControls.Converters
{
    public class CurrencyNameConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is string stirngValue)
            {
                string[] parts = stirngValue.Split('-');
                return string.Join(" ", parts);
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
