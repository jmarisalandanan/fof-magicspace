using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MagicSpace.LS
{
    public class BattleManager : MonoBehaviour
    {
        [SerializeField] private List<LaneController> lanes;

        private bool isSpawning = false;

        public UnityEvent OnBattleStart;

        public void OnPlayerAttack(SwipeDirection direction)
        {
            var targetedLane = lanes.Find((lane) => lane.LaneDirection == direction);
            targetedLane.OnPlayerAttack();
        }

        public void StartBattle()
        {
            OnBattleStart.Invoke();

            foreach (var lane in lanes)
            {
                lane.ClearLanes();
            }

            isSpawning = true;
            StartCoroutine(StartWaves());
        }

        public void StopBattle()
        {
            isSpawning = false;
            StopCoroutine(StartWaves());
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
            while (isSpawning)
            {
                yield return new WaitForSeconds(1.5f);
                SpawnToLane();
            }
        }
    }
}

