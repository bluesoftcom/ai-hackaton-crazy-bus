using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagerWreck : MonoBehaviour
{
    public int damageAmount = 1; // Amount of damage to deal to the player
    public GameObject explosionObj; //prefab for explosion
    public Sprite newSprite; //change the graphic of damaged object

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("Enter");
        if (collision.CompareTag("Player"))
        {
            
            HealthController healthController = collision.gameObject.GetComponent<HealthController>();
            healthController.TakeDamage(damageAmount);

            Vector3 position = gameObject.transform.position;
            Quaternion rotation = Quaternion.identity;
            GameObject newObj = Instantiate(explosionObj, position, rotation);

            //Destroy(gameObject);
            SpriteRenderer spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
            if (spriteRenderer != null && newSprite != null)
            {
                spriteRenderer.sprite = newSprite;
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
