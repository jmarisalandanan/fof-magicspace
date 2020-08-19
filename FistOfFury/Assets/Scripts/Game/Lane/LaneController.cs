using System.Collections.Generic;
using UnityEngine;

namespace MagicSpace.LS
{
    public class LaneController : MonoBehaviour
    {
        [SerializeField]
        private List<Transform> lanePositions = new List<Transform>();
        [SerializeField]
        private PrefabCollection battlePrefabCollection;
        [SerializeField]
        private SwipeDirection laneDirection;
        [SerializeField]
        private Vector3 laneRotation;

        private List<EnemyController> enemiesInLanes = new List<EnemyController>();
        private List<EnemyController> enemiesToRemove = new List<EnemyController>();

        public SwipeDirection LaneDirection { get { return laneDirection; } }

        public void Spawn()
        {
            // TODO: replace with object pooling
            var newEnemy = GameObject.Instantiate(battlePrefabCollection.GetRandom(), lanePositions[0]);
            newEnemy.CachedTransform.eulerAngles = laneRotation;
            enemiesInLanes.Add(newEnemy);
        }

        public void Attack(int animIndex)
        {
            var enemyToAttack = enemiesInLanes.Find(enemy => enemy.LaneIndex == lanePositions.Count - 1);
            if (enemyToAttack != null)
            {
                enemyToAttack.Hit(animIndex);
                enemiesToRemove.Add(enemyToAttack);
            }
        }

        public void Push()
        {
            foreach (var enemy in enemiesToRemove)
            {
                enemiesInLanes.Remove(enemy);
                // TODO: Replace with pooling
                GameObject.Destroy(enemy.gameObject);
            }
            enemiesToRemove.Clear();


            foreach (var enemy in enemiesInLanes)
            {
                var newIndex = enemy.LaneIndex + 1;
                if (newIndex >= lanePositions.Count)
                {
                    enemy.Attack();
                    enemiesToRemove.Add(enemy);
                }
                else
                {
                    enemy.Move(lanePositions[newIndex].position);
                    enemy.SetLaneIndex(newIndex);
                }
            }
        }
    }
}
