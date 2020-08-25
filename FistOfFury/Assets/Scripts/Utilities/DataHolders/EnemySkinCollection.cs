using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MagicSpace.Extensions;

namespace MagicSpace.LS
{
    [CreateAssetMenu(menuName = ("MagicSpace/Data/EnemySkinCollection"))]
    public class EnemySkinCollection : ScriptableObject
    {
        [SerializeField]
        private List<Material> materialVariation = new List<Material>();

        public Material GetRandomSkin()
        {
            return materialVariation.PickRandom();
        }
    }
}

