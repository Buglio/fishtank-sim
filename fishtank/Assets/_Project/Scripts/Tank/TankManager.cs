using System.Collections.Generic;
using UnityEngine;

namespace fishtank
{
    public class TankManager : MonoBehaviour
    {
        [SerializeField] float _simStep = 0.5f; // All this stuff could be moved to the Game Manager
        [SerializeField] TankStats_SO startingStats;

        public TankStats_SO Stats;

        public List<Fish> FishInTank = new List<Fish>();
        //public List<Plant> PlantsInTank = new List<Plant>();

        float _stepTimer = 0;



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
    }
}
