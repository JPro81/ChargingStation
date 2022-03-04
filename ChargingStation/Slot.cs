using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingStationCore
{
    internal class Slot
    {
        internal Slot(SlotId slotId)
        {
            State = new();
            Id = slotId;
            Power = 0;
        }
        
        public SlotState State { get; private set; }
        public SlotId Id { get; private set; }
        public int Power { get; private set; }

        internal void StartCharging()
        {
            State.ChargingState =  ChargingState.Charging;
            Power = 50;
        }

        public void StopCharging()
        {
            State.ChargingState = ChargingState.NonCharging;
            Power = 0;
        }

    }
    
}
