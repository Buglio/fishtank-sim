using System.Collections.Generic;
using UnityEngine;

namespace fishtank
{
    [CreateAssetMenu(fileName = "TankStats", menuName = "Scriptable Objects/Tank Stats")]
    public class TankStats_SO : ScriptableObject
    {
        public float Light; // Played controlled via slider. Set light schedule
        public float TempInK; // Measured in kelvin. Allow player to change between C/F. Player controlled via slider.
        public float pH; // Player controlled via slider?
        public float O2Ppm;
        public float Co2Ppm;
        public float AlkalinityPpm; 
        public float AmmoniaPpm; // Pretty much anything other than 0 will kill fish
        public float NitritePpm; // Couldn't find good info
        public float NitratePpm; // Couldn't find good info
        public float HardnessPpm;
        public SubstrateType Substrate;

        // Alkalinity, Hardness, and pH could be merged, probably...
    }
}
