using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using LaraGoLike;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : Etienne.Singleton<UIManager>
{
    public GameObject NextLevelButton;
    public GameObject LevelSelection;
    public GameObject Buttons;
    public GameObject UnPauseButton;
    
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
        GameObject.Destroy(PlayerMovement.instance.gameObject);
        this.gameObject.SetActive(true);
        Buttons.SetActive(true);
        NextLevelButton.SetActive(false);
        UnPauseButton.SetActive(false);
        LevelSelection.SetActive(false);
        _EndGameText.text = "Your train hit something !";
    }

    public void LoosePlayerUI()
    {
        GameObject.Destroy(PlayerMovement.instance.gameObject);
        this.gameObject.SetActive(true);
        Buttons.SetActive(true);
        NextLevelButton.SetActive(false);
        UnPauseButton.SetActive(false);
        LevelSelection.SetActive(false);
        _EndGameText.text = "Your player hit something !";
    }

    public void WinUI()
    {
        GameObject.Destroy(PlayerMovement.instance.gameObject);
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        Save.HasPlayed = true;
        Save.SetLevelCompleted(currentScene);
        this.gameObject.SetActive(true);
        Buttons.SetActive(true);
        UnPauseButton.SetActive(false);
        NextLevelButton.SetActive(true);
        LevelSelection.SetActive(false);
        _EndGameText.text = "You win !";
    }
    

    public void NextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        LevelLoader.Instance.UnloadLevels(currentScene).LoadLevels(currentScene + 1).StartLoading();
        DOTween.KillAll();
    }
    
    public void Menu()
    {
        Buttons.SetActive(false);
        LevelSelection.SetActive(true);
        LevelSelection.GetComponent<LevelSelection>().SetunloadScene();
    }
    
    public void Retry()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        LevelLoader.Instance.UnloadLevels(currentScene).LoadLevels(currentScene).StartLoading();
        DOTween.KillAll();
    }

    public void Pause()
    {
        PlayerMovement.instance.gameObject.SetActive(false);
        this.gameObject.SetActive(true);
        UnPauseButton.SetActive(true);
        Buttons.SetActive(true);
        NextLevelButton.SetActive(false);
        LevelSelection.SetActive(false);
        _EndGameText.text = "Pause";
        PlayerMovement.instance.transform.DOComplete();
    }

    public void UnPause()
    {
        PlayerMovement.instance.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
    
    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
    }
    
}

