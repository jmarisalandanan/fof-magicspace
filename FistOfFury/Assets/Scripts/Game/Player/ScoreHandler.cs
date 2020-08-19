using UnityEngine;
using TMPro;

namespace MagicSpace.LS
{
    public class ScoreHandler : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI scoreText;

        private int currentScore = 0;

        public int CurrentScore { get { return currentScore; } }

        public void AddScore()
        {
            currentScore++;
            scoreText.text = currentScore.ToString();
        }
    }
}
