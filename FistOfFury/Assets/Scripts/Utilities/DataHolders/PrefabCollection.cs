using System.Collections.Generic;
using UnityEngine;

namespace MagicSpace.LS
{
    [CreateAssetMenu(menuName = "MagicSpace/Data/PrefabCollection")]
    public class PrefabCollection : ScriptableObject
    {
        [SerializeField]
        private List<EnemyController> prefabs = new List<EnemyController>();

        public EnemyController GetRandom()
        {
            return prefabs[Random.Range(0, prefabs.Count)];
        }
    }
}
