using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTester : MonoBehaviour
{
    public HealthController healthController; // Reference to the HealthController script

    private void Start()
    {
        // Get the HealthController script from the player object
        // healthController = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>();
    }

    private void Update()
    {
        // Test taking damage by pressing the "D" key
        if (Input.GetKeyDown(KeyCode.K))
        {
            healthController.TakeDamage(1); // Damage the player by 10 health
        }

        // Test healing by pressing the "H" key
        if (Input.GetKeyDown(KeyCode.L))
        {
            healthController.Heal(1); // Heal the player by 10 health
        }
    }
}
