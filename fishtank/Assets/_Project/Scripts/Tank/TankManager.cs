using System.Collections.Generic;
using UnityEngine;

namespace fishtank
{
    public class TankManager : MonoBehaviour
    {
        public static TankManager Instance = null;

        [SerializeField] float _simStep = 0.5f; // All this stuff could be moved to the Game Manager
        [SerializeField] TankStats_SO startingStats;

        public TankStats_SO Stats;

        public List<Fish> FishInTank = new List<Fish>();
        //public List<Plant> PlantsInTank = new List<Plant>();

        public float Co2Ppm = 1;
        public float O2Ppm = 1;

        float _stepTimer = 0;

        private void Awake()
        {
            EnforceSingleton();
        }


        void Update()
        {
            _stepTimer += Time.deltaTime;
            if (_stepTimer > _simStep)
            {
                _stepTimer -= _simStep;
                DoSimulationStep();
            }
        }

        void DoSimulationStep()
        {
            foreach (Fish fish in FishInTank)
            {
                fish.SimulateStep();
            }
        }

        void EnforceSingleton()
        {
            if (Instance == null)
                Instance = this;
            else if (Instance != this)
                Destroy(gameObject);
        }
    }
}
