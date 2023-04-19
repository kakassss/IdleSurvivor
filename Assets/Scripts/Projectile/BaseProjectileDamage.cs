using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseProjectileDamage : MonoBehaviour
{
    protected float gunDamage;
    protected float passThroghEnemyCounter;
    protected float projectileSpeed;
    protected float knockBackPower;

    public bool knockBackActive = false;

    private Coroutine knockbackCor;

    private void OnEnable()
    {
        //BaseEnemyMovement.OnTakeDamage += ResetKnockBack;    
    }
    private void OnDestroy()
    {
        //BaseEnemyMovement.OnTakeDamage -= ResetKnockBack;
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<BaseEnemyHealth>().
                GetDamage(gunDamage);

            //Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

            //KnockBack(other.gameObject,rb); 
            //KnockBack(other.gameObject,rb);

            if (passThroghEnemyCounter == 0)
            {
                Destroy(gameObject);
            } 

            passThroghEnemyCounter--;
                       
        }
    }

    private void KnockBack(GameObject enemy,Rigidbody2D rb)
    {
        
        //rb.velocity = transform.right * knockBackPower;
        Vector2 direction = (transform.position - enemy.transform.position).normalized;
        rb.AddForce(-direction * knockBackPower,ForceMode2D.Impulse);
        
    }
    private void ResetKnockBack(Rigidbody2D rb)
    {
        StartCoroutine(ResetKnockBackCor(rb));
    }
    private IEnumerator ResetKnockBackCor(Rigidbody2D rb)
    {
        yield return new WaitForSeconds(1f);
        rb.velocity = Vector3.zero;
    }
}
