using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MagicSpace.LS
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField]
        private Animator enemyAnimator;

        private Transform cachedTransform;
        private int laneIndex = 0;
        private bool isDead = false;

        public int LaneIndex { get { return laneIndex; } }
        public bool IsDead { get { return isDead; } }
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
            Debug.LogFormat("Enemy: {0} attacks", gameObject.name);
        }

        public void Hit(int animIndex)
        {
            isDead = true;
        }

        private void Awake()
        {
            cachedTransform = this.transform;
        }
    }
}

