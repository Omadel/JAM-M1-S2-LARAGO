using UnityEngine;

namespace LaraGoLike
{
    [AddComponentMenu("Menu/MainMenu")]
    internal class MainMenu : MonoBehaviour
    {
        public System.Action OnStart, OnSelectLevel, OnQuit;

        [SerializeField] private BetterButton startButton, selectLevelButton, quitButton;

        private void Awake()
        {
            startButton.OnClick += () => OnStart?.Invoke();
            startButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = Save.HasPlayed ? "Continue" : "Start";
            selectLevelButton.OnClick += () => OnSelectLevel?.Invoke();
            quitButton.OnClick += () => OnQuit?.Invoke();

            selectLevelButton.gameObject.SetActive(Save.HasPlayed);
        }
    }
}
