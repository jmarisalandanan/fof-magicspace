using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicSpace.LS
{
    public class LaneManager : MonoBehaviour
    {
        [SerializeField]
        private List<LaneController> lanes = new List<LaneController>();
        public void SpawnToLane()
        {
            foreach (var lane in lanes)
            {
                lane.Push();
            }

            var laneToSpawn = lanes[Random.Range(0, lanes.Count)];
            laneToSpawn.Spawn();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SpawnToLane();
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                foreach (var lane in lanes)
                {
                    lane.Push();
                }
            }
        }
    }
}

