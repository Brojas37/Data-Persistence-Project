using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Manager : MonoBehaviour
{
    public int highScore;
    public string highScoreName;
    public string name;

    public static Manager Instance;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    public void GameOver(int points)
    {
        if (points > highScore)
        {
            highScore = points;
            highScoreName = name;
        }

        SaveScore();
    }
    
    public void StartGame()
    {
        if (highScore == 0)
        {
            highScoreName = name;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int bestScore;
        public string bestScoreName;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.bestScore = highScore;
        data.bestScoreName = highScoreName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.bestScore;
            highScoreName = data.bestScoreName;
        }
    }
}
