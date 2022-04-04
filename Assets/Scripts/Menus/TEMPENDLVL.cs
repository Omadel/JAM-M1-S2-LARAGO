using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LaraGoLike
{
    [RequireComponent(typeof(BetterButton))]
    public class TEMPENDLVL : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<BetterButton>().OnClick += () =>
            {
                Debug.Log("Should Save");
                Save.HasPlayed = true;
                int buildIndex = SceneManager.GetActiveScene().buildIndex;
                Save.SetLevelCompleted(buildIndex);
                LevelLoader.Instance.LoadLevels(Scene.MainMenu).UnloadLevels(buildIndex).StartLoading();
            };
        }
    }
}
