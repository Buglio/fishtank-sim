using System;
using System.Collections.Generic;
using UnityEngine;

namespace fishtank
{
    public class Fish : MonoBehaviour
    {
        public TankManager Tank;

        [SerializeField] float o2AffectRate;
        [SerializeField] float co2AffectRate;

        public void SimulateStep()
        {
            //UpdateStats();
            AffectTankStats(); 
        }

        void UpdateStats()
        {
            throw new NotImplementedException();
            // Check if tank stats are within the requirement range of the fish
            // Affect fish health, age, happiness, etc
        }

        void AffectTankStats()
        {
            print("Updating tank...");
            Tank.Stats.O2Ppm -= o2AffectRate;
            Tank.Stats.Co2Ppm += co2AffectRate;
        }
    }
}
