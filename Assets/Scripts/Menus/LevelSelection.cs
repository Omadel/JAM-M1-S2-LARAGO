using UnityEditor;
using UnityEngine;

namespace LaraGoLike
{
    public class LevelSelection : MonoBehaviour
    {
        [SerializeField] private Transform levelButtonParent;
        [SerializeField] private GameObject levelButtonPrefab;

        private void Awake()
        {
            EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;
            int lastLevel = Save.GetLastLevelCompleted();
            for(int i = (int)Scene.MainMenu + 1; i < scenes.Length; i++)
            {
                int index = i - (int)Scene.MainMenu + 1;

                GameObject go = GameObject.Instantiate(levelButtonPrefab, levelButtonParent);
                LevelButton button = go.GetComponent<LevelButton>();
                button.Init(index);
                Debug.Log(index);
                button.GetComponent<BetterButton>().interactable = index <= lastLevel+1;
            }
        }
    }
}
