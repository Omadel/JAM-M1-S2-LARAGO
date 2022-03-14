using UnityEngine;

namespace LaraGoLike
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerFeedback : MonoBehaviour
    {
        [SerializeField] private Etienne.Feedback.GameEvent successMoveEvent, failMoveEvent;

        private void Awake()
        {
            GetComponent<PlayerMovement>().OnMove += PlayEvent;
        }

        private void PlayEvent(bool sucess)
        {
            if(sucess) StartCoroutine(successMoveEvent.Execute(gameObject));
            else StartCoroutine(failMoveEvent.Execute(gameObject));
        }
    }
}
