using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;

public class Damager : MonoBehaviour
{
    public int damageAmount = 1; // Amount of damage to deal to the player
    public GameObject explosionObj; //prefab for explosion

    [SerializeField]
    private Sprite wreckSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("Enter");
        if (collision.CompareTag("Player"))
        {
            HealthController healthController = collision.gameObject.GetComponent<HealthController>();
            healthController.TakeDamage(damageAmount);

            Vector3 position = gameObject.transform.position;
            Quaternion rotation = Quaternion.identity;
            Instantiate(explosionObj, position, rotation);

            FindObjectOfType<AudioPlaybackController>().PlayExplosionSound();
            transform.GetComponent<BoxCollider2D>().enabled = false;
            SpriteRenderer spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
            if (spriteRenderer != null && wreckSprite != null)
            {
                spriteRenderer.sprite = wreckSprite;
                GetComponent<ObstacleMovementController>().enabled = false;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // Debug.Log("Enter");
            HealthController healthController = collision.gameObject.GetComponent<HealthController>();
            healthController.TakeDamage(damageAmount);
        }
    }
}