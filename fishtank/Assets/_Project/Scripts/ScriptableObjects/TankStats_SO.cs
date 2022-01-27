using System.Collections.Generic;
using UnityEngine;

namespace fishtank
{
    [CreateAssetMenu(fileName = "TankStats", menuName = "Scriptable Objects/Tank Stats")]
    public class TankStats_SO : ScriptableObject
    {
        public float Light;
        public float TempInF;
        public float pH;
        public float O2Ppm;
        public float Co2Ppm;
        public float AlkalinityPpm; // Is this just a different (better?) way to measure pH?
        public float AmmoniaPpm; // Pretty much anything other than 0 will kill fish
        public float NitritePpm; // Couldn't find good info
        public float NitratePpm; // Couldn't find good info
        public float HardnessPpm;
        public SubstrateType Substrate;

        // Alkalinity, Hardness, and pH could be merged, probably...
    }
}
