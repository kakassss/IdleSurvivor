using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileMovement : MonoBehaviour
{
    protected Rigidbody2D rigidbody2D;
    protected virtual void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // protected void FixedUpdate()
    // {
    //     if(rigidbody2D != null)
    //     {
    //         rigidbody2D.velocity = transform.right * data.projectileSpeed;
    //     }           
    // }
    
    protected abstract void Movement();
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
