using UnityEngine;

namespace LaraGoLike
{
    [RequireComponent(typeof(BetterButton)),AddComponentMenu("UI/ButtonAudio")]
    public class ButtonAudio : MonoBehaviour
    {
        [SerializeField] private Etienne.Cue onClick;
        [SerializeField] private Etienne.Cue onHover;
        [SerializeField] private Etienne.Cue onPress;

        private void Start()
        {
            var button =GetComponent<BetterButton>();
            button.OnClick += PlayOnClick;
            button.OnHover += PlayOnHover;
            button.OnPress += PlayOnRelease;
        }
        void PlayOnClick()
        {
            onClick.Play();
        }
        void PlayOnHover()
        {
            onHover.Play();
        }
        void PlayOnRelease()
        {
            onPress.Play();
        }
    }
}
