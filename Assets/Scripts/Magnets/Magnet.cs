using LaraGoLike;
using System.Collections;
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
    public bool test;


    void Start()
    {
        CheckDirection();
        SetDeathDirection(direction);
        transform.GetChild(0).localRotation=Quaternion.Euler(0,rotation[(int)direction],0);
        PlayerMovement.instance.OnMove +=UpdatePossibleTrain;
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

    void UpdatePossibleTrain(bool isMoving, Vector3 arg2)
    {
        StartCoroutine(Test());
    }

    private IEnumerator Test()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        if (Physics.Raycast(ray, out RaycastHit hit, 1.1f, layer_mask, QueryTriggerInteraction.Collide))
        {

            if (hit.collider.GetComponent<Train>())
            {

                Debug.DrawRay(transform.position, ray.direction, Color.red, 15);
                Debug.Log("hit.coll : " + hit.collider.name);
                if (test == false)
                {
                    test = true;
                }
                if (Train.instance.GetDirection() == DeathDirection)
                {
                    UIManager.Instance.LooseTrainUI();
                    Destroy(Train.instance.gameObject);
                }
                else
                {
                    Train.instance.Rotate(direction);
                }
            }
        }
    }
}

