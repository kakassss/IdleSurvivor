using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public GameData gameData; 

    private void Awake()
    {
        Instance = this;
        gameData = LoadPlayerData();    
    }

    private void Update() 
    {
        SavePlayerData(gameData); 
    }

    public GameData LoadPlayerData()
    {
        // read file
        string filePath = Application.dataPath + "/GameData.json"; // persistantdatapath
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
        // write file
        string json = JsonUtility.ToJson(data,true);
        string filePath = Application.dataPath + "/GameData.json";
        File.WriteAllText(filePath, json);
    }

    //Currently not using
    public void ResetPlayerData()
    {
        gameData = new GameData();
    }

}
