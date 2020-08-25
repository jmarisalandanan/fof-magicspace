using System;
using UnityEngine;

namespace MagicSpace.LS
{
    public class EnemyController : MonoBehaviour
    {
        private static readonly int WalkHashValue = Animator.StringToHash("isWalking");
        private static readonly int RunHashValue = Animator.StringToHash("isRunning");
        private static readonly int AttackHashValue = Animator.StringToHash("isAttack");
        private static readonly int HitHashValue = Animator.StringToHash("isHit");
        
        [SerializeField]
        private Animator enemyAnimator;

        public int LaneIndex { get; private set; }
        public bool IsDead { get; private set; }
        public Transform CachedTransform { get; private set; }

        public void SetLaneIndex(int index)
        {
            LaneIndex = index;
        }

        public void Move(Vector3 newPosition)
        {
            enemyAnimator.SetBool(WalkHashValue, true);
        }

        public void Attack()
        {
            Debug.LogFormat("Enemy: {0} attacks", gameObject.name);
            enemyAnimator.Play(AttackHashValue);
        }

        public void Hit(int animIndex)
        {
            IsDead = true;
            enemyAnimator.Play(HitHashValue);
        }

        private void Awake()
        {
            CachedTransform = this.transform;
        }

        private void LateUpdate()
        {
           enemyAnimator.transform.LookAt(new Vector3(0,1,0));
        }
    }
}

