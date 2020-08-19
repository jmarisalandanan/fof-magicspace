using UnityEngine;
using UnityEngine.Events;
using TMPro;

namespace MagicSpace.LS
{
    public class ScoreHandler : MonoBehaviour
    {
        private const int THRESHOLD_INTERVAL = 25;
        [SerializeField]
        private TextMeshProUGUI scoreText;

        private int currentScore = 0;

        public int CurrentScore { get { return currentScore; } }

        public UnityEvent OnScoringThresholdReached;

        public void AddScore()
        {
            currentScore++;
            scoreText.text = currentScore.ToString();
            CheckScoreThreshold();
        }

        private void CheckScoreThreshold()
        {
            switch (currentScore)
            {
                case 5:
                    OnScoringThresholdReached.Invoke();
                    break;
                case 10:
                    OnScoringThresholdReached.Invoke();
                    break;
                case 20:
                    OnScoringThresholdReached.Invoke();
                    break;
                case 30:
                    OnScoringThresholdReached.Invoke();
                    break;
                case 50:
                    OnScoringThresholdReached.Invoke();
                    break;
                case 75:
                    OnScoringThresholdReached.Invoke();
                    break;
                case 100:
                    OnScoringThresholdReached.Invoke();
                    break;
            }
        }
    }
}
