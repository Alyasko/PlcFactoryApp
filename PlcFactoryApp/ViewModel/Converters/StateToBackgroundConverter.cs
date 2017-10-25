using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using PlcFactoryApp.ViewModel.UserControls;

namespace PlcFactoryApp.ViewModel.Converters
{
    class StateToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SensorState? state = value as SensorState?;

            if (state.HasValue == false)
                return Brushes.Gray;

            return state == SensorState.Activated ? Brushes.LightGreen : Brushes.Gainsboro;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
