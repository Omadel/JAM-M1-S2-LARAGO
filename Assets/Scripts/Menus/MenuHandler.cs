using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LaraGoLike
{
    [AddComponentMenu("Menu/Menu Handeler")]
    public class MenuHandler : MonoBehaviour
    {
        MainMenu mainMenu;
        LevelSelection levelSelection;

        private void Awake()
        {
            mainMenu = GetComponentInChildren<MainMenu>();
            levelSelection = GetComponentInChildren<LevelSelection>(true);
            mainMenu.OnStart += StartGame;
            mainMenu.OnSelectLevel += SelectLevel;
            mainMenu.OnQuit += QuitGame;
        }

        private void StartGame()
        {
            if(!LevelLoader.Instance)
            {
                Debug.LogWarning("There is no LevelLoader instance consider launching game throught default scene",this);
                return;
            }
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
