using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileDamage : BaseProjectileDamage
{
    private PlayerProjectileData data;
    void Start()
    {
        data = DataManager.Instance.gameData.projectileData.playerData;
        
        gunDamage = data.damage;
        passThroghEnemyCounter = data.passThroghInEnemy;
        projectileSpeed = data.projectileSpeed;
    }

}
