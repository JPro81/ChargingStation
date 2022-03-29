using System;
using System.Linq;
using System.Collections.Generic;

namespace ChargingStationCore
{
    public class ChargingStation
    {
        private readonly Dictionary<SlotId, Slot> _slots = new()
        {
            [SlotId.One] = new Slot(SlotId.One),
            [SlotId.Two] = new Slot(SlotId.Two),                
            [SlotId.Three] = new Slot(SlotId.Three),
            [SlotId.Four] = new Slot(SlotId.Four)
        };

        public ChargingStation()
        {

        }

        public ChargingState State
        {
            get
            {
                return _slots.Values.Any(x => x.State.ChargingState == ChargingState.Charging)
                    ? ChargingState.Charging 
                    : ChargingState.NonCharging;
            }

        }

        public int Power 
        { 
            get 
            {
                return _slots.Values.Sum(s => s.State.Power);
            }
            private set 
            { 
            } 
        }

        public void StartCharging(SlotId slotId)
        {
            Slot slot = _slots[slotId];
            slot.StartCharging();
        }

        public void StopCharging(SlotId slotId)
        {
            Slot slot = _slots[slotId];
            slot.StopCharging();
        }

        public SlotState GetSlotState(SlotId slotId)
        {
            Slot slot = _slots[slotId];

            return slot.State;

        }
    }


}
