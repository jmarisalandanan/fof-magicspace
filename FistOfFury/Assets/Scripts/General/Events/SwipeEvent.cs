using System.Collections.Generic;
using MagicSpace.LS;
using UnityEngine;

namespace MagicSpace.Foundation
{
    [CreateAssetMenu(fileName = "SwipeEvent", menuName = "MagicSpace/Events/SwipeEvent", order = 0)]
    public class SwipeEvent : ScriptableObject
    {
        private List<SwipeEventListener> listeners = new List<SwipeEventListener>();

        public void Raise(SwipeDirection direction)
        {
            for (var i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised(direction);
            }
        }

        public void RegisterListener(SwipeEventListener listener)
        {
            listeners.Add(listener);
        }

        public void UnRegisterListener(SwipeEventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}
