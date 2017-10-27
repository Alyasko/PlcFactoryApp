using System;
using PlcFactoryApp.Core;
using PlcFactoryApp.Core.Models;

namespace PlcFactoryApp.ViewModel
{
    public class IecCountersImplementation : AbstractCountersImplementation
    {
        public IecCountersImplementation(IPlcSimulator simulator) : base(simulator)
        {
            PublicPinConfig = IecPublicPinConfig;
        }

        protected override PinConfig UpdatePinConfig()
        {
            return PublicPinConfig;
        }

        public override PinConfig PublicPinConfig { get; set; }

        public static PinConfig IecPublicPinConfig = new PinConfig()
        {
            ResetControllerPin = new PinAddress() {ByteAddress = 1, BitAddress = 0},
            LoadProductPin = new PinAddress() {ByteAddress = 1, BitAddress = 1},
            UnloadProductPin = new PinAddress() {ByteAddress = 1, BitAddress = 2},
            StockFullPin = new PinAddress() {ByteAddress = 5, BitAddress = 0},
            StockEmptyPin = new PinAddress() {ByteAddress = 5, BitAddress = 1}
        };
    }
}
