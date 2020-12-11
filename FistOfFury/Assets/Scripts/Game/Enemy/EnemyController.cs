using MagicSpace.Foundation;
using UnityEngine;

namespace MagicSpace.LS
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private GameEvent OnEnemyAttack;
        [SerializeField] private GameEvent OnEnemyHit;
        public int LaneIndex { get; private set; }

        public void Move(int index, Vector3 position)
        {
            LaneIndex = index;
            transform.position = position;
        }

        public void Attack()
        {
            OnEnemyAttack.Raise();
        }

        public void Hit()
        {
            OnEnemyHit.Raise();
            spriteRenderer.color = Color.grey;
        }

    }
}

