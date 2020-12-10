using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicSpace.LS
{
    public class EnemyController : MonoBehaviour
    {
        public int LaneIndex { get; private set; }
        
        public void Move(int index, Vector3 position)
        {
            LaneIndex = index;
            transform.position = position;
        }

        public void Attack()
        {

        }

        public void Hit()
        {

        }

    }
}

