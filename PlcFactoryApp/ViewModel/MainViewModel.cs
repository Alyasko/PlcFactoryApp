using System;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using PlcFactoryApp.Core;
using PlcFactoryApp.ViewModel.UserControls;

namespace PlcFactoryApp.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private IPlcSimulator _simulator;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {

            }

            Initialize();
        }

        private void Initialize()
        {
            try
            {
                Title = "PLC Factory App";

                Storage = new StorageIndicatorViewModel();

                _simulator = new PlcSimulator();
                _simulator.StatusUpdatedEventHandler = StatusUpdatedEventHandler;

                _simulator.Initialize();

                MainWindowCommands = new MainWindowCommands(this, _simulator);

                IsEditMode = true;
            }
            catch (Exception e)
            {
                if (!IsInDesignMode)
                    MessageBox.Show($"Unable to start program. Error occured.\n{e.Message}\n{e.StackTrace}");
            }

        }

        private void StatusUpdatedEventHandler(object sender, StatusUpdateEventArgs statusUpdateEventArgs)
        {
            Storage.EmptySensorState = statusUpdateEventArgs.EmptySensorState;
            Storage.FullSensorState = statusUpdateEventArgs.FullSensorState;

            Storage.ProductsCount = statusUpdateEventArgs.ProductsCount;
        }

        public string Title { get; set; }

        private StorageIndicatorViewModel _storage;
        public StorageIndicatorViewModel Storage
        {
            get => _storage;
            set { _storage = value; }
        }

        private bool _isConnected;
        public bool IsEditMode
        {
            get => _isConnected;
            set
            {
                _isConnected = value;
                RaisePropertyChanged(nameof(IsEditMode));
            }
        }

        public MainWindowCommands MainWindowCommands { get; set; }
    }
}