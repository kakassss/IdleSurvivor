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
    private DataManager data1;

    private void Awake()
    {
        Instance = this;    
    }

    private void Start()
    {
        data = DataManager.Instance.gameData.expData;    
        data1 = GetComponent<DataManager>();
    }
    private void OnValidate()
    {
        
    }
    private void Update() {
        
        
    }
    public void AddExp(float Amount)
    {
        Debug.Log("onur a " + Amount);
        data.totalExp += Amount;
        data1.SavePlayerData();
        Debug.Log(data.totalExp);
        
    }
    private void OnApplicationQuit() {
        
    }

}
