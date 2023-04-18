using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseProjectileDamage : MonoBehaviour
{
    protected float gunDamage;
    protected float passThroghEnemyCounter;
    protected float projectileSpeed;

    protected virtual void OnTriggerEnter2D(Collider2D other)
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
}
