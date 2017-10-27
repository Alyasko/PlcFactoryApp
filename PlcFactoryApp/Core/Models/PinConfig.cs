using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace PlcFactoryApp.Core.Models
{
    public class PinConfig : ViewModelBase
    {
        private PinAddress _loadProductPin;

        public PinConfig()
        {
            
        }

        public PinAddress LoadProductPin
        {
            get { return _loadProductPin; }
            set
            {
                _loadProductPin = value;
                RaisePropertyChanged(nameof(LoadProductPin));
            }
        }

        public PinAddress UnloadProductPin { get; set; }
        public PinAddress ResetControllerPin { get; set; }

        public PinAddress StockEmptyPin { get; set; }
        public PinAddress StockFullPin { get; set; }

        public PinAddress CounterValueByte { get; set; }
    }
}
