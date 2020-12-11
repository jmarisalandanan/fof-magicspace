using System.Collections.Generic;
using MagicSpace.Extensions;
using MagicSpace.Foundation;
using UnityEngine;

namespace MagicSpace.LS
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Animation playerAnimator;
        [SerializeField] private GameObject hitCollider;
        [SerializeField] private GameEvent OnPlayerDead;

        private readonly List<string> attackAnimations = new List<string>();
        private Transform cachedTransform;

        public void Attack(SwipeDirection direction)
        {
            cachedTransform.eulerAngles = BattleUtils.GetVectorDirection(direction);
            playerAnimator.Play(attackAnimations.PickRandom());
            hitCollider.gameObject.SetActive(true);
        }

        public void Hit()
        {
            OnPlayerDead.Raise();
        }

        private void Awake()
        {
            cachedTransform = this.transform;
            attackAnimations.Add("Attack_1");
            attackAnimations.Add("Attack_2");
            attackAnimations.Add("Attack_3");
        }
    }
}

