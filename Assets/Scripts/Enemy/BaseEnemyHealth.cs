using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemyHealth : MonoBehaviour
{
    protected float currentHealth;

    public void GetDamage(float damage)
    {
        currentHealth -= damage;
        Die();
    }

    private void Die()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

  

}
