using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PlcFactoryApp.Core;
using PlcFactoryApp.Core.Config;
using PlcFactoryApp.ViewModel.Contracts;

namespace PlcFactoryApp.ViewModel
{
    public class MainWindowCommands : ViewModelBase
    {
        private MainViewModel _vm;
        private IPlcSimulator _plcSimulator;

        public MainWindowCommands(MainViewModel vm)
        {
            _vm = vm;

            ConnectCommand = new RelayCommand(() =>
            {
                try
                {
                    
                    PlcSimulator = new PlcSimulator();
                    PlcSimulator.StatusUpdatedEventHandler = _vm.StatusUpdatedEventHandler;
                    PlcSimulator.Initialize();

                    PlcSimulator.PinConfig = _vm.Storage.PinConfig;

                    CountersImplementation.PlcSimulator = PlcSimulator;

                    PlcSimulator.Connect();
                    PlcSimulator.ResetAll();

                    _vm.IsEditMode = false;

                    MainViewModel.ConfigProvider.Value.Save(new ConfigModel()
                    {
                        PinConfig = PlcSimulator.PinConfig
                    });
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Connection error.\n{e.Message}\n{e.StackTrace}");
                }
            });

            DisconnectCommand = new RelayCommand(() =>
            {
                try
                {
                    PlcSimulator.Dispose();
                    PlcSimulator = null;

                    _vm.IsEditMode = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Disconnection error.\n{e.Message}\n{e.StackTrace}");
                }
            });
        }

        public IPlcSimulator PlcSimulator
        {
            get { return _plcSimulator; }
            set
            {
                _plcSimulator = value;
            }
        }

        public ICommand ConnectCommand { get; set; }
        public ICommand DisconnectCommand { get; set; }

        public ICountersImplementation CountersImplementation { get; set; }
    }
}
