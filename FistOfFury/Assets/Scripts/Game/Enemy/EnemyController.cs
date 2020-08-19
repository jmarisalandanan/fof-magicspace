using System.Collections.Generic;
using UnityEngine;

namespace MagicSpace.LS
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField]
        private Animation enemyAnimator;

        private Transform cachedTransform;
        private List<string> runAnimations = new List<string>();
        private List<string> hitAnimations = new List<string>();
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
            enemyAnimator.Play(runAnimations[Random.Range(0, runAnimations.Count)]);
        }

        public void Attack()
        {
            Debug.LogFormat("Enemy: {0} attacks", gameObject.name);
        }

        public void Hit(int animIndex)
        {
            Debug.LogFormat("Enemy: {0} hit", gameObject.name);
            enemyAnimator.Play(hitAnimations[animIndex]);
        }

        private void Awake()
        {
            cachedTransform = this.transform;
            runAnimations.Add("Run_1");
            runAnimations.Add("Run_2");
            hitAnimations.Add("Hit_1");
            hitAnimations.Add("Hit_2");
            hitAnimations.Add("Hit_3");

            enemyAnimator.Play(runAnimations[Random.Range(0, runAnimations.Count)]);
        }
    }
}

