using System;
using System.Linq;
using System.Collections.Generic;

namespace ChargingStationCore
{
    public class ChargingStation
    {
        private readonly List<Slot> _slots = new() 
        {
            new(SlotId.One),
            new(SlotId.Two),
            new(SlotId.Three),
            new(SlotId.Four),
        };

        public ChargingStation()
        {

        }

        public ChargingState State { get; private set; }
        public int Power { get; private set; } 

        public void StartCharging(SlotId slotId) 
        {
            if (State == ChargingState.NonCharging)
            {
                State = ChargingState.Charging;
            }

            Slot slot = _slots.Find(x => x.Id == slotId);
            slot.StartCharging();      
            
        }

        public void StopCharging(SlotId slotId)
        {
            if (State == ChargingState.Charging)
            {
                State = ChargingState.NonCharging;
            }

            Slot slot = _slots.Find(x => x.Id == slotId);
            slot.StopCharging();
        }

        public SlotState GetSlotState(SlotId slotId)
        {
            Slot slot = _slots.Find(x => x.Id == slotId);
                                    
            return slot.State;
            
        }
    }

    
}
