using Controllers.Types;
using UnityEngine;

namespace Controllers
{
    public class BoundaryDeleteController : MonoBehaviour
    {
        [SerializeField]
        private Bounds boundaryBox;

        // Update is called once per frame
        void Update()
        {
            // Find all game objects with a Destroyable component
            Destroyable[] destroyables = FindObjectsOfType<Destroyable>();

            // Loop through all Destroyable objects
            foreach (Destroyable destroyable in destroyables)
            {
                // Check if the object's position is outside the boundary box
                if (!boundaryBox.Contains(destroyable.transform.position))
                {
                    // Destroy the object
                    Destroy(destroyable.gameObject);
                    ScoreUiController.AddScore(10);
                }
            }
        }

        // OnDrawGizmosSelected is called when the object is selected in the editor
        void OnDrawGizmosSelected()
        {
            // Draw a wireframe box representing the boundary box
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(boundaryBox.center, boundaryBox.size);
        }
    }
}