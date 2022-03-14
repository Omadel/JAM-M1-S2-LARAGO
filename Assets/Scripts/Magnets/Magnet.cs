using LaraGoLike;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public Direction direction;
    private RaycastHit hit;
    private Ray ray;
    [SerializeField]
    private LayerMask layer_mask;

    // Start is called before the first frame update
    private void Start()
    {
        CheckDirection();
    }
    public void SetDir(Direction dir)
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
    private void Update()
    {
        Vector3[] dirs = new Vector3[4] { Vector3.forward, Vector3.back, Vector3.right, Vector3.left };
        Debug.DrawRay(transform.position, ray.direction, Color.red);
        for (int i = 0; i < dirs.Length; i++)
        {


            ray = new Ray(transform.position, dirs[i]);

            if (Physics.Raycast(ray, out hit, 1f, layer_mask, QueryTriggerInteraction.Ignore))
            {
                if (hit.collider != null && hit.collider.gameObject.TryGetComponent<Train>(out Train train))
                {
                    train.Rotate((Direction)i);
                }
            }
        }
    }

}

