using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicSpace.LS
{
    public class BattleManager : MonoBehaviour
    {
        [SerializeField] private List<LaneController> lanes;

        private bool isSpawning = false;

        public void OnPlayerAttack(SwipeDirection direction)
        {
            var targetedLane = lanes.Find((lane) => lane.LaneDirection == direction);
            targetedLane.OnPlayerAttack();
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
                lane.Push();
            }

            var laneToSpawn = lanes[Random.Range(0, lanes.Count)];
            laneToSpawn.Spawn();
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

