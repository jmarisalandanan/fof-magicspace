using UnityEngine;

namespace MagicSpace.LS
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        public int LaneIndex { get; private set; }

        public void Move(int index, Vector3 position)
        {
            LaneIndex = index;
            transform.position = position;
        }

        public void Attack()
        {
        }

        public void Hit()
        {
            spriteRenderer.color = Color.grey;
        }

    }
}

