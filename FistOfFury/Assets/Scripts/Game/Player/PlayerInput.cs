using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

namespace MagicSpace.LS
{
    public enum SwipeDirection
    {
        Up,
        Down,
        Left,
        Right,
    }
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField]
        private SwipeDirectionUnityEvent OnPlayerSwipe;

        private void HandleFingerSwipe(LeanFinger finger)
        {
            Vector3 direction = (finger.LastScreenPosition - finger.StartScreenPosition).normalized;
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                OnPlayerSwipe.Invoke(direction.x > 0 ? SwipeDirection.Right : SwipeDirection.Left);
            }
            else
            {
                OnPlayerSwipe.Invoke(direction.y > 0 ? SwipeDirection.Up : SwipeDirection.Down);
            }
            Debug.DrawLine(this.transform.position, this.transform.position + direction * 10, Color.red, 3);
        }

        private void Awake()
        {
            LeanTouch.OnFingerSwipe += HandleFingerSwipe;
        }

        private void OnDestroy()
        {
            LeanTouch.OnFingerSwipe -= HandleFingerSwipe;
        }
    }
}

