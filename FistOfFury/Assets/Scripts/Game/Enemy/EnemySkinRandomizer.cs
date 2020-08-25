using System.Collections.Generic;
using UnityEngine;
using MagicSpace.Extensions;

namespace MagicSpace.LS
{
    public class EnemySkinRandomizer : MonoBehaviour
    {
        [SerializeField]
        private List<SkinnedMeshRenderer> headVariation = new List<SkinnedMeshRenderer>();
        [SerializeField]
        private List<SkinnedMeshRenderer> bodyVariation = new List<SkinnedMeshRenderer>();
        [SerializeField]
        private EnemySkinCollection skinCollection;
        
        private void RandomizeSkin()
        {
            foreach (var head in headVariation)
            {
                head.gameObject.SetActive(false);
            }

            foreach (var body in  bodyVariation)
            {
                body.gameObject.SetActive(false);
            }

            var randomHead = headVariation.PickRandom();
            var randomBody = bodyVariation.PickRandom();
            var randomSkin = skinCollection.GetRandomSkin();
            randomHead.material = randomSkin;
            randomBody.material = randomSkin;
            randomHead.gameObject.SetActive(true);
            randomBody.gameObject.SetActive(true);
        }

        private void Awake()
        {
            RandomizeSkin();
        }
    }
}

