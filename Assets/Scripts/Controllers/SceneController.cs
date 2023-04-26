using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controllers
{
    public class SceneController : MonoBehaviour
    {
        public static void GameOver()
        {
            SceneManager.LoadScene("GameOverScene");
        }

        public static void StartGame()
        {
            SceneManager.LoadScene("MainScene");
        }

        public static void StartMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}