using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : MonoBehaviour
{
    public int healAmount = 1; // Amount of points to heal the player

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("Enter");
        if (collision.CompareTag("Player"))
        {
            
            HealthController healthController = collision.gameObject.GetComponent<HealthController>();
            healthController.Heal(healAmount);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // Debug.Log("Enter");
            HealthController healthController = collision.gameObject.GetComponent<HealthController>();
            healthController.Heal(healAmount);
        }
    }
}
