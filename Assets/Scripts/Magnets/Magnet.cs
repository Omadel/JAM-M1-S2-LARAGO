using LaraGoLike;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [Header("Direction For UniMagnet")]
    public Direction direction;
    Direction DeathDirection = Direction.Forward;
    Ray ray;
    [SerializeField]
    LayerMask layer_mask;
    
    
    void Start()
    {
        CheckDirection();
        SetDeathDirection(direction);
    }
    public void  SetDir(Direction dir)
    {
        direction = dir;
        CheckDirection();
    }

    private void CheckDirection()
    {
        switch (direction)
        {
            case Direction.Forward:
                ray = new Ray(transform.position, Vector3.forward);
                break;
            case Direction.Back:
                ray = new Ray(transform.position, Vector3.back);
                break;
            case Direction.Right:
                ray = new Ray(transform.position, Vector3.right);
                break;
            case Direction.Left:
                ray = new Ray(transform.position, Vector3.left);
                break;
            default:
                break;
        }
    }

    public void SetDeathDirection(Direction currentDirection)
    {
        switch (currentDirection)
        {
            case Direction.Forward:
                DeathDirection = Direction.Back;
                break;
            case Direction.Back:
                DeathDirection = Direction.Forward;
                break;
            case Direction.Right:
                DeathDirection = Direction.Left;
                break;
            case Direction.Left:
                DeathDirection = Direction.Right;
                break;
            default:
                break;
        }
    }

    void Update()
    {
        if (Physics.Raycast(ray, out RaycastHit hit, 1.1f, layer_mask, QueryTriggerInteraction.Ignore))
        {
            if (hit.collider != null && hit.collider.gameObject.TryGetComponent<Train>(out Train train))
            {
                if (train.GetDirection() == DeathDirection )
                {
                    Destroy(train.gameObject);
                }
                else
                {
                    train.Rotate(direction);
                }
            }
        }
    }
}

