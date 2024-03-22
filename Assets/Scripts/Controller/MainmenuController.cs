using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainmenuController : MonoBehaviour
{
    [SerializeField] private Button resetHighscoreBtn;

    private List<GameObject> scoreTemplateObjs;

    private void Start() {
        scoreTemplateObjs = new List<GameObject>();
        resetHighscoreBtn.onClick.AddListener(ScoreManager.Instance.ResetHighScore);
    }

    public void OpenPanel(GameObject panel) {
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel) {
        panel.SetActive(false);
    }

    public void GenerateHighScoreUI(GameObject highScorePanel) {
        ClearHighScore();

        float posX = highScorePanel.transform.position.x;
        float posY = highScorePanel.transform.position.y;

        if (ScoreManager.Instance.ScoreList.Count < 1) {
            GameObject scoreObj = Instantiate(highScorePanel, new Vector2(posX, posY), Quaternion.identity, highScorePanel.transform.parent);

            Text numText = scoreObj.transform.GetChild(0).GetComponent<Text>();
            Text nameText = scoreObj.transform.GetChild(1).GetComponent<Text>();
            Text scoreText = scoreObj.transform.GetChild(2).GetComponent<Text>();

            numText.text = "";
            nameText.text = "No Data";
            scoreText.text = "";
        } else {
            for (int i = 0; i < ScoreManager.Instance.ScoreList.Count; i++) {
                GameObject scoreObj = Instantiate(highScorePanel, new Vector2(posX, posY), Quaternion.identity, highScorePanel.transform.parent);

                Text numText = scoreObj.transform.GetChild(0).GetComponent<Text>();
                Text nameText = scoreObj.transform.GetChild(1).GetComponent<Text>();
                Text scoreText = scoreObj.transform.GetChild(2).GetComponent<Text>();

                numText.text = (i+1).ToString();
                nameText.text = ScoreManager.Instance.ScoreList[i].PlayerName.ToString();
                scoreText.text = ScoreManager.Instance.ScoreList[i].PlayerScore.ToString();

                posY -= 60f;

                scoreTemplateObjs.Add(scoreObj);

                if (i > 4)
                    break;
            }
        }
    }

    public void ClearHighScore() {
        if (scoreTemplateObjs.Count > 1) {
            Debug.Log("its in\n");

            foreach (var score in scoreTemplateObjs) {
                Destroy(score);
            }

            scoreTemplateObjs.Clear();
        }
    }

    public void StartGame() {
        GameManager.Instance.GameStartState();
        SceneManager.LoadSceneAsync("Main Game");
    }

    public void ExitGame() {
        Debug.Log("exit game");
        ScoreManager.Instance.SaveScore();
        Application.Quit();
    }
}
