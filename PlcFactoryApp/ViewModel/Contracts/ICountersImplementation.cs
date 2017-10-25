using System.Windows.Input;

namespace PlcFactoryApp.ViewModel.Contracts
{
    public interface ICountersImplementation
    {
        ICommand LoadProductCommand { get; set; }
        ICommand UnladProductCommand { get; set; }
        ICommand ResetStorageCommand { get; set; }
    }
}