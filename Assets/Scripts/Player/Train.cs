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
            Debug.DrawRay(transform.position + (Vector3.up * 0.5f), Vector3.down, Color.red);
            _timer += Time.deltaTime;
            if (_timer > 1)
            {
                _timer = 0;
                Debug.Log("Move");
                Move(currentDirection);
            }
        }

        public void Rotate(Direction direction)
        {
            currentDirection = direction;
        }
    }
}
