using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using PlcFactoryApp.ViewModel.Contracts;

namespace PlcFactoryApp.ViewModel
{
    public class MainWindowCommands
    {
        private MainViewModel _vm;

        public MainWindowCommands(MainViewModel vm)
        {
            _vm = vm;

            S5CountersImplementation = null;
            IecCountersImplementation = null;
        }

        public ICommand ConnectCommand { get; set; } = new RelayCommand(() =>
        {
            MessageBox.Show("Hello");
        });

        public ICountersImplementation S5CountersImplementation { get; set; }
        public ICountersImplementation IecCountersImplementation { get; set; }
    }
}
