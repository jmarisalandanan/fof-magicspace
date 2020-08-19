using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicSpace.LS
{
    //TODO: Replace with GameManager
    public class LaneManager : MonoBehaviour
    {
        [SerializeField]
        private List<LaneController> lanes = new List<LaneController>();

        [SerializeField]
        private PlayerController playerController;

        private bool isSpawning = false;

        public void SpawnToLane()
        {
            foreach (var lane in lanes)
            {
                lane.Push();
            }

            var laneToSpawn = lanes[Random.Range(0, lanes.Count)];
            laneToSpawn.Spawn();
        }

        int animIndex = 0;
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

        private IEnumerator StartWaves()
        {
            while (isSpawning)
            {
                yield return new WaitForSeconds(1f);
                SpawnToLane();
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!isSpawning)
                {
                    isSpawning = true;
                    StartCoroutine(StartWaves());
                }
            }
        }
    }
}

