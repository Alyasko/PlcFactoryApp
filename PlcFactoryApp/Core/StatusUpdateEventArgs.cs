using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlcFactoryApp.ViewModel.UserControls;

namespace PlcFactoryApp.Core
{
    public class StatusUpdateEventArgs : EventArgs
    {
        public SensorState FullSensorState { get; set; }
        public SensorState EmptySensorState { get; set; }
        public int ProductsCount { get; set; }
    }
}
