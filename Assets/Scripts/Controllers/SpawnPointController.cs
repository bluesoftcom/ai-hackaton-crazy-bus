using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Controllers
{
    public class SpawnPointController : MonoBehaviour
    {
        [Serializable]
        public class WeightedPrefab
        {
            public GameObject prefab;
            public float weight = 1f;
        }

        public List<WeightedPrefab> weightedPrefabs = new List<WeightedPrefab>();

        public GameObject GetPrefab()
        {
            if (weightedPrefabs.Count > 0)
            {
                float totalWeight = 0f;
                foreach (var weightedPrefab in weightedPrefabs)
                {
                    totalWeight += weightedPrefab.weight;
                }

                float randomWeight = Random.Range(0f, totalWeight);

                foreach (var weightedPrefab in weightedPrefabs)
                {
                    randomWeight -= weightedPrefab.weight;

                    if (randomWeight <= 0f)
                    {
                        return weightedPrefab.prefab;
                    }
                }
            }

            return null;
        }
    }
}