using GalaSoft.MvvmLight;
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

            Title = "PLC Factory App";

            Storage1 = new StorageIndicatorViewModel();
            Storage2 = new StorageIndicatorViewModel();

            MainWindowCommands = new MainWindowCommands(this);
        }

        public string Title { get; set; }

        private StorageIndicatorViewModel _storage1;
        public StorageIndicatorViewModel Storage1
        {
            get => _storage1;
            set { _storage1 = value; } 
        }

        private StorageIndicatorViewModel _storage2;
        public StorageIndicatorViewModel Storage2
        {
            get => _storage2;
            set { _storage2 = value; }
        }

        public MainWindowCommands MainWindowCommands { get; set; }
    }
}