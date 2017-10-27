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
        protected IPlcSimulator PlcSimulatorInst;

        protected AbstractCountersImplementation(IPlcSimulator simulator)
        {
            PlcSimulatorInst = simulator;

            LoadProductCommand = new RelayCommand(() =>
            {
                PlcSimulatorInst.LoadProduct();
            });

            UnloadProductCommand = new RelayCommand(() =>
            {
                PlcSimulatorInst.UnloadProduct();
            });

            ResetStorageCommand = new RelayCommand(() =>
            {
                PlcSimulatorInst.ResetStorage();
            });
        }

        public virtual ICommand LoadProductCommand { get; set; }

        public virtual ICommand UnloadProductCommand { get; set; }

        public virtual ICommand ResetStorageCommand { get; set; }
    }
}
