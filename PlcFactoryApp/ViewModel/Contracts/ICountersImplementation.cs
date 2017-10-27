using System;
using System.Windows.Input;
using PlcFactoryApp.Core;
using PlcFactoryApp.Core.Models;

namespace PlcFactoryApp.ViewModel.Contracts
{
    public interface ICountersImplementation
    {
        ICommand LoadProductCommand { get; set; }
        ICommand UnloadProductCommand { get; set; }
        ICommand ResetStorageCommand { get; set; }
    }
}