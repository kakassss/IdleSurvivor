using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunProjectileDamage : BaseProjectileDamage
{

    private ShotgunProjectileData data;
    void Start()
    {
        data = DataManager.Instance.gameData.projectileData.shotgunData;
        
        gunDamage = data.damage;
        passThroghEnemyCounter = data.passThroghInEnemy;
        projectileSpeed = data.projectileSpeed;      
    }

  
}