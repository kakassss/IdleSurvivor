using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolProjectileDamage : BaseProjectileDamage
{
    private PistolProjectileData data;
    private void Start()
    {
        data = DataManager.Instance.gameData.projectileData.pistolData;
        
        gunDamage = data.damage;
        passThroghEnemyCounter = data.passThroghInEnemy;
        projectileSpeed = data.projectileSpeed;
        fireofRate = data.fireofRate;
    }

}
