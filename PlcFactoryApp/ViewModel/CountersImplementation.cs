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
            
        }
    }
}
