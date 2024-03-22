// This class will hold all the score data and responsible
// to create, read and update from the JSON file

using System;
using UnityEngine;

[Serializable]
public class ScoreModel {
    [SerializeField] private string _PlayerName;
    [SerializeField] private int _PlayerScore;
    
    public string PlayerName { 
        set {
            _PlayerName = value;
        } 
        get {
            return _PlayerName;
        } 
    }
    public int PlayerScore { 
        set {
            _PlayerScore = value;
        } 
        get {
            return _PlayerScore; 
        }
    }

    public ScoreModel() { }

    public ScoreModel(string p, int s) {
        this._PlayerName = p;
        this._PlayerScore = s;
    }

}