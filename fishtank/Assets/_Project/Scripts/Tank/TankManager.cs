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

        [SerializeField] float simStepInterval = 0.5f; // All this stuff could be moved to the Game Manager
        //[SerializeField] TankStats_SO startingStats;

        public List<Fish> FishInTank = new List<Fish>();
        public List<Plant> PlantsInTank = new List<Plant>();

        //public int TankVolumeInL = 75;
        public float Co2Ppm = 30;
        public float O2Ppm = 8;

        float stepTimer = 0;

        void Update()
        {
            SimulateSteps();
        }

        void SimulateSteps()
        {
            stepTimer += Time.deltaTime;
            if (stepTimer > simStepInterval)
            {
                stepTimer -= simStepInterval;
                DoSimulationStep();
            }
        }

        void DoSimulationStep()
        {
            foreach (Fish fish in FishInTank)
                fish.SimulateStep();

            foreach (Plant plant in PlantsInTank)
                plant.SimulateStep();
        }
    }
}
