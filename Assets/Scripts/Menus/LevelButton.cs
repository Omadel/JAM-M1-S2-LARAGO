using UnityEngine;

namespace LaraGoLike
{
    [RequireComponent(typeof(BetterButton))]
    public class LevelButton : MonoBehaviour
    {
        private TMPro.TextMeshProUGUI uGUI;
        private int UnloadIndex = (int)Scene.MainMenu;
        private int LevelIndex = 0;
        
        private void OnEnable()
        {
            uGUI = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        }

        public void Init(int index)
        {
            LevelIndex = index;
            uGUI.text = $"Level {index-1}";
            //todo : Audiopoool dont destroy on load;
            GetComponent<BetterButton>().OnClick = LoadLevel;
        }

        public void SetUnloadIndex(int index)
        {
            UnloadIndex = index;
        }

        private void LoadLevel()
        {
            LevelLoader.Instance.LoadLevels(LevelIndex).UnloadLevels(UnloadIndex).StartLoading();
        }
    }
}
