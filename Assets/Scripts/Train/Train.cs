using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Train : MovableObject
    {
        public static Train instance;
        
        [Header("First Train Direction")]
        public Direction TrainFirstDir;
        
        [Header("Player Steps Before Train Move")]
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
            if (isMoving == false) return;
            
            if (_compt <= StepBeforMove-1)
            {
                _compt++;
            }
            else
            {
                if (currentTile.neighbours.tiles[(int)currentDirection] != null)
                {
                    Move(currentDirection);
                }
                else
                {
                    UIManager.Instance.LoosePlayerUI();
                }
            }
        }

        protected override void Move(Direction direction)
        {
            base.Move(direction);
            if (currentTile.TryGetComponent<EndTile>(out EndTile end))
            {
                end.DisplayWin();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            PlayerMovement player;
            if (collision.gameObject.TryGetComponent<PlayerMovement>(out player))
            {
                UIManager.Instance.LoosePlayerUI();
                Destroy(collision.gameObject);
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
