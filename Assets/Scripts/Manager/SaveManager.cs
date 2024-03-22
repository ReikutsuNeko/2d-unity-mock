using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using DesignPatterns.Singleton;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
    private readonly string _SaveFileLocation = Application.dataPath + "/score.json";

    public bool WriteJson(string jsonData) {
        try
        {
            File.WriteAllText(_SaveFileLocation, jsonData);

            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }

    public string ReadJson() {
        try
        {
            string jsonData = File.ReadAllText(_SaveFileLocation);

            return jsonData;
        }
        catch (System.Exception)
        {
            return null;
        }
    }
}
