using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LaraGoLike
{
    public class OmniMagnet : MonoBehaviour
    {
        public BoxCollider[] colliders;
        public Vector2 trainDir;
        Vector3[] V3Dir = new Vector3[4] { Vector3.forward, Vector3.back, Vector3.right, Vector3.left };


        private void Start()
        {
            SetMagnetDir();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other != null)
            {
                Train train = other.GetComponent<Train>();
                if (train)
                {
                    
                    Debug.Log(trainDir.x);
                    Debug.Log(trainDir.y);
                    //train.CalculateDirection(trainDir);
                }
            }
        }

        public void SetMagnetDir()
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].center = V3Dir[i];
            }
        }
    }
}
