using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DesignPatterns.Singleton;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    // Update is called once per frame
    void Update() {
        UpdateScoreUI();
    }

    public void UpdateScoreUI() {
        if (SceneManager.GetActiveScene().name == "Main Game") {
            Text scoreText = null;
            GameObject scoreTextComp = GameObject.Find("Score Text");

            if (scoreTextComp != null)
                scoreText = scoreTextComp.GetComponent<Text>();

            if (scoreText != null)
                scoreText.text = ScoreManager.Instance.PlayerScore.ToString();
        }
    }
}
