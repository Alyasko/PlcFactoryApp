using System;
using PlcFactoryApp.Core.Models;

namespace PlcFactoryApp.Core
{
    public interface IPlcSimulator
    {
        EventHandler<StatusUpdateEventArgs> StatusUpdatedEventHandler { get; set; }
        EventHandler BeforeStatusUpdatedEventHandler { get; set; }

        void Connect();
        void Initialize();
        PinConfig PinConfig { get; set; }

        void ResetAll();

        void LoadProduct();
        void UnloadProduct();
        void ResetStorage();
    }
}