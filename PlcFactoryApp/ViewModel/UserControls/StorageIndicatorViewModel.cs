using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using PlcFactoryApp.Core.Models;

namespace PlcFactoryApp.ViewModel.UserControls
{
    public class StorageIndicatorViewModel : ViewModelBase
    {
        private string _fullSensorName;
        private string _emptySensorName;
        private int _productsCount;
        private SensorState _fullSensorState;
        private SensorState _emptySensorState;
        private PinConfig _pinConfig;

        public StorageIndicatorViewModel()
        {
            FullSensorName = "Storage full";
            EmptySensorName = "Storage empty";
            ProductsCount = 5;

            FullSensorState = SensorState.Deactivated;
            EmptySensorState = SensorState.Deactivated;

            PinConfig = new PinConfig()
            {
                LoadProductPin = new PinAddress()
                {
                    ByteAddress = 0,
                    BitAddress = 4
                }
            };
        }

        public string FullSensorName
        {
            get { return _fullSensorName; }
            set
            {
                _fullSensorName = value; 
                RaisePropertyChanged(nameof(FullSensorName));
            }
        }

        public string EmptySensorName
        {
            get { return _emptySensorName; }
            set
            {
                _emptySensorName = value;
                RaisePropertyChanged(nameof(EmptySensorName));
            }
        }

        public int ProductsCount
        {
            get { return _productsCount; }
            set
            {
                _productsCount = value;
                RaisePropertyChanged(nameof(ProductsCount));
            }
        }

        public SensorState FullSensorState
        {
            get { return _fullSensorState; }
            set
            {
                _fullSensorState = value;
                RaisePropertyChanged(nameof(FullSensorState));
            }
        }

        public SensorState EmptySensorState
        {
            get { return _emptySensorState; }
            set
            {
                _emptySensorState = value;
                RaisePropertyChanged(nameof(EmptySensorState));
            }
        }

        public PinConfig PinConfig
        {
            get { return _pinConfig; }
            set
            {
                _pinConfig = value;
                RaisePropertyChanged(nameof(PinConfig));
            }
        }
    }
}
