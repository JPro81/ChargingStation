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

        public ChargingState State
        {
            get
            {
                return _slots.Any(x => x.State.ChargingState == ChargingState.Charging)
                    ? ChargingState.Charging 
                    : ChargingState.NonCharging;
            }

        }

        public int Power { get; private set; }

        public void StartCharging(SlotId slotId)
        {
            Slot slot = _slots.Find(x => x.Id == slotId);
            slot.StartCharging();
        }

        public void StopCharging(SlotId slotId)
        {
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
