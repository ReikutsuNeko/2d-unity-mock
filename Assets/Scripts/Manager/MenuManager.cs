using System.Collections;
using System.Collections.Generic;
using DesignPatterns.Singleton;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : Singleton<MenuManager>
{
    public void RestartGame() {
        GameManager.Instance.GameStartState();
        SceneManager.LoadSceneAsync("Main Game");
    }

    public void BackToMainMenu() {
        GameManager.Instance.MainMenuState();
        SceneManager.LoadSceneAsync("Main Menu");
    }
}
