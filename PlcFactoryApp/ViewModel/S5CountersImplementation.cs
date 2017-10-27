using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using PlcFactoryApp.Core;
using PlcFactoryApp.Core.Models;

namespace PlcFactoryApp.ViewModel
{
    public class S5CountersImplementation : AbstractCountersImplementation
    {
        public S5CountersImplementation(IPlcSimulator simulator) : base(simulator)
        {
            PublicPinConfig = S5PublicPinConfig;
        }

        protected override PinConfig UpdatePinConfig()
        {
            return PublicPinConfig;
        }

        public override PinConfig PublicPinConfig { get; set; }

        public static PinConfig S5PublicPinConfig = new PinConfig()
        {
            ResetControllerPin = new PinAddress() { ByteAddress = 0, BitAddress = 0 },
            LoadProductPin = new PinAddress() { ByteAddress = 0, BitAddress = 1 },
            UnloadProductPin = new PinAddress() { ByteAddress = 0, BitAddress = 2 },
            StockFullPin = new PinAddress() { ByteAddress = 4, BitAddress = 0 },
            StockEmptyPin = new PinAddress() { ByteAddress = 4, BitAddress = 1 }
        };
    }
}
