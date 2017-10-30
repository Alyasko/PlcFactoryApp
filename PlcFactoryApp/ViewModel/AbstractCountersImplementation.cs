using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using PlcFactoryApp.Core;
using PlcFactoryApp.Core.Models;
using PlcFactoryApp.ViewModel.Contracts;

namespace PlcFactoryApp.ViewModel
{
    public abstract class AbstractCountersImplementation : ICountersImplementation
    {
        protected AbstractCountersImplementation(IPlcSimulator simulator)
        {
            PlcSimulator = simulator;

            LoadProductCommand = new RelayCommand(() =>
            {
                PlcSimulator.LoadProduct();
            });

            UnloadProductCommand = new RelayCommand(() =>
            {
                PlcSimulator.UnloadProduct();
            });

            ResetStorageCommand = new RelayCommand(() =>
            {
                PlcSimulator.ResetStorage();
            });
        }

        public virtual ICommand LoadProductCommand { get; set; }

        public virtual ICommand UnloadProductCommand { get; set; }

        public virtual ICommand ResetStorageCommand { get; set; }
        public IPlcSimulator PlcSimulator { get; set; }
    }
}
