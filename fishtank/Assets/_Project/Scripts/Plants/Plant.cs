using System;
using System.Collections.Generic;
using UnityEngine;

namespace fishtank
{
    public class Plant : MonoBehaviour
    {
        public PlantSpeciesStats_SO SpeciesStats;
        TankManager tank;

        void Awake()
        {
            tank = TankManager.Instance;
            if (!tank.PlantsInTank.Contains(this))
                tank.PlantsInTank.Add(this);
        }

        public void SimulateStep()
        {
            //UpdateStats();
            AffectTankStats();
        }

        void UpdateStats()
        {
            throw new NotImplementedException();
            // Check if tank stats are within the requirement range of the plant
            // Affect plant stats
        }

        void AffectTankStats()
        {
            // Might want to move this into SimulateStep (in the fish class)
            print("Plant affecting tank stats");
            tank.O2Ppm += SpeciesStats.O2AffectRate; // Make this logarithmic eventually
            tank.Co2Ppm += SpeciesStats.Co2AffectRate;
        }
    }
}
