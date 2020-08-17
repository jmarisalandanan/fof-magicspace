using UnityEngine;
using UnityEngine.Events;
using System;

namespace MagicSpace.LS
{
    [Serializable]
    public class VectorUnityEvent : UnityEvent<Vector3> { }

    [Serializable]
    public class SwipeDirectionUnityEvent : UnityEvent<SwipeDirection> { }
}