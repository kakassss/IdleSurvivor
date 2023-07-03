
using UnityEngine;

public class ShotGunProjectileDamage : BaseProjectileDamage
{
    private ShotgunProjectileData data;
    private ShotGunPoolManager pool;
    void Start()
    {
        data = DataManager.Instance.gameData.projectileData.shotgunData;
        
        gunDamage = data.damage;
        passThroghEnemyCounter = data.passThroghInEnemy;
        projectileSpeed = data.projectileSpeed;      

        pool = ShotGunPoolManager.Instance;
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
