using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseProjectileDamage : MonoBehaviour
{
    protected float gunDamage;
    protected float passThroghEnemyCounter;
    protected float projectileSpeed;
    protected float fireofRate;

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<BaseEnemyHealth>().
                GetDamage(gunDamage);

            passThroghEnemyCounter--;
            if (passThroghEnemyCounter == 0)
            {
                Destroy(gameObject);
            }            
        }
    }
}
