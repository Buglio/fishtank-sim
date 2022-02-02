using System;
using System.Collections.Generic;
using UnityEngine;

namespace fishtank
{
    public class Fish : MonoBehaviour
    {
        public FishSpeciesStats_SO SpeciesStats;
        TankManager tank;

        int ID;
        int age;
        bool canReproduce;
        float hunger; // Between 0 and 1
        float health; // Between 0 and 1
        //float happiness; // ?

        void Awake()
        {
            ID = this.GetHashCode();

            tank = TankManager.Instance;

            print(ReferenceEquals(tank, TankManager.Instance)); // This neat method confirms that the reference points to the instance

            if (!tank.FishInTank.Contains(this))
                tank.FishInTank.Add(this);
        }

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

        // This is duplicate code. Also present in the plant class.
        void AffectTankStats()
        {
            print("Fish affecting tank stats...");
            tank.O2Ppm += SpeciesStats.O2AffectRate; // Make this logarithmic eventually
            tank.Co2Ppm += SpeciesStats.Co2AffectRate;
        }
    }
}
