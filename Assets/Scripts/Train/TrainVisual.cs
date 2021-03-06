using Etienne;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LaraGoLike
{
    [RequireComponent(typeof(Train))]
    public class TrainVisual : MonoBehaviour
    {
        [SerializeField, Range(1, 10)] private int size = 1;
        [SerializeField] private GameObject locomotivePrefab, straightWagonPrefab, lastWagonPrefab;
        [SerializeField] private Mesh straightWagon, turnWagon;
        [SerializeField] private List<Transform> wagons = new List<Transform>();
        private async void Start()
        {
            GameObject trainParent = new GameObject("TrainVisual");
            trainParent.transform.SetPositionAndRotation(transform.position, transform.rotation);
            GameObject go = GameObject.Instantiate(locomotivePrefab, trainParent.transform);
            go.AddComponent<BoxCollider>().isTrigger = true;
            wagons.Add(go.transform);

            for (int i = 1; i < size; i++)
            {
                go = GameObject.Instantiate(straightWagonPrefab, trainParent.transform);
                go.AddComponent<BoxCollider>().isTrigger = true;
                go.transform.position -= transform.forward * i;
                wagons.Add(go.transform);
            }

            go = GameObject.Instantiate(lastWagonPrefab, trainParent.transform);
            go.transform.position -= transform.forward * size;
            go.AddComponent<BoxCollider>().isTrigger = true;
            wagons.Add(go.transform);
            GetComponent<Train>().OnMove += Move;
            await Task.Delay(100);
            SceneManager.MoveGameObjectToScene(trainParent, SceneManager.GetActiveScene());
        }

        private void Move(bool sucess, Vector3 direction)
        {
            if (!sucess) return;
            for (int i = wagons.Count - 1; i >= 1; i--)
            {
                Transform wagon = wagons[i];
                Transform precWagon = wagons[i - 1];
                wagon.position = precWagon.position;
            }
            wagons[0].position += direction;
            wagons[0].forward = direction;
            for (int i = 1; i < wagons.Count - 1; i++)
            {
                Transform wagon = wagons[i];
                Transform precWagon = wagons[i - 1];
                Transform nextWagon = wagons[i + 1];
                Vector3 forward = precWagon.position - wagon.position;
                Vector3 back = wagon.position - nextWagon.position;
                MeshFilter renderer = wagon.GetComponent<MeshFilter>();
                wagon.forward = forward;
                if (back != forward)
                {
                    renderer.mesh = turnWagon;
                    if (back == -wagon.right)
                    {
                        wagon.Rotate(Vector3.up * 90, Space.Self);
                    }
                }
                else
                {
                    renderer.mesh = straightWagon;
                }
            }
            foreach (var wagon in wagons)
            {
                if (wagon.TryGetComponent<TrainPart>(out TrainPart trainPart))
                {

                    trainPart.OnMoveMethod();
                }
            }
            wagons[wagons.Count - 1].forward = wagons[wagons.Count - 2].position - wagons[wagons.Count - 1].position;

        }
    }
}
