using System;
using System.Collections.Generic;
using UnityEngine;

namespace fishtank
{
    public class PlantNode : MonoBehaviour
    {
        public GameObject parent;
        public PlantNode[] children;
        public float age = 0;

        private void TryGrowth(GameObject prefab)
        {
            var shouldGrow = true;
            if (shouldGrow)
            {
                GrowChild(prefab);
            }
        }

        private void GrowChild(GameObject prefab)
        {
            print("Growing child");
        }

        public void Grow(float timeScale)
        {
            age += Time.deltaTime * timeScale;

            var growthScale = Mathf.Clamp(age, 0, 1);
            this.gameObject.transform.localScale = new Vector3(growthScale, growthScale, 0);
        }

        public void SpawnChild(GameObject plantNodePrefab)
        {
            throw new NotImplementedException();
        }
    }
}
