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
            try
            {
                var ea = new StatusUpdateEventArgs
                {
                    EmptySensorState = ReadOutputPin(PinConfig.StockEmptyPin) ? SensorState.Activated : SensorState.Deactivated,
                    FullSensorState = ReadOutputPin(PinConfig.StockFullPin) ? SensorState.Activated : SensorState.Deactivated,
                    ProductsCount = ReadFlagValue(PinConfig.CounterValueByte.ByteAddress, 0)
                };

                ReportStatus(ea);
            }
            catch (Exception e)
            {
                _dispatcherTimer.Stop();
                MessageBox.Show(e.Message);
            }

        }

        private void ReportStatus(StatusUpdateEventArgs eArg)
        {
            StatusUpdatedEventHandler?.Invoke(this, eArg);
        }

        public void Connect()
        {
            try
            {
                _proSim.Connect();
                _proSim.BeginScanNotify();
                _proSim.SetScanMode(ScanModeConstants.ContinuousScan);

                //_dispatcherTimer = new DispatcherTimer(TimeSpan.FromMilliseconds(500), DispatcherPriority.DataBind, TimerCallback, Dispatcher.CurrentDispatcher);
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
            // MessageBox.Show($"Addr: {PinConfig.CounterValueByte.ByteAddress}");
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

        private ushort ReadFlagValue(int byteAddress, int bitAddress)
        {
            object pData = new ushort();
            _proSim.ReadFlagValue(byteAddress, bitAddress, PointDataTypeConstants.S7_Byte, ref pData);

            return Convert.ToUInt16(pData);
        }

        private int ReadDataBlock(int blockNumber, Byte byteAddress, Byte bitAddress)
        {
            object pData = new int();

            try
            {
                _proSim.ReadDataBlockValue(blockNumber, byteAddress, bitAddress, PointDataTypeConstants.S7_Word, ref pData);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return (int)pData;
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
            _proSim.ConnectionError += ProSimOnConnectionError;

            if (_dispatcherTimer == null)
            {
                _dispatcherTimer = new DispatcherTimer();
                _dispatcherTimer.Interval = TimeSpan.FromMilliseconds(500);
                _dispatcherTimer.Tick += TimerCallback;
            }
        }

        [DispIdAttribute(100)]
        private void ProSimOnConnectionError(string controlEngine, int error)
        {
            MessageBox.Show($"S7 Plc Connection Error.\n" + controlEngine);
        }

        public void Disconnect()
        {
            _dispatcherTimer.Stop();
            //_dispatcherTimer = null;

            ReportStatus(new StatusUpdateEventArgs()
            {
                EmptySensorState = SensorState.Deactivated,
                FullSensorState = SensorState.Deactivated,
                ProductsCount = 0
            });

            _proSim.Disconnect();
        }

        public void Dispose()
        {
            Disconnect();
        }
    }
}
