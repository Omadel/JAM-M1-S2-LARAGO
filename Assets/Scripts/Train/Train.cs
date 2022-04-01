using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LaraGoLike
{
    public class Train : MovableObject
    {
        
        public static Train instance;
        public Direction TrainFirstDir;
        public int StepBeforMove;

        private int _compt = 0;
        
        private Direction currentDirection; 

        float _timer;
        void Awake()
        {
            if (Train.instance != null)
            {
                Debug.LogError("This is more than One Train");
            }
            Train.instance = this;
        }

        public void Start()
        {
            PlayerMovement.instance.OnMove += MoveDir;
            GetCurrentTile();
            currentDirection = TrainFirstDir;
        }

        private void MoveDir(bool isMoving, Vector3 arg2)
        {
            if (_compt <= StepBeforMove-1)
            {
                _compt++;
            }
            else
            {
                if (isMoving == true)
                {
                    Move(currentDirection);
                }
            }
        }

        public void Rotate(Direction direction)
        {
            currentDirection = direction;
        }

        public Direction GetDirection()
        {
            return currentDirection;
        }

        public void SetDirection(Direction dir)
        {
            currentDirection = dir;
        }
    }
}
