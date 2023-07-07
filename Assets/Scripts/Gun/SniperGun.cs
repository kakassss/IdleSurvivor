using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperGun : BaseGun
{
    private SniperGunData data;
    [SerializeField] private GameObject sniperProjectile;
    private SniperGunPoolManager pool;

    protected override void Start()
    {
        data = DataManager.Instance.gameData.gunsData.sniperGunData;

        fireOfRate = data.fireofRate;
        projectilePrefab = sniperProjectile;
        radiusOfDetectArea = data.radiusOfDetectArea;

        pool = SniperGunPoolManager.Instance;
    }

    protected override void InstantiateProjectile()
    {
        if(closestEnemyPos.transform.position.y >= 0)
        {
            projectilePistol = pool.GetObject().gameObject;
            projectilePistol.transform.position = transform.position;
            projectilePistol.transform.rotation = Quaternion.Euler(0,0,angle);
            //projectilePistol = Instantiate(projectilePrefab,transform.position ,Quaternion.Euler(0,0,angle)); // Instantiating for y >= 0 position enemies
        }
        else if(closestEnemyPos.transform.position.y < 0)
        {
            projectilePistol = pool.GetObject().gameObject;
            projectilePistol.transform.position = transform.position;
            projectilePistol.transform.rotation = Quaternion.Euler(0,0,-angle);
            //projectilePistol = Instantiate(projectilePrefab,transform.position ,Quaternion.Euler(0,0,-angle));// Instantiating for y < 0 position enemies
        }
    }
    
    public override void UpgradeGunData(GameData data)
    {
        radiusOfDetectArea = data.gunsData.sniperGunData.radiusOfDetectArea;
        fireOfRate = data.gunsData.sniperGunData.fireofRate;
    }

    protected override void Update()
    {
        Fire();
    }
}
