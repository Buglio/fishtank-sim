using System.Collections.Generic;
using UnityEngine;

namespace fishtank
{
    public class TankManager : MonoBehaviour
    {
        public TankManager()
        {
            Instance = this;
        }
        public static TankManager Instance { get; private set; }

        [Range(0.001f, 100f)]                         // Change this to a modifier later, rather than increasing simStepInterval
        [SerializeField] float timeScale = 1f;
        //[SerializeField] TankStats_SO startingStats;

        public List<Fish> FishInTank = new List<Fish>();
        public List<Plant> PlantsInTank = new List<Plant>();

        //public int TankVolumeInL = 75;
        public float Co2Ppm = 30;
        public float O2Ppm = 8;
        public float PH = 7f;
        public float TempK = 295f;
        public float FoodMG = 0;
        public float DayCycle = 0f;     // 0 to 1 is a full day
        public float Days = 0;

        // add food to tank
        [ContextMenu("Add 100mg of Food")]
        void AddFood()
        {
            FoodMG += 100f;
        }

        void Start()
        {
            InvokeRepeating("SimulateSteps", 1f, 1f);
        }
        void UpdateTime()
        {
            DayCycle += 1f / 86400f * timeScale;
            if (DayCycle >= 1f)
            {
                DayCycle = 0f;
                Days += 1;
            }
        }

        void SimulateSteps()
        {
            DoSimulationStep();
            UpdateTime();
        }

        void DoSimulationStep()
        {
            foreach (Fish fish in FishInTank)
                fish.SimulateStep(timeScale);

            foreach (Plant plant in PlantsInTank)
                plant.SimulateStep(timeScale);
        }



        

    }
}
