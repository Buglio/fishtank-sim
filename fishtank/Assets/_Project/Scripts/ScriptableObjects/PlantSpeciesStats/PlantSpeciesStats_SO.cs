using System.Collections.Generic;
using UnityEngine;

namespace fishtank
{
    [CreateAssetMenu(fileName = "NewPlantSpeciesStats", menuName = "Scriptable Objects/Plant Species Stats")]
    public class PlantSpeciesStats_SO : ScriptableObject
    {   // TODO: add tooltips for these
        public string CommonName;

        public string ScientificName;

        public float SegmentSizeInMM;

        public float SegmentLifespan;

        public int MinTempK;

        public int MaxTempK;

        public float MinPH;

        public float MaxPH;

        public PropagationType PropagationType;

        [Tooltip("Negative float from 0 to 1.")]
        public float O2AffectRate;

        [Tooltip("Positive float from 0 to 1.")] // We originally had a reason for making these affect rates a range from 0 to 1... I forget what it was. 
        public float Co2AffectRate;              // I'll set these to the tetra values as placeholder values

        [Tooltip("Positive float from 0 to 1.")]
        public float AmmoniaAffectRate;
    }
}
