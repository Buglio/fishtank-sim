using System.Collections.Generic;
using UnityEngine;

namespace fishtank
{
    [CreateAssetMenu(fileName = "NewFishStats", menuName = "Scriptable Objects/Fish Stats")]
    public class FishStats_SO : ScriptableObject
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
    }
}
