using System;
using System.Collections.Generic;
using UnityEngine;

namespace fishtank
{
    public class Fish : MonoBehaviour
    {
        public FishSpeciesStats_SO SpeciesStats;
        TankManager tank;

        [SerializeField] int ID;
        [SerializeField] int age = 0;       // increment at the end of each day/night cycle
        [SerializeField] bool canReproduce;
        [SerializeField] float hunger = 1f; // Between 0 and 1
        [SerializeField] float health = 1f; // Between 0 and 1
        [SerializeField] float weightG;
        //float happiness; // ?

        void Awake()
        {
            ID = this.GetHashCode();
            weightG = SpeciesStats.MinWeightInGrams;    // start fish as baby weight

            tank = TankManager.Instance;

            print(ReferenceEquals(tank, TankManager.Instance)); // This neat method confirms that the reference points to the instance

            if (!tank.FishInTank.Contains(this))
                tank.FishInTank.Add(this);
        }

        public void SimulateStep(float timeScale)
        {
            UpdateStats(timeScale);
            AffectTankStats(timeScale); 
        }

        void UpdateStats(float timeScale)
        {
            // HUNGER
            hunger -= 0.0001f; // reduce hunger        // this should run out in one day cycle
            if (hunger < 0.5f && tank.FoodMG > 0)
            {
                var MealSizeMG = UnityEngine.Random.Range(weightG * 0.018f, weightG * 0.025f) * 1000 * timeScale;
                var PossibleMealSizeMG = MealSizeMG <= tank.FoodMG ? MealSizeMG : tank.FoodMG;
                print(MealSizeMG);
                print(PossibleMealSizeMG);
                print(tank.FoodMG);
                tank.FoodMG -= PossibleMealSizeMG;
                hunger = 1f; 
            }

            // HEALTH
            if (tank.Co2Ppm > 29f) // adjust value later
            {
                health -= 0.000001f * timeScale;
            }
        }

        // This is duplicate code. Also present in the plant class.
        void AffectTankStats(float timeScale)
        {
            tank.O2Ppm += SpeciesStats.O2AffectRate * timeScale; // Make this logarithmic eventually
            tank.Co2Ppm += SpeciesStats.Co2AffectRate * timeScale;
        }
    }
}
