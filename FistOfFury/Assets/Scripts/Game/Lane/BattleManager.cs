using System.Collections;
using System.Collections.Generic;
using MagicSpace.Extensions;
using UnityEngine;
using UnityEngine.Events;

namespace MagicSpace.LS
{
    //TODO: Replace with GameManager
    public class BattleManager : MonoBehaviour
    {
        [SerializeField]
        private List<Transform> startPositions = new List<Transform>();
        [SerializeField] 
        private EnemyController enemyPrefab;

        private bool isWaveSpawning = false;

        private IEnumerator SpawnEnemies()
        {
            while (isWaveSpawning)
            {
                yield return new WaitForSeconds(Random.Range(3,5));
                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            var startPos = startPositions.PickRandom();
            var enemy = Instantiate(enemyPrefab, startPos);
            enemy.Move(true);
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isWaveSpawning)
            {
                isWaveSpawning = true;
                StartCoroutine(SpawnEnemies());
            }
        }
    }
}

