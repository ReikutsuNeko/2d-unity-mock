using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gamePausePanel;
    [SerializeField] private InputField playerName;
    [SerializeField] private AudioController audioController;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        
    }

    public void RetryGame() {
        string name = "";

        if (playerName.text == "") {
            name = "Player";
        } else {
            name = playerName.text;
        }

        ScoreManager.Instance.PlayerName = name;
        ScoreManager.Instance.SavePlayerScore();
        MenuManager.Instance.RestartGame();
    }

    public void BackToMainMenu() {
        if (playerName.text != "") {
            ScoreManager.Instance.PlayerName = playerName.text;
        }

        ScoreManager.Instance.SavePlayerScore();
        MenuManager.Instance.BackToMainMenu();
    }

    public void ShowGameOverScreen() {
        if (GameManager.Instance.GameState == (int)GameStateEnum.GAME_START) {
            if (gameOverPanel != null) {
                audioController.PlayOverSound();
                Debug.Log("over");
                gameOverPanel.SetActive(true);
                GameManager.Instance.GameOverState();
            }
        }
    }

    public void ShowPauseScreen() {
        if (GameManager.Instance.GameState == (int)GameStateEnum.GAME_START) {
            if (gamePausePanel != null) {
                Debug.Log("pause");
                gamePausePanel.SetActive(true);
                GameManager.Instance.GamePauseState();
            }
        }
    }

    public void ClosePauseScreen() {
        if (GameManager.Instance.GameState == (int)GameStateEnum.GAME_PAUSE) {
            if (gamePausePanel != null) {
                Debug.Log("close pause");
                gamePausePanel.SetActive(false);
                GameManager.Instance.ResumingGame();
            }
        }
    }
}
