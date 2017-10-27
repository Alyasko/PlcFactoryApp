using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using PlcFactoryApp.Core.Models;
using PlcFactoryApp.ViewModel;
using PlcFactoryApp.ViewModel.UserControls;
using S7PROSIMLib;

namespace PlcFactoryApp.Core
{
    class PlcSimulator : IPlcSimulator
    {
        private S7ProSim _proSim;
        private DispatcherTimer _dispatcherTimer;

        public PinConfig PinConfig { get; set; }

        public PlcSimulator()
        {
            
        }

        private void TimerCallback(object sender, EventArgs eventArgs)
        {
            // BeforeStatusUpdatedEventHandler?.Invoke(this, new EventArgs());

            var ea = new StatusUpdateEventArgs
            {
                S5EmptySensorState = ReadOutputPin(S5CountersImplementation.S5PublicPinConfig.StockEmptyPin) ? SensorState.Activated : SensorState.Deactivated,
                S5FullSensorState = ReadOutputPin(S5CountersImplementation.S5PublicPinConfig.StockFullPin) ? SensorState.Activated : SensorState.Deactivated,
                IecEmptySensorState = ReadOutputPin(IecCountersImplementation.IecPublicPinConfig.StockEmptyPin) ? SensorState.Activated : SensorState.Deactivated,
                IecFullSensorState = ReadOutputPin(IecCountersImplementation.IecPublicPinConfig.StockFullPin) ? SensorState.Activated : SensorState.Deactivated,

                ProductsCount = 0
            };

            StatusUpdatedEventHandler?.Invoke(this, ea);
        }

        public void Connect()
        {
            try
            {
                _proSim.Connect();
                _proSim.BeginScanNotify();
                _proSim.SetScanMode(ScanModeConstants.ContinuousScan);

                if(_dispatcherTimer == null)
                    _dispatcherTimer = new DispatcherTimer(TimeSpan.FromMilliseconds(500), DispatcherPriority.DataBind, TimerCallback, Dispatcher.CurrentDispatcher);

                _dispatcherTimer.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void LoadProduct()
        {
            BlinkInputPin(PinConfig.LoadProductPin);
        }

        public void UnloadProduct()
        {
            BlinkInputPin(PinConfig.UnloadProductPin);
        }

        public void ResetStorage()
        {
            BlinkInputPin(PinConfig.ResetControllerPin);
        }

        private void WriteInputPin(PinAddress config, bool value)
        {
            _proSim.WriteInputPoint(config.ByteAddress, config.BitAddress, value);
        }

        private void BlinkInputPin(PinAddress config)
        {
            WriteInputPin(config, false);

            WriteInputPin(config, true);
            Thread.Sleep(100);

            WriteInputPin(config, false);
        }

        private bool ReadOutputPin(PinAddress config)
        {
            var pData = new Object();
            _proSim.ReadOutputPoint(config.ByteAddress, config.BitAddress, PointDataTypeConstants.S7_Bit, ref pData);

            return (bool)pData;
        }

        private short ReadDataBlock(Byte address)
        {
            object pData = new short();

            try
            {
                _proSim.ReadDataBlockValue(1, address, 0, PointDataTypeConstants.S7_Word, ref pData);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return (short)pData;
        }

        public void ResetAll()
        {
            WriteInputPin(PinConfig.LoadProductPin, false);
            WriteInputPin(PinConfig.UnloadProductPin, false);
            WriteInputPin(PinConfig.ResetControllerPin, false);
        }

        public EventHandler<StatusUpdateEventArgs> StatusUpdatedEventHandler { get; set; }
        public EventHandler BeforeStatusUpdatedEventHandler { get; set; }

        public void Initialize()
        {
            _proSim = new S7ProSim();
            //_proSim.ConnectionError += ProSimOnConnectionError;
        }
    }
}
