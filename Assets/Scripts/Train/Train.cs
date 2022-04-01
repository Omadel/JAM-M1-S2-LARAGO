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
            GetCurrentTile();
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer > 1)
            {
                _timer = 0;
                Move(currentDirection);
            }
            Debug.Log(currentDirection);
        }

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
