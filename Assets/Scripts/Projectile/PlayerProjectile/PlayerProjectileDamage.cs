using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileDamage : BaseProjectileDamage
{
    private PlayerProjectileData data;
    private PlayerGunPoolManager pool;
    void Start()
    {
        data = DataManager.Instance.gameData.projectileData.playerData;
        
        gunDamage = data.damage;
        passThroghEnemyCounter = data.passThroghInEnemy;
        projectileSpeed = data.projectileSpeed;

        pool = PlayerGunPoolManager.Instance;
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<BaseEnemyHealth>().
                GetDamage(gunDamage);

            if (passThroghEnemyCounter == 0)
            {
                pool.ReturnObject(this);
            } 

            passThroghEnemyCounter--;
                       
        }
    }
    
    protected override void OnBecameInvisible()
    {
        pool.ReturnObject(this);
    }
}
