using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicSpace.LS
{
    public static class BattleUtils
    {
        public static Vector3 GetVectorDirection(SwipeDirection direction)
        {
            var vecDirection = Vector3.zero;
            switch (direction)
            {
                case SwipeDirection.Up:
                    vecDirection.y = 180;
                    break;
                case SwipeDirection.Down:
                    vecDirection.y = 0;
                    break;
                case SwipeDirection.Left:
                    vecDirection.y = 90;
                    break;
                case SwipeDirection.Right:
                    vecDirection.y = -90;
                    break;
                default:
                    Debug.LogErrorFormat("Unhandled SwipeDirection: {0}", direction);
                    break;
            }
            return vecDirection;
        }
    }
}

