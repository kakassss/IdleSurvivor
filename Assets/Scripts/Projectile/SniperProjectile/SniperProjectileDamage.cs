using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperProjectileDamage : BaseProjectileDamage
{
    private SniperProjectileData data;

    private void Start()
    {
        data = DataManager.Instance.gameData.projectileData.sniperData;

        gunDamage = data.damage;
        passThroghEnemyCounter = data.passThroghInEnemy;
        projectileSpeed = data.projectileSpeed;
        knockBackPower = data.knockBackPower;
    }
}
