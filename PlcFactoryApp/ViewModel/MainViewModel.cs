using System;
using System.Windows;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using PlcFactoryApp.Core;
using PlcFactoryApp.Core.Config;
using PlcFactoryApp.Core.Models;
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
            IsEditMode = true;

            try
            {
                Title = "PLC Factory App";

                Storage = new StorageIndicatorViewModel();
                MainWindowCommands = new MainWindowCommands(this);
                MainWindowCommands.CountersImplementation = new CountersImplementation(null);

                if (ConfigProvider.Value.Exists)
                {
                    Storage.PinConfig = ConfigProvider.Value.Load().PinConfig;
                }
            }
            catch (Exception e)
            {
                if (!IsInDesignMode)
                    MessageBox.Show($"Unable to start program. Error occured.\n{e.Message}\n{e.StackTrace}");
            }

        }

        public void StatusUpdatedEventHandler(object sender, StatusUpdateEventArgs statusUpdateEventArgs)
        {
            Storage.EmptySensorState = statusUpdateEventArgs.EmptySensorState;
            Storage.FullSensorState = statusUpdateEventArgs.FullSensorState;

            Storage.ProductsCount = statusUpdateEventArgs.ProductsCount;
        }

        public string Title { get; set; }

        public static Lazy<IConfigProvider> ConfigProvider = new Lazy<IConfigProvider>(() => new ConfigProvider());

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
                RaisePropertyChanged(nameof(IsNotEditMode));
            }
        }

        public bool IsNotEditMode
        {
            get { return !IsEditMode; }
        }

        public MainWindowCommands MainWindowCommands { get; set; }
    }
}