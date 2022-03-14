using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LaraGoLike
{
    public class Train : MovableObject
    {
        public static Train instance;
        void Awake()
        {
            if (Train.instance != null)
            {
                Debug.LogError("This is more than One Train");
            }
            Train.instance = this;
        }
    }
}
