using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField]
        private float spawnInterval = 1.0f;

        [SerializeField]
        private float spawnRadius = 1.0f;

        [SerializeField]
        private Transform spawnParent = null;

        [SerializeField]
        private List<SpawnPointController> spawnPointControllers = new List<SpawnPointController>();

        private float _spawnTimer = 0.0f;

        private void Update()
        {
            _spawnTimer -= Time.deltaTime;

            if (_spawnTimer <= 0.0f)
            {
                SpawnPrefab();
                _spawnTimer = spawnInterval;
            }
        }

        private void SpawnPrefab()
        {
            int spawnIndex = Random.Range(0, spawnPointControllers.Count);
            SpawnPointController spawnPointController = spawnPointControllers[spawnIndex];
            GameObject prefabInstance =
                Instantiate(spawnPointController.GetPrefab(), Vector3.zero, Quaternion.identity);
            if (prefabInstance != null)
            {
                Vector3 spawnPosition = spawnPointController.transform.position;
                prefabInstance.transform.position = spawnPosition + Random.insideUnitSphere * spawnRadius;
                prefabInstance.transform.parent = spawnParent;
            }
        }
    }
}