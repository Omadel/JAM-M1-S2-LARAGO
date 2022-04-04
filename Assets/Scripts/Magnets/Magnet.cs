using LaraGoLike;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [Header("Direction For UniMagnet")]
    public Direction direction;
    
    Direction DeathDirection = Direction.Up;
    Ray ray;
    [SerializeField]
    LayerMask layer_mask;
    int[] rotation = new int[] { 0, 180, 90, -90 };


    void Start()
    {
        CheckDirection();
        SetDeathDirection(direction);
        transform.GetChild(0).localRotation=Quaternion.Euler(0,rotation[(int)direction],0);
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
            case Direction.Up:
                ray = new Ray(transform.position, Vector3.forward);
                break;
            case Direction.Down:
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
            case Direction.Up:
                DeathDirection = Direction.Down;
                break;
            case Direction.Down:
                DeathDirection = Direction.Up;
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
                    UIManager.Instance.LooseTrainUI();
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

