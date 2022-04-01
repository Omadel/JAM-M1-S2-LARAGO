using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LaraGoLike
{
    public class Train : MovableObject
    {
        
        public static Train instance;

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

        private void Start()
        {
            PlayerMovement.instance.OnMove += MoveDir;
            GetCurrentTile();
        }

        private void MoveDir(bool isMoving, Vector3 arg2)
        {
            if (isMoving == true)
            {
                Move(currentDirection);
            }
        }
        //private void Update()
        //{
        //    _timer += Time.deltaTime;
        //    if (_timer > 1)
        //    {
        //        _timer = 0;
        //        Move(currentDirection);
        //    }
        //    Debug.Log(currentDirection);
        //}

        public void Rotate(Direction direction)
        {
            currentDirection = direction;
        }

        public Direction GetDirection()
        {
            return currentDirection;
        }
    }
}
