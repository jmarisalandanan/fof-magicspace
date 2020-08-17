using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

namespace MagicSpace.LS
{
    public class PlayerController : MonoBehaviour
    {
        public void Attack(SwipeDirection direction)
        {
            Debug.Log(direction);
        }
    }
}

