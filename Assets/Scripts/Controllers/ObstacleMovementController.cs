using System;
using UnityEngine;

namespace Controllers
{
    public class ObstacleMovementController : MonoBehaviour
    {
        [SerializeField]
        private Vector3 additionalMovement = new Vector3(0f, 0f, 0f);

        [SerializeField]
        private float additionalMovementSpeed = 1f;

        [SerializeField]
        private WorldMovementController _worldMovementController;

        private void Start()
        {
            _worldMovementController = FindObjectOfType<WorldMovementController>();
        }

        private void Update()
        {
            // Move the object based on its additional movement vector and speed
            transform.Translate(additionalMovement * (additionalMovementSpeed * Time.deltaTime * _worldMovementController.WorldSpeedScale));
        }
    }
}