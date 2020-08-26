using UnityEngine;
using UnityEngine.Events;

namespace  MagicSpace.LS
{
    public class TriggerChecker : MonoBehaviour
    {
        [SerializeField] 
        private LayerMask layerToDetect;

        public UnityEvent onTriggerHit;
        private void OnTriggerEnter(Collider other)
        {
            if (((1 << other.gameObject.layer) & layerToDetect) != 0)
            {
                onTriggerHit.Invoke();
            }
        }
    }
}

