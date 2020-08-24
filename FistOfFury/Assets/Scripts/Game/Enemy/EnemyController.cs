using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MagicSpace.LS
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField]
        private Animation enemyAnimator;

        private readonly List<string> runAnimations = new List<string>();
        private readonly List<string> hitAnimations = new List<string>();

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
            enemyAnimator.Play(runAnimations[Random.Range(0, runAnimations.Count)]);
        }

        public void Attack()
        {
            Debug.LogFormat("Enemy: {0} attacks", gameObject.name);
        }

        public void Hit(int animIndex)
        {
            enemyAnimator.Play(hitAnimations[animIndex]);
            IsDead = true;
        }

        private void Awake()
        {
            CachedTransform = this.transform;
            runAnimations.Add("Run_1");
            runAnimations.Add("Run_2");
            hitAnimations.Add("Hit_1");
            hitAnimations.Add("Hit_2");
            hitAnimations.Add("Hit_3");

            enemyAnimator.Play(runAnimations[Random.Range(0, runAnimations.Count)]);
        }
    }
}

