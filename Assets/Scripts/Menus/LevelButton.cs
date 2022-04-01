using UnityEngine;

namespace LaraGoLike
{
    [RequireComponent(typeof(BetterButton))]
    public class LevelButton : MonoBehaviour
    {
        private TMPro.TextMeshProUGUI uGUI;
        private void OnEnable()
        {
            uGUI = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        }

        public void Init(int index)
        {
            int levelIndex = index;
            uGUI.text = $"Level {index-1}";
            //todo : Audiopoool dont destroy on load;
            GetComponent<BetterButton>().OnClick += () => LevelLoader.Instance.LoadLevels(levelIndex).UnloadLevels(Scene.MainMenu).StartLoading();
        }
    }
}
