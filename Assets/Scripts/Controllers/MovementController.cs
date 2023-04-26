using UnityEngine;

namespace Controllers
{
    public class MovementController : MonoBehaviour
    {
        public float speed = 5f; // The speed at which the object will move
        public float minX = -5f; // The minimum X boundary
        public float maxX = 5f; // The maximum X boundary
        public float minY = -5f; // The minimum Y boundary
        public float maxY = 5f; // The maximum Y boundary

        void Update()
        {
            // Get the horizontal and vertical input axes
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            // Calculate the movement direction vector
            Vector2 movement = new Vector2(horizontal, vertical).normalized;

            // Calculate the target position based on movement direction and speed
            Vector3 targetPosition = transform.position + (Vector3)movement * speed * Time.deltaTime;

            // Restrict movement within specified boundaries
            targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);

            // Move the object to the target position
            transform.position = targetPosition;
        }     
    }
}