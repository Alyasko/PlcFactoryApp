using System;
using PlcFactoryApp.Core.Models;

namespace PlcFactoryApp.Core
{
    public interface IPlcSimulator : IDisposable
    {
        EventHandler<StatusUpdateEventArgs> StatusUpdatedEventHandler { get; set; }

        void Connect();
        void Disconnect();

        void Initialize();
        PinConfig PinConfig { get; set; }

        void ResetAll();

        void LoadProduct();
        void UnloadProduct();
        void ResetStorage();
    }
}