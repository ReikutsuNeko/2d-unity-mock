using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns.Singleton;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int _GameState;
    [SerializeField] private bool _InputFrame;
    public int GameState { get => _GameState; set => _GameState = value; }
    public bool InputFrame { get => _InputFrame; set => _InputFrame = value; }

    // Start is called before the first frame update
    void Start() {
        MainMenuState();
    }

    // Update is called once per frame
    void Update() {
        int i = 0;

        while (i < 2) {
            i++;
        }

        InputFrame = true;
    }

    public void GamePauseState() {
        if (GameState == (int)GameStateEnum.GAME_START) {
            Debug.Log("Pause Menu");
            GameState = (int)GameStateEnum.GAME_PAUSE;
        }
    }

    public void ResumingGame() {
        if (GameState == (int)GameStateEnum.GAME_PAUSE) {
            Debug.Log("Resuming game");
            GameState = (int)GameStateEnum.GAME_START;
        }
    }

    public void GameStartState() {
        GameState = (int)GameStateEnum.GAME_START;
        Debug.Log("Game Start");
    }

    public void GameOverState() {
        GameState = (int)GameStateEnum.GAME_OVER;
        Debug.Log("Game Over");
    }

    public void MainMenuState() {
        GameState = (int)GameStateEnum.MAIN_MENU;
        Debug.Log("Main Menu");
    }
}
