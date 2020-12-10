﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicSpace.LS
{
    public class LaneController : MonoBehaviour
    {
        [SerializeField] private List<Transform> lanePositions = new List<Transform>();
        [SerializeField] private SwipeDirection laneDirection;

        [SerializeField] private EnemyController enemyPrefab;

        private List<EnemyController> enemiesInLanes = new List<EnemyController>();
        private List<EnemyController> enemiesToRemove = new List<EnemyController>();

        public SwipeDirection LaneDirection => laneDirection;

        public void Spawn()
        {
            var newEnemy = Instantiate(enemyPrefab, lanePositions[0]);
            enemiesInLanes.Add(newEnemy);
        }

        public void OnPlayerAttack()
        {
            Debug.Log("Attacking enemy in lane: " + laneDirection);
            var enemyToAttack = enemiesInLanes.Find(enemy => enemy.LaneIndex == lanePositions.Count - 1);
            if (enemyToAttack != null)
            {
                enemyToAttack.Hit();
                enemiesInLanes.Remove(enemyToAttack);
                Destroy(enemyToAttack);
            }
        }

        public void Push()
        {
            foreach (var enemy in enemiesToRemove)
            {
                enemiesInLanes.Remove(enemy);
                // TODO: Replace with pooling
                Destroy(enemy.gameObject);
            }
            enemiesToRemove.Clear();

            foreach (var enemy in enemiesInLanes)
            {
                var nextIndex = enemy.LaneIndex + 1;
                if (nextIndex >= lanePositions.Count)
                {
                    enemy.Attack();
                    enemiesToRemove.Add(enemy);
                }
                else
                {
                    enemy.Move(nextIndex, lanePositions[nextIndex].position);
                }
            }
        }
    }
}

