using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LaraGoLike
{
    public enum MagnetDir
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }


    public class UniMagnet : MonoBehaviour
    {
        public BoxCollider collider;
        public MagnetDir magnetDir;
        public Vector2 trainDir;
        Vector3[] V3Dir = new Vector3[4] { Vector3.forward, Vector3.back, Vector3.right, Vector3.left };


        private void Start()
        {
            SetMagnetDir(magnetDir);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other != null)
            {
                Train train = other.GetComponent<Train>();
                if (train)
                {
                    trainDir.x = collider.center.x;
                    trainDir.y = collider.center.z;
                    Debug.Log(trainDir.x);
                    Debug.Log(trainDir.y);
                    //train.CalculateDirection(trainDir);
                }
            }
        }

        public void SetMagnetDir(MagnetDir magnetDir)
        {
            Vector3 centerDir = new Vector3();
            switch (magnetDir)
            {
                case MagnetDir.LEFT:
                    collider.center = V3Dir[3];
                    return;
                case MagnetDir.RIGHT:
                    collider.center = V3Dir[2];
                    return;

                case MagnetDir.UP:
                    collider.center = V3Dir[0];
                    return;

                case MagnetDir.DOWN:
                    collider.center = V3Dir[1];
                    return;

                default:
                    return;
            }
        }
    }
}
