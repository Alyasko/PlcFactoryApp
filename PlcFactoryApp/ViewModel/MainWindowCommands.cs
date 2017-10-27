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

            CountersImplementation = new CountersImplementation(simulator);

            ConnectCommand = new RelayCommand(() =>
            {
                try
                {
                    _simulator.Connect();
                    _simulator.ResetAll();

                    _vm.IsEditMode = false;
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Connection error.\n{e.Message}\n{e.StackTrace}");
                }
            });
        }

        public ICommand ConnectCommand { get; set; }

        public ICountersImplementation CountersImplementation { get; set; }
    }
}
