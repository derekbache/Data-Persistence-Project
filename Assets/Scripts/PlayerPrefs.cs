using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class PlayerPrefs : MonoBehaviour
{
    public static PlayerPrefs Instance;
    public string playerName = "Default";

    public string highScoreName = "OmegaChad";
    public int highScore = 1;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }

    [Serializable]
    public class SaveData
    {
        public string highScoreNameSave;
        public int highScoreSave;
        public string playerNameSave;
    }
    public void Save()
    {
        SaveData data = new SaveData();
        data.highScoreNameSave = highScoreName;
        data.highScoreSave = highScore;
        data.playerNameSave = playerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log(json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScoreSave;
            highScoreName = data.highScoreNameSave;
            playerName = data.playerNameSave;
        }
    }
}






