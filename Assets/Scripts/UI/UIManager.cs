using System;
using System.Collections;
using System.Collections.Generic;
using LaraGoLike;
using TMPro;
using UnityEngine;

public class UIManager : Etienne.Singleton<UIManager>
{
    public GameObject NextLevelButton;
    public GameObject LevelSelection;
    
    TextMeshProUGUI _EndGameText;

    protected override void Awake()
    {
        base.Awake();
        _EndGameText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        this.gameObject.SetActive(false);
        LevelLoader.Instance.OnSceneLoaded += _=> this.gameObject.SetActive(false);
    }

    public void LooseTrainUI()
    {
        this.gameObject.SetActive(true);
        _EndGameText.text = "Your train hit something !";
    }

    public void LoosePlayerUI()
    {
        this.gameObject.SetActive(true);
        NextLevelButton.SetActive(false);
        _EndGameText.text = "Your player hit something !";
    }

    public void WinUI()
    {
        this.gameObject.SetActive(true);
        NextLevelButton.SetActive(true);
        _EndGameText.text = "You win !";
    }
    
    public void Options()
    {
        Debug.Log("C'est les options ");
    }

    public void NextLevel()
    {
        
    }
    
    public void Menu()
    {
        LevelSelection.SetActive(true);
    }
    
    public void Retry()
    {
        
    }
    
    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
    }
    
}

