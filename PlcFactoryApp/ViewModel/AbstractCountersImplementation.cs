using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using PlcFactoryApp.ViewModel.Contracts;

namespace PlcFactoryApp.ViewModel
{
    public class AbstractCountersImplementation : ICountersImplementation
    {
        public ICommand LoadProductCommand { get; set; } = new RelayCommand(() =>
        {

        });

        public ICommand UnladProductCommand { get; set; } = new RelayCommand(() =>
        {

        });

        public ICommand ResetStorageCommand { get; set; } = new RelayCommand(() =>
        {
            
        });
    }
}
