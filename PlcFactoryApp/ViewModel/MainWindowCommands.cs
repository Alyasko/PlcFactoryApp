using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using PlcFactoryApp.Core;
using PlcFactoryApp.ViewModel.Contracts;

namespace PlcFactoryApp.ViewModel
{
    public class MainWindowCommands
    {
        private MainViewModel _vm;
        private IPlcSimulator _simulator;

        public MainWindowCommands(MainViewModel vm, IPlcSimulator simulator)
        {
            _vm = vm;
            _simulator = simulator;

            S5CountersImplementation = new S5CountersImplementation(simulator);
            IecCountersImplementation = new IecCountersImplementation(simulator);

            ConnectCommand = new RelayCommand(() =>
            {
                try
                {
                    _simulator.Connect();
                    S5CountersImplementation.ResetAll();
                    IecCountersImplementation.ResetAll();
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Connection error.\n{e.Message}\n{e.StackTrace}");
                }
            });
        }

        public ICommand ConnectCommand { get; set; }

        public ICountersImplementation S5CountersImplementation { get; set; }
        public ICountersImplementation IecCountersImplementation { get; set; }
    }
}
