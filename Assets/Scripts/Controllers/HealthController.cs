using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health for the character
    public int currentHealth; // Current health for the character
    public RawImage[] healthImages; // Array of health images in the UI

    private void Start()
    {
        currentHealth = maxHealth; // Set current health to the maximum health at the start of the game
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Subtract the damage from the current health

        if (currentHealth <= 0)
        {
            currentHealth = 0; // Ensure health doesn't go below zero
            Debug.Log("Player is dead"); // Display a message that the player has died
            SceneController.GameOver();
        }
        UpdateHealthUI();
    }

    public void Heal(int amount)
    {
        currentHealth += amount; // Add the heal amount to the current health

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // Ensure health doesn't go above the maximum health
        }
        UpdateHealthUI();
        FindObjectOfType<AudioPlaybackController>().PlayPowerUpSound();
    }

    private void UpdateHealthUI(){
        for (int i = 0; i < healthImages.Length; i++)
        {
            if(i<currentHealth){
                healthImages[i].enabled = true;
            }
            else{
                healthImages[i].enabled = false;
            }
        }
    }
}
