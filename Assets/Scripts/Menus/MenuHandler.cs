using System;
using UnityEngine;

namespace LaraGoLike
{
    [AddComponentMenu("Menu/Menu Handeler")]
    public class MenuHandler : MonoBehaviour
    {
        private MainMenu mainMenu;
        private LevelSelection levelSelection;

        private void Awake()
        {
            mainMenu = GetComponentInChildren<MainMenu>();
            levelSelection = GetComponentInChildren<LevelSelection>(true);
            if(Save.HasPlayed) mainMenu.OnStart += ContinueGame;
            else mainMenu.OnStart += StartGame;

            mainMenu.OnSelectLevel += SelectLevel;
            mainMenu.OnQuit += QuitGame;
        }

        private void ContinueGame()
        {
            LevelLoader.Instance.LoadLevels(Save.GetLastLevelCompleted()+1).UnloadLevels(Scene.MainMenu).StartLoading();
            Debug.Log("ContinueGame");
        }

        private void StartGame()
        {
            if(!LevelLoader.Instance)
            {
                Debug.LogWarning("There is no LevelLoader instance consider launching game throught default scene", this);
                return;
            }
            Debug.Log("StartGame");
            LevelLoader.Instance.LoadLevels(2).UnloadLevels(Scene.MainMenu).StartLoading();
        }

        private void SelectLevel()
        {
            mainMenu.gameObject.SetActive(false);
            levelSelection.gameObject.SetActive(true);
        }

        private void QuitGame()
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
#endif
        }
    }
}
