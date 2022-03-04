using ChargingStationCore;
using FluentAssertions;
using System;
using Xunit;

namespace ChargingStationTests
{
    public class ChargingStationTest
    {
        [Fact]
        public void ChargingStationCreation() 
        {
            ChargingStation chargingStation = new();//Arrange + Act

            bool isChargingStationCreated = chargingStation is not null;
            
            Assert.True(isChargingStationCreated);                  //Assert

        }

        [Fact]
        public void ChargingStationCreationWithFluentAssertion()
        {
            ChargingStation chargingStation = new();//Arrange + Act
                    
            chargingStation.Should().NotBeNull();                   //Assert

        }

        [Fact]
        public void InitialChargingStateIsNonCharging()
        {
            ChargingStation chargingStation = new();      //Arrange + Act

            chargingStation.State.Should().Be(ChargingState.NonCharging); //Assert
        }

        [Fact]
        public void ChargingStationStateIsChargingWhenChargingStartedOnSlotOne()
        {
            ChargingStation chargingStation = new();      //Arrange

            chargingStation.StartCharging(SlotId.One);                      //Act

            chargingStation.State.Should().Be(ChargingState.Charging);    //Assert
        }

        [Fact]
        public void StationStateIsChargingWhenChargingStartedOnSlotTwo()
        {
            ChargingStation chargingStation = CreateStationInChargingState();      //Arrange

            chargingStation.StartCharging(SlotId.Two);                      //Act

            chargingStation.State.Should().Be(ChargingState.Charging);    //Assert
        }

        [Fact]
        public void StationStateIsNonChargingWhenAllSlotsChargingStopped()
        {
            ChargingStation chargingStation = CreateStationInChargingState();      //Arrange

            DisconnectAllSlots(chargingStation);

            chargingStation.State.Should().Be(ChargingState.NonCharging);    //Assert
        }

        private static void DisconnectAllSlots(ChargingStation chargingStation)
        {
            chargingStation.StopCharging(SlotId.One);                      
            chargingStation.StopCharging(SlotId.Two);
            chargingStation.StopCharging(SlotId.Three);
            chargingStation.StopCharging(SlotId.Four);
        }

        [Fact]
        public void AllSlotsConnected_DisconnectAllSlots_StationStateIsNonCharging()
        {
            ChargingStation chargingStation = CreateStationInChargingStateAllSlotsConnected();      //Arrange

            DisconnectAllSlots(chargingStation);

            chargingStation.State.Should().Be(ChargingState.NonCharging);    //Assert
        }

        private ChargingStation CreateStationInChargingStateAllSlotsConnected()
        {
            ChargingStation chargingStation = new();
            chargingStation.StartCharging(SlotId.One);
            chargingStation.StartCharging(SlotId.Two);
            chargingStation.StartCharging(SlotId.Three);
            chargingStation.StartCharging(SlotId.Four);
            return chargingStation;
        }

        private ChargingStation CreateStationInChargingState()
        {
            ChargingStation chargingStation = new();
            chargingStation.StartCharging(SlotId.One);
            return chargingStation;
        }

        [Fact]
        public void ChargingStationStateIsNonChargingWhenChargingEndedOnSlotOne()
        {
            ChargingStation chargingStation = new();//Arrange

            chargingStation.StopCharging(SlotId.One);          //Act

            chargingStation.State.Should().Be(ChargingState.NonCharging);    //Assert 
        }

        [Fact]
        public void StationAllSlotsNonCharging()
        {
            ChargingStation chargingStation = new();

            chargingStation.State.Should().Be(ChargingState.NonCharging);
        }

        [Fact]
        public void SlotOneStartCharging()
        {
            ChargingStation chargingStation = new();

            chargingStation.StartCharging(SlotId.One);

            SlotState slotState = chargingStation.GetSlotState(SlotId.One);

            slotState.ChargingState.Should().Be(ChargingState.Charging);
        }

        [Fact]
        public void SlotOneStartChargingSlotTwoShouldNotBeCharging()
        {
            ChargingStation chargingStation = new();

            chargingStation.StartCharging(SlotId.One);

            SlotState slotState = chargingStation.GetSlotState(SlotId.Two);

            slotState.ChargingState.Should().Be(ChargingState.NonCharging);
        }

        [Fact]
        public void SlotOneStopChargingWhenSlotOneIsCharging()
        {
            ChargingStation chargingStation = new();
            chargingStation.StartCharging(SlotId.One);

            chargingStation.StopCharging(SlotId.One);

            SlotState slotState = chargingStation.GetSlotState(SlotId.One);
            slotState.ChargingState.Should().Be(ChargingState.NonCharging);
        }




    }
}