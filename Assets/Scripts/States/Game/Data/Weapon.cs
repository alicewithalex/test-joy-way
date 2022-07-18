using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace alicewithalex.Data
{
    [System.Serializable]
    public class Weapon : Item
    {
        public StatusType StatusType;
        public Transform ShootRay;
    }
}