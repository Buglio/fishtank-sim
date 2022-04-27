using System.Collections.Generic;
using UnityEngine;

namespace fishtank
{
    [CreateAssetMenu(fileName = "NewFishSpeciesStats", menuName = "Scriptable Objects/Fish Species Stats")]
    public class FishSpeciesStats_SO : ScriptableObject
    {   // TODO: add tooltips for these
        public string CommonName;

        public string ScientificName;

        public SizeClass SizeClass;

        public float MinSizeInMM;

        public float MaxSizeInMM;

        public float MinWeightInGrams;

        public float MaxWeightInGrams;

        public float MinLifespanInYears;

        public float MaxLifespanInYears;

        public int MinTempK;

        public int MaxTempK;

        public float MinPH;

        public float MaxPH;

        public int SpeedCMPerSec;

        public DietClass Diet;

        public MovementClass MovementStyle;

        // Somewhere have a multiplier to change the following stats based on life stage
        public float BodyTemp;
    }
}
