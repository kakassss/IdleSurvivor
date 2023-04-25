using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemyHealth : MonoBehaviour
{
    protected float currentHealth;
    protected float knockBackPower;
    protected float exp;
    [HideInInspector] public bool knockBackActive = false;

    private Rigidbody2D rb;
    private GameObject playerPos;
    private Coroutine knockBackCor;
    
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        playerPos = FindPlayerPosition.Instance.player; 
    }
    public void GetDamage(float damage)
    {
        currentHealth -= damage;
        Die();
    }

    private void Die()
    {
        if (currentHealth <= 0)
        {
            BackGroundExpManager.Instance.AddExp(exp);
            Destroy(gameObject);
        }
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag("Projectile")) return;

        knockBackCor = StartCoroutine(KnockBack(other.gameObject,rb));  
    }

    private IEnumerator KnockBack(GameObject enemy,Rigidbody2D rb)
    {
        
        knockBackActive = true;
        Vector2 direction = (transform.position - playerPos.transform.position).normalized; // playerin pozisyonuna göre düşürmek daha sağlıklı
        rb.velocity = direction * knockBackPower;
        
        yield return new WaitForSeconds(0.25f);
        rb.velocity = new Vector2(Mathf.SmoothStep(rb.velocity.x,0,1),
                                Mathf.SmoothStep(rb.velocity.y,0,1));
        knockBackActive = false;

    }
}
