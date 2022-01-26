using System.Collections.Generic;
using UnityEngine;

namespace fishtank
{
    public class TankManager : MonoBehaviour
    {
        [SerializeField] float simStep = 0.5f;

        public float O2Level;
        public float Co2Level;

        public List<Fish> fishInTank = new List<Fish>();
        //public List<Plant> plantsInTank = new List<Plant>();

        public float _stepTimer = 0;

        void Start()
        {

        }

        void Update()
        {
            _stepTimer += Time.deltaTime;
            if (_stepTimer > simStep)
            {
                _stepTimer -= simStep;
                DoSimulationStep();
            }
        }

        void DoSimulationStep()
        {
            foreach (Fish fish in fishInTank)
            {
                fish.SimulateStep();
            }
        }
    }
}
