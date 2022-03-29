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
        }
        
        public SlotState State { get; private set; }
        public SlotId Id { get; private set; }
        
        internal void StartCharging()
        {
            State.ChargingState =  ChargingState.Charging;
            State.Power = 50;
        }

        public void StopCharging()
        {
            State.ChargingState = ChargingState.NonCharging;
            State.Power = 0;
        }

    }
    
}
