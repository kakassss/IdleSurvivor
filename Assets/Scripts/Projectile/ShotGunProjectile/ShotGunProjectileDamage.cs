
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

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<BaseEnemyHealth>().
                GetDamage(gunDamage);

            if (passThroghEnemyCounter == 0)
            {
                Destroy(gameObject);
            } 

            passThroghEnemyCounter--;
                       
        }
    }
    protected override void OnBecameInvisible()
    {
        
    }
  
}
