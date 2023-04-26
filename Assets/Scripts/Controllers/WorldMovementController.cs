using UnityEngine;

namespace Controllers
{
    public class WorldMovementController : MonoBehaviour
    {
        [SerializeField]
        private float worldSpeed = 5f;

        [SerializeField]
        private GameObject[] worldChunkPrefabs;

        [SerializeField]
        private float spawnIntervalMultiplier = 1.5f;

        [SerializeField]
        private Transform parentTransform;

        [SerializeField]
        private Vector3 spawnPosition;

        [SerializeField]
        private float worldSpeedScaling;

        private float _spawnInterval;
        private float _spawnTimer;
        private float _worldScaleTimer;
        private float _worldSpeedScale = 1.00f;

        public float WorldSpeedScale => _worldSpeedScale;

        private void Start()
        {
            _worldScaleTimer = Time.time;
            // Calculate the spawn interval based on the world speed and the spawn interval multiplier
            CalculateSpawnInterval();
        }

        private void Update()
        {
            // Move existing world chunks downwards
            GameObject[] worldChunks = GameObject.FindGameObjectsWithTag("MovingWithWorld");
            foreach (GameObject chunk in worldChunks)
            {
                chunk.transform.Translate(Vector3.down * (worldSpeed * Time.deltaTime * _worldSpeedScale));
            }

            // Spawn new world chunks
            _spawnTimer += Time.deltaTime;
            if (_spawnTimer >= _spawnInterval)
            {
                _spawnTimer = 0f;

                int randomIndex = Random.Range(0, worldChunkPrefabs.Length);
                GameObject newChunk = Instantiate(worldChunkPrefabs[randomIndex], spawnPosition, Quaternion.identity,
                    parentTransform);
            }

            if (_worldScaleTimer < Time.time + 1)
            {
                _worldScaleTimer++;
                _worldSpeedScale += worldSpeedScaling;
                CalculateSpawnInterval();
            }
            
        }

        private void CalculateSpawnInterval()
        {
            
            _spawnInterval = (1f / (worldSpeed * _worldSpeedScale)) * spawnIntervalMultiplier;
        }
    }
}