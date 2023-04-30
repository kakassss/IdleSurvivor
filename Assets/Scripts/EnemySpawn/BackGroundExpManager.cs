using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gerçek manada bir exp sistemi değil, mantığı biraz online oyunlardaki elo sistemi gibi.
//Oyuncu burdaki verisini bilmeyecek.
//Amaç oyuncunun bulunduğu seviyeye göre düşman spawnlamak olacak, hani bir süre sistemine göre bağlı kalmaktansa
//Oyuncunun ne kadar oyunu oynadığına bağlı olacak
public class BackGroundExpManager : MonoBehaviour
{
    public static BackGroundExpManager Instance;
    private ExpData data;

    private void Awake()
    {
        Instance = this;    
    }

    private void Start()
    {
        data = DataManager.Instance.gameData.expData;    
    }

    public void AddExp(float Amount)
    {
        data.totalExp += Amount;  
    }
    private void Update()
    {
        LevelUp();    
    }
    
    private void LevelUp()
    {
        if(data.totalExp >= data.nextLevelRequiredExps[data.nextLevelRequiredExpIndex])
        {
            data.currentLevel++;
            data.nextLevelRequiredExpIndex++;
        }
    }

}
