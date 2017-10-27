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
            PlcSimulatorInst.BeforeStatusUpdatedEventHandler = BeforeStatusUpdate;

            LoadProductCommand = new RelayCommand(() =>
            {
                PlcSimulatorInst.PinConfig = UpdatePinConfig();
                PlcSimulatorInst.LoadProduct();
            });

            UnloadProductCommand = new RelayCommand(() =>
            {
                PlcSimulatorInst.PinConfig = UpdatePinConfig();
                PlcSimulatorInst.UnloadProduct();
            });

            ResetStorageCommand = new RelayCommand(() =>
            {
                PlcSimulatorInst.PinConfig = UpdatePinConfig();
                PlcSimulatorInst.ResetStorage();
            });
        }

        protected abstract PinConfig UpdatePinConfig();

        public virtual ICommand LoadProductCommand { get; set; }

        public virtual ICommand UnloadProductCommand { get; set; }

        public virtual ICommand ResetStorageCommand { get; set; }
        public abstract PinConfig PublicPinConfig { get; set; }
        public void ResetAll()
        {
            PlcSimulatorInst.PinConfig = UpdatePinConfig();
            PlcSimulatorInst.ResetAll();
        }

        private void BeforeStatusUpdate(object sender, EventArgs statusUpdateEventArgs)
        {
            UpdatePinConfig();
        }
    }
}
