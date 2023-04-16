using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public GameData gameData; 

    private void Awake()
    {
        Instance = this;    
    }
    private void OnValidate()
    {
        //LoadPlayerData();
        SavePlayerData();
    }
    public void LoadPlayerData()
    {
        // Dosyayı oku
        //burası şimdilik bilgisayar için eğer mobil ise persistentDataPath yapcan
        string filePath = Application.dataPath + "/GameData.json";
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            gameData = JsonUtility.FromJson<GameData>(json);
        }
        else
        {
            // Dosya yoksa varsayılan verileri ayarla
            gameData = new GameData();
     
        }
    }

    public void SavePlayerData()
    {
        // Dosyayı yaz
        string json = JsonUtility.ToJson(gameData);
        string filePath = Application.dataPath + "/GameData.json";
        File.WriteAllText(filePath, json);
    }

    public void ResetPlayerData()
    {
        gameData = new GameData();
        SavePlayerData();
    }
    
}
