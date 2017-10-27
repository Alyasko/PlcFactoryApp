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
    public class CountersImplementation : AbstractCountersImplementation
    {
        public CountersImplementation(IPlcSimulator simulator) : base(simulator)
        {
            PlcSimulatorInst.PinConfig = new PinConfig()
            {
                ResetControllerPin = new PinAddress() { ByteAddress = 0, BitAddress = 0 },
                LoadProductPin = new PinAddress() { ByteAddress = 0, BitAddress = 1 },
                UnloadProductPin = new PinAddress() { ByteAddress = 0, BitAddress = 2 },
                StockFullPin = new PinAddress() { ByteAddress = 4, BitAddress = 0 },
                StockEmptyPin = new PinAddress() { ByteAddress = 4, BitAddress = 1 }
            };
        }
    }
}
