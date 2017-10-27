using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using PlcFactoryApp.Core.Models;

namespace PlcFactoryApp.ViewModel.Converters
{
    public class PinConfigToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var splited = (value as string).Split(',');

            for (int i = 0; i < splited.Length; i++)
            {
                splited[i] = splited[i].Trim();
            }

            return new PinAddress()
            {
                ByteAddress = Byte.Parse(splited[0]),
                BitAddress = Byte.Parse(splited[1])
            };
        }
    }
}
