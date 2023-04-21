using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemyHealth : MonoBehaviour
{
    protected float currentHealth;
    protected float knockBackPower;
    public bool knockBackActive = false;

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
        //rb.AddForce(direction * knockBackPower,ForceMode2D.Impulse);
        
        yield return new WaitForSeconds(0.25f);
        rb.velocity = new Vector2(Mathf.SmoothStep(rb.velocity.x,0,1),
                                Mathf.SmoothStep(rb.velocity.y,0,1));
        //rb.velocity = Vector2.zero;
        knockBackActive = false;
        // if(rb.velocity != rb.velocity/2)
        // {
        //     Debug.Log("onur11");
        //     //rb.velocity -= Time.deltaTime * rb.velocity/15;
        // }
        //rb.velocity = Vector2.zero;
    }
    private void ResetKnockBack(Rigidbody2D rb)
    {
        StartCoroutine(ResetKnockBackCor(rb));
    }
    private IEnumerator ResetKnockBackCor(Rigidbody2D rb)
    {
        yield return new WaitForSeconds(1f);
        knockBackActive = false;
        rb.velocity = Vector3.zero;
    }

}
