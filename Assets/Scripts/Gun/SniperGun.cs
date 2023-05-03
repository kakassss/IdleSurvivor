using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperGun : BaseGun
{
    private SniperGunData data;
    [SerializeField] private GameObject sniperProjectile;
    protected override void Start()
    {
        data = DataManager.Instance.gameData.gunsData.sniperGunData;

        fireOfRate = data.fireofRate;
        projectilePrefab = sniperProjectile;
        radiusOfDetectArea = data.radiusOfDetectArea;
        base.Start();
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
        Fire();
        //dataManager.gameData.projectileData.damage +=1;
        //DataManager.Instance.SavePlayerData(); // bunu ilerde bi şeyler için kullanabilirsin dursun şimdilik, zaten bu update calısmıyor
        //Fire();
    }
}
