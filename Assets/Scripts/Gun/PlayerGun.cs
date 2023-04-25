using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : BaseGun
{

    private PlayerGunData data;
    
    protected override void Start()
    {
        data = DataManager.Instance.gameData.gunsData.playerGunData;
        
        fireOfRate = data.fireofRate;
        projectilePrefab = data.projectilePrefab;
        radiusOfDetectArea = data.radiusOfDetectArea;
        base.Start();

        Debug.Log(data.gunName + "1111");
    }

    protected override void InstantiateProjectile()
    {
        if(closestEnemyPos.transform.position.y >= 0)
        {
            projectilePistol = Instantiate(projectilePrefab,transform.position ,Quaternion.Euler(0,0,angle)); // Instantiating for y >= 0 position enemies
        }
        else if(closestEnemyPos.transform.position.y < 0)
        {
            projectilePistol = Instantiate(projectilePrefab,transform.position ,Quaternion.Euler(0,0,-angle));// Instantiating for y < 0 position enemies
        }
    }

    protected override void Update()
    {
        PlayerInput();
        //dataManager.gameData.projectileData.damage +=1;
        //DataManager.Instance.SavePlayerData(); // bunu ilerde bi şeyler için kullanabilirsin dursun şimdilik, zaten bu update calısmıyor
        data.fireofRate += Time.deltaTime * 0.2f;
        //Fire();
    }
}
