using UnityEngine;

public abstract class BaseProjectileDamage : MonoBehaviour,IProjectile
{
    protected float gunDamage;
    protected float passThroghEnemyCounter;
    protected float projectileSpeed;
    
    protected abstract void OnTriggerEnter2D(Collider2D other);
    protected abstract void OnBecameInvisible();

    
}
