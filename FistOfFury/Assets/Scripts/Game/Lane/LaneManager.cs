using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicSpace.LS
{
    public class LaneManager : MonoBehaviour
    {
        [SerializeField]
        private List<LaneController> lanes = new List<LaneController>();

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

        public void OnPlayerAttack(SwipeDirection direction)
        {
            var targetedLane = lanes.Find((lane) => lane.LaneDirection == direction);
            targetedLane.Attack();
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
                isSpawning = true;
                StartCoroutine(StartWaves());
            }
        }
    }
}

