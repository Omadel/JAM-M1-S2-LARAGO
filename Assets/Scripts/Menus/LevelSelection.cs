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
            for(int i = (int)Scene.MainMenu + 1; i < scenes.Length; i++)
            {
                GameObject go = GameObject.Instantiate(levelButtonPrefab, levelButtonParent);
                go.GetComponent<LevelButton>().Init(i - (int)Scene.MainMenu+1);
            }
        }
    }
}
