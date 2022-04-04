using UnityEngine;

namespace LaraGoLike
{
    public class OmniMagnet : MonoBehaviour
    {

        private Ray ray;
        [SerializeField]
        LayerMask layer_mask;
        private void Update()
        {
            var position = transform.position;
            Debug.DrawRay(position, Vector3.left, Color.red);
            Debug.DrawRay(position, Vector3.right, Color.red);
            Debug.DrawRay(position, Vector3.forward, Color.red);
            Debug.DrawRay(position, Vector3.back, Color.red);

            Vector3[] dirs = new Vector3[4] { Vector3.forward, Vector3.back, Vector3.right, Vector3.left };
            Debug.DrawRay(position, ray.direction, Color.red);
            for (int i = 0; i < dirs.Length; i++)
            {
                ray = new Ray(transform.position, dirs[i]);
                if (Physics.Raycast(ray, out RaycastHit hit, 1.2f, layer_mask, QueryTriggerInteraction.Ignore))
                {
                    if (hit.collider != null && hit.collider.gameObject.TryGetComponent<Train>(out Train train))
                    {
                        if (dirs[i] == -dirs[(int)train.GetDirection()] )
                        {
                            UIManager.Instance.LooseTrainUI();
                            Destroy(train.gameObject);
                        }
                        else
                        {
                            train.Rotate((Direction)i);
                        }
                    }
                }
            }
        }
    }
}
