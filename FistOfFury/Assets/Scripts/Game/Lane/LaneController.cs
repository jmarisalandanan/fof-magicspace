using System.Collections;
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

        private List<EnemyController> enemiesInLanes = new List<EnemyController>();
        private List<EnemyController> enemiesToRemove = new List<EnemyController>();

        public void Spawn()
        {
            // TODO: replace with object pooling
            var newEnemy = GameObject.Instantiate(battlePrefabCollection.GetRandom(), lanePositions[0]);
            enemiesInLanes.Add(newEnemy);
        }

        public void Push()
        {
            foreach (var enemy in enemiesInLanes)
            {
                var newIndex = enemy.LaneIndex + 1;
                // Sanity check
                if (newIndex >= lanePositions.Count)
                {
                    enemiesToRemove.Add(enemy);
                }
                else
                {
                    enemy.Move(lanePositions[newIndex].position);
                    enemy.SetLaneIndex(newIndex);
                }
            }

            foreach (var enemy in enemiesToRemove)
            {
                enemiesInLanes.Remove(enemy);
                GameObject.Destroy(enemy.gameObject);
            }
            enemiesToRemove.Clear();
        }
    }
}
