using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LaraGoLike
{
    public class AlternMagnet : Magnet
    {
        public Direction firstDirection;
        public Direction secondDirection;
        public int Duration = 1;
        Ray firstRay;
        Vector3[] directions = new Vector3[4] { Vector3.forward, Vector3.back, Vector3.right, Vector3.left };
        float _timer;
        bool IsFirst;

        private void Start()
        {
            firstRay = new Ray(transform.position,directions[(int)firstDirection]);
            direction = firstDirection;
            SetDeathDirection(direction);
        }

        private void FixedUpdate()
        {          
            _timer += Time.deltaTime;
            if (_timer > Duration)
            {
                _timer = 0;
                Alternate();
                SetDeathDirection(direction);
            }
        }

        public void Alternate()
        {
            if (IsFirst)
            {
                SetDir(firstDirection);
                IsFirst = false;
            }
            else
            {
                SetDir(secondDirection);
                IsFirst = true;
            }   
        }
    }
}
