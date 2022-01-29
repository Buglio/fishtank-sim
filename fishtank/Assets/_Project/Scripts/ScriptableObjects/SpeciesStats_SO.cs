using System.Collections.Generic;
using UnityEngine;

namespace fishtank
{
    [CreateAssetMenu(fileName = "NewFishStats", menuName = "Scriptable Objects/Fish Stats")]
    public class SpeciesStats_SO : ScriptableObject
    {
        public string Name;
        public string ScientificName;
        public SizeClass SizeClass;
        public float MinSizeInMM;
        public float MaxSizeInMM;
        public float MinLifespanInYears;
        public float MaxLifespanInYears;
        public int SpeedCMPerSec;
        public DietClass Diet;
        public MovementClass MovementStyle;
        // Somewhere have a multiplier to change the following stats based on life stage
        public float BodyTemp;
        [Tooltip("Positive float from 0 to 1.")]
        public float O2AffectRate;
        [Tooltip("Negative float from 0 to 1.")]
        public float Co2AffectRate;
        [Tooltip("Positive float from 0 to 1.")]
        public float AmmoniaAffectRate;
    }
}
