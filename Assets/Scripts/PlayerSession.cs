using UnityEngine;
using System.IO;

public class PlayerSession : MonoBehaviour
{
    private string datapath;

    public static PlayerSession Instance;
    public string playerName;

    public string highScorePlayerName;

    public int highScore;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        datapath = Application.persistentDataPath + "/highscore.json";

        LoadHighScoreFromFile();
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int highScore;
    }

    private void LoadHighScoreFromFile()
    {
        if (File.Exists(datapath))
        {
            string jsonData = File.ReadAllText(datapath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(jsonData);
            highScore = saveData.highScore;
            highScorePlayerName = saveData.name;
        }
    }

    public void SaveHighScoreToFile()
    {
        SaveData saveData = new SaveData();
        saveData.name = playerName;
        saveData.highScore = highScore;

        string jsonData = JsonUtility.ToJson(saveData);
        File.WriteAllText(datapath, jsonData);
    }

}
