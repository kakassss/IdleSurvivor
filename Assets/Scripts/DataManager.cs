using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public GameData gameData; 

    private void Awake()
    {
        Instance = this;
        gameData = LoadPlayerData(); 
        //LoadPlayerData();    
    }

    private void Update() 
    {
        SavePlayerData(gameData);
    }
    private void OnValidate()
    {
        //SavePlayerData(gameData);
        gameData = LoadPlayerData();   
        
        //SavePlayerData(gameData);   
    }
    
    public GameData LoadPlayerData()
    {
        // Dosyayı oku
        //burası şimdilik bilgisayar için eğer mobil ise persistentDataPath yapcan
        
        string filePath = Application.dataPath + "/GameData.json";
        GameData newGameData = new GameData();

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            newGameData = JsonUtility.FromJson<GameData>(json);
        }
        else
        {
            Debug.Log("save file does not exits");
        }
        
        return newGameData;
    }

    public void SavePlayerData(GameData data)
    {
        // Dosyayı yaz
        string json = JsonUtility.ToJson(data,true);
        string filePath = Application.dataPath + "/GameData.json";
        File.WriteAllText(filePath, json);
    }

    public void ResetPlayerData()
    {
        gameData = new GameData();
        //SavePlayerData();
    }
    private void OnApplicationQuit() 
    {
        //LoadPlayerData();
    }
}
