using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DesignPatterns.Singleton;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    [SerializeField] private List<ScoreModel> _ScoreList;
    [SerializeField] private int playerScore = 0;
    [SerializeField] private string playerName = "";
    public List<ScoreModel> ScoreList { get => _ScoreList; set => _ScoreList = value; }
    public int PlayerScore { get => playerScore; set => playerScore = value; }
    public string PlayerName { get => playerName; set => playerName = value; }

    // Start is called before the first frame update
    void Start() {
        // DummyScore();
        ScoreList = ReadExistedScore();
    }

    public void IncrementScore() {
        PlayerScore += 1;
    }

    public void SavePlayerScore() {
        if (PlayerName != "")
            ScoreList.Add(new ScoreModel(PlayerName, PlayerScore));

        if (PlayerName == "")
            ScoreList.Add(new ScoreModel("Unidentified", PlayerScore));

        if (ScoreList.Count >= 1) {}
            ScoreList = ScoreList.OrderByDescending(o => o.PlayerScore).ToList();
        
        PlayerName = "";
        PlayerScore = 0;
    }

    public void ResetHighScore() {
        ScoreList.Clear(); 
        Debug.Log("reset high score");
    }

    public List<ScoreModel> ReadExistedScore() {
        string jsonData = SaveManager.Instance.ReadJson();
        
        if (jsonData == null) {
            ResetHighScore();

            return ScoreList;
        }

        return JsonHelper.FromJson<ScoreModel>(jsonData);
    }

    public bool SaveScore() {
        List<ScoreModel> scoreToSave = new List<ScoreModel>();
        int i = 0;

        foreach (var item in ScoreList) {
            if (i < 5)
                scoreToSave.Add(item);
            else
                break;
        }

        string jsonData = JsonHelper.ToJson(scoreToSave, true);

        return SaveManager.Instance.WriteJson(jsonData);
    }

    public void DummyScore() {
        ScoreList.Add(new ScoreModel("john", 3));
        ScoreList.Add(new ScoreModel("jhon", 2));
        ScoreList.Add(new ScoreModel("jhn0", 1));
        ScoreList.Add(new ScoreModel("jhnp", 4));
        ScoreList.Add(new ScoreModel("jahn", 5));

        Debug.Log("dummy score generated\n");
    }
}
