using System.Collections.Generic;
using UnityEngine;
using MagicSpace.Extensions;
using UnityEngine.Events;

namespace MagicSpace.LS
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField]
        private Animator enemyAnimator;

        public int LaneIndex { get; private set; } = 0;
        public bool IsDead { get; private set; } = false;
        public Transform CachedTransform { get; private set; }

        public void SetLaneIndex(int index)
        {
            LaneIndex = index;
        }

        public void Move(Vector3 newPosition)
        {
            CachedTransform.position = newPosition;
        }

        public void Attack()
        {
            Debug.LogFormat("Enemy: {0} attacks", gameObject.name);
        }

        public void Hit(int animIndex)
        {
            IsDead = true;
        }

        private void Awake()
        {
            CachedTransform = this.transform;
        }
    }
}

