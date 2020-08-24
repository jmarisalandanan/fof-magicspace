using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MagicSpace.LS
{
    //TODO: Replace with GameManager
    public class LaneManager : MonoBehaviour
    {
        private const float DIFFICULTY_WAVE = 0.15f;

        [SerializeField]
        private List<LaneController> lanes = new List<LaneController>();

        [SerializeField]
        private PlayerController playerController;

        [SerializeField]
        private float spawningCurve;

        private bool isSpawning = false;

        public UnityEvent OnPlayerDead;

        private int animIndex = 0;
        public void OnPlayerAttack(SwipeDirection direction)
        {
            playerController.Attack(direction, animIndex);
            var targetedLane = lanes.Find((lane) => lane.LaneDirection == direction);
            targetedLane.Attack(animIndex);
            animIndex++;
            if (animIndex == 3)
            {
                animIndex = 0;
            }
        }

        public void OnPlayerHit()
        {
            isSpawning = false;
            OnPlayerDead.Invoke();
        }

        public void IncreaseDifficulty()
        {
            spawningCurve -= DIFFICULTY_WAVE;
            Debug.Log("Increasing difficulty: " + spawningCurve);
        }

        private void SpawnToLane()
        {
            foreach (var lane in lanes)
            {
                lane.Push();
            }

            var laneToSpawn = lanes[Random.Range(0, lanes.Count)];
            laneToSpawn.Spawn();
        }

        private IEnumerator StartWaves()
        {
            spawningCurve = 1.5f;
            while (isSpawning)
            {
                yield return new WaitForSeconds(spawningCurve);
                SpawnToLane();
            }
        }

        private void Start()
        {
            isSpawning = true;
            StartCoroutine(StartWaves());
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isSpawning)
            {
                isSpawning = true;
                StartCoroutine(StartWaves());
            }
        }
    }
}

