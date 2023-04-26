using System;
using UnityEngine;

namespace Controllers
{
    public class MainMenuController : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

        public void StartGame()
        {
            FindObjectOfType<AudioPlaybackController>().PlayClickSound();
            SceneController.StartGame();
        }

        public void ExitGame()
        {
            FindObjectOfType<AudioPlaybackController>().PlayClickSound();
            Application.Quit();
        }
    }
}