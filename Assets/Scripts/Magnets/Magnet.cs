
using LaraGoLike;
using UnityEngine;

    public enum DirEnum
    {
        TOP,
        DOWN,
        RIGHT,
        LEFT
    }



    public class Magnet : MonoBehaviour
    {
        public DirEnum dirEnum;
        RaycastHit hit;
        Ray ray;
        

        // Start is called before the first frame update
        void Start()
        {
            switch (dirEnum)
            {
                case DirEnum.TOP:
                    ray = new Ray(transform.position, Vector3.forward);
                    break;
                case DirEnum.DOWN:
                    ray = new Ray(transform.position, Vector3.back);
                    break;
                case DirEnum.RIGHT:
                    ray = new Ray(transform.position, Vector3.right);
                    break;
                case DirEnum.LEFT:
                    ray = new Ray(transform.position, Vector3.left);
                    break;
                default:
                    break;
            }
        }

        // Update is called once per frame
        void Update()
        {
            int layer_mask = LayerMask.GetMask("Default");
            Debug.DrawRay(transform.position, ray.direction, Color.red);
            if (Physics.Raycast(ray, out hit, 1f, layer_mask, QueryTriggerInteraction.Ignore))
            {
                Train.instance.dir = (int)dirEnum;
            }
        }

    }

