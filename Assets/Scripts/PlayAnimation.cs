using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    public Animation anim; // Reference to the Animation component on the object

    private void Start()
    {
        // Make sure the animation component is assigned
        if (anim == null)
        {
            anim = GetComponent<Animation>();
        }
    }

    private void Update()
    {
        // Check for input to trigger the animation
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // If the animation is already playing, stop it first
            if (anim.isPlaying)
            {
                anim.Stop();
            }

            // Play the animation clip
            anim.Play();
        }
    }
}
