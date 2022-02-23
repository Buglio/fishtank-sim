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

        public void SimulateStep(float timeScale)
        {
            //UpdateStats(timeScale);
            AffectTankStats(timeScale);
        }

        void UpdateStats(float timeScale)
        {
            throw new NotImplementedException();
            // Check if tank stats are within the requirement range of the plant
            // Affect plant stats
        }

        // This method is duplicated across this class and the fish class. Maybe we make a base class?
        void AffectTankStats(float timeScale)
        {
            tank.O2Ppm += SpeciesStats.O2AffectRate * timeScale; // Make this logarithmic eventually
            tank.Co2Ppm += SpeciesStats.Co2AffectRate * timeScale;
        }
    }
}
