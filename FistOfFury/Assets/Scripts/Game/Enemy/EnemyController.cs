using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicSpace.LS
{
    public class EnemyController : MonoBehaviour
    {
        private Transform cachedTransform;
        private int laneIndex = 0;

        public int LaneIndex { get { return laneIndex; } }
        public Transform CachedTransform { get { return cachedTransform; } }

        public void SetLaneIndex(int index)
        {
            laneIndex = index;
        }

        public void Move(Vector3 newPosition)
        {
            cachedTransform.position = newPosition;
        }

        public void Attack()
        {

        }

        private void Awake()
        {
            cachedTransform = this.transform;
        }
    }
}

