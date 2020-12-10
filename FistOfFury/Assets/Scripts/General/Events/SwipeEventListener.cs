using MagicSpace.LS;
using UnityEngine;

namespace MagicSpace.Foundation
{
    public class SwipeEventListener : MonoBehaviour
    {
        public SwipeEvent swipeEvent;
        public SwipeDirectionUnityEvent response;

        private void OnEnable()
        {
            swipeEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            swipeEvent.UnRegisterListener(this);
        }

        public void OnEventRaised(SwipeDirection direction)
        {
            response.Invoke(direction);
        }
    }
}
