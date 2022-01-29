using System.Collections.Generic;
using UnityEngine;

namespace fishtank
{
    public class AffectTank : MonoBehaviour
    {
        Fish fish;
        SpeciesStats_SO speciesStats;
        void Start()
        {
            fish = gameObject.GetComponent<Fish>();
            speciesStats = fish.SpeciesStats;
        }

        void AffectTankStats()
        {
            // Might want to move this into SimulateStep (in the fish class)
            print("Updating tank...");
            TankManager.Instance.O2Ppm += speciesStats.O2AffectRate;
            TankManager.Instance.Co2Ppm += speciesStats.Co2AffectRate;
        }
    }
}
