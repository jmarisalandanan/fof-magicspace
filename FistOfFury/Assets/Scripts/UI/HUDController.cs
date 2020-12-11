using TMPro;
using UnityEngine;

namespace MagicSpace.LS
{
    public class HUDController : BaseScreen
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        private int currentScore = 0;

        public void OnEnemyKilled()
        {
            currentScore++;
            scoreText.text = currentScore.ToString();
        }

        public void ResetScore()
        {
            currentScore = 0;
            scoreText.text = currentScore.ToString();
        }
    }
}

