using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicSpace.LS
{
    public class BattleManager : MonoBehaviour
    {
        [SerializeField] private List<LaneController> lanes;
        [SerializeField] private PlayerController playerController;

        private bool isSpawning = false;

        // Consider transferring to other script
        public void OnPlayerAttack(SwipeDirection swipeDirection)
        {

        }

        public void StartBattle()
        {
            isSpawning = true;
            StartCoroutine(StartWaves());
        }

        private void SpawnToLane()
        {
            foreach (var lane in lanes)
            {
                // lane.Push();
            }

            var laneToSpawn = lanes[Random.Range(0, lanes.Count)];
            // laneToSpawn.Spawn();
        }

        private IEnumerator StartWaves()
        {
            // spawningCurve = 1.5f;
            while (isSpawning)
            {
                yield return new WaitForSeconds(1.5f);
                SpawnToLane();
            }
        }

        private void Start()
        {
            // TODO: Add trigger to starting battle
            StartBattle();
        }
    }
}

