using TMPro;
using UnityEngine;

namespace Controllers
{
    public class ScoreUiController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreValueText;
        private static int _currentScore = 0;
        private static ScoreUiController _instance;

        public void Awake()
        {
            _instance = this;
        }

        public void Start()
        {
            scoreValueText.text = _currentScore.ToString();
        }

        public static void AddScore(int scoreValue)
        {
            _currentScore += scoreValue;
            // update the score text
            _instance.scoreValueText.text = _currentScore.ToString();
        }
    }
}