using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlcFactoryApp.ViewModel.UserControls;

namespace PlcFactoryApp.Core
{
    public class StatusUpdateEventArgs : EventArgs
    {
        public SensorState S5FullSensorState { get; set; }
        public SensorState S5EmptySensorState { get; set; }
        public SensorState IecFullSensorState { get; set; }
        public SensorState IecEmptySensorState { get; set; }
        public int ProductsCount { get; set; }
    }
}
