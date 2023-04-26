using System;
using UnityEngine;

namespace Controllers
{
    public class GameOverController : MonoBehaviour
    {
        private void Start()
        {
            FindObjectOfType<AudioPlaybackController>().PlayGameOverSound();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneController.StartGame();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneController.StartMainMenu();
            }
        }
    }
}