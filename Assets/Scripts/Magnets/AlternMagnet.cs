using System;
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
        public bool isPlayer;
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
            if (isPlayer)
            {
                PlayerMovement.instance.OnMove += AlternPlayer;
            }
            else
            {
                PlayerMovement.instance.OnMove += AlternPlate;
            }
        }

        private void AlternPlate(bool arg1, Vector3 arg2)
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

        private void AlternPlayer(bool arg1, Vector3 arg2)
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
