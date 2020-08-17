using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

namespace MagicSpace.LS
{
    public class PlayerController : MonoBehaviour
    {
        private Transform cachedTransform;

        public void Attack(SwipeDirection direction)
        {
            cachedTransform.eulerAngles = BattleUtils.GetVectorDirection(direction);
        }

        private void Awake()
        {
            cachedTransform = this.transform;
        }
    }
}

