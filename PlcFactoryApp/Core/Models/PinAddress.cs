using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;

namespace PlcFactoryApp.Core.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class PinAddress : ViewModelBase
    {
        private short _byteAddress;
        private byte _bitAddress;

        [JsonProperty]
        public short ByteAddress
        {
            get { return _byteAddress; }
            set
            {
                _byteAddress = value;
                RaisePropertyChanged(nameof(ByteAddress));
            }
        }

        [JsonProperty]
        public byte BitAddress
        {
            get { return _bitAddress; }
            set
            {
                _bitAddress = value; 
                RaisePropertyChanged(nameof(BitAddress));
            }
        }

        public override string ToString()
        {
            return $"{ByteAddress}, {BitAddress}";
        }
    }
}
