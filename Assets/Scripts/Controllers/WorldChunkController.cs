using UnityEngine;

namespace Controllers
{
    public class WorldChunkController : MonoBehaviour
    {
        [SerializeField] private float yThreshold = -10f;

        // Update is called once per frame
        void Update()
        {
            if(transform.position.y < yThreshold)
            {
                Destroy(gameObject);
            }
        }
    }
}