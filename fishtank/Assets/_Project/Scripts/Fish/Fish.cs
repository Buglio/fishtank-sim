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

            //print(ReferenceEquals(tank, TankManager.Instance)); // This neat method confirms that the reference points to the instance

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
            HandleHunger(timeScale);

            HandleHealth(timeScale);
        }

        void HandleHealth(float timeScale)
        {
            var idealPh = new Vector2Int(5, 7);
            var phExtremes = new Vector2Int(0, 14);

            var phInIdealRange = tank.PH >= idealPh.x && tank.PH <= idealPh.y;
            // If ph not in acceptable range
            if (!phInIdealRange)
            {
                var pH = tank.PH;
                if (pH > idealPh.y)
                {
                    var healthDecreaseAmount = (float)(Math.Pow(pH - idealPh.y, 3) / 3) / 8;
                    health -= healthDecreaseAmount;
                }
                if (pH < idealPh.x)
                {
                    var healthDecreaseAmount = (float)-((Math.Pow(pH - idealPh.x, 3) / 3) / 8);
                    health -= healthDecreaseAmount;
                }
            }
        }


        void HandleHunger(float timeScale)
        {
            // HUNGER
            hunger -= 0.0001f * timeScale; // reduce hunger        // this should run out in one day cycle
            if (hunger < 0.5f && tank.FoodMG > 0)
            {
                var mealSizeMG = UnityEngine.Random.Range(weightG * 0.018f, weightG * 0.025f) * 1000;

                tank.FoodMG -= Mathf.Clamp(mealSizeMG, 0f, tank.FoodMG); ;
                hunger = 1f;
            }
        }

        // This is duplicate code. Also present in the plant class.
        void AffectTankStats(float timeScale)
        {
            tank.O2Ppm -= 0.000188f * weightG * timeScale; // sus
            tank.Co2Ppm += 0.000188f * weightG * timeScale; // sus, def change this
            tank.AmmoniaPpm += 0.0000001f * weightG * timeScale; // sus, def change this
        }
    }
}
