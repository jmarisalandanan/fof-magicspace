using System.Collections.Generic;
using UnityEngine;

namespace MagicSpace.LS
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private Animation playerAnimator;

        private List<string> attackAnimations = new List<string>();
        private Transform cachedTransform;

        public void Attack(SwipeDirection direction)
        {
            cachedTransform.eulerAngles = BattleUtils.GetVectorDirection(direction);
            playerAnimator.Play(attackAnimations[Random.Range(0, attackAnimations.Count)]);
        }

        private void Awake()
        {
            cachedTransform = this.transform;
            attackAnimations.Add("Attack_1");
            attackAnimations.Add("Attack_2");
        }
    }
}

