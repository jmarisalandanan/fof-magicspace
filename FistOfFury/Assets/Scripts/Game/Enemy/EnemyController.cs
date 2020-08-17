using UnityEngine;

namespace MagicSpace.LS
{
    public class EnemyController : MonoBehaviour
    {
        private Transform cachedTransform;
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
        }

        public void Attack()
        {
            Debug.LogFormat("Enemy: {0} attacks", gameObject.name);
        }

        public void Hit()
        {
            Debug.LogFormat("Enemy: {0} hit", gameObject.name);

            var rot = cachedTransform.localEulerAngles;
            rot.x = -55;
            cachedTransform.localEulerAngles = rot;
        }

        private void Awake()
        {
            cachedTransform = this.transform;
        }
    }
}

