using LaraGoLike;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public Direction direction;
    RaycastHit hit;
    Ray ray;
    [SerializeField]
    LayerMask layer_mask;
    // Start is called before the first frame update
    void Start()
    {
        CheckDirection();
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

    // Update is called once per frame
    void Update()
    {
        
        Debug.DrawRay(transform.position, ray.direction, Color.red);
        if (Physics.Raycast(ray, out hit, 1f, layer_mask, QueryTriggerInteraction.Ignore))
        {
            if(hit.collider!=null&&hit.collider.gameObject.TryGetComponent<Train>(out Train train))
                train.Rotate(direction);
        }
    }

}

