using UnityEngine;

public class SniperProjectileDamage : BaseProjectileDamage
{
    private SniperProjectileData data;
    private SniperGunPoolManager pool;

    private void Start()
    {
        data = DataManager.Instance.gameData.projectileData.sniperData;

        gunDamage = data.damage;
        passThroghEnemyCounter = data.passThroghInEnemy;
        projectileSpeed = data.projectileSpeed;

        pool = SniperGunPoolManager.Instance;
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
